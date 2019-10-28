
using System;
using System.Drawing;
using System.IO;

namespace WOEMapEditor
{
	/// <summary>
	/// Summary description for CMap.
	/// </summary>
	public class CMap
	{
		const int TILE_WIDTH = 16;
		const int TILE_HEIGHT = 16;		
		const int ZOOM = 4;
		const int MAPFILE_ID = 0x1222;

		public CMap()
		{
			int i,j;
			int[,] mapConeriaTown =
			{
				{33, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34,  6,  1,  6, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 33},
				{33,  6,  5,  5,  0,  0,  0,  0,  0,  0,  0,  5,  5,  5,  5,  5,  1,  5,  6,  6,  6,  6,  5,  5,  5,  5,  5,  6,  6,  6,  6, 33},
				{33,  5, 67, 67, 67,  0, 67, 67, 67,  0,  0,  0,  5, 96,  5,  0,  1,  0,  6,  6,  6,  6,  0, 67, 67, 67,  0,  6,  6,  5,  5, 33},
				{33,  0, 67,130, 67, 69, 67,131, 67, 69,  0,  0,  0, 96,  0,  0,  1,  0,  6,  6,  6,  5,  0, 71,132, 71, 69,  5,  6, 96,  0, 33},
				{33,  0, 70, 64, 70, 68, 70, 64, 70, 68,  0,  4,  1, 99,  1,  1,  1,  0,  5,  5,  5,  0,  0, 70, 64, 70, 68,  0,  5, 96,  0, 33},
				{33,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0, 96,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0, 96,  0, 33},
				{33,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0, 96,  0,  0,  1,  0,  0,  0,  0, 32, 32,  0,  1,  0, 32, 32,  0, 96,  0, 33},
				{33,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 96, 96, 96, 97, 96, 96, 96, 96, 96, 96, 96, 97, 96, 96, 96, 96, 96,  0, 33},
				{33,  0,  0,  0, 67, 67, 67, 67,  0, 67, 67, 67, 67,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0, 67, 67, 67, 96,  0, 33},
				{33,  6,  0,  0, 67, 67,129, 67, 69, 67, 67,128, 67, 69,  0,  5,  1,  5,  0,  0,  0,  0,  0,  0,  1,  0, 67,133, 67, 96,  0, 33},
				{33,  6,  6,  0, 65, 65, 64, 65, 68, 65, 65, 64, 65, 68,  4,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0, 65, 64, 65, 96,  0,  5},
				{33,  6,  6,  6,  0,  0,  1,  0,  0,  0,  0,  1,  0,  5,  1,  1,  1,  1,  1,  5,  0,  0,  0,  0,  1,  0,  0,  1,  0, 96,  0,  5},
				{33,  6,  5,  5,  0,  0,  2,  1,  1,  1,  1,  1,  1,  1,  1,  1, 98,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1, 99,  0,  0},
				{33,  6, 35,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  5,  1,  1,  1,  1,  1,  5,  0,  0,  0,  0,  0,  0,  0,  0,  0, 96,  0,  5},
				{33,  5,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  1,  1,  1,  3,  0,  0, 96, 96, 96, 96, 96, 96, 96, 96, 96,  0,  5},
				{33, 34, 34, 34, 34, 34, 34, 34, 33, 67, 67, 67, 67, 67,  0,  5,  1,  5,  0,  0,  0, 96,  0, 33, 34, 34, 34, 34, 34, 34, 34, 34},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33, 67, 67, 67, 67, 67,  0,  0,  1,  0,  0,  0,  0, 96,  0, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33, 65, 65, 66, 65, 65, 69,  5,  1,  5,  0,  0,  0, 96,  0, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33, 65, 65, 64, 65, 65, 68,  0,  1,  0,  0,  0,  0, 96,  0, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33,  0,  0,  1,  0,  0,  0,  5,  1,  5,  0,  0,  0, 96,  0, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33,  0, 32,  1, 32,  0,  0,  0,  1,  0,  0,  0,  0, 96,  0, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  0,  6, 96,  6, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 33,  0,  0,  0,  0,  0,  0,  5,  1,  5,  0,  0,  5,  5,  5, 33,  0,  0,  0,  0,  0,  0,  0,  0},
				{ 0,  0,  0,  0,  0,  0,  0,  0, 34, 34, 34, 34, 34, 34,  5,  5,  1,  5,  5, 34, 34, 34, 34, 34,  0,  0,  0,  0,  0,  0,  0,  0},
			};

