using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HugoLand.ViewModels;
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
        // Local variable
        private GestionCompteJoueur _gestionCompteJoueur = new GestionCompteJoueur();
        public int _tentative { get; set; }
        public HugoLand.CompteJoueur _compte { get; set; }

        // Constructor
        public frmLogIn()
        {
            InitializeComponent();
            txtMotDePasse.PasswordChar = '*';
            loadFont();
        }

        // Load special font style
        private void loadFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"..\..\Resources\DiabloLight.ttf");
            lblTitre1.Font = new Font(pfc.Families[0], lblTitre1.Font.Size);
            label1.Font = new Font(pfc.Families[0], label1.Font.Size, FontStyle.Underline);
        }

        // Validate user connection
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _compte = _gestionCompteJoueur.ConnexionCompteJoueur(txtNomJoueur.Text, txtMotDePasse.Text);
                if (_compte.Id > 0 && _compte.TypeUtilisateur == 0)
                    DialogResult = DialogResult.OK;
                else
                {
                    lblEchec.Text = "Connexion failed : attempt # " + ++_tentative;
                    txtMotDePasse.Clear();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception)
            {
                // Advice user that the editor can't connect to the server and close editor.
                Cursor.Current = Cursors.Default;
                DialogResult mboxEchecConntivité = MessageBox.Show("Can't connect to the database.\r\nCheck your connexion to the server and try again!", "Can't reach server!");
                if (mboxEchecConntivité == DialogResult.OK)
                    DialogResult = DialogResult.Cancel;
            }
        }
    }
}
