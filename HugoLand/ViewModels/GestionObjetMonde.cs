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
    public class GestionObjetMonde
    {
        public void CréerObjetMonde(ObjetMonde objetMonde)
        {
            using (EntitiesGEDEquipe1 contexteCréationObjetMonde = new EntitiesGEDEquipe1())
            {
                if (objetMonde.Description != null && objetMonde.x > -1 && objetMonde.y > -1
                    && !(contexteCréationObjetMonde.ObjetMondes.Any(x => x.Id == objetMonde.Id))
                    && objetMonde.TypeObjet > -1 && contexteCréationObjetMonde.Mondes.Any(x => x.Id == objetMonde.MondeId))
                {
                    contexteCréationObjetMonde.ObjetMondes.Add(objetMonde);
                    contexteCréationObjetMonde.SaveChanges();
                }
            }
        }

        public void SupprimerObjetMonde(ObjetMonde objetMonde)
        {
            using (EntitiesGEDEquipe1 contexteSupressionObjetMonde = new EntitiesGEDEquipe1())
            {
                if (contexteSupressionObjetMonde.ObjetMondes.Any(x => x.Id == objetMonde.Id))
                {
                    contexteSupressionObjetMonde.Mondes.Remove(contexteSupressionObjetMonde.Mondes.FirstOrDefault(x => x.Id == objetMonde.Id));
                    contexteSupressionObjetMonde.SaveChanges();
                }
            }

        }

        public void ModifierObjetMonde(ObjetMonde objetMonde, string description)
        {
            using (EntitiesGEDEquipe1 contexteModifierObjetMonde = new EntitiesGEDEquipe1())
            {
                ObjetMonde objetMondeDB = contexteModifierObjetMonde.ObjetMondes.FirstOrDefault(x => x.Id == objetMonde.Id);
                if (objetMondeDB != null)
                {
                    objetMondeDB.Description = description;
                    contexteModifierObjetMonde.SaveChanges();
                }
            }
        }
    }
}
