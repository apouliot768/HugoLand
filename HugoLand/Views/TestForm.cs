﻿using HugoLand.Models;
using HugoLand.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoLand
{
    /// <summary>
    /// Auteurs:        Alexandre Pouliot et Joëlle Boyer
    /// Description:    Formulaire pour tester les fonctions 
    ///                 (TO DO: Valider l'utilité avec Joëlle, car des tests unitaires feraient aussi le travail.)
    /// Date:           2019-10-01
    /// </summary>
    public partial class TestForm : Form
    {
        private EntitiesGEDEquipe1 contextEF = new EntitiesGEDEquipe1();

        public TestForm()
        {
            InitializeComponent();
        }


        private void BtnObjetMonde_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionMonde gestionMonde = new GestionMonde();

            GestionObjetMonde gestionObjetMonde = new GestionObjetMonde();

            Monde monde = gestionMonde.LstMondes.Last();

            ObjetMonde objMonde = new ObjetMonde
            {
                x = 2,
                y = 2,
                Description = "Objet test!",
                MondeId = monde.Id
            };

            txtTestes.Text += "Création ObjetMonde \r\n";
            gestionObjetMonde.CréerObjetMonde(objMonde);
            txtTestes.Text += objMonde.Description + "\r\n\r\n";

            txtTestes.Text += "Modification ObjetMonde \r\n";
            objMonde = gestionObjetMonde.ModifierObjetMonde(objMonde, "Nouvelle description");
            txtTestes.Text += objMonde.Description + "\r\n\r\n";

            txtTestes.Text += "Supression ObjetMonde \r\n";
            gestionObjetMonde.SupprimerObjetMonde(objMonde);
            txtTestes.Text += "Suppression réussie!";
        }

        private void BtnCompteJoueur_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            txtTestes.Text = "CompteJoueur";
        }

        private void BtnMonde_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionMonde gMonde = new GestionMonde();

            txtTestes.Text += "Test RetournerMondes: (Affiche les descriptions, limites X et limites Y des mondes)...\r\n";
            txtTestes.Text += "\r\n";
            AfficherInfoMondes(gMonde);

            txtTestes.Text += "\r\n";
            txtTestes.Text += "Test CréerMonde...\r\n";
            txtTestes.Text += "\r\n";

            Monde monde1 = new Monde()
            {
                Description = "test",
                PathTile = "test",
                PathCsv = "test",
                DefaultTile = 1,
                SizeTile = 1
            };

            gMonde.CréerMonde(monde1);
            AfficherInfoMondes(gMonde);

            txtTestes.Text += "\r\n";
            txtTestes.Text += "Test ModifierMonde...\r\n";
            txtTestes.Text += "\r\n";

            gMonde.ModifierMonde(gMonde.LstMondes.Last(), 2, 2, "Modification");
            AfficherInfoMondes(gMonde);

            txtTestes.Text += "\r\n";
            txtTestes.Text += "Test SuprimerMonde...\r\n";
            txtTestes.Text += "\r\n";

            gMonde.SupprimerMonde(gMonde.LstMondes.Last());
            AfficherInfoMondes(gMonde);
        }

        private void BtnClasse_Click(object sender, EventArgs e)
        {

            txtTestes.Clear();
            GestionMonde gestionMonde = new GestionMonde();
            GestionClasse gestionClasse = new GestionClasse();
            gestionClasse.RecevoirClassesMonde(gestionMonde.LstMondes.First().Id);

            txtTestes.Text += "Liste des classes du premier monde  de la base de données: \r\n";
            AfficherInfoClasses(gestionClasse);

            txtTestes.Text += "\r\nCréation d'une classe : \r\n";
            Classe classe = new Classe()
            {
                NomClasse = "test",
                Description = "test",
                StatBaseStr = 3,
                StatBaseDex = 3,
                StatBaseInt = 3,
                StatBaseVitalite = 3,
                MondeId = gestionMonde.LstMondes.First().Id                
            };
            classe = gestionClasse.CréerClasse(classe);
            AfficherInfoClasses(gestionClasse);

            txtTestes.Text += "\r\nModification d'une classe : \r\n";
            classe.NomClasse = "Test Modifier";

            classe = gestionClasse.ModifierClasse(classe);
            AfficherInfoClasses(gestionClasse);

            txtTestes.Text += "\r\nSuppression d'une classe : \r\n";
            classe = gestionClasse.SupprimerClasse(classe);

            if (classe.NomClasse == null)
                txtTestes.Text += "Supression réussie!\r\n";

            classe = gestionClasse.LstClasses.First();

            txtTestes.Text += "\r\nTrouver la classe d'un Hero : \r\n";

            Hero hero = new Hero();

            using (EntitiesGEDEquipe1 context = new EntitiesGEDEquipe1())
            {
                hero = context.Heros.FirstOrDefault(x => x.MondeId == classe.MondeId);
            }

            txtTestes.Text += "Numéro de classe du Hero : "+ hero.ClasseId.ToString() +" \r\n";

            classe = gestionClasse.TrouverClasseHero(hero);

            txtTestes.Text += "Numéro de classe et nom de classe du Hero : " + classe.Id.ToString() + ", " + classe.NomClasse + " \r\n";
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            txtTestes.Text = "Item";
        }

        private void BtnEffetItem_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            txtTestes.Text = "EffetItem";
        }

        private void BtnMonstre_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();

            GestionMonstre gMonstre = new GestionMonstre();
            Monstre monstre = new Monstre
            {
                Id = 11874,
                x = 8,
                y = 8,
                MondeId = 3114,
                Nom = "Test",
                Niveau = 17,
                StatPV = 18
            };

            // Création d'un monstre
            gMonstre.CréerMonstre(monstre);
            AfficherInfoMonstres(gMonstre);

            // Modification d'un monstre
            txtTestes.Text += "\r\nModification du monstre créé : \r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";
            gMonstre.ModifierMonstre(monstre, monstre.x, monstre.y, 3111, "Pompom", 1, 8, 8f, 12f, null);
            monstre = gMonstre.LstMonstres.Last();
            txtTestes.Text += "Info du monstre modifié : \r\n";
            txtTestes.Text += monstre.Id + " - " + monstre.x + " - " + monstre.y + " - " + monstre.MondeId + " - " + monstre.Niveau + " - " + monstre.Nom
                + " - " + monstre.StatPV + " - " + monstre.StatDmgMax + " - " + monstre.StatDmgMin + "\r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";

            // Suppression d'un monstre
            txtTestes.Text += "\r\nSuppression de monstre : \r\n";
            txtTestes.Text += "Compte avant : " + gMonstre.LstMonstres.Count() + "\r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";
            gMonstre.SupprimerMonstre(monstre);
            txtTestes.Text += "Compte après : " + gMonstre.LstMonstres.Count() + "\r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";
        }

        private void BtnHeros_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionHeros gHero = new GestionHeros();
            List<Hero> lstHeros = new List<Hero>();

            Hero hero = new Hero
            {
                Id = 11874,
                x = 8,
                y = 8,
                MondeId = 3114,
                NomHero = "Test",
                Niveau = 17,
                StatVitalite = 18,
                CompteJoueurId = 2091
            };

            // Création d'un monstre
            gHero.CréationHero(hero);
            AfficherInfoHeros(gHero);

            // Modification d'un monstre
            txtTestes.Text += "\r\nModification du héro créé : \r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";
            gHero.ModifierHero(hero, 11, 15487, hero.x, hero.y, 18, 17, 16, 15, 3111, false);
            hero = gHero.LstHeros.Last();
            txtTestes.Text += "Info du héro modifié : \r\n";
            txtTestes.Text += hero.Id + " - " + hero.x + " - " + hero.y + " - " + hero.MondeId + " - " + hero.Niveau + " - " + hero.Experience + " - " + hero.NomHero
                + " - " + hero.StatVitalite + " - " + hero.StatStr + " - " + hero.StatDex + " - " + hero.StatInt + " - " + hero.EstConnecte + "\r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";

            // Suppression d'un monstre
            txtTestes.Text += "\r\nSuppression de héro : \r\n";
            txtTestes.Text += "Compte avant : " + gHero.LstHeros.Count() + "\r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";
            gHero.SuppressionHero(hero);
            txtTestes.Text += "Compte après : " + gHero.LstHeros.Count() + "\r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";

            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                txtTestes.Text += "Retourner les héros pour le joueur 2091 : " + contexte.CompteJoueurs.First(x => x.Id == 2091).NomJoueur;
            }
            lstHeros = gHero.RetourHerosJoueur(2091);
            foreach (var h in lstHeros)
                txtTestes.Text += h.Id + " - " + h.NomHero + "\r\n";


            // Je considère le 200 x 200 comme un multiple de la taille d'une tile (SizeTile) et de la position du héro
            // Si le héro est à la position 8, peu importe en x ou y, la marge sera de 200/monde.SizeTile (si SizeTile = 32, marge = +/- 6.25)
                    // Donc dans le 200 x 200, le héros aura comme éléments se situant à 6 tuiles plus haut, plus bas, à gauche et à droite.
                    // Donc entre 8-6 et 8+6, entre 2 et 14 autant en x qu'en y.
            hero = gHero.LstHeros.Last();
            txtTestes.Text += "Tous les éléments dans un rayon de 200 x 200 : \r\n" +
                "Position du héro de base : " + hero.x + ", " + hero.y;
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                gHero.ÉlémentsRayon200x200(hero);
                txtTestes.Text += "\r\nLes héros : \r\n";
                foreach (var h in gHero.lstHero)
                    txtTestes.Text += h.Id + " : " + h.NomHero + " - " + h.x + ", " + h.y + "\r\n";
                txtTestes.Text += "Les monstres : \r\n";
                foreach (var h in gHero.lstMonstres)
                    txtTestes.Text += h.Id + " : " + h.Nom + " - " + h.x + ", " + h.y + "\r\n";
                txtTestes.Text += "Les items : \r\n";
                foreach (var h in gHero.lstItems)
                    txtTestes.Text += h.Id + " : " + h.Nom + " - " + h.x + ", " + h.y + "\r\n";
                txtTestes.Text += "Les objets du monde : \r\n";
                foreach (var h in gHero.lstObjmonde)
                    txtTestes.Text += h.Id + " : " + h.Description + " - " + h.x + ", " + h.y + "\r\n";
            }
        }



        public void AfficherInfoMondes(GestionMonde gMonde)
        {
            foreach (Monde monde in gMonde.LstMondes)
            {
                txtTestes.Text += monde.Description.ToString() + " " + monde.LimiteX.ToString() + " " + monde.LimiteY.ToString() + "\r\n";
            }
        }

        public void AfficherInfoClasses(GestionClasse gestionClasse)
        {
            foreach (Classe classe in gestionClasse.LstClasses)
            {
                txtTestes.Text += classe.Id.ToString() + " " + classe.NomClasse.ToString() + "\r\n";
            }
        }

        public void AfficherInfoMonstres(GestionMonstre gMonstre)
        {
            foreach (Monstre monstre in gMonstre.LstMonstres)
            {
                txtTestes.Text += monstre.Id.ToString() + " - " + monstre.Nom.ToString() + "\r\n";
            }
        }

        public void AfficherInfoHeros(GestionHeros gHeros)
        {
            foreach (Hero hero in gHeros.LstHeros)
            {
                txtTestes.Text += "Joueur : " + hero.CompteJoueurId + " | Héro : " + hero.Id.ToString() + " - " + hero.NomHero + "\r\n";
            }
        }
    }
}
