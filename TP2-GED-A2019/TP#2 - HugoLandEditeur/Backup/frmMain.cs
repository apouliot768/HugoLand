using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace WOEMapEditor
{	
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 	

	public struct ComboItem
	{
		public string	Text;
		public int		Value;

		public ComboItem(string text, int val)
		{
			Text = text;
			Value = val;
		}
		public override string ToString()
		{			
			return Text;
		}
	};

	public class frmMain : System.Windows.Forms.Form
	{
		const int TILE_HEIGHT = 16;
		const int TILE_WIDTH = 16;
		const int BUFFER_WIDTH = 16;
		const int BUFFER_HEIGHT = 16;
		const int ZOOM = 4;

		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.PictureBox picEditArea;
		private System.Windows.Forms.MainMenu mbMain;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuFileExit;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.Windows.Forms.ToolBar tbMain;
		private System.Windows.Forms.Panel panelTools;
		private System.Windows.Forms.Panel panelTiles;
		private System.Windows.Forms.PictureBox picEditSel;
		private System.Windows.Forms.VScrollBar vscMap;
		private System.Windows.Forms.HScrollBar hscMap;
		private System.Windows.Forms.VScrollBar vscTiles;
		private System.Windows.Forms.PictureBox picTiles;
		private System.Windows.Forms.ImageList il16;
		private System.ComponentModel.IContainer components;

		private CMap						m_Map;
		private CTileLibrary				m_TileLibrary;
		//private bool						m_bDraw;
		private int							m_XSel;
		private int							m_YSel;
		private int							m_TilesHoriz;
		private System.Windows.Forms.Timer timer1;
		private int							m_TilesVert;
		private bool						m_bRefresh;
		private bool						m_bResize;
		private int							m_Zoom;
		private Rectangle					m_TileRect;
		private Rectangle					m_LibRect;
		private int							m_ActiveXIndex;
		private int							m_ActiveYIndex;
		private int							m_ActiveTileID;
		//private int							m_MouseoverTile;
		private int							m_ActiveTileXIndex;
		private int							m_ActiveTileYIndex;		
		private System.Windows.Forms.PictureBox picMap;
		private System.Windows.Forms.MenuItem mnuZoom;
		private System.Windows.Forms.MenuItem mnuZoomX1;
		private System.Windows.Forms.MenuItem mnuZoomX2;
		private System.Windows.Forms.MenuItem mnuZoomX4;
		private System.Windows.Forms.MenuItem mnuZoomX8;
		private System.Windows.Forms.MenuItem mnuZoomX16;
		private System.Windows.Forms.MenuItem mnuSettings;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbOpen;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ToolBarButton tbbSeperator1;
		private System.Windows.Forms.ToolBarButton tbbCut;
		private System.Windows.Forms.ToolBarButton tbbCopy;
		private System.Windows.Forms.ToolBarButton tbbPaste;
		private System.Windows.Forms.ToolBarButton tbbSeperator2;
		private System.Windows.Forms.ToolBarButton tbbHelp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuEditCut;
		private System.Windows.Forms.MenuItem mnuEditCopy;
		private System.Windows.Forms.MenuItem mnuEditPaste;
		private System.Windows.Forms.PictureBox picActiveTile;
		private System.Windows.Forms.Timer tmrLoad;
		private System.Windows.Forms.OpenFileDialog dlgLoadMap;
		private System.Windows.Forms.SaveFileDialog dlgSaveMap;
		private System.Windows.Forms.MenuItem mnuFileNew;
		private System.Windows.Forms.MenuItem mnuFileOpen;
		private System.Windows.Forms.MenuItem mnuFileClose;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuFileSaveAs;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuFileSave;

		private frmDebug					m_Debug;
		private bool						m_bOpen;
		private Pen							m_pen;
		private Brush						m_brush;
		private Brush						m_brush2;
		private bool						m_bRefreshLib;
		private bool						m_bDrawTileRect;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label lblZoom;
		private bool						m_bDrawMapRect;

		public frmMain()
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
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.picEditArea = new System.Windows.Forms.PictureBox();
			this.mbMain = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuFileNew = new System.Windows.Forms.MenuItem();
			this.mnuFileOpen = new System.Windows.Forms.MenuItem();
			this.mnuFileClose = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuFileSave = new System.Windows.Forms.MenuItem();
			this.mnuFileSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mnuFileExit = new System.Windows.Forms.MenuItem();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuEditCut = new System.Windows.Forms.MenuItem();
			this.mnuEditCopy = new System.Windows.Forms.MenuItem();
			this.mnuEditPaste = new System.Windows.Forms.MenuItem();
			this.mnuSettings = new System.Windows.Forms.MenuItem();
			this.mnuZoom = new System.Windows.Forms.MenuItem();
			this.mnuZoomX1 = new System.Windows.Forms.MenuItem();
			this.mnuZoomX2 = new System.Windows.Forms.MenuItem();
			this.mnuZoomX4 = new System.Windows.Forms.MenuItem();
			this.mnuZoomX8 = new System.Windows.Forms.MenuItem();
			this.mnuZoomX16 = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.tbMain = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbOpen = new System.Windows.Forms.ToolBarButton();
			this.tbbSave = new System.Windows.Forms.ToolBarButton();
			this.tbbSeperator1 = new System.Windows.Forms.ToolBarButton();
			this.tbbCut = new System.Windows.Forms.ToolBarButton();
			this.tbbCopy = new System.Windows.Forms.ToolBarButton();
			this.tbbPaste = new System.Windows.Forms.ToolBarButton();
			this.tbbSeperator2 = new System.Windows.Forms.ToolBarButton();
			this.tbbHelp = new System.Windows.Forms.ToolBarButton();
			this.il16 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.panelTools = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.picActiveTile = new System.Windows.Forms.PictureBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panelTiles = new System.Windows.Forms.Panel();
			this.picTiles = new System.Windows.Forms.PictureBox();
			this.vscTiles = new System.Windows.Forms.VScrollBar();
			this.picEditSel = new System.Windows.Forms.PictureBox();
			this.vscMap = new System.Windows.Forms.VScrollBar();
			this.hscMap = new System.Windows.Forms.HScrollBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.picMap = new System.Windows.Forms.PictureBox();
			this.tmrLoad = new System.Windows.Forms.Timer(this.components);
			this.dlgLoadMap = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveMap = new System.Windows.Forms.SaveFileDialog();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.lblZoom = new System.Windows.Forms.Label();
			this.panelTools.SuspendLayout();
			this.panelTiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// picEditArea
			// 
			this.picEditArea.BackColor = System.Drawing.Color.Gray;
			this.picEditArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picEditArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picEditArea.Location = new System.Drawing.Point(0, 0);
			this.picEditArea.Name = "picEditArea";
			this.picEditArea.Size = new System.Drawing.Size(640, 505);
			this.picEditArea.TabIndex = 0;
			this.picEditArea.TabStop = false;
			this.picEditArea.Resize += new System.EventHandler(this.picEditArea_Resize);
			// 
			// mbMain
			// 
			this.mbMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mnuFile,
																				   this.mnuEdit,
																				   this.mnuSettings,
																				   this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFileNew,
																					this.mnuFileOpen,
																					this.mnuFileClose,
																					this.menuItem4,
																					this.mnuFileSave,
																					this.mnuFileSaveAs,
																					this.menuItem6,
																					this.mnuFileExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuFileNew
			// 
			this.mnuFileNew.Index = 0;
			this.mnuFileNew.Text = "&New";
			this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
			// 
			// mnuFileOpen
			// 
			this.mnuFileOpen.Index = 1;
			this.mnuFileOpen.Text = "&Open";
			this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
			// 
			// mnuFileClose
			// 
			this.mnuFileClose.Index = 2;
			this.mnuFileClose.Text = "&Close";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// mnuFileSave
			// 
			this.mnuFileSave.Index = 4;
			this.mnuFileSave.Text = "&Save";
			this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
			// 
			// mnuFileSaveAs
			// 
			this.mnuFileSaveAs.Index = 5;
			this.mnuFileSaveAs.Text = "Save &As";
			this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 6;
			this.menuItem6.Text = "-";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Index = 7;
			this.mnuFileExit.Text = "E&xit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 1;
			this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuEditCut,
																					this.mnuEditCopy,
																					this.mnuEditPaste});
			this.mnuEdit.Text = "&Edit";
			// 
			// mnuEditCut
			// 
			this.mnuEditCut.Enabled = false;
			this.mnuEditCut.Index = 0;
			this.mnuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.mnuEditCut.Text = "Cu&t";
			// 
			// mnuEditCopy
			// 
			this.mnuEditCopy.Enabled = false;
			this.mnuEditCopy.Index = 1;
			this.mnuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.mnuEditCopy.Text = "&Copy";
			// 
			// mnuEditPaste
			// 
			this.mnuEditPaste.Enabled = false;
			this.mnuEditPaste.Index = 2;
			this.mnuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.mnuEditPaste.Text = "&Paste";
			// 
			// mnuSettings
			// 
			this.mnuSettings.Index = 2;
			this.mnuSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuZoom});
			this.mnuSettings.Text = "&Settings";
			this.mnuSettings.Visible = false;
			// 
			// mnuZoom
			// 
			this.mnuZoom.Index = 0;
			this.mnuZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuZoomX1,
																					this.mnuZoomX2,
																					this.mnuZoomX4,
																					this.mnuZoomX8,
																					this.mnuZoomX16});
			this.mnuZoom.Text = "&Zoom";
			// 
			// mnuZoomX1
			// 
			this.mnuZoomX1.Index = 0;
			this.mnuZoomX1.Text = "x 1";
			this.mnuZoomX1.Click += new System.EventHandler(this.mnuZoomX1_Click);
			// 
			// mnuZoomX2
			// 
			this.mnuZoomX2.Index = 1;
			this.mnuZoomX2.Text = "x 2";
			this.mnuZoomX2.Click += new System.EventHandler(this.mnuZoomX2_Click);
			// 
			// mnuZoomX4
			// 
			this.mnuZoomX4.Index = 2;
			this.mnuZoomX4.Text = "x 4";
			this.mnuZoomX4.Click += new System.EventHandler(this.mnuZoomX4_Click);
			// 
			// mnuZoomX8
			// 
			this.mnuZoomX8.Index = 3;
			this.mnuZoomX8.Text = "x 8";
			this.mnuZoomX8.Click += new System.EventHandler(this.mnuZoomX8_Click);
			// 
			// mnuZoomX16
			// 
			this.mnuZoomX16.Index = 4;
			this.mnuZoomX16.Text = "x 16";
			this.mnuZoomX16.Click += new System.EventHandler(this.mnuZoomX16_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 3;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuHelpAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "&About";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// tbMain
			// 
			this.tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					  this.tbbNew,
																					  this.tbbOpen,
																					  this.tbbSave,
																					  this.tbbSeperator1,
																					  this.tbbCut,
																					  this.tbbCopy,
																					  this.tbbPaste,
																					  this.tbbSeperator2,
																					  this.tbbHelp});
			this.tbMain.DropDownArrows = true;
			this.tbMain.ImageList = this.il16;
			this.tbMain.Location = new System.Drawing.Point(0, 0);
			this.tbMain.Name = "tbMain";
			this.tbMain.ShowToolTips = true;
			this.tbMain.Size = new System.Drawing.Size(640, 28);
			this.tbMain.TabIndex = 1;
			this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMain_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			// 
			// tbbOpen
			// 
			this.tbbOpen.ImageIndex = 1;
			// 
			// tbbSave
			// 
			this.tbbSave.ImageIndex = 2;
			// 
			// tbbSeperator1
			// 
			this.tbbSeperator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbCut
			// 
			this.tbbCut.Enabled = false;
			this.tbbCut.ImageIndex = 3;
			// 
			// tbbCopy
			// 
			this.tbbCopy.Enabled = false;
			this.tbbCopy.ImageIndex = 4;
			// 
			// tbbPaste
			// 
			this.tbbPaste.Enabled = false;
			this.tbbPaste.ImageIndex = 5;
			// 
			// tbbSeperator2
			// 
			this.tbbSeperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbHelp
			// 
			this.tbbHelp.ImageIndex = 6;
			// 
			// il16
			// 
			this.il16.ImageSize = new System.Drawing.Size(16, 16);
			this.il16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il16.ImageStream")));
			this.il16.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 483);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(640, 22);
			this.statusBar1.TabIndex = 2;
			this.statusBar1.Text = "sbMain";
			// 
			// panelTools
			// 
			this.panelTools.Controls.Add(this.button3);
			this.panelTools.Controls.Add(this.label1);
			this.panelTools.Controls.Add(this.picActiveTile);
			this.panelTools.Controls.Add(this.button2);
			this.panelTools.Controls.Add(this.button1);
			this.panelTools.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelTools.Location = new System.Drawing.Point(552, 28);
			this.panelTools.Name = "panelTools";
			this.panelTools.Size = new System.Drawing.Size(88, 455);
			this.panelTools.TabIndex = 3;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 192);
			this.button3.Name = "button3";
			this.button3.TabIndex = 4;
			this.button3.Text = "button3";
			this.button3.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Active Tile";
			// 
			// picActiveTile
			// 
			this.picActiveTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picActiveTile.Location = new System.Drawing.Point(8, 27);
			this.picActiveTile.Name = "picActiveTile";
			this.picActiveTile.Size = new System.Drawing.Size(64, 64);
			this.picActiveTile.TabIndex = 2;
			this.picActiveTile.TabStop = false;
			this.picActiveTile.Paint += new System.Windows.Forms.PaintEventHandler(this.picActiveTile_Paint);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(8, 344);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 56);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 280);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 56);
			this.button1.TabIndex = 0;
			this.button1.Text = "Load Map";
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panelTiles
			// 
			this.panelTiles.Controls.Add(this.picTiles);
			this.panelTiles.Controls.Add(this.vscTiles);
			this.panelTiles.Controls.Add(this.picEditSel);
			this.panelTiles.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelTiles.Location = new System.Drawing.Point(0, 383);
			this.panelTiles.Name = "panelTiles";
			this.panelTiles.Size = new System.Drawing.Size(552, 100);
			this.panelTiles.TabIndex = 4;
			// 
			// picTiles
			// 
			this.picTiles.BackColor = System.Drawing.Color.White;
			this.picTiles.Location = new System.Drawing.Point(16, 16);
			this.picTiles.Name = "picTiles";
			this.picTiles.Size = new System.Drawing.Size(392, 56);
			this.picTiles.TabIndex = 2;
			this.picTiles.TabStop = false;
			this.picTiles.Click += new System.EventHandler(this.picTiles_Click);
			this.picTiles.Paint += new System.Windows.Forms.PaintEventHandler(this.picTiles_Paint);
			this.picTiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTiles_MouseMove);
			this.picTiles.MouseLeave += new System.EventHandler(this.picTiles_MouseLeave);
			// 
			// vscTiles
			// 
			this.vscTiles.Dock = System.Windows.Forms.DockStyle.Right;
			this.vscTiles.Location = new System.Drawing.Point(535, 0);
			this.vscTiles.Name = "vscTiles";
			this.vscTiles.Size = new System.Drawing.Size(17, 100);
			this.vscTiles.TabIndex = 1;
			this.vscTiles.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vscTiles_Scroll);
			// 
			// picEditSel
			// 
			this.picEditSel.BackColor = System.Drawing.Color.White;
			this.picEditSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picEditSel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picEditSel.Location = new System.Drawing.Point(0, 0);
			this.picEditSel.Name = "picEditSel";
			this.picEditSel.Size = new System.Drawing.Size(552, 100);
			this.picEditSel.TabIndex = 0;
			this.picEditSel.TabStop = false;
			// 
			// vscMap
			// 
			this.vscMap.Dock = System.Windows.Forms.DockStyle.Right;
			this.vscMap.Location = new System.Drawing.Point(535, 28);
			this.vscMap.Name = "vscMap";
			this.vscMap.Size = new System.Drawing.Size(17, 355);
			this.vscMap.TabIndex = 6;
			this.vscMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vscMap_Scroll);
			// 
			// hscMap
			// 
			this.hscMap.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.hscMap.Location = new System.Drawing.Point(0, 366);
			this.hscMap.Name = "hscMap";
			this.hscMap.Size = new System.Drawing.Size(535, 17);
			this.hscMap.TabIndex = 7;
			this.hscMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscMap_Scroll);
			// 
			// timer1
			// 
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// picMap
			// 
			this.picMap.BackColor = System.Drawing.Color.White;
			this.picMap.Location = new System.Drawing.Point(16, 40);
			this.picMap.Name = "picMap";
			this.picMap.Size = new System.Drawing.Size(504, 304);
			this.picMap.TabIndex = 8;
			this.picMap.TabStop = false;
			this.picMap.Visible = false;
			this.picMap.Click += new System.EventHandler(this.picMap_Click);
			this.picMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picMap_Paint);
			this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseMove);
			this.picMap.MouseLeave += new System.EventHandler(this.picMap_MouseLeave);
			// 
			// tmrLoad
			// 
			this.tmrLoad.Tick += new System.EventHandler(this.tmrLoad_Tick);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(40, 328);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 9;
			this.comboBox1.TabStop = false;
			this.comboBox1.Text = "comboBox1";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// lblZoom
			// 
			this.lblZoom.Location = new System.Drawing.Point(176, 336);
			this.lblZoom.Name = "lblZoom";
			this.lblZoom.Size = new System.Drawing.Size(40, 24);
			this.lblZoom.TabIndex = 10;
			this.lblZoom.Text = "Zoom:";
			this.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 505);
			this.Controls.Add(this.lblZoom);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.picMap);
			this.Controls.Add(this.hscMap);
			this.Controls.Add(this.vscMap);
			this.Controls.Add(this.panelTiles);
			this.Controls.Add(this.panelTools);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.tbMain);
			this.Controls.Add(this.picEditArea);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mbMain;
			this.Name = "frmMain";
			this.Text = "WOE Map Editor";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.panelTools.ResumeLayout(false);
			this.panelTiles.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		/* -------------------------------------------------------------- *\
			frmMain_Load()			
			- Main Form Initialization		
		\* -------------------------------------------------------------- */
		private void frmMain_Load(object sender, System.EventArgs e)
		{			
			m_Map = new CMap();
			m_TileLibrary = new CTileLibrary();
			m_Map.TileLibrary = m_TileLibrary;

			picMap.Parent = picEditArea;
			picMap.Left = 0;
			picMap.Top = 0;
 
			picTiles.Parent = picEditSel;			
			picTiles.Width = 640; 
			picTiles.Height = 480;
			picTiles.Left = 16;
			picTiles.Top = 16;

			vscMap.LargeChange = 1;
			vscMap.Minimum = 0;
			vscMap.Maximum = m_Map.Height;
			m_YSel = 0;

			hscMap.LargeChange = 1;
			hscMap.Minimum = 0;
			hscMap.Maximum = m_Map.Width;
			m_XSel = 0;

			m_bRefresh = true;
			m_bResize = true;
			timer1.Enabled = true;
			m_Zoom = ZOOM;

			m_TileRect = new Rectangle(-1,-1,-1,-1);			
			m_LibRect = new Rectangle(-1,-1,-1,-1);			
			m_ActiveTileID = 1;

			InitializeDebug();			
			
			dlgLoadMap.InitialDirectory =  Path.GetDirectoryName(Application.ExecutablePath) + "\\maps\\";
			dlgSaveMap.InitialDirectory = dlgLoadMap.InitialDirectory;
			m_bOpen = false;
			m_MenuLogic();
			//tmrLoad.Enabled = true;	
		
			m_pen = new Pen(Color.Orange,4);
			m_brush = new SolidBrush(Color.FromArgb(160, 249, 174, 55));
			m_brush2 = new SolidBrush(Color.FromArgb(160, 255, 0, 0));

			m_bDrawTileRect = false;
			m_bDrawMapRect = false;

			comboBox1.Left = 220;
			comboBox1.Top = 2;
			comboBox1.Items.Add(new ComboItem("1X",1));
			comboBox1.Items.Add(new ComboItem("2X",2));
			comboBox1.Items.Add(new ComboItem("4X",4));
			comboBox1.Items.Add(new ComboItem("8X",8));
			comboBox1.Items.Add(new ComboItem("16X",16));
			comboBox1.SelectedIndex = 2;
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

			lblZoom.Left = 180;
			lblZoom.Top = 2;

			tbMain.Controls.Add(lblZoom);
			tbMain.Controls.Add(comboBox1);			
		}

		/* -------------------------------------------------------------- *\
			Menus
		\* -------------------------------------------------------------- */
		#region Menu Code
		private void mnuFileExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void mnuHelpAbout_Click(object sender, System.EventArgs e)
		{			
			frmAbout f = new frmAbout();
			f.ShowDialog(this);
		}

		private void mnuZoomX1_Click(object sender, System.EventArgs e)
		{
			ResetScroll();
			m_Zoom = 1;
			m_bResize = true;
		}

		private void mnuZoomX2_Click(object sender, System.EventArgs e)
		{
			ResetScroll();
			m_Zoom = 2;
			m_bResize = true;
		}

		private void mnuZoomX4_Click(object sender, System.EventArgs e)
		{
			ResetScroll();
			m_Zoom = 4;
			m_bResize = true;
		}

		private void mnuZoomX8_Click(object sender, System.EventArgs e)
		{
			ResetScroll();
			m_Zoom = 8;
			m_bResize = true;
		}

		private void mnuZoomX16_Click(object sender, System.EventArgs e)
		{
			ResetScroll();
			m_Zoom = 16;
			m_bResize = true;
		}

		private void mnuFileOpen_Click(object sender, System.EventArgs e)
		{
			m_LoadMap();
		}

		private void mnuFileSaveAs_Click(object sender, System.EventArgs e)
		{
			m_SaveMap();
		}

		private void mnuFileSave_Click(object sender, System.EventArgs e)
		{
			m_SaveMap();
		}

		private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			//m_Map.Save("C:\\erictest1.map");

			if (e.Button == tbbSave)
				m_SaveMap();
			if (e.Button == tbbOpen)
				m_LoadMap();
			else if (e.Button == tbbNew)
				m_NewMap();						
		}

		#endregion


		private void button1_Click(object sender, System.EventArgs e)
		{			
		}


		/* -------------------------------------------------------------- *\
			vscMap_Scroll()
			- vertical scroll bar for map editor window		
		\* -------------------------------------------------------------- */
		private void vscMap_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{		
			m_YSel = e.NewValue;
			if (m_bOpen)				
				picMap.Refresh();
		}

		/* -------------------------------------------------------------- *\
			hscMap_Scroll()
			- horizontal scroll bar for map editor window		
		\* -------------------------------------------------------------- */
		private void hscMap_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			m_XSel = e.NewValue;
			if (m_bOpen)			
				picMap.Refresh();
		}

		/* -------------------------------------------------------------- *\
			picEditArea_Resize()
			
			- resize event for the parent of the map. The edit area is
			  auto-sized to the space not taken by the lower and right 
			  panes.		
		\* -------------------------------------------------------------- */
		private void picEditArea_Resize(object sender, System.EventArgs e)
		{
			if (m_bOpen)
			{
				m_XSel = 0;
				hscMap.Value = m_XSel;
				m_YSel = 0;
				vscMap.Value = m_YSel;
				m_bResize = true;
			}
		}

		/* -------------------------------------------------------------- *\
			timer1_Tick()
			
			- I'm not sure if this is necessary or not, but I was having
			  difficulty updating things correctly due to timing of resizing
			  items or updating scrolls and their values not getting set 
			  until after the event already occurred... so I'm setting
			  flags instead.
		\* -------------------------------------------------------------- */
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (m_bRefresh)
			{
				m_bRefresh = false;
				picMap.Refresh();
			}			
			if (m_bResize)
			{
				m_bResize = false;
				m_ResizeMap();
			}
			if (m_bRefreshLib)
			{
				m_bRefreshLib = false;
				picTiles.Refresh();
			}
		}

		/* -------------------------------------------------------------- *\
			picMap_Paint()
			
			- This is where the Map picture box is painted to.
			  This event happens when Refresh() is called or any section
			  of the picture box is invalidated (i.e. covering up part of
			  the picture box with another windows and then moving it away)
		\* -------------------------------------------------------------- */
		private void picMap_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (m_bOpen)
			{
				if (m_XSel < 0)
					m_XSel = 0;
				if (m_YSel < 0)
					m_YSel = 0;
				m_Map.Draw(e.Graphics,e.ClipRectangle,m_XSel, m_YSel);

				//e.Graphics.DrawRectangle(m_pen,m_TileRect);
//				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 0, 0, 255)), m_TileRect);
				if (m_bDrawMapRect)
					e.Graphics.FillRectangle(m_brush, m_TileRect);
			}
		}

		/* -------------------------------------------------------------- *\
			m_ResizeMap()
			
			- Takes care of Zoom, scroll and visible area logic.
		\* -------------------------------------------------------------- */
		private void m_ResizeMap()
		{
			int xpos, ypos;
			int nWidth = (vscMap.Left - 0); //picEditArea.Left);
			int AvailableWidth = nWidth - (2 * BUFFER_WIDTH); 
			m_TilesHoriz = AvailableWidth / (m_Zoom * TILE_WIDTH);
			int nMapWidth = m_TilesHoriz * TILE_WIDTH * m_Zoom;			
			int BorderX = (nWidth - nMapWidth) / 2;

			int nHeight = (hscMap.Top - 0); //picEditArea.Top);
			int AvailableHeight = nHeight - 2 * BUFFER_HEIGHT; 
			m_TilesVert = AvailableHeight / (m_Zoom * TILE_HEIGHT);
			int nMapHeight = m_TilesVert * TILE_HEIGHT * m_Zoom;
			int BorderY = (nHeight - nMapHeight) / 2;			

			PrintDebug("AvailableHeight = " + AvailableHeight.ToString());
			PrintDebug("BorderY = " + BorderY.ToString());
			PrintDebug("AvailableWidth = " + AvailableWidth.ToString());
			PrintDebug("BorderX = " + BorderX.ToString());

			m_Map.OffsetX = 0; //BorderX;
			m_Map.OffsetY = 0; //BorderY;						
			m_Map.Zoom = m_Zoom;			

			if (m_TilesHoriz < m_Map.Width)
			{
				//xpos = 16;
				xpos = 16 + (AvailableWidth - nMapWidth) / 2;
				m_Map.TilesHoriz = m_TilesHoriz;
				hscMap.Maximum = m_Map.Width - m_TilesHoriz;
			}
			else
			{				
				m_Map.TilesHoriz = m_Map.Width;
				nMapWidth = m_Map.Width * TILE_WIDTH * m_Zoom;	
				xpos = 16 + (AvailableWidth - nMapWidth) / 2;
				hscMap.Maximum = 0;
			}

			if (m_TilesVert < m_Map.Height)
			{
				//ypos = 32;
				ypos = 32 + (AvailableHeight - nMapHeight) / 2;
				m_Map.TilesVert = m_TilesVert;
				vscMap.Maximum = m_Map.Height - m_TilesVert;
			}
			else
			{
				m_Map.TilesVert = m_Map.Height;
				nMapHeight = m_Map.Height * TILE_HEIGHT * m_Zoom;
				ypos = 32 + (AvailableHeight - nMapHeight) / 2;
				vscMap.Maximum = 0;
			}			
			
			picMap.Location = new System.Drawing.Point(xpos, ypos);
			picMap.Size = new Size(nMapWidth,nMapHeight);

			m_bRefresh = true;
		}

		
		/* -------------------------------------------------------------- *\
			picMap_MouseMove()
			
			- Keeps track / translates coordinates to map tile to be
			  updated if clicked on.
		\* -------------------------------------------------------------- */
		private void picMap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.X < 0 || e.Y < 0)
				return;
			if (e.X < m_TileRect.Left || e.X > m_TileRect.Right || e.Y < m_TileRect.Top || e.Y > m_TileRect.Bottom)
			{
				m_bDrawMapRect = true;

				m_Map.PointToTile(e.X, e.Y, ref m_ActiveXIndex, ref m_ActiveYIndex);
				m_Map.PointToBoundingRect(e.X,e.Y, ref m_TileRect);
				m_ActiveXIndex += m_XSel;
				m_ActiveYIndex += m_YSel;

				m_bRefresh = true;

				PrintDebug("XIndex = " + m_ActiveXIndex.ToString() + " YIndex = " + m_ActiveYIndex.ToString());
			}
		}

		/* -------------------------------------------------------------- *\
			picMap_Click()
			
			- Plots the ActiveTile from the tile library to the selected
			  tile location on the map.
		\* -------------------------------------------------------------- */
		private void picMap_Click(object sender, System.EventArgs e)
		{
			m_Map.PlotTile(m_ActiveXIndex,m_ActiveYIndex,m_ActiveTileID);
			m_bRefresh = true;
		}

		/* -------------------------------------------------------------- *\
			picTiles_Paint()
			
			- Paints the tile library at the bottom of the screen.
		\* -------------------------------------------------------------- */
		private void picTiles_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (m_TileLibrary != null)
			{
				m_TileLibrary.Draw(e.Graphics,e.ClipRectangle);
				if (m_bDrawTileRect)
					e.Graphics.FillRectangle(m_brush2, m_LibRect);
			}
		}

		/* -------------------------------------------------------------- *\
			picTiles_Click()
			
			- Selects the active tile ID
		\* -------------------------------------------------------------- */
		private void picTiles_Click(object sender, System.EventArgs e)
		{
			m_ActiveTileID = m_TileLibrary.TileToTileID(m_ActiveTileXIndex,m_ActiveTileYIndex);
			picActiveTile.Refresh();
		}

		/* -------------------------------------------------------------- *\
			vscTiles_Scroll()
			
			- controls the tile library scroll / position
		\* -------------------------------------------------------------- */
		private void vscTiles_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			picTiles.Top = -e.NewValue;
		}

		/* -------------------------------------------------------------- *\
			picTiles_MouseMove()
			
			- Keeps track / translates coordinates to tilelibrary tile to be
			  selected if clicked on.
		\* -------------------------------------------------------------- */
		private void picTiles_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.X < 0 || e.Y < 0)
				return;
			if (e.X < m_LibRect.Left || e.X > m_LibRect.Right || e.Y < m_LibRect.Top || e.Y > m_LibRect.Bottom)
			{				
				m_bDrawTileRect = true;

				m_TileLibrary.PointToTile(e.X, e.Y, ref m_ActiveTileXIndex, ref m_ActiveTileYIndex);
				m_TileLibrary.PointToBoundingRect(e.X,e.Y, ref m_LibRect);

				m_bRefreshLib = true;

				PrintDebug("TileXIndex = " + m_ActiveTileXIndex.ToString() + " TileYIndex = " + m_ActiveTileYIndex.ToString());
				PrintDebug("X = " + e.X.ToString() + " Y = " + e.Y.ToString());
			}
		}

		/* -------------------------------------------------------------- *\
			ResetScroll()
			
			- Resets the scrollbar to 0.
			  I'm not sure if this is necessary anymore.. I was trouble-
			  shooting an odd issue.			  
		\* -------------------------------------------------------------- */
		private void ResetScroll()
		{
			vscMap.Value = 0;
			m_YSel = 0;
			hscMap.Value = 0;
			m_XSel = 0;
		}

		/* -------------------------------------------------------------- *\
			picActiveTile_Paint()
			
			- Displays the selected tile.	  
		\* -------------------------------------------------------------- */
		private void picActiveTile_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Rectangle destrect = new Rectangle(0,0,picActiveTile.Width,picActiveTile.Height);
			m_TileLibrary.DrawTile(e.Graphics, m_ActiveTileID, destrect);
		}

		/* -------------------------------------------------------------- *\
			tmrLoad_Tick()
			
			- Loads the default map. 
		\* -------------------------------------------------------------- */
		private void tmrLoad_Tick(object sender, System.EventArgs e)
		{
			tmrLoad.Enabled = false;
			this.Cursor = Cursors.WaitCursor;
			m_Map.Refresh();			
			m_bOpen = true;
			m_bRefresh = true;
			picMap.Visible = true;
			m_MenuLogic();
			this.Cursor = Cursors.Default;
		}

		/* -------------------------------------------------------------- *\
			Debug Code
			- set the compile-time attribute ERICDEBUG to enable debug
			  console.					
		\* -------------------------------------------------------------- */
		#region Debug Code
		[Conditional("ERICDEBUG")]
		private void InitializeDebug()
		{
			m_Debug = new frmDebug();
			m_Debug.Show();
		}

		[Conditional("ERICDEBUG")]
		private void PrintDebug(String strDebug)
		{
			m_Debug.AddLine(strDebug);
		}
		#endregion

		private void m_LoadMap()
		{
			DialogResult result;

			dlgLoadMap.Title = "Load Map";
			dlgLoadMap.Filter = "Map Files (*.map)|*.map|All Files (*.*)|*.*";			

			result = dlgLoadMap.ShowDialog();
			if (result == DialogResult.OK)
			{
				m_bOpen = false;
				picMap.Visible = false;
				this.Cursor = Cursors.WaitCursor;
				try
				{
					m_Map.Load(dlgLoadMap.FileName);
					m_bOpen = true;
					m_bRefresh = true;
					picMap.Visible = true;
				}
				catch
				{
					Debug.WriteLine("Error Loading...");
				}
				m_MenuLogic();
				this.Cursor = Cursors.Default;
			}
		}

		/* -------------------------------------------------------------- *\
			m_SaveMap()
			
			- Saves the current map to the selected filename / path
		\* -------------------------------------------------------------- */
		private void m_SaveMap()
		{
			DialogResult result;

			dlgSaveMap.Title = "Save Map";
			dlgSaveMap.Filter = "Map File (*.map)|*.map";			

			result = dlgSaveMap.ShowDialog();
			if (result == DialogResult.OK)
			{				
				this.Cursor = Cursors.WaitCursor;
				try
				{
					m_Map.Save(dlgSaveMap.FileName);
				}
				catch
				{
					Debug.WriteLine("Error Saving...");
				}
				this.Cursor = Cursors.Default;
			}
		}

		/* -------------------------------------------------------------- *\
			m_NewMap()
			
			- Creates a new map of the selected size.
		\* -------------------------------------------------------------- */
		private void m_NewMap()
		{
			frmNew			f;
			DialogResult	result;
			bool			bResult;

			f = new frmNew();
			f.MapWidth = m_Map.Width;
			f.MapHeight = m_Map.Height;

			result = f.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				m_bOpen = false;
				picMap.Visible = false;
				this.Cursor = Cursors.WaitCursor;
				try
				{
					bResult = m_Map.CreateNew(f.MapWidth,f.MapHeight,0);
					if (bResult)
					{
						m_bOpen = true;
						m_bRefresh = true;
						m_bResize = true;
						picMap.Visible = true;
					}
				}
				catch
				{
					Debug.WriteLine("Error Creating...");
				}
				m_MenuLogic();
				this.Cursor = Cursors.Default;
				//MessageBox.Show("New Map width = " + f.MapWidth.ToString() + " height = " + f.MapHeight.ToString());
			}
		}

		/* -------------------------------------------------------------- *\
			m_MenuLogic()
			
			- Enables / Disables menus based on application status
		\* -------------------------------------------------------------- */
		private void m_MenuLogic()
		{
			bool bEnabled;

			bEnabled				= m_bOpen;
			mnuFileSave.Enabled		= bEnabled;
			mnuFileClose.Enabled	= bEnabled;
			mnuFileSaveAs.Enabled	= bEnabled;
			mnuZoom.Enabled			= bEnabled;
			tbbSave.Enabled			= bEnabled;			
		}

		/* -------------------------------------------------------------- *\
			mnuFileNew_Click()
		\* -------------------------------------------------------------- */
		private void mnuFileNew_Click(object sender, System.EventArgs e)
		{
			m_NewMap();
		}

		private void picTiles_MouseLeave(object sender, System.EventArgs e)
		{
			m_bDrawTileRect = false;
			m_LibRect.X = -1;
			m_LibRect.Y = -1;
			m_LibRect.Width = -1;
			m_LibRect.Height = -1;
			m_bRefreshLib = true;
		}

		private void picMap_MouseLeave(object sender, System.EventArgs e)
		{
			m_bDrawMapRect = false;
			m_TileRect.X = -1;
			m_TileRect.Y = -1;
			m_TileRect.Width = -1;
			m_TileRect.Height = -1;
			m_bRefresh = true;
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboItem myItem;
			myItem = (ComboItem) comboBox1.SelectedItem;

			ResetScroll();
			m_Zoom = myItem.Value;
			m_bResize = true;
			picTiles.Focus();
		}
	}
}
