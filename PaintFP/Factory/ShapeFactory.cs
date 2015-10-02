using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using PaintFP.Shapes;

namespace PaintFP.Factory
{
	public class ShapeFactory : AbstractShapeFactory<DrawName, AbstractDrawShape>
	{

		public ShapeFactory()
		{

			ShapesSet = new Dictionary<DrawName, Func<AbstractDrawShape>>()
			{
				{DrawName.Pencil,()=> new DrawPencil() },
				{DrawName.Line, ()=> new DrawLine()},
				{DrawName.Circle,()=> new DrawCircle() },
				{DrawName.Rectangle,()=> new DrawRectangle() },
				{DrawName.Eraser, ()=> new DrawEraser()},
			};
		}
	}
}