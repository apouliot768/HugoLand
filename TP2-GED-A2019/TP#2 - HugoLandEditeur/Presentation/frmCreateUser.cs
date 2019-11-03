using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HugoLand.Models;
using HugoLand.ViewModels;

namespace HugoLandEditeur.Presentation
{
    public partial class frmCreateUser : Form
    {
        private GestionCompteJoueur _gestionCompteJoueur = new GestionCompteJoueur();
        private CompteCréation _compteCréation = new CompteCréation();
        public frmCreateUser()
        {
            InitializeComponent();
            loadFont();
            // Binding
            cmbRole.DataSource = Enum.GetValues(typeof(Constantes.Role));
            txtUserName.DataBindings.Add("Text", _compteCréation, "UserName", true);
            txtFirstName.DataBindings.Add("Text", _compteCréation, "FirstName", true);
            txtLastName.DataBindings.Add("Text", _compteCréation, "LastName", true);
            txtEmail.DataBindings.Add("Text", _compteCréation, "Email", true);
            cmbRole.DataBindings.Add("Text", _compteCréation, "Role", true);
            txtPassword.DataBindings.Add("Text", _compteCréation, "Password", true);
            txtConfirmPassword.DataBindings.Add("Text", _compteCréation, "PasswordConfirm", true);
        }

        private void loadFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"..\..\Resources\DiabloLight.ttf");
            lblTitle1.Font = new Font(pfc.Families[0], lblTitle1.Font.Size, FontStyle.Underline);
            lblTitleName.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
            lblFirstName.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
            lblLastName.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
            lblEmail.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
            lblRole.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
            lblPassword.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
            lblConfirmPassword.Font = new Font(pfc.Families[0], lblTitleName.Font.Size, FontStyle.Bold);
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {

            lblErrUserName.Text = "";

            lblErrFirstName.Text = "";

            lblErrLastName.Text = "";

            lblErrEmail.Text = "";

            lblErrRole.Text = "";

            lblErrPassword.Text = "";

            lblErrConfirmPassword.Text = "";

            Dictionary<string, string> dicErrors = _compteCréation.IsValid();
            foreach (var item in dicErrors)
            {
                switch (item.Value)
                {
                    case "UserName":
                        lblErrUserName.Text += "* " + item.Key;
                        break;
                    case "FirstName":
                        lblErrFirstName.Text += "* " + item.Key;
                        break;
                    case "LastName":
                        lblErrLastName.Text += "* " + item.Key;
                        break;
                    case "Email":
                        lblErrEmail.Text += "* " + item.Key;
                        break;
                    case "Role":
                        lblErrRole.Text += "* " + item.Key;
                        break;
                    case "Password":
                        lblErrPassword.Text += "* " + item.Key;
                        break;
                    case "PasswordConfirm":
                        lblErrConfirmPassword.Text += "* " + item.Key;
                        break;
                    default:
                        lblErrConfirmPassword.Text += "* " + item.Key;
                        break;
                }
            }

            if (dicErrors.Count == 0)
            {
                try
                {
                    string sCreationState = _gestionCompteJoueur.CréerCompteJoueur(_compteCréation.UserName, _compteCréation.Email, _compteCréation.FirstName, _compteCréation.LastName, (int)_compteCréation.Role, _compteCréation.Password);
                    DialogResult mboxCreation = MessageBox.Show("Creation state is :\r\n\r\n" + sCreationState, "Creation result");
                    if (mboxCreation == DialogResult.OK)
                        DialogResult = DialogResult.OK;
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to create a new user.\r\n\r\nPlease try again or restart the game editor.", "Creation failed!");
                }
            }
        }
    }
}