			m_Width = 32;
			m_Height = 32;
			m_DefaultTileID = 0;
			m_Tiles = new int[m_Height,m_Width];
			m_TileLibrary = null;

			m_BackBuffer = new Bitmap(m_Width * TILE_WIDTH, m_Height * TILE_HEIGHT);
			m_BackBufferDC = Graphics.FromImage(m_BackBuffer);

			m_nTilesVert = 10;
			m_nTilesHoriz = 10;
			m_OffsetX = 50;
			m_OffsetY = 50;
			m_Zoom = ZOOM;

			for (i=0; i<24; i++)
			{
				for (j=0; j<m_Width; j++)
					m_Tiles[i,j] = mapConeriaTown[i,j];				
			}
			for (i=24; i<m_Height; i++)
				for (j=0; j<m_Width; j++)
					m_Tiles[i,j] = 0;

		}

		private int				m_Width;			// map width (tiles)
		private int				m_Height;			// map height (tiles)
		private int				m_DefaultTileID;	// default tile id for outside normal bounds
		private int[,]			m_Tiles;			// logical 2-D array for map building
		private Bitmap			m_BackBuffer;		// Back Buffer for plotting graphical map data.. We will not store in picture box.
		private Graphics		m_BackBufferDC;
		private int				m_OffsetX;
		private int				m_OffsetY;
		private int				m_nTilesVert;
		private int				m_nTilesHoriz;
		private int				m_Zoom;

		private CTileLibrary	m_TileLibrary;		// Reference to a Tile Library

		// Map Width (in Tiles)
		public	int		Width
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

		// Map Zoom (X)
		public	int		Zoom
		{
			get
			{
				return m_Zoom;
			}
			set
			{
				m_Zoom = value;
			}
		}

		// Map Height (in Tiles)
		public	int		Height
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
		// Default Tile ID
		public	int		DefaultTileID
		{
			get
			{
				return m_DefaultTileID;
			}
			set
			{
				m_DefaultTileID = value;
			}
		}

		// Default Tile ID
		public	CTileLibrary	TileLibrary
		{
			set
			{
				m_TileLibrary = value;
			}
		}

		// OffsetX (pixels)
		public	int		OffsetX
		{
			set
			{
				m_OffsetX = value;
			}
		}
		// OffsetY (pixels)
		public	int		OffsetY
		{
			set
			{
				m_OffsetY = value;
			}
		}

		// TilesVert
		public	int		TilesVert
		{
			set
			{
				m_nTilesVert = value;
			}
		}
		// TilesHoriz
		public	int		TilesHoriz
		{
			set
			{
				m_nTilesHoriz = value;
			}
		}


		public void Refresh()
		{
			int i;
			int j;			

			for (i=0; i<m_Height; i++)
				for (j=0; j<m_Width; j++)
				{					
					m_TileLibrary.DrawTile(m_BackBufferDC, m_Tiles[i,j],j * TILE_WIDTH, i * TILE_HEIGHT);
				}
		}

		public void Draw(Graphics pGraphics, Rectangle destRect, int TileX, int TileY)
		{
			int xindex = 0;
			int yindex = 0;
			int width;
			int height;

			width = destRect.Width / m_Zoom;
			height = destRect.Height / m_Zoom;

			PointToTile(destRect.X,destRect.Y,ref xindex, ref yindex);
			destRect.X = xindex * m_Zoom * TILE_WIDTH;
			destRect.Y = yindex * m_Zoom * TILE_HEIGHT;
			destRect.Width = (m_nTilesHoriz - xindex) * TILE_WIDTH * m_Zoom;
			destRect.Height = (m_nTilesVert - yindex) * TILE_HEIGHT * m_Zoom;

			Rectangle srcRect = new Rectangle((TileX + xindex) * TILE_WIDTH, (TileY + yindex) * TILE_HEIGHT, (m_nTilesHoriz - xindex) * TILE_WIDTH, (m_nTilesVert - yindex) * TILE_HEIGHT);
			pGraphics.DrawImage(m_BackBuffer, destRect, srcRect, GraphicsUnit.Pixel);			
		}

		public void PointToTile(int x, int y, ref int xindex, ref int yindex)
		{
			// unscale zoom;
			x = x / m_Zoom;
			y = y / m_Zoom;
			
			xindex = x / TILE_WIDTH;
			yindex = y / TILE_HEIGHT;
		}

		public void PointToBoundingRect(int x, int y, ref Rectangle bounding)
		{
			x = x / m_Zoom;
			y = y / m_Zoom;
			x = x / TILE_WIDTH;
			y = y / TILE_HEIGHT;
			bounding.Size = new Size((TILE_WIDTH * m_Zoom) + 6, (TILE_HEIGHT * m_Zoom) + 6);
			bounding.X = (x * TILE_WIDTH * m_Zoom) - 3;
			bounding.Y = (y * TILE_HEIGHT * m_Zoom) - 3;
		}

