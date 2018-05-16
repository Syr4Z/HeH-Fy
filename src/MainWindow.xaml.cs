using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Hehfy.Classes;
using Hehfy.Fenêtres;
using Hehfy.Windows;

namespace Hehfy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Utilisateur> Utilisateurs;

        public MainWindow()
        {
            InitializeComponent();

            Initialisation();
            RafraichirListe();
        } 

        /// <summary>
        /// Méthode permettant d'initialiser l'application et de forcer la création d'un utilisateur si nécessaire
        /// </summary>
        private void Initialisation()
        {
            string message = "Il semble que vous utilisez cette application pour la première fois.\nNous alons donc créer un utilisateur afin d'initialiser l'application !";

            if (Utilisateur.InitialiserFichier())
            {
                if(MessageBox.Show(message, "Bienvenue !", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    FicheUtilisateur fiche = new FicheUtilisateur(true);
                    fiche.ShowDialog();
                    RafraichirListe();
                } else
                {
                    // Fermeture de l'application
                    Environment.Exit(0);
                }
            }
        }



        /*
         * Gestion des boutons
         */
        private void BTN_Connexion_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur utilisateur;
            string message = "Veuillez sélectionner un utilisateur afin de pouvoir vous connecter.";

            if (LB_ListUtilisateurs.SelectedIndex >= 0)
            {
                utilisateur = LB_ListUtilisateurs.SelectedItem as Utilisateur;
                try
                {
                    if(PWD_MotDePasse.Password == utilisateur.MotDePasse)
                    {
                        Global.UtilisateurConnecte = utilisateur;

                        ListeMusiques fenetre = new ListeMusiques();
                        fenetre.Show();
                        Close();
                    } else
                    {
                        message = "Le mot de passe est incorrect !";
                        MessageBox.Show(message, "Mot de passe incorrect", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                } catch(Exception exception) {
                    message = "Une erreur est survenue durant le traitement.\n\nDétail de l'erreur:\n" + exception.Message;
                    MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BTN_AjouterUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            FicheUtilisateur fiche = new FicheUtilisateur();
            fiche.ShowDialog();
            RafraichirListe();
        }

        private void BTN_ModifierUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur utilisateur;
            string message = "Veuillez sélectionner un utilisateur afin de pouvoir le modifier.";

            if (LB_ListUtilisateurs.SelectedIndex >= 0)
            {
                utilisateur = LB_ListUtilisateurs.SelectedItem as Utilisateur;

                FicheUtilisateur fiche = new FicheUtilisateur(utilisateur.Nom);
                fiche.ShowDialog();

                RafraichirListe();
            } else
            {
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void BTN_SupprimerUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            string message;
            Utilisateur utilisateur;
            if (LB_ListUtilisateurs.SelectedIndex >= 0)
            {
                message = "Cette action entrainera la suppression de la vidéothèque complète de cet utilisateur.\n";
                message += "Êtes vous certain de vouloir supprimer cet utilisateur ?";
                utilisateur = LB_ListUtilisateurs.SelectedItem as Utilisateur;

                if (MessageBox.Show(message, "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Utilisateur.Supprimer(utilisateur.Nom);
                    RafraichirListe();
                }
            }
            else
            {
                message = "Veuillez sélectionner un utilisateur afin de pouvoir le supprimer.";
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void RafraichirListe()
        {
            // Liste des utilisateurs
            Utilisateurs = Utilisateur.Lister();
            LB_ListUtilisateurs.ItemsSource = Utilisateurs;

            if (LB_ListUtilisateurs.Items.Count > 1)
            {
                BTN_SupprimerUtilisateur.IsEnabled = true;
            } else
            {
                BTN_SupprimerUtilisateur.IsEnabled = false;
            }
                
        }

        private void LB_ListUtilisateurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PWD_MotDePasse.Focus();
        }

        private void PWD_MotDePasse_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                BTN_Connexion.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
