using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Hehfy.Classes
{
    class Musique
    {
        public int Numero { get; set; }
        public string Titre { get; set; }
        public string Realisateur { get; set; }
        public string Resume { get; set; }
        public string Affiche { get; set; }
        public DateTime DateSortie { get; set; }
        public int NumeroCategorie { get; set; }

        /*
         * Constructeurs
         */

        public Musique() { }

        public Musique(int numero, string titre, string realisateur, string resume, string affiche, DateTime dateSortie, int numeroCategorie)
        {
            this.Numero = numero;
            this.Titre = titre;
            this.Realisateur = realisateur;
            this.Resume = resume;
            this.Affiche = affiche;
            this.DateSortie = dateSortie;
            this.NumeroCategorie = numeroCategorie;
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
            List<Musique> Musiques = Musique.Lister(nomUtilisateur);
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\Musiques.dat";
            string chaine;
            StreamWriter fichier = null;

            bool operationReussie = false;

            // Ouverture du fichier en écriture
            try
            {
                fichier = new StreamWriter(cheminFichier, false);
                if (fichier != null)
                {
                    foreach (Musique f in Musiques)
                    {
                        if (f.Numero == this.Numero)
                        {
                            // Si le Musique lu est le Musique courant, on sérialise la nouvelle instance
                            chaine = this.Serialiser();
                            operationReussie = true;
                        }
                        else
                        {
                            // Sinon, on resérialise le Musique lu
                            chaine = f.Serialiser();
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
            } catch(Exception e)
            {
                string message = "Une erreur est survenue durant le traitement.\n Détail de l'erreur :\n" + e.Message;
                MessageBox.Show(message, "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            } finally
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
            chaine += this.Titre + "[#]";
            chaine += this.Realisateur + "[#]";
            chaine += this.Resume + "[#]";
            chaine += this.Affiche + "[#]";
            chaine += this.DateSortie.ToString() + "[#]";
            chaine += this.NumeroCategorie;

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

            if (tmp.Length == 7)
            {
                result = true;
                try
                {
                    this.Numero = Int32.Parse(tmp[0]);
                    this.Titre = tmp[1];
                    this.Realisateur = tmp[2];
                    this.Resume = tmp[3];
                    this.Affiche = tmp[4];
                    this.DateSortie = DateTime.Parse(tmp[5]);
                    this.NumeroCategorie = Int32.Parse(tmp[6]);
                } catch(Exception e)
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
        /// Methode statique permettant de lister les Musiques de l'utilisateur
        /// </summary>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <returns>Liste des Musiques appartenant à l'utilisateur</returns>
        public static List<Musique> Lister(string nomUtilisateur)
        {
            List<Musique> listeMusiques = new List<Musique>();
            Musique Musique;

            string nomFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\Musiques.dat";
            StreamReader fichier = null; 
            string ligne;

            // Ouverture du fichier en lecture
            try
            {
                fichier = new StreamReader(nomFichier);
                if (fichier != null)
                {
                    // Ajout de tous les Musiques dans la liste
                    while ((ligne = fichier.ReadLine()) != null)
                    {
                        Musique = new Musique();
                        if (Musique.Deserialiser(ligne))
                        {
                            listeMusiques.Add(Musique);
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

            return listeMusiques;
        }

        /// <summary>
        /// Methode statique permettant de lister les Musiques de l'utilisateur par catégorie
        /// </summary>
        /// <param name="numeroCategorie">Numéro de la catégorie concernée</param>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <returns>Liste des Musiques appartenant à l'utilisateur et à la catégorie</returns>
        public static List<Musique> ListerParCategorie(int numeroCategorie, string nomUtilisateur)
        {
            List<Musique> listeMusiques = new List<Musique>();
            Musique Musique;

            string nomFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\Musiques.dat";
            StreamReader fichier = null;
            string ligne;

            // Ouverture du fichier en lecture
            try
            {
                fichier = new StreamReader(nomFichier);
                if (fichier != null)
                {
                    // Ajout de tous les Musiques de la catégorie dans la liste
                    while ((ligne = fichier.ReadLine()) != null)
                    {
                        Musique = new Musique();
                        Musique.Deserialiser(ligne);

                        // Vérification que le Musique appartient à la catégorie souhaitée
                        if(numeroCategorie == Musique.NumeroCategorie)
                        {
                            listeMusiques.Add(Musique);
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

            return listeMusiques;
        }

        /// <summary>
        /// Méthode statique permettant de rechercher un Musique par son numéro de savoir s'il existe par un booléen passé en paramètre (out)
        /// </summary>
        /// <param name="numeroMusique">Numéro du Musique à rechercher</param>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <param name="existe">Booléen indiquant si le Musique existe ou non (out)</param>
        /// <returns>Instance de la classe Musique contenant les informations du Musique (null si non trouvés)</returns>
        public static Musique Rechercher(int numeroMusique, string nomUtilisateur, out bool existe)
        {
            Musique Musique = new Musique();
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\Musiques.dat";
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
                        // Désarialisation du Musique et vérification poru voir s'il s'agit du Musique recherché
                        Musique = new Musique();
                        if (Musique.Deserialiser(ligne) && Musique.Numero == numeroMusique)
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

            return Musique;
        }
        
        /// <summary>
        /// Méthode statique permettant de supprimer un Musique appartenant à l'utilisateur
        /// </summary>
        /// <param name="numeroMusique">Numéro du Musique à supprimer</param>
        /// <param name="nomUtilisateur">Nom de l'utilisateur connecté</param>
        /// <returns>Résultat de la suppression</returns>
        public static bool Supprimer(int numeroMusique, string nomUtilisateur)
        {
            List<Musique> Musiques = Musique.Lister(nomUtilisateur);
            string cheminFichier = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\Musiques.dat";
            string chaine;
            StreamWriter fichier = null;

            bool operationReussie = false;

            try
            {
                fichier = new StreamWriter(cheminFichier, false);
                if (fichier != null)
                {
                    foreach (Musique f in Musiques)
                    {
                        if (f.Numero == numeroMusique)
                        {
                            // Suppression de l'affiche si elle existe
                            if (f.Affiche != "")
                            {
                                chaine = AppDomain.CurrentDomain.BaseDirectory + nomUtilisateur + "\\images\\" + f.Affiche;
                                if (File.Exists(chaine))
                                {
                                    File.Delete(chaine);
                                }
                            }
                            operationReussie = true;
                        }
                        else
                        {
                            // S'il ne s'agit pas du Musique à supprimer, on réécrit la ligne dans le fichier;
                            chaine = f.Serialiser();
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
