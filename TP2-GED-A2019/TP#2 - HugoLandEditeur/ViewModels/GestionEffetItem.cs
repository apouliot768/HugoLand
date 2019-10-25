﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur.ViewModels
{
    /// <summary>
    /// Auteurs:        Joëlle Boyer et Alexandre Pouliot
    /// Description:    Gère les objets EffetsItems qui définissent l'effet donné d'un item
    /// Date:           2019-10-07
    /// </summary>
    public class GestionEffetItem : EffetItem
    {
        // Liste des effets d'items à renvoyer à la vue
        public List<EffetItem> LstEffetsItem { get; set; }

        // Liste des erreurs de fonctionnements pour les effets d'items
        public List<string> LstErreursEffetsItems { get; set; } = new List<string>();

        // Remplir la liste des effets d'items
        public GestionEffetItem()
        {
            RetournerEffetItem();
        }

        // Ajouter des effets d'items
        public EffetItem AjouterEffetItem(EffetItem effetItem)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;

            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (!(contexte.EffetItems.Any(x => x.Id == effetItem.Id)) && !(contexte.EffetItems.Any(x => x.ItemId == effetItem.ItemId)))
                        {
                            effetItem.Item = new Item();
                            effetItem.Item = contexte.Items.First(x => x.Id == effetItem.ItemId);
                            contexte.EffetItems.Add(effetItem);
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursEffetsItems.Add("Erreur dans la méthode \'AjouterEffetItem\' : Effet d\' déjà existant ou données invalides!");

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
                        LstErreursEffetsItems.Add("Erreur dans la méthode \'AjouterEffetItem\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

            RetournerEffetItem();
            return LstEffetsItem.Last();
        }

        // Supprimer des effets d'items
        public EffetItem SupprimerEffetItem(EffetItem effetItem)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;

            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (effetItem.Item != null && contexte.EffetItems.Any(x => x.Id == effetItem.Id))
                        {
                            contexte.EffetItems.Remove(contexte.EffetItems.Find(effetItem.Id));
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursEffetsItems.Add("Erreur dans la méthode \'AjouterEffetItem\' : Effet d\' déjà existant ou données invalides!");

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
                        LstErreursEffetsItems.Add("Erreur dans la méthode \'SupprimerEffetItem\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

            RetournerEffetItem();
            return new EffetItem();
        }

        // Modifier des effets d'items
        public EffetItem ModifierEffetItem(EffetItem effetItem, int itemId, int valEffet, int typeEffet)
        {
            EffetItem dbeffetItem = new EffetItem();

            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    dbeffetItem = contexte.EffetItems.FirstOrDefault(x => x.Id == effetItem.Id);

                    if (effetItem.Item != null && contexte.EffetItems.Any(x => x.Id == effetItem.Id))
                    {
                        dbeffetItem.Item = contexte.Items.First(x => x.Id == itemId);
                        dbeffetItem.TypeEffet = typeEffet;
                        dbeffetItem.ValeurEffet = valEffet;
                        contexte.SaveChanges();
                        RetournerEffetItem();
                        return dbeffetItem;
                    }
                    else
                    {
                        LstErreursEffetsItems.Add("Erreur dans la méthode \'ModifierEffetItem\' : Effet d\'item inexistant!");
                        dbeffetItem.TypeEffet = 0;
                        dbeffetItem.ValeurEffet = 0;
                        AjouterEffetItem(dbeffetItem);
                        RetournerEffetItem();
                        return dbeffetItem;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion volontairement pessimiste de la concurence
                LstErreursEffetsItems.Add("Erreur dans la méthode \'ModifierEffetItem\' : " + ex.Message);
                RetournerEffetItem();
                dbeffetItem.TypeEffet = 0;
                dbeffetItem.ValeurEffet = 0;
                AjouterEffetItem(dbeffetItem);
                RetournerEffetItem();
                return dbeffetItem;
            }
        }

        // Peupler la liste des items
        public void RetournerEffetItem()
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    LstEffetsItem = contexte.EffetItems.ToList();
                }
            }
            catch (Exception ex)
            {
                LstErreursEffetsItems.Add("Erreur dans la méthode \'RetournerEffetItem\' : " + ex.Message);
            }
        }
    }
}