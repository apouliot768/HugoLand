using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoLand.Models;

namespace HugoLand.ViewModels
{
    /// <summary>
    /// Auteurs:        Joëlle Boyer et Alexandre Pouliot
    /// Description:    
    /// Date:           
    /// </summary>
    public class GestionMonde
    {
        public List<Monde> LstMondes { get; set; }

        public List<string> LstErreursMondes { get; set; } = new List<string>();

        public GestionMonde()
        {
            RetournerMondes();
        }

        public Monde CréerMonde(Monde monde)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (monde.Description != null && monde.LimiteX >= 0 && monde.LimiteY >= 0 && !(contexte.Mondes.Any(x => x.Id == monde.Id)))
                        {
                            contexte.Mondes.Add(monde);
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursMondes.Add("Erreur dans la méthode \'CréerMonde\' : Monde déjà existant ou données invalides!");
                        echecSauvegarde = false;
                    }
                }
                catch (Exception ex)
                {
                    echecSauvegarde = true;
                    nombreEchec++;
                    if (nombreEchec == byte.MaxValue)
                    {
                        echecSauvegarde = false;
                        LstErreursMondes.Add("Erreur dans la méthode \'CréerMonde\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);
            RetournerMondes();
            return LstMondes.Last();
        }

        public Monde SupprimerMonde(Monde monde)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == monde.Id))
                        {
                            // Supression des Items dépendants et de ses dépendances
                            foreach (Item item in contexte.Items.Where(x => x.MondeId == monde.Id))
                            {
                                using (SqlConnection connection = new SqlConnection(Constantes.ConnectionString))
                                {
                                    //la commade a exécuter avec la query et la connection
                                    SqlCommand sql = new SqlCommand(Constantes.RequeteDeleteItem, connection);
                                    //insérer toutes les valeurs dans les paramêtres
                                    sql.Parameters.AddWithValue("@ItemId", item.Id);
                                    // ouvrir la connection
                                    connection.Open();
                                    // exécuter la commande
                                    sql.ExecuteNonQuery();
                                    // Ferme la connection
                                    connection.Close();
                                }
                            }

                            // Supression des dépendances de l'objet Monde
                            using (SqlConnection connection = new SqlConnection(Constantes.ConnectionString))
                            {
                                //la commade a exécuter avec la query et la connection
                                SqlCommand sql = new SqlCommand(Constantes.RequeteDeleteDependancesMonde, connection);
                                //insérer toutes les valeurs dans les paramêtres
                                sql.Parameters.AddWithValue("@MondeId", monde.Id);
                                // ouvrir la connection
                                connection.Open();
                                // exécuter la commande
                                sql.ExecuteNonQuery();
                                // Ferme la connection
                                connection.Close();
                            }
                        }
                        else
                            LstErreursMondes.Add("Erreur dans la méthode \'SupprimerMonde\' : Monde inexistant lors de la tentative de supression!");

                        echecSauvegarde = false;
                    }
                }
                catch (Exception ex)
                {
                    echecSauvegarde = true;
                    nombreEchec++;
                    if (nombreEchec == byte.MaxValue)
                    {
                        echecSauvegarde = false;
                        LstErreursMondes.Add("Erreur dans la méthode \'SupprimerMonde\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

            RetournerMondes();
            return new Monde();
        }

        public Monde ModifierMonde(Monde monde, int limiteX, int limiteY, string description)
        {
            Monde mondeDB = new Monde();
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    mondeDB = contexte.Mondes.FirstOrDefault(x => x.Id == monde.Id);
                    if (mondeDB != null)
                    {
                        mondeDB.LimiteX = limiteX;
                        mondeDB.LimiteY = limiteY;
                        mondeDB.Description = description;
                        contexte.SaveChanges();
                        RetournerMondes();
                        return mondeDB;
                    }
                    else
                    {
                        LstErreursMondes.Add("Erreur dans la méthode \'ModifierMonde\' : Monde inexistant!");
                        mondeDB.LimiteX = limiteX;
                        mondeDB.LimiteY = limiteY;
                        mondeDB.Description = description + " BugModif";
                        CréerMonde(mondeDB);
                        RetournerMondes();
                        return mondeDB;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion volontairement pessimiste de la concurence
                LstErreursMondes.Add("Erreur dans la méthode \'ModifierMonde\' : " + ex.Message);
                RetournerMondes();
                mondeDB.LimiteX = limiteX;
                mondeDB.LimiteY = limiteY;
                mondeDB.Description = description + " BugModif";
                CréerMonde(mondeDB);
                RetournerMondes();
                return mondeDB;
            }
        }

        public void RetournerMondes()
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    LstMondes = contexte.Mondes.ToList();
                }
            }
            catch (Exception ex)
            {
                LstErreursMondes.Add("Erreur dans la méthode \'RetournerMonde\' : " + ex.Message);
            }
        }
    }
}
