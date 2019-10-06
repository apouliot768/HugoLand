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
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                bool echecSauvegarde = false;
                do
                {
                    try
                    {
                        if (objetMonde.Description != null && objetMonde.x > -1 && objetMonde.y > -1 &&
                            !(contexte.ObjetMondes.Any(x => x.Id == objetMonde.Id)) &&
                            objetMonde.TypeObjet > -1 && contexte.Mondes.Any(x => x.Id == objetMonde.MondeId))
                        {
                            contexte.ObjetMondes.Add(objetMonde);
                            contexte.SaveChanges();
                            echecSauvegarde = false;
                        }
                    }
                    catch (Exception)
                    {
                        echecSauvegarde = true;
                    }
                } while (echecSauvegarde);
            }
        }

        public void SupprimerObjetMonde(ObjetMonde objetMonde)
        {
            bool echecSauvegarde = false;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.ObjetMondes.Any(x => x.Id == objetMonde.Id))
                        {
                            contexte.ObjetMondes.Remove(contexte.ObjetMondes.FirstOrDefault(x => x.Id == objetMonde.Id));
                            contexte.SaveChanges();
                        }
                        echecSauvegarde = false;
                    }
                }
                catch (Exception)
                {
                    echecSauvegarde = true;
                }
            } while (echecSauvegarde);
        }

        public void ModifierObjetMonde(ObjetMonde objetMonde, string description)
        {
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                try
                {
                    ObjetMonde objetMondeDB = contexte.ObjetMondes.FirstOrDefault(x => x.Id == objetMonde.Id);
                    if (objetMondeDB != null)
                    {
                        objetMondeDB.Description = description;
                        contexte.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    // Gestion volontairement pessimiste de la concurence
                }
            }
        }
    }
}
