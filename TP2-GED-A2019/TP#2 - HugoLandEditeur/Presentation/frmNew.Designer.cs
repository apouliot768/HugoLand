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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGScreenH = new System.Windows.Forms.TextBox();
            this.txtGScreenW = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtAllGameScreen = new System.Windows.Forms.TextBox();
            this.txtAllGameTiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(12, 49);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(125, 20);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width :";
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(12, 77);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(125, 20);
            this.lblHeight.TabIndex = 1;
            this.lblHeight.Text = "Height :";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(196, 46);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(120, 22);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "32";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(196, 74);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(120, 22);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "32";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(118, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(214, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(30, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 68);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGScreenH
            // 
            this.txtGScreenH.Location = new System.Drawing.Point(339, 74);
            this.txtGScreenH.Name = "txtGScreenH";
            this.txtGScreenH.ReadOnly = true;
            this.txtGScreenH.Size = new System.Drawing.Size(66, 22);
            this.txtGScreenH.TabIndex = 8;
            this.txtGScreenH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGScreenW
            // 
            this.txtGScreenW.Location = new System.Drawing.Point(339, 46);
            this.txtGScreenW.Name = "txtGScreenW";
            this.txtGScreenW.ReadOnly = true;
            this.txtGScreenW.Size = new System.Drawing.Size(66, 22);
            this.txtGScreenW.TabIndex = 7;
            this.txtGScreenW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(12, 105);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(125, 20);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total number of : ";
            // 
            // txtAllGameScreen
            // 
            this.txtAllGameScreen.Location = new System.Drawing.Point(339, 102);
            this.txtAllGameScreen.Name = "txtAllGameScreen";
            this.txtAllGameScreen.ReadOnly = true;
            this.txtAllGameScreen.Size = new System.Drawing.Size(66, 22);
            this.txtAllGameScreen.TabIndex = 10;
            this.txtAllGameScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAllGameTiles
            // 
            this.txtAllGameTiles.Location = new System.Drawing.Point(196, 102);
            this.txtAllGameTiles.Name = "txtAllGameTiles";
            this.txtAllGameTiles.ReadOnly = true;
            this.txtAllGameTiles.Size = new System.Drawing.Size(120, 22);
            this.txtAllGameTiles.TabIndex = 11;
            this.txtAllGameTiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(196, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tiles :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(339, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 38);
            this.label3.TabIndex = 13;
            this.label3.Text = "Game screens :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 281);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAllGameTiles);
            this.Controls.Add(this.txtAllGameScreen);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtGScreenH);
            this.Controls.Add(this.txtGScreenW);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGScreenH;
        private System.Windows.Forms.TextBox txtGScreenW;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtAllGameScreen;
        private System.Windows.Forms.TextBox txtAllGameTiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}