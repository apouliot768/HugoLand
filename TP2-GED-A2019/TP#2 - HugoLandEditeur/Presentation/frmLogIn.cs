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
using System.Runtime.InteropServices;

namespace HugoLandEditeur.Presentation
{
    /// <summary>
    /// Auteur:         Alexandre Pouliot
    /// Description:    Formulaire de connexion à l'éditeur de jeu
    /// Date:           2019-10-24
    /// </summary>
    public partial class frmLogIn : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemRessourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv,
            [In] ref GraphicsUnit pcFonts);

        FontFamily ff;
        Font font;

        private GestionCompteJoueur _gestionCompteJoueur = new GestionCompteJoueur();
        public int Tentative { get; set; }
        public CompteJoueur Compte { get; set; }

        public frmLogIn()
        {
            InitializeComponent();
            txtMotDePasse.PasswordChar = '*';
            loadFont();
        }

        private void loadFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"..\..\Resources\DiabloHeavy.ttf");
            lblTitre1.Font = new Font(pfc.Families[0], lblTitre1.Font.Size);
            label1.Font = new Font(pfc.Families[0], label1.Font.Size, FontStyle.Underline);
        }

        // Valide la connexion de l'utilisateur et son statut d'administrateur
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            Compte = _gestionCompteJoueur.ConnexionCompteJoueur(txtNomJoueur.Text, txtMotDePasse.Text);
            if (Compte.Id > 0 && Compte.TypeUtilisateur == 0)
                DialogResult = DialogResult.OK;
            else
                lblEchec.Text = "Connexion failed : attempt # " + ++Tentative;
        }
    }
}
