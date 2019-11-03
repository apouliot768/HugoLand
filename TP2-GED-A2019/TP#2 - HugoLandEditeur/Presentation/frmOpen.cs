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

namespace HugoLandEditeur.Presentation
{
    public partial class frmOpen : Form
    {
        // Local variables
        private GestionMonde _gMonde = new GestionMonde(); // Allowing to have infos from db.

        /// <summary>
        ///  Auteure : Joëlle Boyer
        /// Description : Initialization of frmOpen and adding items in cboChoose.
        /// Date : 2019/11/02
        /// </summary>
        public frmOpen()
        {
            InitializeComponent();

            foreach (HugoLand.Monde m in _gMonde.LstMondes)
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

            HugoLand.Monde m = _gMonde.LstMondes.FirstOrDefault(x => x.Description == sDescription);

            txtHeight.Text = m.LimiteY.ToString();
            txtWidth.Text = m.LimiteX.ToString();
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
    }
}
