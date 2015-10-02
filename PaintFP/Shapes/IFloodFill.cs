using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintFP.Shapes
{
	public interface IFloodFill
	{
		void SetPixel(int x, int y, Color c, byte[] buffer, int rawStride);
		int GetPixelColor(WriteableBitmap bm, int x, int y, int width, int height);
		void SafeFloodFill(ref WriteableBitmap bm, int x, int y, int new_color, ref WriteableBitmap bmTop, ref int[] edges);
		void SafeCheckPoint(WriteableBitmap bm, Stack<Point> pts, ref int x, ref int y, int old_color, int new_color, int bm_PixelWidth, WriteableBitmap bmTop);
	}
}