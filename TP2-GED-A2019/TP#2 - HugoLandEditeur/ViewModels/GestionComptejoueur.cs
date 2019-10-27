using HugoLandEditeur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur.ViewModels
{
    /// <summary>
    /// Auteurs:        Alexandre Pouliot et Joëlle Boyer
    /// Description:    Classe de gestion des comptes utilisateurs
    /// Date:           2019-10-07
    /// </summary>
    public class GestionCompteJoueur
    {
        // liste des erreurs de connexion
        public List<string> LstErreursComptesJoueurs { get; set; } = new List<string>();

        // Liste des joueurs d'un objet GestionComptesjoueurs
        public List<CompteJoueur> LstComptes { get; set; }

        // Compte courrant
        public CompteJoueur CompteCourrant { get; set; }

        // Rôles des utilisateurs
        public enum Role
        {
            Admin,
            Joueur,
            Défaut
        }

        // Création du compte d'un joueur à l'aide de la procédure stockée
        public string CréerCompteJoueur(string NomJoueur, string Courriel, string Prenom, string Nom, int TypeUtilisateur, string MotDePasse)
        {
            string Message = "";
            ObjectParameter objectParameter = new ObjectParameter("message", Message);
            using (EntitiesGEDEquipe1 context = new EntitiesGEDEquipe1())
            {
                if (!(context.CompteJoueurs.Any(x => x.NomJoueur == NomJoueur)))
                {
                    var procédureInsertion = context.CreerCompteJoueur(NomJoueur, Courriel, Prenom, Nom, TypeUtilisateur, MotDePasse, objectParameter);
                    RafraichirComptes();
                    return objectParameter.Value.ToString();
                }
                else
                {
                    Message = "Nom de joueur déjà existant!";
                    return Message;
                }
            }
        }

        // Supression du compte d'un joueur
        public CompteJoueur SupprimerCompteJoueur(CompteJoueur compteJoueur)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    List<Hero> lstheros = contexte.Heros.Where(x => x.CompteJoueurId == compteJoueur.Id).ToList();
                    foreach (Hero hero in lstheros)
                    {
                        List<InventaireHero> inventaireHeroes = contexte.InventaireHeroes.Where(x => x.IdHero == hero.Id).ToList();
                        foreach (InventaireHero inventaire in inventaireHeroes)
                        {
                            using (SqlConnection connection = new SqlConnection(Constantes.ConnectionString))
                            {
                                //la commade a exécuter avec la query et la connection
                                SqlCommand sql = new SqlCommand(Constantes.RequeteDeleteItem, connection);
                                //insérer toutes les valeurs dans les paramêtres
                                sql.Parameters.AddWithValue("@ItemId", inventaire.ItemId);
                                // ouvrir la connection
                                connection.Open();
                                // exécuter la commande
                                sql.ExecuteNonQuery();
                                // Ferme la connection
                                connection.Close();
                            }
                        }
                    }

                    using (SqlConnection connection = new SqlConnection(Constantes.ConnectionString))
                    {
                        //la commade a exécuter avec la query et la connection
                        SqlCommand sql = new SqlCommand(Constantes.RequeteDeleteHeroDuCompteJoueur, connection);
                        //insérer toutes les valeurs dans les paramêtres
                        sql.Parameters.AddWithValue("@CompteJoueurId", compteJoueur.Id);
                        // ouvrir la connection
                        connection.Open();
                        // exécuter la commande
                        sql.ExecuteNonQuery();
                        // Ferme la connection
                        connection.Close();
                    }

                    contexte.SaveChanges();
                    RafraichirComptes();
                }
            }
            catch (Exception ex)
            {
                LstErreursComptesJoueurs.Add(ex.Message);
            }

            compteJoueur = new CompteJoueur();
            return compteJoueur;
        }

        // Modification complète d'un compte joueur à l'aide de l'envoie 
        // d'un compte joueur contenant l'ID du compte visé, des informations souhaités et 
        // d'une string contenant le mot de passe en claire.
        public CompteJoueur ModifierCompteJoueur(CompteJoueur compteJoueur, string MotDePasse)
        {
            try
            {
                CompteJoueur compteJoueurBD = new CompteJoueur();
                CompteJoueur compteJoueurUpdate = new CompteJoueur();
                List<CompteJoueur> compteJoueurs = new List<CompteJoueur>();
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {

                    // Création d'un nouveau compte pour updater le mot de passe
                    string Message = "";
                    ObjectParameter objectParameter = new ObjectParameter("message", Message);
                    var procédureInsertion = contexte.CreerCompteJoueur("Update", "Update", "Update", "Update", 1, MotDePasse, objectParameter);
                    contexte.SaveChanges();
                    compteJoueurBD = contexte.CompteJoueurs.FirstOrDefault(x => x.Id == compteJoueur.Id);

                    compteJoueurs = contexte.CompteJoueurs.ToList();
                    compteJoueurUpdate = compteJoueurs.Last();

                    compteJoueurBD.NomJoueur = compteJoueur.NomJoueur;
                    compteJoueurBD.Courriel = compteJoueur.Courriel;
                    compteJoueurBD.Prenom = compteJoueur.Prenom;
                    compteJoueurBD.Nom = compteJoueur.Nom;
                    compteJoueurBD.TypeUtilisateur = compteJoueur.TypeUtilisateur;
                    compteJoueurBD.MotDePasseHash = compteJoueurUpdate.MotDePasseHash;
                    compteJoueurBD.Salt = compteJoueurUpdate.Salt;

                    contexte.SaveChanges();
                }
                SupprimerCompteJoueur(compteJoueurUpdate);
                RafraichirComptes();
            }
            catch (Exception ex)
            {
                LstErreursComptesJoueurs.Add(ex.Message);
            }

            compteJoueur = new CompteJoueur();
            return compteJoueur;
        }

        // Connexion du compte d'un joueur à l'aide de la procédure stockée
        public CompteJoueur ConnexionCompteJoueur(string pNomJoueur, string pMotDePasse)
        {
            string Message = "";
            ObjectParameter objectParameter = new ObjectParameter("message", Message);
            using (EntitiesGEDEquipe1 context = new EntitiesGEDEquipe1())
            {
                var procédureInsertion = context.Connexion(pNomJoueur, pMotDePasse, objectParameter);
                if (objectParameter.Value.ToString() == "SUCCESS")
                {
                    CompteJoueur compteJoueur = context.CompteJoueurs.FirstOrDefault(x => x.NomJoueur == pNomJoueur);
                    compteJoueur.Connexion = true;
                    context.SaveChanges();
                    RafraichirComptes();
                    return compteJoueur;
                }
                else
                    return new CompteJoueur();
            }
        }

        public void Déconnexion(CompteJoueur compte)
        {
            using (EntitiesGEDEquipe1 context = new EntitiesGEDEquipe1())
            {
                CompteJoueur compteJoueur = context.CompteJoueurs.FirstOrDefault(x => x.NomJoueur == compte.NomJoueur);
                compteJoueur.Connexion = false;
                context.SaveChanges();
            }
        }

        public void RafraichirComptes()
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    LstComptes = contexte.CompteJoueurs.ToList();
                }
            }
            catch (Exception ex)
            {
                LstErreursComptesJoueurs.Add(ex.Message);
            }
        }

        public void ObtenirCompte(string nomJoueur)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    CompteCourrant = contexte.CompteJoueurs.FirstOrDefault(x => x.NomJoueur == nomJoueur);
                }
            }
            catch (Exception ex)
            {
                LstErreursComptesJoueurs.Add(ex.Message);
            }
        }
    }
}
