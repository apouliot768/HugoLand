using HugoLandEditeur.ViewModels;
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
        private int m_DefaultTile;
        private GestionMonde gMonde = new GestionMonde();

        // Width
        public int MapWidth
        {
            get { return m_Width; }
            set { m_Width = value; }
        }

        // Height
        public int MapHeight
        {
            get { return m_Height; }
            set { m_Height = value; }
        }

        // Default Tile
        public int DefaultTile
        {
            get { return m_DefaultTile; }
            set { m_DefaultTile = value; }
        }


        public frmNew()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            m_Width = 32;
            m_Height = 32;

            // Add tile names to combobox when the window is initialized
            CTileLibrary cTile = new CTileLibrary();
            cboDefaultTile.Items.Add("No tile");

            foreach (Tile t in cTile.ObjMonde.Values)
                cboDefaultTile.Items.Add(cTile.TileToTileID(t.X_Image, t.Y_Image) + "-" + t.Name);
        }

        #region Validations
        /// <summary>
        /// Auteur : ???
        /// Updated by : Joëlle Boyer
        /// Description : Validate what is written in the "Width" and "Height" fields.
        /// Last updated : 2019/10/31
        /// </summary>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <returns></returns>
        private bool ValidateInputHW(ref int nWidth, ref int nHeight)
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
        /// Auteure : Joëlle Boyer 
        /// Description : Validate the fields that are not related to limits x and y of the new world.
        /// Date : 2019/11/03
        /// </summary>
        /// <param name="desc"> Description/Name of the new world </param>
        /// <param name="size"> Size of the tiles of the world </param>
        /// <param name="pathCsv"> Path to the *.csv file </param>
        /// <param name="pathBmp"> Path to the *.bmp file </param>
        /// <param name="defaultTile"> What is the default tile of the world? </param>
        /// <returns></returns>
        private bool ValidateInput(string desc, int size, string pathCsv, string pathBmp, int defaultTile)
        {
            string csv = "", bmp = "";

            if (!string.IsNullOrWhiteSpace(pathCsv))
                csv = pathCsv.Substring(pathCsv.LastIndexOf('.'));
            if (!string.IsNullOrWhiteSpace(pathBmp))
                bmp = pathBmp.Substring(pathBmp.LastIndexOf('.'));

            if (string.IsNullOrWhiteSpace(desc) || gMonde.LstMondes.Any(x => x.Description == desc))
                return false;
            if (size <= 0 || size > 3200)
                return false;
            if (csv != ".csv")
                return false;
            if (bmp != ".bmp")
                return false;
            if (defaultTile == -1) // If no default tile is chosen, set it at "Grass"
                m_DefaultTile = 32;

            return true;
        }
        #endregion

        #region When an update occurs
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
            ValidateInputHW(ref valW, ref valH);

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

        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : Allows the user to select a .csv file from his computer
        /// Date : 2019/11/03
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeCsv_Click(object sender, EventArgs e)
        {
            DialogResult result;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Find (*.csv) file";
            ofd.Filter = "Csv File (*.csv)|*.csv";

            result = ofd.ShowDialog();
            if (result == DialogResult.OK)
                txtPathCsv.Text = ofd.FileName;
            else
                txtPathCsv.Text = "";
        }

        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : Allows the user to select a .bmp file from his computer
        /// Date : 2019/11/03
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeBmp_Click(object sender, EventArgs e)
        {
            DialogResult result;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Find (*.bmp) file";
            ofd.Filter = "Bmp File (*.bmp)|*.bmp";

            result = ofd.ShowDialog();
            if (result == DialogResult.OK)
                txtPathBmp.Text = ofd.FileName;
            else
                txtPathBmp.Text = "";
        }

        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : Changes the id of the selected tile and add it as the default tile.
        /// Date : 2019/11/03
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDefaultTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            CTileLibrary cTile = new CTileLibrary();
            Tile t;
            string myItem = cboDefaultTile.SelectedItem.ToString();

            if (myItem == "No tile")
                m_DefaultTile = -1;
            else
                myItem = myItem.Substring(myItem.IndexOf('-')).Replace("-", "");
            
            if (myItem != "No tile")
            {
                t = cTile.ObjMonde.FirstOrDefault(x => x.Value.Name == myItem).Value;
                m_DefaultTile = cTile.TileToTileID(t.X_Image, t.Y_Image);
            }
        }
        #endregion

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
            bool validHW = false, valid = false;
            string pathCsv = txtPathCsv.Text;
            string pathBmp = txtPathBmp.Text;
            int defaultTile = m_DefaultTile;
            string desc = txtDescription.Text;
            int size = -1;
            int.TryParse(txtSizeTile.Text, out size);

            // Validate input of fields Height and Width
            if (ValidateInputHW(ref width, ref height))
            {
                m_Width = width;
                m_Height = height;
                validHW = true;
            }

            // Validate input of fields other than Height and Width
            if (ValidateInput(desc, size, pathCsv, pathBmp, defaultTile))
            {
                valid = true;
            }

            // If both are valid, create a world with the parameters entered.
            if (validHW && valid)
            {
                Monde m = new Monde()
                {
                    Description = desc,
                    DefaultTile = defaultTile,
                    LimiteX = m_Width,
                    LimiteY = m_Height,
                    PathCsv = pathCsv,
                    PathTile = pathBmp,
                    SizeTile = size
                };

                gMonde.CréerMonde(m);
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
    }
}
