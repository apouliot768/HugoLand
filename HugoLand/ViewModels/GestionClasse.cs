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
    public class GestionClasse
    {
        public List<Classe> LstClasses { get; set; }

        public List<string> LstErreursClasses { get; set; } = new List<string>();

        public Classe CréerClasse(Classe classe)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == classe.MondeId) && classe.NomClasse != null && classe.Description != null)
                        {
                            contexte.Classes.Add(classe);
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'CréerClasse\' : Données invalides ou Monde inexistant!");

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
                        LstErreursClasses.Add("Erreur dans la méthode \'CréerClasse\' : " + ex.Message);
                    }
                }
            } while (echecSauvegarde);

            RecevoirClassesMonde(classe.MondeId);
            return LstClasses.Last();
        }

        public Classe SupprimerClasse(Classe classe)
        {
            bool echecSauvegarde = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Classes.Any(x => x.Id == classe.Id))
                        {
                            contexte.Classes.Remove(contexte.Classes.FirstOrDefault(x => x.Id == classe.Id));
                            contexte.SaveChanges();
                        }
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'SupprimerClasse\' : Classe déjà supprimée avant la tentative de suppression!");
                        echecSauvegarde = false;
                    }
                }
                catch (Exception ex)
                {
                    echecSauvegarde = true;
                    nombreEchec++;
                    if (nombreEchec == byte.MaxValue - 1)
                    {
                        LstErreursClasses.Add("Erreur dans la méthode \'SupprimerClasse\' : " + ex.Message);
                        echecSauvegarde = false;
                    }
                }
            } while (echecSauvegarde);

            RecevoirClassesMonde(classe.MondeId);
            return new Classe();
        }

        public Classe ModifierClasse(Classe classe)
        {
            Classe classeBD = new Classe();
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    classeBD = contexte.Classes.FirstOrDefault(x => x.Id == classe.Id);
                    if (classeBD != null)
                    {
                        classeBD.NomClasse = classe.NomClasse;
                        classeBD.Description = classe.Description;
                        classeBD.StatBaseStr = classe.StatBaseStr;
                        classeBD.StatBaseDex = classe.StatBaseInt;
                        classeBD.StatBaseVitalite = classe.StatBaseVitalite;
                        classeBD.MondeId = classe.MondeId;
                        contexte.SaveChanges();
                    }
                    else
                        LstErreursClasses.Add("Erreur dans la méthode \'ModifierClasse\' : Classe inexistante!");
                }
            }
            catch (Exception ex)
            {
                // Gestion volontairement pessimiste de la concurence
                LstErreursClasses.Add("Erreur dans la méthode \'ModifierClasse\' : " + ex.Message);
            }

            RecevoirClassesMonde(classe.MondeId);
            return classeBD;
        }

        public void RecevoirClassesMonde(int mondeId)
        {
            bool echecConnexion = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == mondeId))
                            LstClasses = contexte.Classes.Where(x => x.MondeId == mondeId).ToList();
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'RecevoirClassesMonde\' : Monde inexistant!");
                    }
                    echecConnexion = false;
                }
                catch (Exception ex)
                {
                    echecConnexion = true;
                    nombreEchec++;
                    if (nombreEchec == byte.MaxValue)
                    {
                        echecConnexion = false;
                        LstErreursClasses.Add("Erreur dans la méthode \'RecevoirClassesMonde\' : " + ex.Message);
                    }
                }
            } while (echecConnexion);
        }

        public Classe TrouverClasseHero(Hero hero)
        {
            Classe clone = new Classe();
            Classe classeHero = new Classe();
            bool echecConnexion = false;
            byte nombreEchec = 0;
            do
            {
                try
                {
                    using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                    {
                        if (contexte.Mondes.Any(x => x.Id == hero.MondeId))
                        {
                            classeHero = contexte.Classes.FirstOrDefault(x => x.Id == hero.ClasseId);
                            return classeHero;
                        }
                        else
                            LstErreursClasses.Add("Erreur dans la méthode \'TrouverClasseHero\' : Monde inexistant!");
                        echecConnexion = false;
                        return clone;
                    }
                }
                catch (Exception ex)
                {
                    echecConnexion = true;
                    nombreEchec++;
                    if (nombreEchec == byte.MaxValue)
                    {
                        echecConnexion = false;
                        LstErreursClasses.Add("Erreur dans la méthode \'TrouverClasseHero\' : " + ex.Message);
                    }
                }
            } while (echecConnexion);

            return clone;
        }
    }
}
