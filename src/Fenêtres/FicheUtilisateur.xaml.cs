using System;
using System.Windows;
using Hehfy.Classes;

namespace Hehfy.Windows
{
    /// <summary>
    /// Logique d'interaction pour FicheUtilisateur.xaml
    /// </summary>
    public partial class FicheUtilisateur : Window
    {
        private string NomUtilisateur = "";
        private Utilisateur Utilisateur = new Utilisateur();
        private bool init = false;
        private bool ConfirmationFermeture = true;

        // Constructeur initial
        public FicheUtilisateur()
        {
            InitializeComponent();
        }

        // Constructeur pour l'initialisation de l'application (force l'ajout du premier utilisateur)
        public FicheUtilisateur(bool init) : this()
        {
            this.init = init;
        }

        // Constructeur pour l'ouverture en modification de fiche
        public FicheUtilisateur(string nomUtilisateur) : this()
        {
            bool existe;
            this.NomUtilisateur = nomUtilisateur;
            this.Utilisateur = Utilisateur.Rechercher(nomUtilisateur, out existe);

            if (!existe)
            {
                string message = "L'utilisateur recherché n'existe pas.";
                MessageBox.Show(message, "Utilisateur non trouvé", MessageBoxButton.OK, MessageBoxImage.Error);

                // Fermeture de la fenêtre
                DialogResult = false;
            }
            else
            {
                TB_Nom.IsReadOnly = true;
                this.DataContext = this.Utilisateur;
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

            if (TB_Nom.Text == "")
            {
                formulaireOK = false;
                messageErreur += "Le nom est obligtoire.";
            }
            else
            {
                // Nouvel utilisateur
                if (this.NomUtilisateur == "")
                {
                    if (TB_MotDePasse.Password == "" || TB_MotDePasse.Password != TB_MotDePasse2.Password)
                    {
                        formulaireOK = false;
                        messageErreur += "Les mots de passe sont obligatoires et doivent être identiques.";
                    }
                }
                else    // Utilisateur existant
                {
                    if (TB_MotDePasse.Password != TB_MotDePasse2.Password)
                    {
                        formulaireOK = false;
                        messageErreur += "Les mots de passe doivent être identiques.";
                    }
                }
            }

            if (!formulaireOK)
            {
                MessageBox.Show(messageErreur, "Erreur dans la fiche", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return formulaireOK;
        }

        /// <summary>
        /// Méthode permettant de modifier le comportement du clic sur le bouton de fermeture de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ConfirmationFermeture == true)
            {
                string message = "Les modification non enregistrées seront perdues.\nVoulez-vous vraiment annuler ?";
                if (MessageBox.Show(message, "Voulez-vous continuer?", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    // Si l'utilisateur clique sur non, on annule la fermeture de la fenêtre
                    e.Cancel = true;
                }
            }
        }



        /*
         * Méthodes pour les boutons, les sélections de liste et les click dans les listes.
         */
        private void BTN_Valider_Click(object sender, RoutedEventArgs e)
        {
            bool existe;
            string message;
            bool operationReussie = true;
            
            
            if (VerifierFormulaire())
            {
                if(NomUtilisateur == "")
                {
                    Utilisateur.Rechercher(TB_Nom.Text, out existe);
                    if (!existe)
                    {
                        this.Utilisateur.Nom = TB_Nom.Text;
                        this.Utilisateur.MotDePasse = TB_MotDePasse.Password;
                    }
                    else
                    {
                        message = "Un utilisateur existe déjà avec le nom \"" + TB_Nom.Text + "\".\nVeuillez modifier le nom du nouvel utilisateur pour continuer.";
                        MessageBox.Show(message, "Utilisateur déjà existant", MessageBoxButton.OK, MessageBoxImage.Error);
                        operationReussie = false;
                    }
                    
                } else
                {
                    if(TB_MotDePasse.Password != "")
                    {
                        this.Utilisateur.MotDePasse = TB_MotDePasse.Password;
                    }
                }

                

                if (operationReussie)
                {
                    ConfirmationFermeture = false;
                    this.Utilisateur.Sauver();
                    DialogResult = true;
                }
            }

        }

        private void BTN_Annuler_Click(object sender, RoutedEventArgs e)
        {
            if(this.init == true)
            {
                string message = "Vous devez créer un utilisteur afin de continuer.\nVoulez-vous vraiment annuler ?";
                if(MessageBox.Show(message, "Voulez-vous continuer?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConfirmationFermeture = false;

                    // Fermeture de l'application
                    Environment.Exit(0);
                }

            } else
            {
                    DialogResult = false;
            }
        }

        
    }
}
