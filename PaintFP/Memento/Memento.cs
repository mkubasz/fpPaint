using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace PaintFP.Memento
{
	public class Memento
	{
		private List<UIElement> _containerState;
		public List<UIElement> ContainerState => _containerState;

		public Memento(List<UIElement> constainerState)
		{
			this._containerState = constainerState;
		}
	}

}