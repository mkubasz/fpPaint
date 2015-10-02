using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintFP.Shapes
{
	public class DrawEraser : AbstractDrawShape 
	{
		public DrawEraser()
		{
			shape = new Line();
		}

		public override void Draw(Point currentPoint, Point startedPoint, Brush stroke)
		{
			this.startedPoint = startedPoint;
			shape.Stroke = Brushes.White;
			shape.StrokeThickness = 15;
			
			this.currentPoint = currentPoint;
			((Line)shape).X1 = startedPoint.X;
			((Line)shape).X2 = currentPoint.X;
			((Line)shape).Y1 = startedPoint.Y;
			((Line)shape).Y2 = currentPoint.Y;
			//SetPosition();

		}

		public override Shape GetShape()
		{
			return shape;
		}
	}
}