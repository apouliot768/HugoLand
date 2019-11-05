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
    /// Description:    Gère les objets Héros qui définissent les propriétés d'un héro
    /// Date:           2019-10-07
    /// </summary>
    public class GestionHeros : Hero
    {
        // Liste des héros à renvoyer à la vue
        public List<Hero> LstHeros { get; set; }

        // Listes des objets se trouvant dans le champs de vision du héro (rayon de 200x200)
        public List<Hero> lstHero = new List<Hero>();
        public List<ObjetMonde> lstObjmonde = new List<ObjetMonde>();
        public List<Item> lstItems = new List<Item>();
        public List<Monstre> lstMonstres = new List<Monstre>();

        // Remplir la liste des héros
        public GestionHeros()
        {
            RetournerHeros();
        }

        // Création d'un héro
        public void CréationHero(Hero hero)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    // Ajouter le héro au compte du joueur et au monde
                    CompteJoueur compte = contexte.CompteJoueurs.Find(hero.CompteJoueurId);
                    hero.CompteJoueur = compte;
                    Monde monde = contexte.Mondes.Find(hero.MondeId);
                    hero.Monde = monde;

                    if ((hero.y > -1 && hero.y <= monde.LimiteY) && (hero.x > -1 && hero.x <= monde.LimiteX)
                        && monde.Id == hero.MondeId && hero.NomHero != "" && hero.Niveau > 0 && hero.CompteJoueurId == compte.Id
                        && !(contexte.Heros.Any(z => z.Id == hero.Id)))
                    {
                        compte.Heros.Add(hero);
                        monde.Heros.Add(hero);

                        // Donner une classe de novice si la classe est à null
                        if (hero.Classe == null)
                        {
                            hero.ClasseId = 2056;
                            hero.Classe = contexte.Classes.Find(hero.ClasseId);
                        }
                        contexte.Heros.Add(hero);
                        contexte.SaveChanges();
                        RetournerHeros();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        // Suppression d'un héro
        public void SuppressionHero(Hero hero)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexte.Mondes.Find(hero.MondeId);
                    CompteJoueur compte = contexte.CompteJoueurs.Find(hero.CompteJoueurId);
                    monde.Heros.Remove(hero);
                    compte.Heros.Remove(hero);

                    if (contexte.Heros.Any(x => x.Id == hero.Id))
                    {
                        contexte.Heros.Remove(contexte.Heros.Find(hero.Id));
                        contexte.SaveChanges();
                        RetournerHeros();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        // Modification d'un héro
        public void ModifierHero(Hero hero, int niveau, long exp, int x, int y, int str, int dex, int inte, int vit, int mondeId, bool estConnecte)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    // Retirer le héro au monde
                    Monde monde = contexte.Mondes.Find(hero.MondeId);
                    monde.Heros.Remove(hero);

                    Hero dbHero = contexte.Heros.FirstOrDefault(z => z.Id == hero.Id);

                    if (dbHero != null)
                    {
                        dbHero.Niveau = niveau;
                        dbHero.Experience = exp;
                        dbHero.EstConnecte = estConnecte;
                        dbHero.StatStr = str;
                        dbHero.StatDex = dex;
                        dbHero.StatInt = inte;
                        dbHero.StatVitalite = vit;
                        dbHero.MondeId = mondeId;
                        dbHero.x = x;
                        dbHero.y = y;

                        monde = contexte.Mondes.Find(mondeId);
                        dbHero.Monde = monde;
                        monde.Heros.Add(dbHero);

                        contexte.SaveChanges();
                        RetournerHeros();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        // Déplacement d'un héro
        public void DéplacerHero(Hero hero, int x, int y)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexte.Mondes.Find(hero.MondeId);

                    if (contexte.Heros.Any(z => z.Id == hero.Id))
                    {
                        // Si le héro ne peut bouger en x, ne rien faire, sinon avancer et sauvegarder la nouvelle position du héro
                        if (hero.x + x > monde.LimiteX || !(monde.ObjetMondes.Any(om => om.x == hero.x + x && om.y == hero.y)))
                            return;
                        else if (hero.x + x < monde.LimiteX || !(monde.ObjetMondes.Any(om => om.x == hero.x + x && om.y == hero.y)))
                        {
                            hero.x += x;
                            contexte.SaveChanges();
                            return;
                        }
                        // Si le héro ne peut bouger en y, ne rien faire, sinon avancer et sauvegarder la nouvelle position du héro
                        else if (hero.y + y > monde.LimiteY || !(monde.ObjetMondes.Any(om => om.x == hero.x && om.y == hero.y + y)))
                            return;
                        else if (hero.y + y < monde.LimiteY || !(monde.ObjetMondes.Any(om => om.x == hero.x && om.y == hero.y + y)))
                        {
                            hero.y += y;
                            contexte.SaveChanges();
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        // Éléments étant à proximité du héro
        public void ÉlémentsRayon200x200(Hero hero)
        {
            try
            {
                int tileX = 0;

                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexte.Mondes.Find(hero.MondeId);
                    Hero heros = contexte.Heros.Find(hero.MondeId);

                    if (contexte.Heros.Any(z => z.Id == hero.Id))
                    {
                        if (monde.SizeTile != null)
                            tileX = 200 / (int)monde.SizeTile;
                        else
                            tileX = 200 / 16;

                        lstHero = contexte.Heros.Where(z => z.MondeId == hero.MondeId && (z.x <= hero.x + tileX && z.x >= hero.x - tileX) 
                            && (z.y <= hero.y + tileX && z.y >= hero.y - tileX) && hero.Id != z.Id).ToList();
                        lstItems = contexte.Items.Where(z => z.MondeId == hero.MondeId && (z.x <= hero.x + tileX && z.x >= hero.x - tileX)
                            && (z.y <= hero.y + tileX && z.y >= hero.y - tileX) && hero.Id != z.Id).ToList();
                        lstMonstres = contexte.Monstres.Where(z => z.MondeId == hero.MondeId && (z.x <= hero.x + tileX && z.x >= hero.x - tileX)
                            && (z.y <= hero.y + tileX && z.y >= hero.y - tileX) && hero.Id != z.Id).ToList();
                        lstObjmonde = contexte.ObjetMondes.Where(z => z.MondeId == hero.MondeId && (z.x <= hero.x + tileX && z.x >= hero.x - tileX)
                            && (z.y <= hero.y + tileX && z.y >= hero.y - tileX) && hero.Id != z.Id).ToList();

                        //foreach (var obj in monde.Heros)
                        //    if (obj.MondeId == hero.MondeId && (obj.x <= hero.x + tileX && obj.x >= hero.x - tileX)
                        //        && (obj.y <= hero.y + tileX && obj.y >= hero.y - tileX) && hero.Id != obj.Id)
                        //        lstHero.Add(obj);

                        //foreach (var obj in monde.Items)
                        //    if (obj.MondeId == hero.MondeId && (obj.x <= hero.x + tileX && obj.x >= hero.x - tileX)
                        //        && (obj.y <= hero.y + tileX && obj.y >= hero.y - tileX))
                        //        lstItems.Add(obj);

                        //foreach (var obj in monde.Monstres)
                        //    if (obj.MondeId == hero.MondeId && (obj.x <= hero.x + tileX && obj.x >= hero.x - tileX)
                        //        && (obj.y <= hero.y + tileX && obj.y >= hero.y - tileX))
                        //        lstMonstres.Add(obj);

                        //foreach (var obj in monde.ObjetMondes)
                        //    if (obj.MondeId == hero.MondeId && (obj.x <= hero.x + tileX && obj.x >= hero.x - tileX)
                        //        && (obj.y <= hero.y + tileX && obj.y >= hero.y - tileX))
                        //        lstObjmonde.Add(obj);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        // Retourne la liste des héros pour un joueur donné
        public List<Hero> RetourHerosJoueur(int joueurId)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    return contexte.Heros.Where(h => h.CompteJoueurId == joueurId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Peupler la liste des héros
        public void RetournerHeros()
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                LstHeros = contexte.Heros.ToList();
            }
        }
    }
}
