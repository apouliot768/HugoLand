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
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.DiabloHeavy.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.DiabloHeavy;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

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
