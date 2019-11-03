namespace HugoLandEditeur
{
    partial class frmNew
    {
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNew));
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInfos = new System.Windows.Forms.Label();
            this.txtGScreenH = new System.Windows.Forms.TextBox();
            this.txtGScreenW = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtAllGameScreen = new System.Windows.Forms.TextBox();
            this.txtAllGameTiles = new System.Windows.Forms.TextBox();
            this.lblTiles = new System.Windows.Forms.Label();
            this.lblGameScreens = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDefaultTile = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSizeTile = new System.Windows.Forms.TextBox();
            this.lblSizeTile = new System.Windows.Forms.Label();
            this.cboDefaultTile = new System.Windows.Forms.ComboBox();
            this.lblPathCsv = new System.Windows.Forms.Label();
            this.lblPathTile = new System.Windows.Forms.Label();
            this.txtPathCsv = new System.Windows.Forms.TextBox();
            this.txtPathBmp = new System.Windows.Forms.TextBox();
            this.btnChangeCsv = new System.Windows.Forms.Button();
            this.btnChangeBmp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(12, 310);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(125, 20);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width :";
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(12, 338);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(125, 20);
            this.lblHeight.TabIndex = 1;
            this.lblHeight.Text = "Height :";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(237, 307);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(120, 22);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "32";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(237, 335);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(120, 22);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "32";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(129, 473);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 473);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInfos
            // 
            this.lblInfos.AutoSize = true;
            this.lblInfos.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblInfos.Location = new System.Drawing.Point(62, 402);
            this.lblInfos.Name = "lblInfos";
            this.lblInfos.Size = new System.Drawing.Size(418, 68);
            this.lblInfos.TabIndex = 6;
            this.lblInfos.Text = resources.GetString("lblInfos.Text");
            this.lblInfos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGScreenH
            // 
            this.txtGScreenH.Location = new System.Drawing.Point(380, 335);
            this.txtGScreenH.Name = "txtGScreenH";
            this.txtGScreenH.ReadOnly = true;
            this.txtGScreenH.Size = new System.Drawing.Size(66, 22);
            this.txtGScreenH.TabIndex = 8;
            this.txtGScreenH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGScreenW
            // 
            this.txtGScreenW.Location = new System.Drawing.Point(380, 307);
            this.txtGScreenW.Name = "txtGScreenW";
            this.txtGScreenW.ReadOnly = true;
            this.txtGScreenW.Size = new System.Drawing.Size(66, 22);
            this.txtGScreenW.TabIndex = 7;
            this.txtGScreenW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(12, 366);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(125, 20);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total number of : ";
            // 
            // txtAllGameScreen
            // 
            this.txtAllGameScreen.Location = new System.Drawing.Point(380, 363);
            this.txtAllGameScreen.Name = "txtAllGameScreen";
            this.txtAllGameScreen.ReadOnly = true;
            this.txtAllGameScreen.Size = new System.Drawing.Size(66, 22);
            this.txtAllGameScreen.TabIndex = 10;
            this.txtAllGameScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAllGameTiles
            // 
            this.txtAllGameTiles.Location = new System.Drawing.Point(237, 363);
            this.txtAllGameTiles.Name = "txtAllGameTiles";
            this.txtAllGameTiles.ReadOnly = true;
            this.txtAllGameTiles.Size = new System.Drawing.Size(120, 22);
            this.txtAllGameTiles.TabIndex = 11;
            this.txtAllGameTiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTiles
            // 
            this.lblTiles.Location = new System.Drawing.Point(237, 275);
            this.lblTiles.Name = "lblTiles";
            this.lblTiles.Size = new System.Drawing.Size(120, 20);
            this.lblTiles.TabIndex = 12;
            this.lblTiles.Text = "Tiles :";
            this.lblTiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameScreens
            // 
            this.lblGameScreens.Location = new System.Drawing.Point(380, 266);
            this.lblGameScreens.Name = "lblGameScreens";
            this.lblGameScreens.Size = new System.Drawing.Size(66, 38);
            this.lblGameScreens.TabIndex = 13;
            this.lblGameScreens.Text = "Game screens :";
            this.lblGameScreens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(91, 17);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description : ";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefaultTile
            // 
            this.lblDefaultTile.AutoSize = true;
            this.lblDefaultTile.Location = new System.Drawing.Point(12, 40);
            this.lblDefaultTile.Name = "lblDefaultTile";
            this.lblDefaultTile.Size = new System.Drawing.Size(92, 17);
            this.lblDefaultTile.TabIndex = 15;
            this.lblDefaultTile.Text = "Default Tile : ";
            this.lblDefaultTile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(108, 8);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(338, 22);
            this.txtDescription.TabIndex = 16;
            // 
            // txtSizeTile
            // 
            this.txtSizeTile.Location = new System.Drawing.Point(326, 228);
            this.txtSizeTile.Name = "txtSizeTile";
            this.txtSizeTile.Size = new System.Drawing.Size(120, 22);
            this.txtSizeTile.TabIndex = 18;
            this.txtSizeTile.Text = "64";
            this.txtSizeTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSizeTile
            // 
            this.lblSizeTile.Location = new System.Drawing.Point(12, 231);
            this.lblSizeTile.Name = "lblSizeTile";
            this.lblSizeTile.Size = new System.Drawing.Size(125, 20);
            this.lblSizeTile.TabIndex = 17;
            this.lblSizeTile.Text = "Size of tiles :";
            // 
            // cboDefaultTile
            // 
            this.cboDefaultTile.FormattingEnabled = true;
            this.cboDefaultTile.Location = new System.Drawing.Point(108, 39);
            this.cboDefaultTile.Name = "cboDefaultTile";
            this.cboDefaultTile.Size = new System.Drawing.Size(338, 24);
            this.cboDefaultTile.TabIndex = 19;
            this.cboDefaultTile.SelectedIndexChanged += new System.EventHandler(this.cboDefaultTile_SelectedIndexChanged);
            // 
            // lblPathCsv
            // 
            this.lblPathCsv.AutoSize = true;
            this.lblPathCsv.Location = new System.Drawing.Point(12, 86);
            this.lblPathCsv.Name = "lblPathCsv";
            this.lblPathCsv.Size = new System.Drawing.Size(131, 17);
            this.lblPathCsv.TabIndex = 20;
            this.lblPathCsv.Text = "Path of (*.csv) file : ";
            this.lblPathCsv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPathTile
            // 
            this.lblPathTile.AutoSize = true;
            this.lblPathTile.Location = new System.Drawing.Point(12, 161);
            this.lblPathTile.Name = "lblPathTile";
            this.lblPathTile.Size = new System.Drawing.Size(137, 17);
            this.lblPathTile.TabIndex = 21;
            this.lblPathTile.Text = "Path of (*.bmp) file : ";
            this.lblPathTile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPathCsv
            // 
            this.txtPathCsv.Location = new System.Drawing.Point(147, 86);
            this.txtPathCsv.Name = "txtPathCsv";
            this.txtPathCsv.ReadOnly = true;
            this.txtPathCsv.Size = new System.Drawing.Size(299, 22);
            this.txtPathCsv.TabIndex = 22;
            // 
            // txtPathBmp
            // 
            this.txtPathBmp.Location = new System.Drawing.Point(147, 156);
            this.txtPathBmp.Name = "txtPathBmp";
            this.txtPathBmp.ReadOnly = true;
            this.txtPathBmp.Size = new System.Drawing.Size(299, 22);
            this.txtPathBmp.TabIndex = 23;
            // 
            // btnChangeCsv
            // 
            this.btnChangeCsv.Location = new System.Drawing.Point(320, 114);
            this.btnChangeCsv.Name = "btnChangeCsv";
            this.btnChangeCsv.Size = new System.Drawing.Size(126, 29);
            this.btnChangeCsv.TabIndex = 24;
            this.btnChangeCsv.Text = "Change csv...";
            this.btnChangeCsv.UseVisualStyleBackColor = true;
            this.btnChangeCsv.Click += new System.EventHandler(this.btnChangeCsv_Click);
            // 
            // btnChangeBmp
            // 
            this.btnChangeBmp.Location = new System.Drawing.Point(320, 184);
            this.btnChangeBmp.Name = "btnChangeBmp";
            this.btnChangeBmp.Size = new System.Drawing.Size(126, 29);
            this.btnChangeBmp.TabIndex = 25;
            this.btnChangeBmp.Text = "Change bmp...";
            this.btnChangeBmp.UseVisualStyleBackColor = true;
            this.btnChangeBmp.Click += new System.EventHandler(this.btnChangeBmp_Click);
            // 
            // frmNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 507);
            this.Controls.Add(this.btnChangeBmp);
            this.Controls.Add(this.btnChangeCsv);
            this.Controls.Add(this.txtPathBmp);
            this.Controls.Add(this.txtPathCsv);
            this.Controls.Add(this.lblPathTile);
            this.Controls.Add(this.lblPathCsv);
            this.Controls.Add(this.cboDefaultTile);
            this.Controls.Add(this.txtSizeTile);
            this.Controls.Add(this.lblSizeTile);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDefaultTile);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblGameScreens);
            this.Controls.Add(this.lblTiles);
            this.Controls.Add(this.txtAllGameTiles);
            this.Controls.Add(this.txtAllGameScreen);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtGScreenH);
            this.Controls.Add(this.txtGScreenW);
            this.Controls.Add(this.lblInfos);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create a new map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblInfos;
        private System.Windows.Forms.TextBox txtGScreenH;
        private System.Windows.Forms.TextBox txtGScreenW;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtAllGameScreen;
        private System.Windows.Forms.TextBox txtAllGameTiles;
        private System.Windows.Forms.Label lblTiles;
        private System.Windows.Forms.Label lblGameScreens;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDefaultTile;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSizeTile;
        private System.Windows.Forms.Label lblSizeTile;
        private System.Windows.Forms.ComboBox cboDefaultTile;
        private System.Windows.Forms.Label lblPathCsv;
        private System.Windows.Forms.Label lblPathTile;
        private System.Windows.Forms.TextBox txtPathCsv;
        private System.Windows.Forms.TextBox txtPathBmp;
        private System.Windows.Forms.Button btnChangeCsv;
        private System.Windows.Forms.Button btnChangeBmp;
    }
}