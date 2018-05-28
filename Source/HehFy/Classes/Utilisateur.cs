using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Hehfy.Classes
{
    class Utilisateur
    {
        public string Nom { get; set; }
        public string MotDePasse { get; set; }
        public int CompteurCategories { get; set; }
        public int CompteurMusiques { get; set; }


        private static string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + "utilisateurs.dat";

        /* 
         * Constructeurs
         */
        public Utilisateur() { }

        public Utilisateur(string nom, string motDePasse)
        {
            this.Nom = nom;
            this.MotDePasse = motDePasse;
            this.CompteurCategories = 0;
            this.CompteurMusiques = 0;
        }

        public Utilisateur(string nom, string motDePasse, int compteurCategories, int compteurMusiques)
        {
            this.Nom = nom;
            this.MotDePasse = motDePasse;
            this.CompteurCategories = compteurCategories;
            this.CompteurMusiques = compteurMusiques;
        }


        /*
         * Méthodes publiques
         */
        
        /// <summary>
        /// Méthode permettant d'incrémenter le compteur de catégories de l'utilisateur
        /// </summary>
        public void IncrementerCompteurCategories()
        {
            this.CompteurCategories++;
            this.Sauver();
        }

        /// <summary>
        /// Méthode permettant d'incrémenter le compteur de Musiques de l'utilisateur
        /// </summary>
        public void IncrementerCompteurMusiques()
        {
            this.CompteurMusiques++;
            this.Sauver();
        }

        /// <summary>
        /// Méthode permettant de sauvegarder les données dans le fichier (ou des les ajouter si besoin)
        /// </summary>
        public void Sauver()
        {
            List<Utilisateur> utilisateurs = Utilisateur.Lister();
            string chaine;

            bool operationReussie = false;

            StreamWriter fichier = null;

            try
            { 
                fichier = new StreamWriter(Utilisateur.cheminFichier, false);
                if (fichier != null)
                {
                    foreach(Utilisateur u in utilisateurs)
                    {
                        if(u.Nom == this.Nom)
                        {
                            chaine = this.Serialiser();
                            operationReussie = true;
                        } else
                        {
                            chaine = u.Serialiser();
                        }

                        fichier.WriteLine(chaine);
                    }

                    if (!operationReussie)
                    {
                        chaine = this.Serialiser();
                        fichier.WriteLine(chaine);
                    }
                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                // Fermeture du fichier
                if (fichier != null)
                {
                    fichier.Close();
                }
            }
        }

        /// <summary>
        /// Méthode permettant de sérialiser l'objet en une chaine de caractère pour stocker dans le fichier
        /// </summary>
        /// <returns>Chaine sérialisée</returns>
        public string Serialiser()
        {
            string chaine = "";

            chaine += this.Nom + "[#]";
            chaine += this.MotDePasse + "[#]";
            chaine += this.CompteurCategories + "[#]";
            chaine += this.CompteurMusiques;

            return chaine;
        }

        /// <summary>
        /// Méthode permettant de déserialiser une chaine de catactère et de stocker les valeurs dans l'instance de l'objet
        /// </summary>
        /// <param name="chaine">Chaine à déserialiser</param>
        /// <returns>Résultat de la déserialisation</returns>
        public bool Deserialiser(string chaine)
        {
            bool result = false;
            string[] tmp = chaine.Split(new string[] { "[#]" }, StringSplitOptions.None);

            if (tmp.Length == 4)
            {
                result = true;
                try
                {
                    this.Nom = tmp[0];
                    this.MotDePasse = tmp[1];
                    this.CompteurCategories = Int32.Parse(tmp[2]);
                    this.CompteurMusiques = Int32.Parse(tmp[3]);
                }
                catch (Exception e)
                {
                    string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                    MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return result;
        }


        /*
         * Méthodes statiques
         */

        /// <summary>
        /// Méthode permettant d'initialiser le fichier des utilisateurs et d'indiquer s'il faut créer un utilisateur ou non
        /// </summary>
        /// <returns>Booléen indiquant s'il faut initialiser programme ou non</returns>
        public static bool InitialiserFichier()
        {
            bool faireInit = true;

            try
            {
                if (!File.Exists(Utilisateur.cheminFichier))
                {
                    // Création du fichier des utilisateurs si celui-ci n'existe pas
                    var fichier = File.Create(Utilisateur.cheminFichier);
                    fichier.Close();
                }
                else
                {
                    // Vérification que le fichier n'est pas vide
                    if (File.ReadAllText(Utilisateur.cheminFichier) != "")
                    {
                        faireInit = false;
                    }
                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return faireInit;
        }

        /// <summary>
        /// Methode statique permettant de lister les utilisateurs
        /// </summary>
        /// <returns>Liste des utilisateurs enregistrés</returns>
        public static List<Utilisateur> Lister()
        {
            List<Utilisateur> liste = new List<Utilisateur>();
            Utilisateur utilisateur;
            string ligne;

            StreamReader fichier = null;

            try { 
                fichier = new StreamReader(@Utilisateur.cheminFichier);
                while ((ligne = fichier.ReadLine()) != null)
                {
                    utilisateur = new Utilisateur();

                    if (utilisateur.Deserialiser(ligne))
                    {
                        liste.Add(utilisateur);
                    }
                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                // Fermeture du fichier
                if (fichier != null)
                {
                    fichier.Close();
                }
            }

            return liste;
        }

        /// <summary>
        /// Méthode statique permettant de rechercher un utilisateur par son nom
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur à rechercher</param>
        /// <returns>Instance de la classe Utilisateur contant les informations de l'utilisateur recherché (null si non trouvé)</returns>
        public static Utilisateur Rechercher(string nom)
        {
            Utilisateur utilisateur = null;
            string ligne;
            StreamReader fichier = null;

            // On part du principe qu'il n'existe pas
            bool existe = false;


            try { 
                fichier = new StreamReader(Utilisateur.cheminFichier);
                if (fichier != null)
                {
                    // On recherche l'utilisateur pour vori s'il existe
                    while ((ligne = fichier.ReadLine()) != null && existe == false)
                    {
                        utilisateur = new Utilisateur();
                        if (utilisateur.Deserialiser(ligne) && utilisateur.Nom == nom)
                        {
                            existe = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                // Fermeture du fichier
                if (fichier != null)
                {
                    fichier.Close();
                }
            }

            if(existe == false)
            {
                utilisateur = null;
            }

            return utilisateur;
        }

        /// <summary>
        /// Méthode statique permettant de rechercher un utilisateur et de savoir s'il existe par un booléen passé en paramètre (out)
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur à rechercher</param>
        /// <param name="existe">Booléen indiquant si l'utilisateur existe ou non (out)</param>
        /// <returns></returns>
        public static Utilisateur Rechercher(string nom, out bool existe)
        {
            Utilisateur utilisateur = Rechercher(nom);
            if (utilisateur == null)
                existe = false;
            else
                existe = true;

            return utilisateur;
        }

        /// <summary>
        /// Méthode statique permettant de supprimer un utilisateur
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur à supprimer</param>
        /// <returns>Résultat de la suppression</returns>
        public static bool Supprimer(string nom)
        {
            bool operationReussie = false;

            List<Utilisateur> utilisateurs = Utilisateur.Lister();

            StreamWriter fichier = null;

            try {
                fichier = new StreamWriter(Utilisateur.cheminFichier, false);
                if (fichier != null)
                {
                    foreach (Utilisateur u in utilisateurs)
                    {
                        if (u.Nom.ToUpperInvariant() != nom.ToUpperInvariant())
                        {
                            fichier.WriteLine(u.Serialiser());
                        }
                    }

                    operationReussie = true;
                }
            }
            catch (Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                // Fermeture du fichier
                if (fichier != null)
                {
                    fichier.Close();
                }
            }

            return operationReussie;
        }
    }
}
