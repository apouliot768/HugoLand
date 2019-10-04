using System;
using System.Collections.Generic;
using System.Configuration;
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

        public void CréerMonde(Monde monde)
        {

            using (EntitiesGEDEquipe1 contexteCréationMonde = new EntitiesGEDEquipe1())
            {
                if (monde.Description != null && monde.LimiteX > -1 && monde.LimiteY > -1
                    && !(contexteCréationMonde.Mondes.Any(x => x.Id == monde.Id)))
                {
                    contexteCréationMonde.Mondes.Add(monde);
                    contexteCréationMonde.SaveChanges();
                    RetournerMondes();
                }
            }

        }

        public void SupprimerMonde(Monde monde)
        {
            using (EntitiesGEDEquipe1 contexteSupressionMonde = new EntitiesGEDEquipe1())
            {
                if (contexteSupressionMonde.Mondes.Any(x => x.Id == monde.Id))
                {

                    // Supression des Items dépendants et de ses dépendances
                    foreach (Item item in contexteSupressionMonde.Items.Where(x => x.MondeId == monde.Id))
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


                    //contexteSupressionMonde.Mondes.Remove(contexteSupressionMonde.Mondes.FirstOrDefault(x => x.Id == monde.Id));
                    //contexteSupressionMonde.SaveChanges();
                    RetournerMondes();
                }
            }
        }

        public void ModifierMonde(Monde monde, int limiteX, int limiteY, string description)
        {
            using (EntitiesGEDEquipe1 contexteModifierMonde = new EntitiesGEDEquipe1())
            {
                Monde mondeDB = contexteModifierMonde.Mondes.FirstOrDefault(x => x.Id == monde.Id);
                if (mondeDB != null)
                {
                    mondeDB.LimiteX = limiteX;
                    mondeDB.LimiteY = limiteY;
                    mondeDB.Description = description;
                    contexteModifierMonde.SaveChanges();
                    RetournerMondes();
                }
            }
        }

        public void RetournerMondes()
        {
            using (EntitiesGEDEquipe1 contexteListerMonde = new EntitiesGEDEquipe1())
            {
                LstMondes = contexteListerMonde.Mondes.ToList();
            }
        }
    }
}
