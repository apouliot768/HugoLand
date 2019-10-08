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
    public class GestionMonstre : Monstre
    {
        public List<Monstre> LstMonstres { get; set; }

        public GestionMonstre()
        {
            RetournerMonstres();
        }

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

        public void RetournerMonstres()
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                LstMonstres = contexte.Monstres.ToList();
            }
        }
    }
}
