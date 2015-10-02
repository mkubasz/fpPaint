using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintFP.Shapes
{
	public class FloodFill : IFloodFill
	{
		public void SetPixel(int x, int y, Color c, byte[] buffer, int rawStride)
		{
			int xIndex = x * 3;
			int yIndex = y * rawStride;
			int indexer = xIndex + yIndex;
			buffer[indexer] = c.R;
			buffer[indexer + 1] = c.G;
			buffer[indexer + 2] = c.B;
		}

		public int GetPixelColor(WriteableBitmap bm, int x, int y, int width, int height)
		{
			return 0;
		}

		public void SafeFloodFill(ref WriteableBitmap bm, int x, int y, int new_color, ref WriteableBitmap bmTop, ref int[] edges)
		{
			int bm_PixelWidth = bm.PixelWidth;
			int bm_PixelHeight = bm.PixelHeight;

			int old_color = GetPixelColor(bm, x, y, bm_PixelWidth, bm_PixelHeight);
			if (new_color == old_color) return;

			Stack<Point> pts = new Stack<Point>(1000);
			pts.Push(new Point(x, y));

			while (pts.Count > 0)
			{
				Point pt = (Point)pts.Pop();
				int ix = (int)pt.X;
				int ixmin = (int)pt.X - 1;
				int ixplus = (int)pt.X + 1;
				int iy = (int)pt.Y;
				int iymin = (int)pt.Y - 1;
				int iyplus = (int)pt.Y + 1;

				if (ix > edges[2])
					edges[2] = ix;
				if (ix < edges[0])
					edges[0] = ix;
				if (iy > edges[3])
					edges[3] = iy;
				if (iy < edges[1])
					edges[1] = iy;

				if (pt.X > 0) SafeCheckPoint(bm, pts, ref ixmin, ref iy, old_color, new_color, bm_PixelWidth, bmTop);
				if (pt.Y > 0) SafeCheckPoint(bm, pts, ref ix, ref iymin, old_color, new_color, bm_PixelWidth, bmTop);
				if (pt.X < bm_PixelWidth - 1) SafeCheckPoint(bm, pts, ref ixplus, ref iy, old_color, new_color, bm_PixelWidth, bmTop);
				if (pt.Y < bm_PixelHeight - 1) SafeCheckPoint(bm, pts, ref ix, ref iyplus, old_color, new_color, bm_PixelWidth, bmTop);
			}
		}

		public void SafeCheckPoint(WriteableBitmap bm, Stack<Point> pts, ref int x, ref int y, int old_color, int new_color, int bm_PixelWidth, WriteableBitmap bmTop)
		{
		//	int clr = bm.Pixels[x + bm_PixelWidth * y];
		//	if (clr == old_color)
			//{
			//	pts.Push(new Point(x, y));
			//	bm.Pixels[x + bm_PixelWidth * y] = new_color;
			//	bmTop.Pixels[x + bm_PixelWidth * y] = new_color;
		//	}
		}
	}
}