using HugoLand.Models;
using System;

namespace HugoLandEditeur.Presentation
{
    partial class frmMenuUsers
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgUsers = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Connexion = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTitleUsersMenu = new System.Windows.Forms.Label();
            this.lblEditRole = new System.Windows.Forms.Label();
            this.timRefreshUsers = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatbox = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgUsers
            // 
            this.dtgUsers.AllowUserToAddRows = false;
            this.dtgUsers.AllowUserToDeleteRows = false;
            this.dtgUsers.BackgroundColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.UserName,
            this.Role,
            this.Connexion});
            this.dtgUsers.Location = new System.Drawing.Point(12, 108);
            this.dtgUsers.Name = "dtgUsers";
            this.dtgUsers.RowHeadersVisible = false;
            this.dtgUsers.RowHeadersWidth = 51;
            this.dtgUsers.RowTemplate.Height = 24;
            this.dtgUsers.Size = new System.Drawing.Size(356, 296);
            this.dtgUsers.TabIndex = 0;
            this.dtgUsers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUsers_CellValueChanged);
            this.dtgUsers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgUsers_CurrentCellDirtyStateChanged);
            this.dtgUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgUsers_DataError);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // UserName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UserName.DefaultCellStyle = dataGridViewCellStyle2;
            this.UserName.HeaderText = "User name";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 125;
            // 
            // Role
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            this.Role.DefaultCellStyle = dataGridViewCellStyle3;
            this.Role.HeaderText = "Role";
            this.Role.Items.AddRange(new object[] {
            "Admin",
            "Player",
            "Default"});
            this.Role.MinimumWidth = 6;
            this.Role.Name = "Role";
            this.Role.Width = 60;
            // 
            // Connexion
            // 
            this.Connexion.HeaderText = "Connexion";
            this.Connexion.MinimumWidth = 6;
            this.Connexion.Name = "Connexion";
            this.Connexion.ReadOnly = true;
            this.Connexion.Width = 60;
            // 
            // lblTitleUsersMenu
            // 
            this.lblTitleUsersMenu.AutoSize = true;
            this.lblTitleUsersMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleUsersMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleUsersMenu.ForeColor = System.Drawing.Color.SeaShell;
            this.lblTitleUsersMenu.Location = new System.Drawing.Point(12, 22);
            this.lblTitleUsersMenu.Name = "lblTitleUsersMenu";
            this.lblTitleUsersMenu.Size = new System.Drawing.Size(210, 39);
            this.lblTitleUsersMenu.TabIndex = 1;
            this.lblTitleUsersMenu.Text = "Users menu";
            // 
            // lblEditRole
            // 
            this.lblEditRole.AutoSize = true;
            this.lblEditRole.BackColor = System.Drawing.Color.Transparent;
            this.lblEditRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditRole.ForeColor = System.Drawing.Color.SeaShell;
            this.lblEditRole.Location = new System.Drawing.Point(14, 61);
            this.lblEditRole.Name = "lblEditRole";
            this.lblEditRole.Size = new System.Drawing.Size(317, 17);
            this.lblEditRole.TabIndex = 2;
            this.lblEditRole.Text = "* You can edit users role from this window.";
            // 
            // timRefreshUsers
            // 
            this.timRefreshUsers.Enabled = true;
            this.timRefreshUsers.Interval = 5000;
            this.timRefreshUsers.Tick += new System.EventHandler(this.timRefreshUsers_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaShell;
            this.label1.Location = new System.Drawing.Point(12, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chatbox";
            // 
            // txtChatbox
            // 
            this.txtChatbox.Location = new System.Drawing.Point(12, 477);
            this.txtChatbox.Multiline = true;
            this.txtChatbox.Name = "txtChatbox";
            this.txtChatbox.ReadOnly = true;
            this.txtChatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatbox.Size = new System.Drawing.Size(356, 274);
            this.txtChatbox.TabIndex = 4;
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(12, 773);
            this.txtPost.Multiline = true;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(356, 53);
            this.txtPost.TabIndex = 5;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(147, 832);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 6;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // frmMenuUsers
            // 
            this.AcceptButton = this.btnPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HugoLandEditeur.Properties.Resources.UserMenu6;
            this.ClientSize = new System.Drawing.Size(421, 876);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.txtChatbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEditRole);
            this.Controls.Add(this.lblTitleUsersMenu);
            this.Controls.Add(this.dtgUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenuUsers";
            this.Text = "Users menu";
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Role;
        private System.Windows.Forms.DataGridViewImageColumn Connexion;
        private System.Windows.Forms.Label lblTitleUsersMenu;
        private System.Windows.Forms.Label lblEditRole;
        private System.Windows.Forms.Timer timRefreshUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatbox;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.Button btnPost;
    }
}