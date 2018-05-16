using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Hehfy.Classes;
using Hehfy.Windows;

namespace Hehfy.Fenêtres
{
    
    /// <summary>
    /// Logique d'interaction pour ListeMusiques.xaml
    /// </summary>
    public partial class ListeMusiques : Window
    {
        List<Categorie> Categories = new List<Categorie>();
        List<Musique> Musiques = new List<Musique>();

        public static RoutedCommand CMD_FicheUtilisateur = new RoutedCommand();
        public static RoutedCommand CMD_ChangerUtilisateur = new RoutedCommand();
        public static RoutedCommand CMD_Quitter = new RoutedCommand();
        public static RoutedCommand CMD_AjouterCategorie = new RoutedCommand();
        public static RoutedCommand CMD_ModifierCategorie = new RoutedCommand();
        public static RoutedCommand CMD_SupprimerCategorie = new RoutedCommand();
        public static RoutedCommand CMD_AjouterMusique = new RoutedCommand();
        public static RoutedCommand CMD_ModifierMusique = new RoutedCommand();
        public static RoutedCommand CMD_SupprimerMusique = new RoutedCommand();
        public static RoutedCommand CMD_APropos = new RoutedCommand();

        public ListeMusiques()
        {
            InitializeComponent();
            CreerFichiers(Global.UtilisateurConnecte.Nom);

            RafraichirListeCategories();
            RafraichirListeMusiques();

            // Raccourcis clavier pour le menu
            CMD_FicheUtilisateur.InputGestures.Add(new KeyGesture(Key.F, ModifierKeys.Alt));
            CMD_ChangerUtilisateur.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
            CMD_Quitter.InputGestures.Add(new KeyGesture(Key.F4, ModifierKeys.Alt));
            CMD_AjouterCategorie.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Alt));
            CMD_ModifierCategorie.InputGestures.Add(new KeyGesture(Key.E, ModifierKeys.Alt));
            CMD_SupprimerCategorie.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Alt));
            CMD_AjouterMusique.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            CMD_ModifierMusique.InputGestures.Add(new KeyGesture(Key.E, ModifierKeys.Control));
            CMD_SupprimerMusique.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control));
            CMD_APropos.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
        }

        /// <summary>
        /// Méthode permettant de rafraichir la liste des catégories
        /// </summary>
        private void RafraichirListeCategories()
        {
            Categories = Categorie.Lister(Global.UtilisateurConnecte.Nom);
            Categorie categorieSelectionnee = LB_ListeCategories.SelectedItem as Categorie;

            if(Categories.Count == 0)
            {
                // Si pas de catégories, on cache les différents éléments de navigation 
                // et on affiche le message inquant qu'il n'y a aucune catégorie
                GRID_BoutonsMusiques.Visibility = Visibility.Collapsed;
                LV_ListeMusiques.Visibility = Visibility.Collapsed;
                LAB_PasDeMusique.Visibility = Visibility.Collapsed;
                LAB_PasDeCategorie.Visibility = Visibility.Visible;
                MENU_Musiques.IsEnabled = false;
                ModifierStatusBoutonsCategories(false);
            } else
            {
                // Sinon on affiche les différents éléments de navigation 
                // et on cache le message inquant qu'il n'y a aucune catégorie
                GRID_BoutonsMusiques.Visibility = Visibility.Visible;
                LV_ListeMusiques.Visibility = Visibility.Visible;
                LAB_PasDeCategorie.Visibility = Visibility.Collapsed;
                MENU_Musiques.IsEnabled = true;
                ModifierStatusBoutonsCategories(true);

                // Création de la catégorie virtuelle "Toutes les catégories"
                Categorie toutesCategories = new Categorie(0, "Toutes les catégories");
                Categories.Insert(0, toutesCategories);
            }

            // Rafraichissement de la liste
            LB_ListeCategories.ItemsSource = Categories;

            // Sélection de la catégorie précédemment sélectionnée
            if (categorieSelectionnee != null)
            {
                foreach (Categorie c in Categories)
                {
                    if (c.Numero == categorieSelectionnee.Numero)
                    {
                        LB_ListeCategories.SelectedItem = c;
                        return;
                    }
                }
            }


        }

        /// <summary>
        /// Méthode permettant de rafraichir la liste des Musiques
        /// </summary>
        private void RafraichirListeMusiques()
        {
            Categorie categorie = LB_ListeCategories.SelectedItem as Categorie;
            Musique Musiqueselectionne = LV_ListeMusiques.SelectedItem as Musique;

            // Si il y a au moins une catégorie, on effectue le traitement
            if(LB_ListeCategories.Items.Count > 0)
            {   
                
                if (categorie == null || categorie.Numero == 0)
                {
                    Musiques = Musique.Lister(Global.UtilisateurConnecte.Nom);
                }
                else
                {
                    Musiques = Musique.ListerParCategorie(categorie.Numero, Global.UtilisateurConnecte.Nom);
                }

                // Rafraichissement de la liste
                LV_ListeMusiques.ItemsSource = Musiques;

                // Mise à jour de la taille des colonnes
                foreach(GridViewColumn c in (LV_ListeMusiques.View as GridView).Columns)
                {
                    if (double.IsNaN(c.Width))
                    {
                        c.Width = c.ActualWidth;
                    }
                    c.Width = Double.NaN;
                }
               

                // Sélection du Musique précédemment sélectionné (si présent)
                if (Musiqueselectionne != null)
                {
                    foreach (Musique f in Musiques)
                    {
                        if (f.Numero == Musiqueselectionne.Numero)
                        {
                            LV_ListeMusiques.SelectedItem = f;
                            return;
                        }
                    }
                }

                // Si le nombre de Musique est plus grand que 0, on affiche la liste des Musiques
                if (Musiques.Count > 0)
                {
                    LV_ListeMusiques.SelectedIndex = 0;

                    LV_ListeMusiques.Visibility = Visibility.Visible;
                    LAB_PasDeMusique.Visibility = Visibility.Collapsed;
                    LAB_PasDeCategorie.Visibility = Visibility.Collapsed;
                    ModifierStatusBoutonsMusiques(true);
                }
                else
                {
                    // Sinon on affiche le message indiquant qu'il n'y a pas de Musiques dans la catégorie
                    LV_ListeMusiques.Visibility = Visibility.Collapsed;
                    LAB_PasDeMusique.Visibility = Visibility.Visible;
                    LAB_PasDeCategorie.Visibility = Visibility.Collapsed;
                    ModifierStatusBoutonsMusiques(false);
                }
            } else
            {
                // Sinon on affiche le message indiquant qu'il n'y a pas de catégorie
                LAB_PasDeCategorie.Visibility = Visibility.Visible;
                LAB_PasDeMusique.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Méthode permettant de créer les fichiers et dossiers nécessaires au stockage des informations
        /// </summary>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        private void CreerFichiers(string nomUtilisateur)
        {
            string cheminFichier;

            try
            {
                // Dossier de l'utilisateur
                cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur;
                if (!Directory.Exists(cheminFichier))
                {
                    var fichier = Directory.CreateDirectory(cheminFichier);
                }

                // Dossier pour les images
                cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\images";
                if (!Directory.Exists(cheminFichier))
                {
                    var fichier = Directory.CreateDirectory(cheminFichier);
                }

                // Categories
                cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\categories.dat";
                if (!File.Exists(cheminFichier))
                {
                    var fichier = File.Create(cheminFichier);
                    fichier.Close();
                }

                // Musiques
                cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\Musiques.dat";
                if (!File.Exists(cheminFichier))
                {
                    var fichier = File.Create(cheminFichier);
                    fichier.Close();
                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Méthode permettant de charger et d'afficher une image
        /// </summary>
        /// <param name="chemin">Chemin de l'image à afficher</param>
        private void ChargerImage(string chemin)
        {
            Uri uriImage;
            BitmapImage image;

            try
            {
                if (chemin != "" && File.Exists(chemin))
                {
                    uriImage = new Uri(chemin, UriKind.Absolute);
                    image = new BitmapImage();
                    using (var fs = new FileStream(uriImage.LocalPath, FileMode.Open))
                    {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = fs;
                        image.EndInit();
                    }
                    image.Freeze();
                }
                else
                {
                    uriImage = new Uri("/Ressources/Images/NoPhoto.png", UriKind.Relative);
                    image = new BitmapImage(uriImage);
                }

                IMG_Affiche.Source = image;
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OuvrirYoutube(string nommusique)
        {
            try
            {
                nommusique = nommusique.Replace(" ", "+");
                Process youtube = new Process();
                youtube.StartInfo.FileName = "https://www.youtube.com/results?search_query=" + nommusique;
                youtube.Start();
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Méthode permettant de modifier l'état des boutons et menus de gestion des catégories
        /// </summary>
        /// <param name="etat">Etat d'activation à appliquer sur les éléments</param>
        private void ModifierStatusBoutonsCategories(bool etat)
        {
            BTN_ModifierCategorie.IsEnabled = etat;
            BTN_SupprimerCategorie.IsEnabled = etat;

            MENU_ModifierCategorie.IsEnabled = etat;
            MENU_SupprimerCategorie.IsEnabled = etat;
        }

        /// <summary>
        /// Méthode permettant de modifier l'état des boutons et menus de gestion des Musiques
        /// </summary>
        /// <param name="etat">Etat d'activation à appliquer sur les éléments</param>
        private void ModifierStatusBoutonsMusiques(bool etat)
        {
            BTN_ModifierMusique.IsEnabled = etat;
            BTN_SupprimerMusique.IsEnabled = etat;

            MENU_ModifierMusique.IsEnabled = etat;
            MENU_SupprimerMusique.IsEnabled = etat;
        }



        /*
         * Raccourcis claviers pour le menu
         */

        private void Click_Menu_FicheUtilisateur(object sender, ExecutedRoutedEventArgs e)
        {
            Utilisateur utilisateur = Utilisateur.Rechercher(Global.UtilisateurConnecte.Nom);

            FicheUtilisateur fiche = new FicheUtilisateur(utilisateur.Nom);
            fiche.ShowDialog();
        }

        private void Click_Menu_ChangerUtilisateur(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            Close();
        }

        private void Click_Menu_Quitter(object sender, ExecutedRoutedEventArgs e)
        {
            string message = "Êtes-vous certain de vouloir fermer l'application ?";
            if(MessageBox.Show(message, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Fermeture de l'application
                Application.Current.Shutdown();
            }
        }

        private void Click_Menu_AjouterCategorie(object sender, ExecutedRoutedEventArgs e)
        {
            BTN_AjouterCategorie.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Click_Menu_ModifierCategorie(object sender, ExecutedRoutedEventArgs e)
        {
            BTN_ModifierCategorie.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Click_Menu_SupprimerCategorie(object sender, ExecutedRoutedEventArgs e)
        {
            BTN_SupprimerCategorie.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Click_Menu_AjouterMusique(object sender, ExecutedRoutedEventArgs e)
        {
            BTN_AjouterMusique.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Click_Menu_ModifierMusique(object sender, ExecutedRoutedEventArgs e)
        {
            BTN_ModifierMusique.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Click_Menu_SupprimerMusique(object sender, ExecutedRoutedEventArgs e)
        {
            BTN_SupprimerMusique.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Click_Menu_APropos(object sender, ExecutedRoutedEventArgs e)
        {
            APropos fenetre = new APropos();
            fenetre.ShowDialog();
        }



        /*
         * Methodes pour les boutons, les sélections de liste et les click dans les listes.
         */

        private void BTN_AjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
            FicheCategorie fiche = new FicheCategorie();
            fiche.ShowDialog();
            RafraichirListeCategories();
        }

        private void BTN_ModifierCategorie_Click(object sender, RoutedEventArgs e)
        {
            Categorie categorie;
            string message = "Veuillez sélectionner une catégorie afin de pouvoir la modifier.";

            if (LB_ListeCategories.SelectedIndex >= 0)
            {
                categorie = LB_ListeCategories.SelectedItem as Categorie;

                FicheCategorie fiche = new FicheCategorie(categorie.Numero);
                fiche.ShowDialog();

                RafraichirListeCategories();
            }
            else
            {
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BTN_SupprimerCategorie_Click(object sender, RoutedEventArgs e)
        {
            List<Musique> Musiques;
            Categorie categorie;
            string message = "Veuillez sélectionner une catégorie afin de pouvoir la supprimer.";

            if (LB_ListeCategories.SelectedIndex >= 0)
            {
                categorie = LB_ListeCategories.SelectedItem as Categorie;
                if(categorie != null)
                {
                    message = "Si vous supprimer la catégorie, tous les Musiques appartenants à celle-ci seront supprimés.\nÊtes-vous certain de vouloir supprimer cette catégorie ?";
                    if (MessageBox.Show(message, "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        Categorie.Supprimer(categorie.Numero, Global.UtilisateurConnecte.Nom);
                    }
                }
                RafraichirListeCategories();
            }
            else
            {
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BTN_AjouterMusique_Click(object sender, RoutedEventArgs e)
        {
            Categorie categorie = LB_ListeCategories.SelectedItem as Categorie;
            FicheMusique fiche;

            if(categorie == null || categorie.Numero == 0)
            {
                fiche = new FicheMusique();
            } else
            {
                fiche = new FicheMusique(0, categorie.Numero);
            }
            
            fiche.ShowDialog();
            RafraichirListeCategories();
            RafraichirListeMusiques();
        }

        private void BTN_ModifierMusique_Click(object sender, RoutedEventArgs e)
        {
            Musique Musique;
            Categorie categorie;

            string message = "Veuillez sélectionner un Musique afin de pouvoir le modifier.";

            if (LV_ListeMusiques.SelectedIndex >= 0)
            {
                Musique = LV_ListeMusiques.SelectedItem as Musique;
                categorie = LB_ListeCategories.SelectedItem as Categorie;

                FicheMusique fiche = new FicheMusique(Musique.Numero);
                fiche.ShowDialog();

                RafraichirListeCategories();
                RafraichirListeMusiques();
            }
            else
            {
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BTN_SupprimerMusique_Click(object sender, RoutedEventArgs e)
        {
            Musique Musique;
            string message = "Veuillez sélectionner un Musique afin de pouvoir le supprimer.";

            if (LB_ListeCategories.SelectedIndex >= 0)
            {
                Musique = LV_ListeMusiques.SelectedItem as Musique;
                message = "Êtes-vous certain de vouloir supprimer ce Musique ?";
                if(MessageBox.Show(message, "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ChargerImage("");
                    Musique.Supprimer(Musique.Numero, Global.UtilisateurConnecte.Nom);
                    RafraichirListeMusiques();
                }

                RafraichirListeCategories();
            }
            else
            {
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void BTN_YouTube_Click(object sender, RoutedEventArgs e)
        {
            Musique Musique = LV_ListeMusiques.SelectedItem as Musique;
            OuvrirYoutube(Musique.Titre);
        }
        private void LB_ListeCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorie categorie = LB_ListeCategories.SelectedItem as Categorie;
            if(categorie == null || categorie.Numero == 0)
            {
                ModifierStatusBoutonsCategories(false);
            } else
            {
                ModifierStatusBoutonsCategories(true);
            }
            RafraichirListeMusiques();
        }

        private void LV_ListeMusiques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string chemin;
            Musique Musique = LV_ListeMusiques.SelectedItem as Musique;

            if(Musique != null)
            {
                TxtBlk_Titre.Text = Musique.Titre;
                TxtBlk_Realisateur.Text = Musique.Realisateur;
                TxtBlk_DateSortie.Text = Musique.DateSortie.ToString("dd/MM/yyyy");
                TxtBlk_Resume.Text = Musique.Resume.Replace("[#RETURN#]", "\r\n");

                if (Musique.Affiche != "")
                {
                    chemin = AppDomain.CurrentDomain.BaseDirectory + Global.UtilisateurConnecte.Nom + "\\images\\" + Musique.Affiche;
                    ChargerImage(chemin);
                }
                else
                {
                    ChargerImage("");
                }

                GRID_DetailMusique.Visibility = Visibility.Visible;

                ModifierStatusBoutonsMusiques(true);
            }
            else
            {
                GRID_DetailMusique.Visibility = Visibility.Collapsed;
                ModifierStatusBoutonsMusiques(false);
            }
        }

        private void LV_ListeMusiques_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BTN_ModifierMusique.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }
        
    }
}