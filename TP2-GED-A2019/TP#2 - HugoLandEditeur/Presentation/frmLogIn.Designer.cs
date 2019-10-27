namespace HugoLandEditeur.Presentation
{
    partial class frmLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.lblTitre1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomJoueur = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.lblEchec = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitre1
            // 
            this.lblTitre1.AutoSize = true;
            this.lblTitre1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitre1.Font = new System.Drawing.Font("Diablo", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre1.ForeColor = System.Drawing.Color.Red;
            this.lblTitre1.Location = new System.Drawing.Point(209, 120);
            this.lblTitre1.Name = "lblTitre1";
            this.lblTitre1.Size = new System.Drawing.Size(270, 43);
            this.lblTitre1.TabIndex = 0;
            this.lblTitre1.Text = "Hugo Land";
            this.lblTitre1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Diablo", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(230, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(307, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sign in";
            // 
            // txtNomJoueur
            // 
            this.txtNomJoueur.BackColor = System.Drawing.Color.LightGray;
            this.txtNomJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomJoueur.Location = new System.Drawing.Point(159, 285);
            this.txtNomJoueur.Name = "txtNomJoueur";
            this.txtNomJoueur.Size = new System.Drawing.Size(367, 30);
            this.txtNomJoueur.TabIndex = 3;
            this.txtNomJoueur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.BackColor = System.Drawing.Color.LightGray;
            this.txtMotDePasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotDePasse.Location = new System.Drawing.Point(159, 343);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(367, 30);
            this.txtMotDePasse.TabIndex = 4;
            this.txtMotDePasse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnexion
            // 
            this.btnConnexion.Location = new System.Drawing.Point(282, 391);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(110, 23);
            this.btnConnexion.TabIndex = 5;
            this.btnConnexion.Text = "Connect";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.BackColor = System.Drawing.Color.Transparent;
            this.lblNom.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.ForeColor = System.Drawing.Color.Red;
            this.lblNom.Location = new System.Drawing.Point(279, 263);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(113, 19);
            this.lblNom.TabIndex = 6;
            this.lblNom.Text = "Player name :";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.BackColor = System.Drawing.Color.Transparent;
            this.lblMotDePasse.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotDePasse.ForeColor = System.Drawing.Color.Red;
            this.lblMotDePasse.Location = new System.Drawing.Point(292, 321);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(93, 19);
            this.lblMotDePasse.TabIndex = 7;
            this.lblMotDePasse.Text = "Password :";
            // 
            // lblEchec
            // 
            this.lblEchec.AutoSize = true;
            this.lblEchec.BackColor = System.Drawing.Color.Transparent;
            this.lblEchec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEchec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblEchec.Location = new System.Drawing.Point(176, 226);
            this.lblEchec.Name = "lblEchec";
            this.lblEchec.Size = new System.Drawing.Size(0, 29);
            this.lblEchec.TabIndex = 8;
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(656, 445);
            this.Controls.Add(this.lblEchec);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtNomJoueur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitre1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogIn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editeur Hugo Land : Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomJoueur;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.Label lblEchec;
    }
}