		public void PlotTile(int xindex, int yindex, int TileID)
		{
			if (xindex < 0 || yindex < 0 || yindex >= m_Height || xindex >= m_Width)
				return;
			m_Tiles[yindex,xindex] = TileID;
			m_TileLibrary.DrawTile(m_BackBufferDC, TileID, xindex * TILE_WIDTH, yindex * TILE_HEIGHT);
		}

		public int Save(String strFilename)
		{
			int i,j;

			FileStream file = new FileStream(strFilename, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter(file);

			sw.WriteLine("ID: {0}",MAPFILE_ID.ToString());
			sw.WriteLine("WIDTH: {0}",m_Width.ToString());
			sw.WriteLine("HEIGHT: {0}",m_Height.ToString());
			sw.WriteLine("DATA:");

			for (i=0; i<m_Height; i++)
			{
				for (j=0; j<m_Width; j++)
					sw.Write("{0},", m_Tiles[i,j]);
				sw.WriteLine();
			}
			sw.Close();

			return 0;
		}

		public int Load(String strFilename)
		{
			int i;
			
			FileStream file;						
			StreamReader sr;
			String strLine;
			int index;
			char[] delim = {':'};
			char[] delim2 = {','};
			int id = -1;
			int width = -1;
			int height = -1;
			int data = -1;
			String strVar;
			String strValue;
			String[] arrValues;
			int count;
			int[] arrData;
			int rowcount = 0;

			arrData = new int[128];

			try
			{
				file = new FileStream(strFilename, FileMode.Open, FileAccess.Read);
				sr = new StreamReader(file);
			}
			catch
			{
				return -1;
			}

			while(sr.Peek() >= 0)
			{					
				strLine = sr.ReadLine();
				index = strLine.IndexOfAny(delim);
				if (index > 0)
				{
					strVar = strLine.Substring(0,index);
					strVar = strVar.Trim();					
					strVar = strVar.ToLower();
					strValue = strLine.Substring(index+1);
					strValue = strValue.Trim();
					strValue = strValue.ToLower();

					if (strVar == "id")
						id = Convert.ToInt32(strValue);
					else if (strVar == "width")
						width = Convert.ToInt32(strValue);
					else if (strVar == "height")
						height = Convert.ToInt32(strValue);
					else if (strVar == "data")
					{
						data = 1;						
						break;
					}
				}
			}

			if (width <= 0 || height <=0 || data < 0 || id < 0)
				return -1;
			if (width < 8 || width > 64)
				return -1;
			if (height < 8 || height > 64)
				return -1;

			// Build Backbuffer
			m_Width = width;
			m_Height = height;
			m_Tiles = new int[m_Height,m_Width];
			m_BackBuffer = new Bitmap(m_Width * TILE_WIDTH, m_Height * TILE_HEIGHT);
			m_BackBufferDC = Graphics.FromImage(m_BackBuffer);

			while(sr.Peek() >= 0)
			{
				strLine = sr.ReadLine();
				strLine = strLine.Trim();
				if (strLine.Length > 1)
				{
					arrValues = strLine.Split(delim2);

					count = 0;
					for (i=0; i<=arrValues.GetUpperBound(0); i++)
					{
						strValue = arrValues[i].Trim();
						if (strValue.Length > 0)
						{
							arrData[count] = Convert.ToByte(arrValues[i],10);
							count++;
						}
					}
					if (count != width)
						return -1;

					for (i=0; i<width; i++)
						m_Tiles[rowcount,i] = arrData[i];
					rowcount++;
				}
			}			
			sr.Close();

			Refresh();

			return 0;
		}

		public bool CreateNew(int width, int height, int defaulttile)
		{
			int i, j;

			if (width < 8 || width > 64)
				return false;
			if (height < 8 || height > 64)
				return false;

			// Build Backbuffer
			m_Width = width;
			m_Height = height;

			try
			{
				m_Tiles = new int[m_Height,m_Width];

				for (i=0; i<m_Height; i++)
					for (j=0; j<m_Width; j++)
						m_Tiles[i,j] = defaulttile;

				m_BackBuffer = new Bitmap(m_Width * TILE_WIDTH, m_Height * TILE_HEIGHT);
				m_BackBufferDC = Graphics.FromImage(m_BackBuffer);

				Refresh();
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
