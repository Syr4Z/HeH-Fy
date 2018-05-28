using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Hehfy.Classes
{
    class Categorie
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public string NomComparaison { get; set; }

        /*
         * Constructeurs
         */

        public Categorie() { }

        public Categorie(int numero, string nom)
        {
            this.Numero = numero;
            this.Nom = nom;
            this.NomComparaison = nom.ToUpperInvariant();
        }


        /*
         * Méthodes publiques
         */

        /// <summary>
        /// Méthode permettant de sauvegarder les données dans le fichier (ou des les ajouter si besoin)
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// </summary>
        public void Sauver(string nomUtilisateur)
        {
            List<Categorie> categorie = Categorie.Lister(nomUtilisateur);
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\categories.dat";
            string chaine;
            StreamWriter fichier = null;

            bool operationReussie = false;

            // Ouverture du fichier en écriture
            try
            {
                fichier = new StreamWriter(cheminFichier, false);
                if (fichier != null)
                {
                    foreach (Categorie c in categorie)
                    {
                        if (c.Numero == this.Numero)
                        {
                            // Si la catégorie lue est la catégorie courante, on sérialise la nouvelle instance
                            chaine = this.Serialiser();
                            operationReussie = true;
                        }
                        else
                        {
                            // Sinon, on resérialise la catégorie lue
                            chaine = c.Serialiser();
                        }

                        // Ecriture dans le fichier
                        fichier.WriteLine(chaine);
                    }

                    // Si l'élément n'est pas trouvé dans la liste, on l'ajoute à la fin
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
            chaine += this.Numero + "[#]";
            chaine += this.Nom + "[#]";
            chaine += this.NomComparaison;

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

            if (tmp.Length == 3)
            {
                result = true;
                try
                {
                    this.Numero = Int32.Parse(tmp[0]);
                    this.Nom = tmp[1];
                    this.NomComparaison = tmp[2];
                } catch (Exception e)
                {
                    string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                    MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = false;
                }
            }

            return result;
        }


        /*
         * Méthodes statiques
         */

        /// <summary>
        /// Methode statique permettant de lister les catégories
        /// </summary>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <returns>Liste des catégories appartenant à l'utilisateur</returns>
        public static List<Categorie> Lister(string nomUtilisateur)
        {
            List<Categorie> listeCategories = new List<Categorie>();
            Categorie categorie;

            string nomFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\categories.dat";
            StreamReader fichier = null;
            string ligne;

            // Ouverture du fichier en lecture
            try
            {
                fichier = new StreamReader(nomFichier);

                if (fichier != null)
                {
                    // On recherche l'utilisateur pour vori s'il existe
                    while((ligne = fichier.ReadLine()) != null)
                    {
                        categorie = new Categorie();
                        if (categorie.Deserialiser(ligne))
                        {
                            listeCategories.Add(categorie);
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

            return listeCategories;
        }

        /// <summary>
        /// Méthode statique permettant de rechercher une catégorie par son numéro de savoir si elle existe par un booléen passé en paramètre (out)
        /// </summary>
        /// <param name="numeroCategorie">Numéro de la catégorie à rechercher</param>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <param name="existe">Booléen indiquant si la catégorie existe ou non (out)</param>
        /// <returns>Instance de la classe Catégorie contant les informations de la catégorie recherchée (null si non trouvée)</returns>
        public static Categorie Rechercher(int numeroCategorie, string nomUtilisateur, out bool existe)
        {
            Categorie categorie = new Categorie();
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\categories.dat";
            StreamReader fichier = null;
            string ligne;

            existe = false;
            try {
                fichier = new StreamReader(cheminFichier);
                if (fichier != null)
                {
                    // On recherche l'utilisateur pour vori s'il existe
                    while ((ligne = fichier.ReadLine()) != null && existe == false)
                    {
                        categorie = new Categorie();
                        if (categorie.Deserialiser(ligne) && categorie.Numero == numeroCategorie)
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

            return categorie;
        }

        /// <summary>
        /// Méthode statique permettant de rechercher une catégorie par son nom de savoir si elle existe par un booléen passé en paramètre (out)
        /// </summary>
        /// <param name="nomCategorie">Nom de la catégorie à rechercher</param>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <param name="existe">Booléen indiquant si la catégorie existe ou non (out)</param>
        /// <returns>Instance de la classe Catégorie contant les informations de la catégorie recherchée (null si non trouvée)</returns>
        public static Categorie Rechercher(string nomCategorie, string nomUtilisateur, out bool existe)
        {
            Categorie categorie = new Categorie();
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\categories.dat";
            StreamReader fichier = null;
            string ligne;

            existe = false;
            try
            {
                fichier = new StreamReader(cheminFichier);
                if (fichier != null)
                {
                    // On recherche l'utilisateur pour vori s'il existe
                    while ((ligne = fichier.ReadLine()) != null && existe == false)
                    {
                        categorie = new Categorie();
                        if (categorie.Deserialiser(ligne) && categorie.NomComparaison == nomCategorie.ToUpperInvariant())
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

            return categorie;
        }

        /// <summary>
        /// Méthode statique permettant de supprimer une catégorie appartenant à l'utilisateur
        /// </summary>
        /// <param name="numeroCategorie">Numéro de la catégorie à supprimer</param>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <returns>Résultat de la suppression</returns>
        public static bool Supprimer(int numeroCategorie, string nomUtilisateur)
        {
            List<Categorie> categories = Categorie.Lister(nomUtilisateur);
            List<Musique> Musiques = Musique.ListerParCategorie(numeroCategorie, nomUtilisateur);
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\categories.dat";
            string chaine;

            StreamWriter fichier = null;

            bool operationReussie = false;

            try
            {
                fichier = new StreamWriter(cheminFichier, false);
                if (fichier != null)
                {
                    foreach (Categorie c in categories)
                    {
                        if (c.Numero == numeroCategorie)
                        {
                            // Suppression des Musiques
                            foreach (Musique f in Musiques)
                            {
                                Musique.Supprimer(f.Numero, Global.UtilisateurConnecte.Nom);
                            }

                            operationReussie = true;
                        }
                        else
                        {
                            chaine = c.Serialiser();
                            fichier.WriteLine(chaine);
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

            return operationReussie;
        }


    }
}
