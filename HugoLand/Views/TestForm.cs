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
            txtTestes.Text = "Monde";
        }

        private void BtnClasse_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
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
    }
}
