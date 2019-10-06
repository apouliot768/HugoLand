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
        public List<string> LstErreursMonstres { get; set; }

        public void CréerMonstre(Monstre monstre)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexteCréationMonstre = new EntitiesGEDEquipe1())
                {
                    // Ajouter le monstre dans le monde demandé
                    Monde monde = contexteCréationMonstre.Mondes.Find(monstre.MondeId);
                    monstre.Monde = monde;
                    monde.Monstres.Add(monstre);

                    if ((monstre.y > -1 && monstre.y <= monstre.Monde.LimiteY) && (monstre.x > -1 && monstre.x <= monstre.Monde.LimiteX)
                        && (monstre.MondeId > 0 && contexteCréationMonstre.Mondes.Any(x => x.Id == monstre.MondeId))
                        && monstre.Nom != "" && monstre.Niveau > 0 && monstre.StatPV > 0
                        && !(contexteCréationMonstre.Monstres.Any(x => x.Id == monstre.Id)))
                    {
                        contexteCréationMonstre.Monstres.Add(monstre);
                        contexteCréationMonstre.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception ex)
            {
                LstErreursMonstres.Add("Erreur dans la méthode \'CréerMonstre\' : " + ex.Message);
            }
        }

        public void SupprimerMonstre(Monstre monstre)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexteSuppressionMonstre = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexteSuppressionMonstre.Mondes.Find(monstre.MondeId);
                    monstre.Monde = monde;
                    monde.Monstres.Remove(monstre);

                    if (contexteSuppressionMonstre.Monstres.Any(x => x.Id == monstre.Id))
                    {
                        contexteSuppressionMonstre.Monstres.Remove(contexteSuppressionMonstre.Monstres.Find(monstre.Id));
                        contexteSuppressionMonstre.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception ex)
            {
                LstErreursMonstres.Add("Erreur dans la méthode \'SupprimerMonstre\' : " + ex.Message);
            }
        }

        public void ModifierMonstre(Monstre monstre, int x, int y, int mondeId, string nom, int niveau, int Pv, float DmgMin, float DmgMax, int? imgId)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexteModifierMonstre = new EntitiesGEDEquipe1())
                {
                    Monde monde = contexteModifierMonstre.Mondes.Find(monstre.MondeId);
                    monstre.Monde = monde;
                    monde.Monstres.Remove(monstre);

                    Monstre dbMonstre = contexteModifierMonstre.Monstres.FirstOrDefault(z => z.Id == monstre.Id);

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

                        monde = contexteModifierMonstre.Mondes.Find(mondeId);
                        dbMonstre.Monde = monde;
                        monde.Monstres.Add(dbMonstre);

                        contexteModifierMonstre.SaveChanges();
                        RetournerMonstres();
                    }
                }
            }
            catch (Exception ex)
            {
                LstErreursMonstres.Add("Erreur dans la méthode \'ModifierMonstre\' : " + ex.Message);
            }
        }

        public void RetournerMonstres()
        {
            using (EntitiesGEDEquipe1 contexteListerMonstre = new EntitiesGEDEquipe1())
            {
                LstMonstres = contexteListerMonstre.Monstres.ToList();
            }
        }
    }
}
