using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using PaintFP.Shapes;

namespace PaintFP.Factory
{
	public class AbstractShapeFactory<TKey,TValue> where TValue : AbstractDrawShape
	{
		protected Dictionary<TKey,Func<TValue>> ShapesSet;

		public TValue GetItem(TKey key)
		{
			return ShapesSet.ContainsKey(key) ? ShapesSet[key]() : null;
		}
	}
}