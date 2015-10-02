using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintFP.Shapes
{
	public class DrawCircle : AbstractDrawShape
	{

		public DrawCircle()
		{
			shape = new Ellipse();
		}

		public override void Draw(Point currentPoint, Point startedPoint, Brush stroke)
		{
			this.startedPoint = startedPoint;
			this.currentPoint = currentPoint;
			shape.Stroke = stroke;
			shape.StrokeThickness = 5;
			SetPosition();

			if (startedPoint.X >= currentPoint.X && startedPoint.Y >= currentPoint.Y)
			{
				Canvas.SetLeft(shape, currentPoint.X);
				Canvas.SetTop(shape, currentPoint.Y);
			}
			if (startedPoint.X < currentPoint.X && startedPoint.Y < currentPoint.Y)
			{
				Canvas.SetLeft(shape, startedPoint.X);
				Canvas.SetTop(shape, startedPoint.Y);
			}
			if (startedPoint.X >= currentPoint.X && startedPoint.Y < currentPoint.Y)
			{
				Canvas.SetLeft(shape, currentPoint.X);
				Canvas.SetTop(shape, startedPoint.Y);
			}
			if (startedPoint.X < currentPoint.X && startedPoint.Y >= currentPoint.Y)
			{
				Canvas.SetLeft(shape, startedPoint.X);
				Canvas.SetTop(shape, currentPoint.Y);
			}

		}

		public override Shape GetShape()
		{
			return shape;
		}
		protected void SetPosition()
		{
			if (startedPoint.X  >= currentPoint.X)
			{
				point.X = currentPoint.X;
				shape.Width = startedPoint.X - currentPoint.X;
			}
			else
			{
				point.X = startedPoint.X;
				shape.Width = currentPoint.X - startedPoint.X;
			}
			if (startedPoint.Y >= currentPoint.Y)
            {
				point.Y = currentPoint.Y;
				shape.Height = startedPoint.Y - currentPoint.Y;
			}
			else
			{
				point.Y = startedPoint.Y;
				shape.Height = currentPoint.Y - startedPoint.Y;
			}
		}
	}
}