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
    /// Description:    Gère les objets items qui définissent un item
    /// Date:           2019-10-07
    /// </summary>
    public class GestionItem : Item
    {
        // Liste des items à renvoyer à la vue
        public List<Item> LstItems { get; set; }

        // Remplir la liste des items
        public GestionItem()
        {
            RetournerItems();
        }

        // Création d'un item
        public void CréationItem(Item item)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    // Ajouter le monstre dans le monde demandé
                    Monde monde = contexte.Mondes.Find(item.MondeId);
                    item.Monde = monde;
                    monde.Items.Add(item);

                    if ((item.y > -1 && item.y <= item.Monde.LimiteY) && (item.x > -1 && item.x <= item.Monde.LimiteX)
                        && (item.MondeId > 0 && contexte.Mondes.Any(x => x.Id == item.MondeId))
                        && item.Nom != "" && !(contexte.Items.Any(x => x.Id == item.Id)))
                    {
                        contexte.Items.Add(item);
                        contexte.SaveChanges();
                        RetournerItems();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Suppression d'un item
        public void SuppressionItem(Item item, Hero hero)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexte.Mondes.Find(item.MondeId);
                    InventaireHero inventaire;
                    if (contexte.InventaireHeroes.Any(x => x.IdHero == hero.Id))
                        inventaire = contexte.InventaireHeroes.Find(hero.Id);
                    else
                        inventaire = new InventaireHero();

                    monde.Items.Remove(item);

                    Item dbItem = contexte.Items.FirstOrDefault(z => z.Id == item.Id);

                    if (dbItem != null)
                    {
                        dbItem.x = null;
                        dbItem.y = null;
                        dbItem.IdHero = hero.Id;

                        inventaire.IdHero = hero.Id;
                        inventaire.Hero = hero;
                        inventaire.ItemId = dbItem.Id;
                        inventaire.Item = dbItem;

                        contexte.SaveChanges();
                        RetournerItems();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Modification d'un item
        public void ModificationItem(int idItem, int idHero, int quantite)
        {
            // Item item, string description, int x, int y, int mondeId, int? imgId
            try
            {
                InventaireHero inv = new InventaireHero();

                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Item item = contexte.Items.FirstOrDefault(x => x.Id == idItem);
                    Hero hero = contexte.Heros.FirstOrDefault(x => x.Id == idHero);

                    if (hero != null && item != null)
                    {
                        if (quantite > 0)
                            for (int i = 0; i < quantite; i++)
                            {
                                item.Hero = hero;
                                item.IdHero = hero.Id;
                                hero.Items.Add(item);
                            }
                        else
                        {
                            for (int i = 0; i > quantite; i--)
                            {
                                contexte.Items.Remove(item);
                                item = contexte.Items.FirstOrDefault(x => x.IdHero == idHero);
                            }
                        }
                    }

                    contexte.SaveChanges();
                    RetournerItems();
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Peupler la liste des items
        public void RetournerItems()
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                LstItems = contexte.Items.ToList();
            }
        }
    }
}
