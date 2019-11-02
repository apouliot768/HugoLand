using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoLandEditeur
{
    public partial class frmNew : Form
    {
        private int m_Width;
        private int m_Height;

        public frmNew()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            m_Width = 32;
            m_Height = 32;
        }

        // Width
        public int MapWidth
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }

        // Height
        public int MapHeight
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }

        /// <summary>
        /// Auteur : ???
        /// Updated by : Joëlle Boyer
        /// Description : Allows the UI to be updated regularly.
        /// Last updated : 2019/10/31
        /// </summary>
        private void UpdateUI()
        {
            int valH = 0, valW = 0;
            string sTilesW = "", sTilesH = "";
            btnOK.Enabled = ValidateInput(ref valW, ref valH);

            // Calculate number of game screen on width
            if (valW % 8 == 0)
                sTilesW = (valW / 8).ToString();
            else
                sTilesW = "0";
            // Calculate number of game screen on height
            if (valH % 8 == 0)
                sTilesH = (valH / 8).ToString();
            else
                sTilesH = "0";
             
            // Calculate total of tiles and show the values
            if (sTilesW != "0" && sTilesH != "0")
            {
                txtAllGameTiles.Text = (valH * valW).ToString();
                txtAllGameScreen.Text = ((valH / 8) * (valW / 8)).ToString();
                txtGScreenH.Text = sTilesH;
                txtGScreenW.Text = sTilesW;
            }
            else
            {
                txtAllGameTiles.Text = "0";
                txtAllGameScreen.Text = "0";
                txtGScreenW.Text = sTilesH = "0";
                txtGScreenW.Text = sTilesW = "0";
            }
        }

        /// <summary>
        /// Auteur : ???
        /// Updated by : Joëlle Boyer
        /// Description : Validate what is written in the "Width" and "Height" fields.
        /// Last updated : 2019/10/31
        /// </summary>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <returns></returns>
        private bool ValidateInput(ref int nWidth, ref int nHeight)
        {
            string strValue = txtWidth.Text.Trim();
            int nValue = 0;

            // Verify that strValue != "";
            if (!string.IsNullOrWhiteSpace(strValue))
                nValue = Convert.ToInt32(strValue, 10);

            nWidth = nValue;
            nValue = 0;
            strValue = txtHeight.Text.Trim();

            // Verify that strValue != "";
            if (!string.IsNullOrWhiteSpace(strValue))
                nValue = Convert.ToInt32(strValue, 10);

            nHeight = nValue;

            // Validate Height
            if (nHeight % 8 != 0 || nHeight < 8 || nHeight > 64000)
                return false;

            // Validate Width
            if (nWidth % 8 != 0 || nWidth < 8 || nWidth > 64000)
                return false;

            return true;
        }

        /// <summary>
        /// Auteur : ???
        /// Description : Close this window if the informations are valid.
        /// Date : ??? 
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            int width = 0, height = 0;

            if (ValidateInput(ref width, ref height))
            {
                m_Width = width;
                m_Height = height;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Auteur : ???
        /// Description : Close this window and cancel the creation of a new world.
        /// Date : ??? 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Auteur : ???
        /// Description : When the text changes, update the UI.
        /// Date : ??? 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWidth_TextChanged(object sender, System.EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Auteur : ???
        /// Description : When the text changes, update the UI.
        /// Date : ??? 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeight_TextChanged(object sender, System.EventArgs e)
        {
            UpdateUI();
        }
    }
}
