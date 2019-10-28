using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WOEMapEditor
{
	/// <summary>
	/// Summary description for frmDebug.
	/// </summary>
	public class frmDebug : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtDebug;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDebug()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		public void AddLine(string newstring)
		{
			txtDebug.AppendText(newstring + Environment.NewLine);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDebug));
			this.txtDebug = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDebug
			// 
			this.txtDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDebug.Location = new System.Drawing.Point(0, 0);
			this.txtDebug.Multiline = true;
			this.txtDebug.Name = "txtDebug";
			this.txtDebug.Size = new System.Drawing.Size(292, 266);
			this.txtDebug.TabIndex = 0;
			this.txtDebug.Text = "textBox1";
			// 
			// frmDebug
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.txtDebug);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDebug";
			this.Text = "Debug Window";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion
	}
}
