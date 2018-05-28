using System.Windows;
using Hehfy.Classes;

namespace Hehfy.Fenêtres
{
    /// <summary>
    /// Logique d'interaction pour FicheCategorie.xaml
    /// </summary>
    /// 

    public partial class FicheCategorie : Window
    {
        private int NumeroCategorie = 0;
        private Categorie Categorie = new Categorie();
        private bool ConfirmationFermeture = true;

        public FicheCategorie()
        {
            InitializeComponent();
        }

        // Constructeur pour l'ouverture en modification de fiche
        public FicheCategorie(int numeroCategorie) : this()
        {
            bool existe;
            this.NumeroCategorie = numeroCategorie;
            this.Categorie = Categorie.Rechercher(numeroCategorie, Global.UtilisateurConnecte.Nom, out existe);

            if (!existe)
            {
                string message = "La catégorie recherchée n'existe pas.";
                MessageBox.Show(message, "Catégorie non trouvée", MessageBoxButton.OK, MessageBoxImage.Error);

                // Fermeture de la fenêtre
                DialogResult = false;
            }
            else
            {
                this.DataContext = this.Categorie;
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
                messageErreur += "Le nom est obligatoire.";
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
                string message = "Les modifications non enregistrées seront perdues.\nVoulez-vous vraiment annuler ?";
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
            bool existe;
            string message;
            Categorie categorie;

            ConfirmationFermeture = false;

            if (VerifierFormulaire())
            {
                categorie = Categorie.Rechercher(TB_Nom.Text, Global.UtilisateurConnecte.Nom, out existe);
                if (!existe || NumeroCategorie == categorie.Numero )
                {
                    if (NumeroCategorie == 0)
                    {
                        Global.UtilisateurConnecte.IncrementerCompteurCategories();
                        this.Categorie.Numero = Global.UtilisateurConnecte.CompteurCategories;
                        this.Categorie.Nom = TB_Nom.Text;
                        this.Categorie.NomComparaison = (TB_Nom.Text).ToUpperInvariant();

                    }
                    else
                    {
                        this.Categorie.Nom = TB_Nom.Text;
                        this.Categorie.NomComparaison = (TB_Nom.Text).ToUpperInvariant();
                    }

                    this.Categorie.Sauver(Global.UtilisateurConnecte.Nom);
                    DialogResult = true;
                }
                else
                {
                    message = "Une catégorie existe déjà avec le nom \"" + TB_Nom.Text + "\".\nVeuillez modifier le nom de la nouvelle catégorie pour continuer.";
                    MessageBox.Show(message, "Utilisateur déjà existant", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BTN_Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

       
    }
}
