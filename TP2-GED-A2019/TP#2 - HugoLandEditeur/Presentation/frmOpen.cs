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

namespace HugoLandEditeur.Presentation
{
    public partial class frmOpen : Form
    {
        // Local variables
        private GestionMonde _gMonde = new GestionMonde(); // Allowing to have infos from db.
        private Monde monde = new Monde();
        private bool noFile = false;

        public Monde MyWorld
        {
            get { return monde; }
            set { monde = value; }
        }

        public bool NoFile
        {
            get { return noFile; }
            set { noFile = value; }
        }



        /// <summary>
        ///  Auteure : Joëlle Boyer
        /// Description : Initialization of frmOpen and adding items in cboChoose.
        /// Date : 2019/11/02
        /// </summary>
        public frmOpen()
        {
            InitializeComponent();

            cboChoose.Items.Add("Browse from my maps...");

            foreach (Monde m in _gMonde.LstMondes)
                cboChoose.Items.Add(m.Description);
        }

        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : This event allows the informations to change according to the selected world
        /// Date : 2019/11/02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sDescription = cboChoose.Text;

            if (sDescription != "Browse from my maps...")
                monde = _gMonde.LstMondes.FirstOrDefault(x => x.Description == sDescription);

            txtHeight.Text = monde.LimiteY.ToString();
            txtWidth.Text = monde.LimiteX.ToString();
            btnOk.Enabled = true;
        }

        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : Validate the opening of the selected world.
        /// Date : 2019/11/02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboChoose.SelectedIndex == 0)
                monde = _gMonde.CréerMonde(monde);

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : Cancel the opening of the selected world.
        /// Date : 2019/11/02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chkNoFile_CheckedChanged(object sender, EventArgs e)
        {
            noFile = chkNoFile.Checked;
        }
    }
}
