using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintFP.Shapes
{
	public class DrawFill : AbstractDrawShape
	{
		public DrawFill()
		{
			
		}

		public override void Draw(Point currentPoint, Point startedPoint, Brush stroke)
		{
			this.startedPoint = startedPoint;
			this.currentPoint = currentPoint;

		}

		public override Shape GetShape()
		{
			return shape;
		}
	}
}