using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur.ViewModels
{
    /// <summary>
    /// Auteurs:        Joëlle Boyer et Alexandre Pouliot
    /// Description:    Gère les objets monstres qui définissent les monstres
    /// Date:           2019-10-07
    /// </summary>
    public class GestionMonstre : Monstre
    {
        // Liste des monstres à renvoyer à la vue
        public List<Monstre> LstMonstres { get; set; }

        // Remplir la liste des monstres
        public GestionMonstre()
        {
            RetournerMonstres();
        }

        // Création d'un monstre
        public void CréerMonstre(Monstre monstre)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    // Ajouter le monstre dans le monde demandé
                    Monde monde = contexte.Mondes.Find(monstre.MondeId);
                    monstre.Monde = monde;
                    monde.Monstres.Add(monstre);

                    if ((monstre.y > -1 && monstre.y <= monstre.Monde.LimiteY) && (monstre.x > -1 && monstre.x <= monstre.Monde.LimiteX)
                        && (monstre.MondeId > 0 && contexte.Mondes.Any(x => x.Id == monstre.MondeId))
                        && monstre.Nom != "" && monstre.Niveau > 0 && monstre.StatPV > 0
                        && !(contexte.Monstres.Any(x => x.Id == monstre.Id)))
                    {
                        contexte.Monstres.Add(monstre);
                        contexte.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception ex)
            {
                //LstErreursMonstres.Add("Erreur dans la méthode \'CréerMonstre\' : " + ex.Message);
            }
        }

        public void CréerMonstre(Monstre monstre, int statPv, float statAttkMax, float statAttkMin, int statLevel)
        {
            int defStatPv = 0, lvl = 0;
            float defStatMax = 0, defStatMin = 0;
            Random rdn = new Random();

            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {

                    // Ajouter le monstre dans le monde demandé
                    Monstre mNew = new Monstre()
                    {
                        Nom = monstre.Nom,
                        x = monstre.x,
                        y = monstre.y,
                        ImageId = monstre.ImageId,
                        MondeId = monstre.MondeId
                    };

                    if (statLevel == 0)
                    {
                        lvl = rdn.Next(1, 11);
                        mNew.Niveau = lvl;
                    }
                    else
                        mNew.Niveau = statLevel;

                    if (statPv == 0)
                    {
                        defStatPv = 50;
                        mNew.StatPV = defStatPv + (lvl * 10);
                    }
                    else
                        mNew.StatPV = statPv;

                    if (statAttkMax == 0)
                    {
                        defStatMax = 10;
                        mNew.StatDmgMax = defStatMax * (1 + lvl / 5);
                    }
                    else
                        mNew.StatDmgMax = statAttkMax;

                    if (statAttkMin == 0)
                    {
                        defStatMin = 5;
                        mNew.StatDmgMin = defStatMin * (1 + lvl / 4);
                    }
                    else
                        mNew.StatDmgMin = statAttkMin;

                    //Monde monde = contexte.Mondes.Find(item.MondeId)
                    if (monstre.y > -1 && monstre.x > -1)
                    {
                        contexte.Monstres.Add(mNew);
                        contexte.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void ModificationMonstre(string tileName, int tileID, int id, int statPv, float statAttkMax, float statAttkMin, int statLevel)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {

                    Monstre monstre = contexte.Monstres.FirstOrDefault(x => x.Id == id);
                    monstre.Nom = tileName;
                    monstre.ImageId = tileID;
                    if (statPv != 0)
                        monstre.StatPV = statPv;
                    if (statAttkMax != 0)
                        monstre.StatDmgMax = statAttkMax;
                    if (statAttkMin != 0)
                        monstre.StatDmgMin = statAttkMin;
                    if (statLevel != 0)
                        monstre.Niveau = statLevel;

                    contexte.SaveChanges();
                    RetournerMonstres();
                }
            }
            catch (Exception)
            {

            }
        }

        // Suppression d'un monstre
        public void SupprimerMonstre(Monstre monstre)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexte.Mondes.Find(monstre.MondeId);
                    monstre.Monde = monde;
                    monde.Monstres.Remove(monstre);

                    if (contexte.Monstres.Any(x => x.Id == monstre.Id))
                    {
                        contexte.Monstres.Remove(contexte.Monstres.Find(monstre.Id));
                        contexte.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception ex)
            {
                //LstErreursMonstres.Add("Erreur dans la méthode \'SupprimerMonstre\' : " + ex.Message);
            }
        }

        // Modification d'un monstre
        public void ModifierMonstre(Monstre monstre, int x, int y, int mondeId, string nom, int niveau, int Pv, float DmgMin, float DmgMax, int? imgId)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexte.Mondes.Find(monstre.MondeId);
                    monde.Monstres.Remove(monstre);

                    Monstre dbMonstre = contexte.Monstres.FirstOrDefault(z => z.Id == monstre.Id);

                    if (dbMonstre != null)
                    {
                        dbMonstre.Nom = nom;
                        dbMonstre.Niveau = niveau;
                        dbMonstre.ImageId = imgId;
                        dbMonstre.StatPV = Pv;
                        dbMonstre.StatDmgMax = DmgMax;
                        dbMonstre.StatDmgMin = DmgMin;
                        dbMonstre.MondeId = mondeId;
                        dbMonstre.x = x;
                        dbMonstre.y = y;

                        monde = contexte.Mondes.Find(mondeId);
                        dbMonstre.Monde = monde;
                        monde.Monstres.Add(dbMonstre);

                        contexte.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception ex)
            {
                //LstErreursMonstres.Add("Erreur dans la méthode \'ModifierMonstre\' : " + ex.Message);
            }
        }

        // Peupler la liste des monstres
        public void RetournerMonstres()
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                LstMonstres = contexte.Monstres.ToList();
            }
        }
    }
}
