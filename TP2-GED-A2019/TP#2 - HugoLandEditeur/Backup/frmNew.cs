using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WOEMapEditor
{
	/// <summary>
	/// Summary description for frmNew.
	/// </summary>
	public class frmNew : System.Windows.Forms.Form
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

		private int m_Width;
		private int m_Height;

		public frmNew()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.DialogResult = DialogResult.Cancel;
			m_Width = 32;
			m_Height = 32;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNew));
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblWidth
			// 
			this.lblWidth.Location = new System.Drawing.Point(8, 16);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(80, 23);
			this.lblWidth.TabIndex = 0;
			this.lblWidth.Text = "Width (tiles):";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(8, 40);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(72, 23);
			this.lblHeight.TabIndex = 1;
			this.lblHeight.Text = "Height (tiles):";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(103, 16);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.TabIndex = 2;
			this.txtWidth.Text = "32";
			this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(103, 40);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.TabIndex = 3;
			this.txtHeight.Text = "32";
			this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 80);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(112, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmNew
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(218, 120);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtHeight);
			this.Controls.Add(this.txtWidth);
			this.Controls.Add(this.lblHeight);
			this.Controls.Add(this.lblWidth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNew";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create New Map";
			this.ResumeLayout(false);

		}
		#endregion


		// Width
		public	int		MapWidth
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
		public	int		MapHeight
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


		private void UpdateUI()
		{
			int val1 = 0, val2 = 0;
			btnOK.Enabled = ValidateInput(ref val1, ref val2);
		}

		private bool ValidateInput(ref int nWidth, ref int nHeight)
		{			
			String strValue = txtWidth.Text.Trim();
			int nValue = Convert.ToInt32(strValue,10);
			nWidth = nValue;
			
			strValue = txtHeight.Text.Trim();
			nValue = Convert.ToInt32(strValue,10);
			nHeight = nValue;

			// Validate Height
			if (nHeight < 8 || nHeight > 64)
				return false;

			// Validate Width
			if (nWidth < 8 || nWidth > 64)
				return false;

			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			int width = 0, height = 0;

			if (ValidateInput(ref width,ref height))
			{
				m_Width = width;
				m_Height = height;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void txtWidth_TextChanged(object sender, System.EventArgs e)
		{			
			UpdateUI();
		}

		private void txtHeight_TextChanged(object sender, System.EventArgs e)
		{
			UpdateUI();
		}
	}
}
