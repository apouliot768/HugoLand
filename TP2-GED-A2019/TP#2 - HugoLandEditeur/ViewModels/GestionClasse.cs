using HugoLandEditeur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur.ViewModels
{
    /// <summary>
    /// Auteurs:        Alexandre Pouliot et Joëlle Boyer
    /// Description:    Gère les objets Classe qui définissent la classe d'un héro
    /// Date:           2019-10-27
    /// </summary>
    public class GestionClasse
    {
        // Liste des classes à renvoyer à la vue
        public List<Classe> LstClasses { get; set; }

        // Liste des erreurs de connexions de la classe
        public List<string> LstErreursClasses { get; set; } = new List<string>();

        // Crée des objets classe
        public Classe CréerClasse(Classe classe)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == classe.MondeId) && classe.NomClasse != null && classe.Description != null)
                        {
                            contexte.Classes.Add(classe);
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'CréerClasse\' : Données invalides ou Monde inexistant!");

                        echecSauvegarde = false;
                    }
                }
                catch (Exception ex)
                {
                    echecSauvegarde = true;
                    nombreEchec++;
                    if (nombreEchec > 10)
                    {
                        echecSauvegarde = false;
                        LstErreursClasses.Add("Erreur dans la méthode \'CréerClasse\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

            RecevoirClassesMonde(classe.MondeId);
            return LstClasses.Last();
        }

        // Supprime des classes de héros
        public Classe SupprimerClasse(Classe classe)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Classes.Any(x => x.Id == classe.Id))
                        {
                            List<Hero> lstHero = contexte.Heros.ToList();
                            foreach (Hero hero in lstHero)
                            {
                                foreach (InventaireHero inventaire in contexte.InventaireHeroes.Where(x => x.IdHero == hero.Id).ToList())
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
                                SqlCommand sql = new SqlCommand(Constantes.RequeteDeleteHeroClasse, connection);
                                //insérer toutes les valeurs dans les paramêtres
                                sql.Parameters.AddWithValue("@ClasseId", classe.Id);
                                // ouvrir la connection
                                connection.Open();
                                // exécuter la commande
                                sql.ExecuteNonQuery();
                                // Ferme la connection
                                connection.Close();
                            }
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'SupprimerClasse\' : Classe déjà supprimée avant la tentative de suppression!");
                        echecSauvegarde = false;
                    }
                }
                catch (Exception ex)
                {
                    echecSauvegarde = true;
                    nombreEchec++;
                    if (nombreEchec > 10)
                    {
                        LstErreursClasses.Add("Erreur dans la méthode \'SupprimerClasse\' : " + ex.Message);
                        echecSauvegarde = false;
                    }
                }
            } while (echecSauvegarde);

            RecevoirClassesMonde(classe.MondeId);
            return new Classe();
        }

        // Modifie la classe d'un héro
        public Classe ModifierClasse(Classe classe)
        {
            Classe classeBD = new Classe();
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    classeBD = contexte.Classes.FirstOrDefault(x => x.Id == classe.Id);
                    if (classeBD != null)
                    {
                        classeBD.NomClasse = classe.NomClasse;
                        classeBD.Description = classe.Description;
                        classeBD.StatBaseStr = classe.StatBaseStr;
                        classeBD.StatBaseDex = classe.StatBaseInt;
                        classeBD.StatBaseVitalite = classe.StatBaseVitalite;
                        classeBD.MondeId = classe.MondeId;
                        contexte.SaveChanges();
                    }
                    else
                        LstErreursClasses.Add("Erreur dans la méthode \'ModifierClasse\' : Classe inexistante!");
                }
            }
            catch (Exception ex)
            {
                // Gestion volontairement pessimiste de la concurence
                LstErreursClasses.Add("Erreur dans la méthode \'ModifierClasse\' : " + ex.Message);
            }

            RecevoirClassesMonde(classe.MondeId);
            return classeBD;
        }

        // Mise dans la propriété LstClasses les classes d'un monde
        public void RecevoirClassesMonde(int mondeId)
        {
            bool echecConnexion = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == mondeId))
                            LstClasses = contexte.Classes.Where(x => x.MondeId == mondeId).ToList();
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'RecevoirClassesMonde\' : Monde inexistant!");
                    }
                    echecConnexion = false;
                }
                catch (Exception ex)
                {
                    echecConnexion = true;
                    nombreEchec++;
                    if (nombreEchec > 10)
                    {
                        echecConnexion = false;
                        LstErreursClasses.Add("Erreur dans la méthode \'RecevoirClassesMonde\' : " + ex.Message);
                    }
                }
            } while (echecConnexion);
        }

        // Retourne la classe d'un héro
        public Classe TrouverClasseHero(Hero hero)
        {
            Classe clone = new Classe();
            Classe classeHero = new Classe();
            bool echecConnexion = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == hero.MondeId))
                        {
                            classeHero = contexte.Classes.FirstOrDefault(x => x.Id == hero.ClasseId);
                            return classeHero;
                        }
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'TrouverClasseHero\' : Monde inexistant!");
                        echecConnexion = false;
                        return clone;
                    }
                }
                catch (Exception ex)
                {
                    echecConnexion = true;
                    nombreEchec++;
                    if (nombreEchec > 10)
                    {
                        echecConnexion = false;
                        LstErreursClasses.Add("Erreur dans la méthode \'TrouverClasseHero\' : " + ex.Message);
                    }
                }
            } while (echecConnexion);

            return clone;
        }
    }
}
