using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintFP.Shapes
{
	public class DrawPencil : AbstractDrawShape
	{

		public DrawPencil()
		{
			shape = new Line();
			
		}

		public override void Draw(Point currentPoint, Point startedPoint, Brush stroke)
		{
			this.startedPoint = startedPoint;
			this.currentPoint = currentPoint;
			shape.Stroke = stroke;
			shape.StrokeThickness = 1;
			SetPosition();
			

		}

		protected void SetPosition()
		{
			((Line)shape).X1 = startedPoint.X;
			((Line)shape).X2 = currentPoint.X;
			((Line)shape).Y1 = startedPoint.Y;
			((Line)shape).Y2 = currentPoint.Y;

		}
		public override Shape GetShape()
		{
			return shape;
		}
	}
}