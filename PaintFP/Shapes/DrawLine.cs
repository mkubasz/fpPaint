using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintFP.Shapes
{
	public class DrawLine : AbstractDrawShape
	{

		public DrawLine()
		{
			shape = new Line();
		}

		public override void Draw(Point currentPoint, Point startedPoint, Brush stroke)
		{
			this.startedPoint = startedPoint;
			shape.Stroke = stroke;
			shape.StrokeThickness = 5;
			this.currentPoint = currentPoint;
			SetPosition();
		}
		protected void SetPosition()
		{
			((Line)shape).X2 = startedPoint.X;
			((Line)shape).X1 = currentPoint.X;
			((Line)shape).Y2 = startedPoint.Y;
			((Line)shape).Y1 = currentPoint.Y;
		}
		public override Shape GetShape()
		{
			return shape;
		}
	}
}