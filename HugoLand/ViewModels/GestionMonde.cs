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

        public GestionMonde()
        {
            RetournerMondes();
        }

        public void CréerMonde(Monde monde)
        {
            bool echecSauvegarde = false;
            byte nombeEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (monde.Description != null && monde.LimiteX > -1 && monde.LimiteY > -1 && !(contexte.Mondes.Any(x => x.Id == monde.Id)))
                        {
                            contexte.Mondes.Add(monde);
                            contexte.SaveChanges();
                            echecSauvegarde = false;
                        }
                    }
                }
                catch (Exception)
                {
                    echecSauvegarde = true;

                    if (nombeEchec == byte.MaxValue)
                        echecSauvegarde = false;
                }
            } while (echecSauvegarde);
            RetournerMondes();
        }

        public void SupprimerMonde(Monde monde)
        {
            bool echecSauvegarde = false;
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
                        echecSauvegarde = false;
                    }
                }
                catch (Exception)
                {
                    echecSauvegarde = true;
                }
            } while (echecSauvegarde);

            RetournerMondes();
        }

        public void ModifierMonde(Monde monde, int limiteX, int limiteY, string description)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde mondeDB = contexte.Mondes.FirstOrDefault(x => x.Id == monde.Id);
                    if (mondeDB != null)
                    {
                        mondeDB.LimiteX = limiteX;
                        mondeDB.LimiteY = limiteY;
                        mondeDB.Description = description;
                        contexte.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                // Gestion volontairement pessimiste de la concurence
            }
            RetournerMondes();
        }

        public void RetournerMondes()
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                LstMondes = contexte.Mondes.ToList();
            }
        }
    }
}
