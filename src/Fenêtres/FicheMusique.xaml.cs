using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;
using Hehfy.Classes;

namespace Hehfy.Fenêtres
{
    /// <summary>
    /// Logique d'interaction pour FicheMusique.xaml
    /// </summary>
    public partial class FicheMusique : Window
    {
        private int NumeroMusique = 0;
        private List<Categorie> categories = Categorie.Lister(Global.UtilisateurConnecte.Nom);
        private Musique Musique = new Musique();
        private bool ImageModifiee = false;
        private string Affiche = null;
        private bool ConfirmerFermeture = true;

        public FicheMusique()
        {
            InitializeComponent();
            COMBO_Categorie.ItemsSource = categories;
        }

        // Constructeur pour l'ouverture en modification de fiche
        public FicheMusique(int numeroMusique, int numeroCategorie = 0) : this()
        {
            bool existe;

            if (numeroMusique != 0)
            {
                this.Musique = Musique.Rechercher(numeroMusique, Global.UtilisateurConnecte.Nom, out existe);

                if (!existe)
                {
                    string message = "Le Musique recherché n'existe pas.";
                    MessageBox.Show(message, "Musique non trouvé", MessageBoxButton.OK, MessageBoxImage.Error);

                    // Fermeture de la fenêtre
                    DialogResult = false;
                }
                else
                {
                    NumeroMusique = Musique.Numero;
                    this.Musique.Resume = this.Musique.Resume.Replace("[#RETURN#]", "\r\n");
                    this.DataContext = this.Musique;

                    // Chargement des informations
                    ChargerImage();
                    SelectionnerCategorie(Musique.NumeroCategorie);
                    DP_DateSortie.SelectedDate = Musique.DateSortie;
                    Affiche = Musique.Affiche;
                }
            } else if(numeroCategorie > 0)
            {
                foreach (Categorie c in COMBO_Categorie.Items)
                {
                    if (c.Numero == numeroCategorie)
                    {
                        COMBO_Categorie.SelectedItem = c;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Méthode permettant d'afficher une image pour l'affiche (sélection automatique du chemin)
        /// </summary>
        private void ChargerImage()
        {
            string chemin;
            string appFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            if (Musique.Affiche != "")
            {
                chemin = AppDomain.CurrentDomain.BaseDirectory + Global.UtilisateurConnecte.Nom + "\\images\\" + Musique.Affiche;
                ChargerImage(chemin);
            }
            else
            {
                ChargerImage("");
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

        /// <summary>
        /// Méthode permettant de vérifier si le formulaire est complété correctement
        /// </summary>
        /// <returns>Résultat de la vérifcation</returns>
        private bool VerifierFormulaire()
        {
            bool formulaireOK = true;
            string messageErreur = "";
            DateTime tmp;

            if (TB_Titre.Text == "")
            {
                formulaireOK = false;
                messageErreur += "Le nom est obligtoire.";
            }

            if (TB_Auteur.Text == "")
            {
                formulaireOK = false;
                if (messageErreur != "")
                    messageErreur += "\n";
                messageErreur += "Le réalisateur est obligtoire.";
            }

            if (DP_DateSortie.Text == "")
            {
                formulaireOK = false;
                if (messageErreur != "")
                    messageErreur += "\n";
                messageErreur += "La date de sortie est obligtoire.";
            }
            else if (!DateTime.TryParse(DP_DateSortie.Text, out tmp))
            {
                formulaireOK = false;
                if (messageErreur != "")
                    messageErreur += "\n";
                messageErreur += "La date de sortie n'est pas valide.";
            }

            if (!formulaireOK)
            {
                MessageBox.Show(messageErreur, "Erreur dans la fiche", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return formulaireOK;
        }

        /// <summary>
        /// Méthode permettant de copier une image dans le dossier contenant les images de l'utilisateur.
        /// </summary>
        private void CopierImage()
        {
            string source = Musique.Affiche;
            string destination = AppDomain.CurrentDomain.BaseDirectory + Global.UtilisateurConnecte.Nom + "\\images\\";

            SupprimerImage();

            if (NumeroMusique == 0)
            {
                destination += Global.UtilisateurConnecte.CompteurMusiques;
            }
            else
            {
                destination += NumeroMusique;
            }

            try
            {
                destination += System.IO.Path.GetExtension(source);
                File.Copy(source, destination);

                Musique.Affiche = System.IO.Path.GetFileName(destination);
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Méthode permettant de sélectionner une catégorie en fonction de son numéro
        /// </summary>
        /// <param name="numeroCategorie">Numéro de la catégorie a sélectionner</param>
        private void SelectionnerCategorie(int numeroCategorie)
        {
            foreach (Categorie c in categories)
            {
                if (c.Numero == numeroCategorie)
                {
                    COMBO_Categorie.SelectedItem = c;
                    return;
                }
            }
        }

        /// <summary>
        /// Méthode permettant de supprimer l'image qui se trouve dans la variable "Affiche"
        /// </summary>
        private void SupprimerImage()
        {
            string chemin = AppDomain.CurrentDomain.BaseDirectory + Global.UtilisateurConnecte.Nom + "\\images\\";

            try
            {
                if (Affiche != "" && File.Exists(chemin + Affiche))
                {
                
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + Global.UtilisateurConnecte.Nom + "\\images\\" + Affiche);
                

                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Méthode permettant de modifier le comportement du clic sur le bouton de fermeture de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ConfirmerFermeture == true)
            {
                string message = "Les modification non enregistrées seront perdues.\nVoulez-vous vraiment annuler ?";
                if (MessageBox.Show(message, "Voulez-vous continuer?", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
            }
           
        }



        /*
         * Méthodes pour les boutons, les sélections de liste et les click dans les listes.
         */
        private void BTN_Valider_Click(object sender, RoutedEventArgs e)
        {
            if (VerifierFormulaire())
            {
                if (NumeroMusique == 0)
                {
                    Global.UtilisateurConnecte.IncrementerCompteurMusiques();
                    this.Musique.Numero = Global.UtilisateurConnecte.CompteurMusiques;
                }

                this.Musique.Titre = TB_Titre.Text;
                this.Musique.Realisateur = TB_Auteur.Text;
                this.Musique.Resume = TB_Note.Text.Replace("\r\n", "[#RETURN#]");
                this.Musique.DateSortie = DP_DateSortie.SelectedDate.Value;
                this.Musique.NumeroCategorie = (COMBO_Categorie.SelectedItem as Categorie).Numero;

                if (ImageModifiee == true)
                {
                    if(Musique.Affiche == "")
                    {
                        SupprimerImage();
                    } else
                    {
                        CopierImage();
                    }
                }

                this.Musique.Sauver(Global.UtilisateurConnecte.Nom);
                ConfirmerFermeture = false;
                DialogResult = true;
            }
        }

        private void BTN_Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BTN_ModifierImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers images (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageModifiee = true;
                Musique.Affiche = openFileDialog.FileName;

                ChargerImage(openFileDialog.FileName);
            }
        }

        private void BTN_SupprimerImage_Click(object sender, RoutedEventArgs e)
        {
            Musique.Affiche = "";
            ImageModifiee = true;
            ChargerImage("");
        }
        
    }
}
