using System.Windows;
using System.Windows.Controls;

namespace PaintFP.Extension
{
	public static class CanvasExstension
	{
		public static int AddChild(this Canvas canvas, UIElement element, int x, int y)
		{
			Canvas.SetLeft(element,x);
			Canvas.SetTop(element,y);
			return canvas.Children.Add(element);
		} 
	}
}