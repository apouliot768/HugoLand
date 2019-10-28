using System;
using System.Drawing;
using System.IO;

namespace WOEMapEditor
{
	/// <summary>
	/// Summary description for CTileLibrary.
	/// </summary>
	public class CTileLibrary
	{
		const int TILE_WIDTH = 16;
		const int TILE_HEIGHT = 16;

		public CTileLibrary()
		{
			//
			// TODO: Add constructor logic here
			//
			Stream s = this.GetType().Assembly.GetManifestResourceStream("WOEMapEditor.IconLibrary.jpg");
			m_TileSource = new Bitmap( s );
			m_Width = (m_TileSource.Width / TILE_WIDTH) + 1;
			m_Height = (m_TileSource.Height / TILE_HEIGHT) + 1;
		}

		private int		m_Count;			// number of tiles
		//private int[]	m_Tiles;			// Tile index to ID array?
		private Bitmap	m_TileSource;		// to be loaded from external File or resource...
		private int		m_Width;
		private int		m_Height;

		// Count
		public	int		Count
		{
			get
			{
				return m_Count;
			}
			set
			{
				m_Count = value;
			}
		}

		//Width
		public	int		Width
		{
			get
			{
				return 640; //m_TileSource.Width;;
			}
		}

		//Height
		public	int		Height
		{
			get
			{
				return 480; //m_TileSource.Height;;
			}
		}


		public void Draw(Graphics pGraphics, Rectangle destRect)
		{
			Rectangle srcRect = new Rectangle(0, 0, 10 * TILE_WIDTH, 5 * TILE_HEIGHT);
			Rectangle destRect2 = new Rectangle(0, 0, 10 * TILE_WIDTH, 5 * TILE_HEIGHT);
			pGraphics.DrawImage(m_TileSource, destRect2, srcRect, GraphicsUnit.Pixel);
		}

		public void DrawTile(Graphics pGraphics, int ID, int X, int Y)
		{
			Rectangle sourcerect = new Rectangle((ID % 32) * TILE_WIDTH,(ID / 32) * TILE_HEIGHT, TILE_WIDTH,TILE_HEIGHT);
			Rectangle destrect = new Rectangle(X,Y,TILE_WIDTH,TILE_HEIGHT);
			pGraphics.DrawImage(m_TileSource,destrect,sourcerect,GraphicsUnit.Pixel);
		}

		public void DrawTile(Graphics pGraphics, int ID, Rectangle destrect)
		{
			Rectangle sourcerect = new Rectangle((ID % 32) * TILE_WIDTH,(ID / 32) * TILE_HEIGHT, TILE_WIDTH,TILE_HEIGHT);
			pGraphics.DrawImage(m_TileSource,destrect,sourcerect,GraphicsUnit.Pixel);
		}

		public void GetSourceRect(Rectangle sourcerect, int ID)
		{
			sourcerect.X = ID % 32;
			sourcerect.Y = ID / 32;
			sourcerect.Width = TILE_WIDTH;
			sourcerect.Height = TILE_HEIGHT;
		}

		public int TileToTileID(int xindex, int yindex)
		{	
			if (xindex > m_Width)
				xindex = m_Width;
			if (yindex > m_Height)
				yindex = m_Height;
			return (yindex * 32 + xindex);
		}

		public void PointToBoundingRect(int x, int y, ref Rectangle bounding)
		{
			x = x / TILE_WIDTH;
			y = y / TILE_HEIGHT;
			bounding.Size = new Size(TILE_WIDTH + 6, TILE_HEIGHT + 6);
			bounding.X = (x * TILE_WIDTH) - 3;			
			bounding.Y = (y * TILE_HEIGHT) - 3;			
		}

		public void PointToTile(int x, int y, ref int xindex, ref int yindex)
		{
			xindex = x / TILE_WIDTH;
			yindex = y / TILE_HEIGHT;
		}
	}
}
