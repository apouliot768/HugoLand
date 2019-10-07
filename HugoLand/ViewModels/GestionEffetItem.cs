using System;
using System.Collections.Generic;
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
    public class GestionEffetItem : EffetItem
    {
        public List<EffetItem> LstEffetsItem { get; set; }

        public void AjouterEffetItem(EffetItem effetItem)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    if (!(contexte.EffetItems.Any(x => x.Id == effetItem.Id)) && !(contexte.EffetItems.Any(x => x.ItemId == effetItem.ItemId)))
                    {
                        effetItem.Item = contexte.Items.First(x => x.Id == effetItem.ItemId);
                        contexte.EffetItems.Add(effetItem);
                        contexte.SaveChanges();
                        RetournerEffetItem();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void SupprimerEffetItem(EffetItem effetItem)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    if (effetItem.Item != null && contexte.EffetItems.Any(x => x.Id == effetItem.Id))
                    {
                        contexte.EffetItems.Remove(contexte.EffetItems.Find(effetItem.Id));
                        contexte.SaveChanges();
                        RetournerEffetItem();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ModifierEffetItem(EffetItem effetItem, int itemId, int valEffet, int typeEffet)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    EffetItem dbeffetItem = contexte.EffetItems.FirstOrDefault(x => x.Id == effetItem.Id);

                    if (effetItem.Item != null && contexte.EffetItems.Any(x => x.Id == effetItem.Id))
                    {
                        dbeffetItem.Item = contexte.Items.First(x => x.Id == itemId);
                        dbeffetItem.TypeEffet = typeEffet;
                        dbeffetItem.ValeurEffet = valEffet;
                        contexte.SaveChanges();
                        RetournerEffetItem();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RetournerEffetItem()
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                LstEffetsItem = contexte.EffetItems.ToList();
            }
        }
    }
}
