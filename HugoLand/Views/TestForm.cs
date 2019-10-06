using HugoLand.Models;
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

            txtTestes.Text += "Aupression ObjetMonde \r\n";
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

            gMonstre.CréerMonstre(monstre);
            AfficherInfoMonstres(gMonstre);

            txtTestes.Text += "\r\nModification du monstre créé : \r\n";
            gMonstre.ModifierMonstre(monstre, monstre.x, monstre.y, 3111, "Pompom", 1, 8, 8f,12f,null);
            AfficherInfoMonstres(gMonstre);
            monstre = gMonstre.LstMonstres.Last();

            txtTestes.Text += "Monstre modifié : \r\n";
            txtTestes.Text += monstre.Id + " - " + monstre.x + " - " + monstre.y + " - " + monstre.MondeId + " - " + monstre.Niveau + " - " + monstre.Nom
                + " - " + monstre.StatPV + " - " + monstre.StatDmgMax + " - " + monstre.StatDmgMin + "\r\n";

            txtTestes.Text += "\r\nSuppression de monstre : \r\n";
            txtTestes.Text += "Compte avant : " + gMonstre.LstMonstres.Count() + "\r\n";
            gMonstre.SupprimerMonstre(monstre);
            AfficherInfoMonstres(gMonstre);
            txtTestes.Text += "Compte après : " + gMonstre.LstMonstres.Count() + "\r\n";
        }

        private void BtnHeros_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
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
                txtTestes.Text += monstre.Nom.ToString() + "\r\n";
            }
        }
    }
}
