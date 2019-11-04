namespace HugoLandEditeur.Presentation
{
    partial class frmOpen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.cboChoose = new System.Windows.Forms.ComboBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblChooseWorld = new System.Windows.Forms.Label();
            this.chkNoFile = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboChoose
            // 
            this.cboChoose.FormattingEnabled = true;
            this.cboChoose.Location = new System.Drawing.Point(36, 39);
            this.cboChoose.Name = "cboChoose";
            this.cboChoose.Size = new System.Drawing.Size(330, 24);
            this.cboChoose.TabIndex = 3;
            this.cboChoose.SelectedIndexChanged += new System.EventHandler(this.cboChoose_SelectedIndexChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.BackColor = System.Drawing.Color.Transparent;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblWidth.ForeColor = System.Drawing.Color.Red;
            this.lblWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWidth.Location = new System.Drawing.Point(32, 104);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(69, 20);
            this.lblWidth.TabIndex = 4;
            this.lblWidth.Text = "Width :";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.BackColor = System.Drawing.Color.Transparent;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeight.ForeColor = System.Drawing.Color.Red;
            this.lblHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeight.Location = new System.Drawing.Point(32, 153);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(76, 20);
            this.lblHeight.TabIndex = 5;
            this.lblHeight.Text = "Height :";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(125, 104);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(113, 22);
            this.txtWidth.TabIndex = 7;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(125, 153);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(113, 22);
            this.txtHeight.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(277, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(182, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblChooseWorld
            // 
            this.lblChooseWorld.AutoSize = true;
            this.lblChooseWorld.BackColor = System.Drawing.Color.Transparent;
            this.lblChooseWorld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblChooseWorld.ForeColor = System.Drawing.Color.Red;
            this.lblChooseWorld.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblChooseWorld.Location = new System.Drawing.Point(9, 9);
            this.lblChooseWorld.Name = "lblChooseWorld";
            this.lblChooseWorld.Size = new System.Drawing.Size(151, 20);
            this.lblChooseWorld.TabIndex = 16;
            this.lblChooseWorld.Text = "Choose a world :";
            this.lblChooseWorld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNoFile
            // 
            this.chkNoFile.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chkNoFile.AutoSize = true;
            this.chkNoFile.BackColor = System.Drawing.Color.Transparent;
            this.chkNoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.chkNoFile.ForeColor = System.Drawing.Color.Red;
            this.chkNoFile.Location = new System.Drawing.Point(36, 218);
            this.chkNoFile.Name = "chkNoFile";
            this.chkNoFile.Size = new System.Drawing.Size(376, 80);
            this.chkNoFile.TabIndex = 17;
            this.chkNoFile.Text = "If you do not have a (*.map) file \r\nfor the chosen world, \r\ncheck this box";
            this.chkNoFile.UseVisualStyleBackColor = false;
            this.chkNoFile.CheckedChanged += new System.EventHandler(this.chkNoFile_CheckedChanged);
            // 
            // frmOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HugoLandEditeur.Properties.Resources.OpenWorld;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(381, 375);
            this.Controls.Add(this.chkNoFile);
            this.Controls.Add(this.lblChooseWorld);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.cboChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOpen";
            this.Text = "Open an existing world";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboChoose;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblChooseWorld;
        private System.Windows.Forms.CheckBox chkNoFile;
    }
}