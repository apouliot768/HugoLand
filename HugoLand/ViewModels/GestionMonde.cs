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
    public class GestionMonde
    {
        public List<Monde> LstMondes { get; set; }

        public void CréerMonde(Monde monde)
        {

            using (EntitiesGEDEquipe1 contexteCréationMonde = new EntitiesGEDEquipe1())
            {
                if (monde.Description != "" && monde.LimiteX > 0 && monde.LimiteY > 0 && !(contexteCréationMonde.Mondes.Any(x => x.Id == monde.Id)))
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
                    contexteSupressionMonde.Mondes.Remove(contexteSupressionMonde.Mondes.FirstOrDefault(x => x.Id == monde.Id));
                    contexteSupressionMonde.SaveChanges();
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
