using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintFP.Shapes
{
	public abstract class AbstractDrawShape 
	{
		protected Dictionary<DrawName, Func<Shape>> ShapesSet;
		protected Shape shape;
		protected Point point = new Point();
		protected Point currentPoint = new Point();
		protected Point startedPoint = new Point();
		public  abstract void Draw(Point currentPoint, Point startedPoint, Brush brushes);

		public virtual Shape GetShape()
		{
			return null;
		}
	}
}