using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoLand.Models;

namespace HugoLand.ViewModels
{
    /// <summary>
    /// Auteurs:        Alexandre Pouliot et Joëlle Boyer
    /// Description:    Classe de gestion des objets composant un monde donné
    /// Date:           2019-10-07
    /// </summary>
    public class GestionObjetMonde
    {
        // Liste qui cumul les erreurs de connexion si lieu
        public List<string> LstErreursObjetMondes { get; set; } = new List<string>();

        // Création d'un Objet présent dans un monde
        public void CréerObjetMonde(ObjetMonde objetMonde)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {

                        if (objetMonde.Description != null && objetMonde.x >= 0 && objetMonde.y >= 0 &&
                            !(contexte.ObjetMondes.Any(x => x.Id == objetMonde.Id)) &&
                            objetMonde.TypeObjet >= 0 && contexte.Mondes.Any(x => x.Id == objetMonde.MondeId))
                        {
                            contexte.ObjetMondes.Add(objetMonde);
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursObjetMondes.Add("Erreur dans la méthode \'CréerObjetMonde\' : Monde non existant ou données invalides");

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
                        LstErreursObjetMondes.Add("Erreur dans la méthode \'CréerObjetMonde\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

        }
        // Supression d'un Objet présent dans un monde
        public ObjetMonde SupprimerObjetMonde(ObjetMonde objetMonde)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.ObjetMondes.Any(x => x.Id == objetMonde.Id))
                        {
                            contexte.ObjetMondes.Remove(contexte.ObjetMondes.FirstOrDefault(x => x.Id == objetMonde.Id));
                            try
                            {
                                contexte.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                echecSauvegarde = true;
                                nombreEchec++;
                                if (nombreEchec == byte.MaxValue)
                                {
                                    echecSauvegarde = false;
                                    LstErreursObjetMondes.Add("Erreur dans la méthode \'SupprimerObjetMonde\' : " + ex.Message);
                                }
                            }

                        }
                        else
                            LstErreursObjetMondes.Add("Erreur dans la méthode \'SupprimerObjetMonde\' : ObjetMonde inexistant!");

                        echecSauvegarde = false;
                    }
                }
                catch (Exception ex)
                {
                    echecSauvegarde = true;
                    nombreEchec++;
                    if (nombreEchec == byte.MaxValue)
                    {
                        echecSauvegarde = false;
                        LstErreursObjetMondes.Add("Erreur dans la méthode \'SupprimerObjetMonde\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

            return new ObjetMonde();
        }

        // Modification de la description d'un objet présent dans un monde
        public ObjetMonde ModifierObjetMonde(ObjetMonde objetMonde, string description)
        {
            ObjetMonde objetMondeDB = new ObjetMonde();
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                try
                {
                    objetMondeDB = contexte.ObjetMondes.FirstOrDefault(x => x.Id == objetMonde.Id);
                    if (objetMondeDB != null)
                    {
                        objetMondeDB.Description = description;
                        contexte.SaveChanges();
                        return objetMondeDB;
                    }
                    else
                    {
                        LstErreursObjetMondes.Add("Erreur dans la méthode \'ModifierObjetMonde\' : ObjetMonde inexistant!");
                        objetMondeDB.Description = description + " bugModif";
                        CréerObjetMonde(objetMondeDB);
                        return objetMondeDB;
                    }
                }
                catch (Exception ex)
                {
                    LstErreursObjetMondes.Add("Erreur dans la méthode \'ModifierObjetMonde\' : " + ex.Message);
                    objetMondeDB.Description = description + " bugModif";
                    CréerObjetMonde(objetMondeDB);
                    return objetMondeDB;
                }
                
            }
        }
    }
}
