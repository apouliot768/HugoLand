﻿using HugoLandEditeur.Presentation;
using HugoLand.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoLandEditeur
{
    public partial class frmMain : Form
    {
        private CMap m_Map;
        private CTileLibrary m_TileLibrary;
        private int m_XSel;
        private int m_YSel;
        private int m_TilesHoriz;
        private System.Windows.Forms.Timer timer1;
        private int m_TilesVert;
        private bool m_bRefresh;
        private bool m_bResize;
        private int m_Zoom;
        private Rectangle m_TileRect;
        private Rectangle m_LibRect;
        private int m_ActiveXIndex;
        private int m_ActiveYIndex;
        private int m_ActiveTileID;
        private int m_ActiveTileXIndex;
        private int m_ActiveTileYIndex;
        private GestionCompteJoueur m_GestionCompteJoueur = new GestionCompteJoueur();
        private GestionItem m_GestionItem = new GestionItem();
        private GestionMonde m_GestionMonde = new GestionMonde();
        private GestionMonstre m_GestionMonstre = new GestionMonstre();
        private GestionObjetMonde m_GestionObjetMonde = new GestionObjetMonde();
        private frmMenuUsers m_frmUser = null;
        private Tile tile;
        private HugoLand.Monde world = new HugoLand.Monde();

        /// <summary>
        /// Summary description for Form1.
        /// </summary>
        public struct ComboItem
        {
            public string Text;
            public int Value;

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

        public frmMain()
        {
            using (frmLogIn logIn = new frmLogIn())
            {
                if (logIn.ShowDialog() == DialogResult.OK)
                {
                    InitializeComponent();
                    m_GestionCompteJoueur.ObtenirCompte(logIn._compte.NomJoueur);
                }
                else
                    System.Environment.Exit(1);
            }
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
            picTiles.Width = m_TileLibrary.Width * csteApplication.TILE_WIDTH_IN_IMAGE;
            picTiles.Height = m_TileLibrary.Height * csteApplication.TILE_HEIGHT_IN_IMAGE;
            picTiles.Left = 0;
            picTiles.Top = 0;

            vscMap.Minimum = 0;
            vscMap.Maximum = m_Map.Height;
            m_YSel = 0;

            hscMap.Minimum = 0;
            hscMap.Maximum = m_Map.Width;
            m_XSel = 0;

            m_bRefresh = true;
            m_bResize = true;
            timer1.Enabled = true;
            m_Zoom = csteApplication.ZOOM;

            m_TileRect = new Rectangle(-1, -1, -1, -1);
            m_LibRect = new Rectangle(-1, -1, -1, -1);
            m_ActiveTileID = 32;

            //dlgLoadMap.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\maps\\";
            //dlgSaveMap.InitialDirectory = dlgLoadMap.InitialDirectory;
            m_bOpen = false;
            m_MenuLogic();
            //tmrLoad.Enabled = true;	

            m_pen = new Pen(Color.Orange, 4);
            m_brush = new SolidBrush(Color.FromArgb(160, 249, 174, 55));
            m_brush2 = new SolidBrush(Color.FromArgb(160, 255, 0, 0));

            m_bDrawTileRect = false;
            m_bDrawMapRect = false;

            cboZoom.Left = 270;
            cboZoom.Top = 2;
            cboZoom.Items.Add(new ComboItem("1X", 1));
            cboZoom.Items.Add(new ComboItem("2X", 2));
            cboZoom.Items.Add(new ComboItem("4X", 4));
            cboZoom.Items.Add(new ComboItem("8X", 8));
            cboZoom.Items.Add(new ComboItem("16X", 16));
            cboZoom.SelectedIndex = 1;
            cboZoom.DropDownStyle = ComboBoxStyle.DropDownList;

            lblZoom.Left = 180;
            lblZoom.Top = 2;

            tbMain.Controls.Add(lblZoom);
            tbMain.Controls.Add(cboZoom);

        }

        /* -------------------------------------------------------------- *\
        Menus
        \* -------------------------------------------------------------- */
        #region Menu Code
        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        #region Zoom options
        // Zoom at x1 force.
        private void mnuZoomX1_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 1;
            m_bResize = true;
        }

        // Zoom at x2 force.
        private void mnuZoomX2_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 2;
            m_bResize = true;
        }

        // Zoom at x4 force.
        private void mnuZoomX4_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 4;
            m_bResize = true;
        }

        // Zoom at x8 force.
        private void mnuZoomX8_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 8;
            m_bResize = true;
        }

        // Zoom at x16 force.
        private void mnuZoomX16_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 16;
            m_bResize = true;
        }
        #endregion

        /// <summary>
        /// Auteur : ???
        /// Description : From the file drop-down menu, open the map of the selected world.
        /// Date : ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileOpen_Click(object sender, System.EventArgs e)
        {
            LoadMap();
        }

        /// <summary>
        /// Auteur : ???
        /// Description : From the file drop-down menu, save the current map.
        /// Date : ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileSave_Click(object sender, System.EventArgs e)
        {
            m_SaveMap();
        }

        /// <summary>
        /// Auteur : Alexandre Pouliot
        /// Description : Allows the creation of a new user.
        /// Date : 2019/10/27
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCreateNewUser_Click(object sender, EventArgs e)
        {
            using (frmCreateUser createUser = new frmCreateUser())
            {
                createUser.ShowDialog();
            }
        }

        /// <summary>
        /// Author : Alexandre Pouliot
        /// Description : Disconnect the user when the form is closed.
        /// Date : 2019/10/27
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_GestionCompteJoueur.Déconnexion(m_GestionCompteJoueur.CompteCourrant);
        }

        /// <summary>
        /// Author :        Alexandre Pouliot
        /// Description :   Open the users menu that allows to edit user role,
        ///                 watch if a user is connected and chat with users.
        /// Date :          2019-11-04
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuUsers_Click(object sender, EventArgs e)
        {
            if (m_frmUser == null)
            {
                m_frmUser = new frmMenuUsers();
                m_frmUser._gestionCompteJoueur.CompteCourrant = m_GestionCompteJoueur.CompteCourrant;
                m_frmUser.Location = new Point((this.Location.X + this.Width + this.Width / 6) - (m_frmUser.Width / 2), (this.Location.Y + this.Height / 2) - (m_frmUser.Height / 2));
                m_frmUser.StartPosition = FormStartPosition.Manual;
                m_frmUser.Owner = this;
                m_frmUser.FormClosed += m_frmUser_Closed;
                m_frmUser.Show();
            }
        }

        /// <summary>
        /// Author :        Alexandre Pouliot
        /// Description :   Clear the frmUser variable to allow the user to open and close the form at will.
        /// Date :          2019-11-04
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_frmUser_Closed(object sender, EventArgs e)
        {
            m_frmUser = null;
        }

        /// <summary>
        /// Auteur : ???
        /// Description : From the file drop-down menu, show the about window.
        /// Date : ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHelpAbout_Click(object sender, System.EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog(this);
        }

        // Toolbar menu ↓
        /// <summary>
        /// Auteur : ???
        /// Description : When using the toolbar, do an action depending on the button clicked.
        /// Date : ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == tbbSave) // Save the world
                m_SaveMap();
            if (e.Button == tbbOpen) // Browse for an existing world
                LoadMap();
            if (e.Button == tbbNew) // Create a new map
                NewMap();
            /*else if (e.Button == tbbHelp) // Open the help window
                ShowHelp();*/ // TP #3
        }
        #endregion


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
                m_Map.Draw(e.Graphics, e.ClipRectangle, m_XSel, m_YSel);

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
            int AvailableWidth = nWidth - (2 * csteApplication.BUFFER_WIDTH);
            m_TilesHoriz = AvailableWidth / (m_Zoom * csteApplication.TILE_WIDTH_IN_MAP);
            int nMapWidth = m_TilesHoriz * csteApplication.TILE_WIDTH_IN_MAP * m_Zoom;
            int BorderX = (nWidth - nMapWidth) / 2;

            int nHeight = (hscMap.Top - 0); //picEditArea.Top);
            int AvailableHeight = nHeight - 2 * csteApplication.BUFFER_HEIGHT;
            m_TilesVert = AvailableHeight / (m_Zoom * csteApplication.TILE_HEIGHT_IN_MAP);
            int nMapHeight = m_TilesVert * csteApplication.TILE_HEIGHT_IN_MAP * m_Zoom;
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
                nMapWidth = m_Map.Width * csteApplication.TILE_WIDTH_IN_MAP * m_Zoom;
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
                nMapHeight = m_Map.Height * csteApplication.TILE_HEIGHT_IN_MAP * m_Zoom;
                ypos = 32 + (AvailableHeight - nMapHeight) / 2;
                vscMap.Maximum = 0;
            }

            picMap.Location = new System.Drawing.Point(xpos, ypos);
            picMap.Size = new Size(nMapWidth, nMapHeight);

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
                m_Map.PointToBoundingRect(e.X, e.Y, ref m_TileRect);
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
            m_Map.PlotTile(m_ActiveXIndex, m_ActiveYIndex, m_ActiveTileID);
            UpdateTile(tile, world.Id, m_ActiveXIndex, m_ActiveYIndex, m_ActiveTileID);
            txtAttkMax.Clear();
            txtAttkMin.Clear();
            txtLevel.Clear();
            txtPv.Clear();
            m_bRefresh = true;
        }

        private void UpdateTile(Tile t, int worldId, int ActiveX, int ActiveY,int TileID)
        {
            switch (t.TypeObjet)
            {
                case TypeTile.Item:
                    m_GestionItem.RetournerItems();
                    HugoLand.Item item = m_GestionItem.LstItems.FirstOrDefault(x => x.MondeId == worldId && x.x == ActiveX && x.y == ActiveY);
                    if (item != null)
                    {
                        m_GestionItem.ModificationItem(t.Name, TileID, item.Id);
                    }
                    else
                    {
                        item = new HugoLand.Item()
                        {
                            Nom = t.Name,
                            MondeId = worldId,
                            x = ActiveX,
                            y = ActiveY,
                            ImageId = TileID,
                            Description = t.Category + " " + t.Color
                        };

                        m_GestionItem.CreerItemMonde(item);
                    }
                    break;
                case TypeTile.Monstre:
                    m_GestionMonstre.RetournerMonstres();
                    int statPv = 0, statLevel = 0;
                    float statAttkMax = 0f, statAttkMin = 0f;
                    
                    int.TryParse(txtLevel.Text, out statLevel);
                    int.TryParse(txtPv.Text, out statPv);
                    float.TryParse(txtAttkMax.Text, out statAttkMax);
                    float.TryParse(txtAttkMin.Text, out statAttkMin);

                    HugoLand.Monstre monstre = m_GestionMonstre.LstMonstres.FirstOrDefault(x => x.MondeId == worldId && x.x == ActiveX && x.y == ActiveY);
                    if (monstre != null)
                    {
                        m_GestionMonstre.ModificationMonstre(t.Name, TileID, monstre.Id, statPv, statAttkMax, statAttkMin, statLevel);
                    }
                    else
                    {
                        monstre = new HugoLand.Monstre()
                        {
                            Nom = t.Name,
                            MondeId = worldId,
                            x = ActiveX,
                            y = ActiveY,
                            ImageId = TileID,
                        };

                        m_GestionMonstre.CréerMonstre(monstre, statPv, statAttkMax, statAttkMin, statLevel);
                    }
                    break;
                case TypeTile.ObjetMonde:
                    m_GestionObjetMonde.RetournerObjetMonde();
                    HugoLand.ObjetMonde objMonde = m_GestionObjetMonde.LstObjetMondes.FirstOrDefault(x => x.MondeId == worldId && x.x == ActiveX && x.y == ActiveY);
                    if (objMonde != null)
                    {
                        m_GestionObjetMonde.ModificationObjetMonde(t.Name, TileID, objMonde.Id);
                    }
                    else
                    {
                        objMonde = new HugoLand.ObjetMonde()
                        {
                            Description = t.Name,
                            MondeId = worldId,
                            x = ActiveX,
                            y = ActiveY,
                            TypeObjet = TileID
                        };

                        m_GestionObjetMonde.CreerObjetMonde(objMonde);
                    }
                    break;

            }
        }

        /* -------------------------------------------------------------- *\
            picTiles_Paint()
			
            - Paints the tile library at the bottom of the screen.
        \* -------------------------------------------------------------- */
        private void picTiles_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (m_TileLibrary != null)
            {
                m_TileLibrary.Draw(e.Graphics, e.ClipRectangle);
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
            m_ActiveTileID = m_TileLibrary.TileToTileID(m_ActiveTileXIndex, m_ActiveTileYIndex);
            tile = m_TileLibrary.ObjMonde.FirstOrDefault(x => x.Value.X_Image == m_ActiveTileXIndex &&
                                                              x.Value.Y_Image == m_ActiveTileYIndex).Value;
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
                m_TileLibrary.PointToBoundingRect(e.X, e.Y, ref m_LibRect);

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
            Rectangle destrect = new Rectangle(0, 0, picActiveTile.Width, picActiveTile.Height);
            if (m_TileLibrary != null)
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
        #region Debug Code

        private void PrintDebug(String strDebug)
        {
            Console.WriteLine(strDebug);
        }
        #endregion

        /// <summary>
        /// Auteur : ???
        /// Description : Open a window allowing the user to select a *.map file to load.
        /// Update : Joëlle Boyer -> Added "m_ResizeMap()" so that the map immediately shows the changes made. 2019/11/03
        /// Date : ???
        /// </summary>
        private void LoadMap()
        {
            frmOpen f = new frmOpen();
            f.ShowDialog(this);

            if (f.DialogResult == DialogResult.OK)
            {
                DialogResult result;
                HugoLand.Monde monde = f.MyWorld;
                string myWorld = monde.Id.ToString() + ".map";

                if (File.Exists(myWorld) && f.MyWorld.Id != -1)
                {
                    try
                    {
                        m_Map.Load(myWorld);
                        m_bOpen = true;
                        m_bRefresh = true;
                        picMap.Visible = true;
                    }
                    catch
                    {
                        Console.WriteLine("Error Loading Existing File ...");
                    }
                }

                else if (!f.NoFile)
                {
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
                            Console.WriteLine("Error Loading Chosen File ...");
                        }
                    }
                }
                else if (f.NoFile && f.MyWorld.Id != -1)
                {
                    m_bOpen = false;
                    picMap.Visible = false;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        m_Map.MapExistingWorld(f.MyWorld.Id);
                        m_bOpen = true;
                        m_bRefresh = true;
                        picMap.Visible = true;
                    }
                    catch
                    {
                        Console.WriteLine("Error Loading Chosen File ...");
                    }
                }

                m_ResizeMap();
                m_MenuLogic();
                world = f.MyWorld;
                this.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show("You have cancelled the opening of a new world.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    m_GestionMonde.ChargerMondeCourrant(world.Id);

                    m_Map.Save(dlgSaveMap.FileName);
                }
                catch
                {
                    Console.WriteLine("Error Saving...");
                }
                this.Cursor = Cursors.Default;
            }
        }

        /* -------------------------------------------------------------- *\
            m_NewMap()
			
            - Creates a new map of the selected size.
        \* -------------------------------------------------------------- */
        private void NewMap()
        {
            frmNew f;
            DialogResult result;
            bool bResult;

            f = new frmNew();
            f.MapWidth = m_Map.Width;
            f.MapHeight = m_Map.Height;
            f.DefaultTile = m_Map.DefaultTileID;


            result = f.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                m_bOpen = false;
                picMap.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bResult = m_Map.CreateNew(f.MapWidth, f.MapHeight, f.DefaultTile);

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
                    Console.WriteLine("Error Creating...");
                }
                m_MenuLogic();
                world = f.MyWorld;
                this.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show("You have cancelled the creation of a new world.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /*
         * Sera implémenté lors de la prochaine version (TP#3)
         * 
        /// <summary>
        /// Auteure : Joëlle Boyer
        /// Description : Opens the window when help is needed.
        /// Date : 2019/11/02
        /// </summary>
        private void ShowHelp()
        {
            frmHelp f = new frmHelp();
            f.ShowDialog(this);
        }
        */

        /* -------------------------------------------------------------- *\
            m_MenuLogic()
			
            - Enables / Disables menus based on application status
        \* -------------------------------------------------------------- */
        private void m_MenuLogic()
        {
            bool bEnabled;

            bEnabled = m_bOpen;
            mnuFileSave.Enabled = bEnabled;
            mnuFileClose.Enabled = bEnabled;
            //mnuCreateNewUser.Enabled = bEnabled; // Not look like a nessecity A.P. 2019-10-27
            mnuZoom.Enabled = bEnabled;
            tbbSave.Enabled = bEnabled;
        }

        /* -------------------------------------------------------------- *\
            mnuFileNew_Click()
        \* -------------------------------------------------------------- */
        private void mnuFileNew_Click(object sender, System.EventArgs e)
        {
            NewMap();
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

        /// <summary>
        /// Auteur : ???
        /// Description : Changes the zoom on the map depending on the selected index of cboZoom.
        /// Date : ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboItem myItem;
            myItem = (ComboItem)cboZoom.SelectedItem;
            ResetScroll();
            m_Zoom = myItem.Value;
            m_bResize = true;
            picTiles.Focus();
        }
    }
}
