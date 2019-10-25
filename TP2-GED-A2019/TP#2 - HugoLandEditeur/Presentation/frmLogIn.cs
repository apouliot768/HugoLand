using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HugoLandEditeur.ViewModels;
using System.Drawing.Text;

namespace HugoLandEditeur.Presentation
{
    /// <summary>
    /// Auteur:         Alexandre Pouliot
    /// Description:    Formulaire de connexion à l'éditeur de jeu
    /// Date:           2019-10-24
    /// </summary>
    public partial class frmLogIn : Form
    {
        private GestionCompteJoueur _gestionCompteJoueur = new GestionCompteJoueur();
        public int Tentative { get; set; }
        public CompteJoueur Compte { get; set; }

        public frmLogIn()
        {
            InitializeComponent();
            txtMotDePasse.PasswordChar = '*';
        }

        // Valide la connexion de l'utilisateur et son statut d'administrateur
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            Compte = _gestionCompteJoueur.ConnexionCompteJoueur(txtNomJoueur.Text, txtMotDePasse.Text);
            if (Compte.Id > 0 && Compte.TypeUtilisateur == 1)
                DialogResult = DialogResult.OK;
            else
                lblEchec.Text = "Échec de connexion : Tentative " + ++Tentative;
        }
    }
}
