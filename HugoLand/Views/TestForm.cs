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
        public TestForm()
        {
            InitializeComponent();
        }

        private void BtnObjetMonde_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            txtTestes.Text = "ObjetMonde";
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
            gMonde.RetournerMondes();

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
            // test SupprimerMonde temporaire
            txtTestes.Clear();
            GestionMonde gMonde = new GestionMonde();
            gMonde.RetournerMondes();
            gMonde.SupprimerMonde(gMonde.LstMondes.Last());

            txtTestes.Text = "Classe";
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
            txtTestes.Text = "Monstre";
        }

        private void BtnHeros_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            txtTestes.Text = "Hero";
        }

        public void AfficherInfoMondes(GestionMonde gMonde)
        {
            foreach (Monde monde in gMonde.LstMondes)
            {
                txtTestes.Text += monde.Description.ToString() + "\r\n";
            }
        }
    }
}
