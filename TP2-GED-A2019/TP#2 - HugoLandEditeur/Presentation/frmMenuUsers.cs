using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HugoLandEditeur.Models;
using HugoLandEditeur.ViewModels;

namespace HugoLandEditeur.Presentation
{
    public partial class frmMenuUsers : Form
    {
        bool _loaded = false;
        public GestionCompteJoueur _gestionCompteJoueur = new GestionCompteJoueur();
        private int _lastMessageId = 0;
        public frmMenuUsers()
        {
            InitializeComponent();
            ShowUsers();
            LoadChatbox();
        }

        private void dtgUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dtgUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_loaded)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dtgUsers.Rows[e.RowIndex].Cells[2];
                if (cb.Value != null)
                {
                    // do stuff
                    dtgUsers.Invalidate();
                }
            }

        }

        private void dtgUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dtgUsers.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dtgUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
                string selected = dtgUsers.CurrentCell.Value.ToString();
                _gestionCompteJoueur.UpdateRole(dtgUsers.CurrentRow.Cells[0].Value.ToString(), selected);
            }
        }

        private void ShowUsers()
        {
            _gestionCompteJoueur.RafraichirComptes();
            for (int i = 0; i < _gestionCompteJoueur.LstComptes.Count; i++)
            {
                CompteJoueur compte = _gestionCompteJoueur.LstComptes[i];

                if (compte.Connexion == false)
                    dtgUsers.Rows.Add(compte.Id, compte.NomJoueur, Enum.GetName(typeof(Constantes.Role), compte.TypeUtilisateur), Properties.Resources.red);
                else
                    dtgUsers.Rows.Add(compte.Id, compte.NomJoueur, Enum.GetName(typeof(Constantes.Role), compte.TypeUtilisateur), Properties.Resources.green);
            }
            _loaded = true;
        }

        private void timRefreshUsers_Tick(object sender, EventArgs e)
        {
            if (_gestionCompteJoueur.CompareUsersList())
            {
                dtgUsers.Rows.Clear();
                ShowUsers();
            }
            LoadChatbox();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            _gestionCompteJoueur.PostOnChatEditor(_gestionCompteJoueur.CompteCourrant.Id, txtPost.Text);
            LoadChatbox();
        }

        private void LoadChatbox()
        {
            List<string> lstChatMessages = _gestionCompteJoueur.UpdateEditorChatBox(_lastMessageId);
            if (lstChatMessages.Any(x => x == "???ERROR???"))
            {
                txtChatbox.Text = "ERROR : Connexion failed!";
            }
            else
            {
                if (lstChatMessages.Count != 0)
                {
                    txtChatbox.Clear();
                    for (int i = lstChatMessages.Count - 1; i >= 0; i--)
                    {
                        txtChatbox.AppendText(lstChatMessages[i]);
                    }
                    _lastMessageId = _gestionCompteJoueur.GetLastEditorPostId();
                }
            }
        }
    }
}
