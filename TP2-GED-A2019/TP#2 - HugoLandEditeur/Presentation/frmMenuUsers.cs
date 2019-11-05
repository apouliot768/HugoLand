using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HugoLand.Models;
using HugoLand.ViewModels;

namespace HugoLandEditeur.Presentation
{
    /// <summary>
    /// Author :        Alexandre Pouliot
    /// Description :   Nice tool form that allows user to administrtate role
    ///                 to others users, know who works on the editor and 
    ///                 chat with them.
    /// Date :          2019-11-04
    /// </summary>
    public partial class frmMenuUsers : Form
    {
        // Local variables
        bool _loaded = false;
        public GestionCompteJoueur _gestionCompteJoueur = new GestionCompteJoueur();
        private GestionChatMessage _gestionChatMessage = new GestionChatMessage();
        private int _lastMessageId = 0;

        // Constructor
        public frmMenuUsers()
        {
            InitializeComponent();
            ShowUsers();
            LoadChatbox();
        }

        // Handle the useless error messagebox created by microsoft that spam for nothing.
        private void dtgUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        // Handle changes on role's combobox
        private void dtgUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_loaded)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dtgUsers.Rows[e.RowIndex].Cells[2];
                if (cb.Value != null)
                {
                    dtgUsers.Invalidate();
                }
            }

        }

        // Commit changes on role's combobox
        private void dtgUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dtgUsers.IsCurrentCellDirty)
            {
                dtgUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string selected = dtgUsers.CurrentCell.Value.ToString();
                _gestionCompteJoueur.UpdateRole(dtgUsers.CurrentRow.Cells[0].Value.ToString(), selected);
            }
        }

        // Load users list
        private void ShowUsers()
        {
            _gestionCompteJoueur.RafraichirComptes();
            for (int i = 0; i < _gestionCompteJoueur.LstComptes.Count; i++)
            {
                HugoLand.CompteJoueur compte = _gestionCompteJoueur.LstComptes[i];

                if (compte.Connexion == false)
                    dtgUsers.Rows.Add(compte.Id, compte.NomJoueur, Enum.GetName(typeof(Constantes.Role), compte.TypeUtilisateur), Properties.Resources.red);
                else
                    dtgUsers.Rows.Add(compte.Id, compte.NomJoueur, Enum.GetName(typeof(Constantes.Role), compte.TypeUtilisateur), Properties.Resources.green);
            }
            _loaded = true;
        }

        // Refrech the users list and chatbox every 5 seconds when new changes are commited on database
        private void timRefreshUsers_Tick(object sender, EventArgs e)
        {
            if (_gestionCompteJoueur.CompareUsersList()) // Check if refresh needed
            {
                dtgUsers.Rows.Clear();
                ShowUsers();
            }
            LoadChatbox();
        }

        // Post new message on common chatbox
        private void btnPost_Click(object sender, EventArgs e)
        {
            _gestionChatMessage.PostOnChatEditor(_gestionCompteJoueur.CompteCourrant.Id, txtPost.Text);
            LoadChatbox();
            txtPost.Clear();
        }

        // Load the 50 lasts post for the chatbox
        private void LoadChatbox()
        {
            List<string> lstChatMessages = _gestionChatMessage.UpdateEditorChatBox(_lastMessageId);
            if (lstChatMessages.Any(x => x == "???ERROR???"))
            {
                txtChatbox.Text = "ERROR : Connexion failed!";
            }
            else
            {
                if (lstChatMessages.Count != 0) // Check if refresh needed
                {
                    txtChatbox.Clear();
                    for (int i = lstChatMessages.Count - 1; i >= 0; i--)
                    {
                        txtChatbox.AppendText(lstChatMessages[i]);
                    }
                    _lastMessageId = _gestionChatMessage.GetLastEditorPostId();
                }
            }
        }
    }
}
