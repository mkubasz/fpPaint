using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Xml;

namespace PaintFP.Memento
{
	public class MementoOrigin
	{
		private Canvas _Container;

		public MementoOrigin(Canvas cointainer)
		{
			_Container = cointainer;
		}

		public Memento GetMemento()
		{
			List<UIElement> _ContainerState = new List<UIElement>();
			foreach (UIElement item in _Container.Children)
			{
				if (!(item is Thumb))
				{
					UIElement newItem = DeepClone(item);
					_ContainerState.Add(newItem);
				}
			}
			return new Memento(_ContainerState);
		}

		public void SetMemento(Memento memento)
		{
			_Container.Children.Clear();
			Memento mementoTemp = MementoClone(memento);
			foreach (UIElement item in mementoTemp.ContainerState)
			{
				((Shape) item).Stroke = System.Windows.Media.Brushes.Black;
				_Container.Children.Add(item);
			}
		}

		public Memento MementoClone(Memento memento)
		{
			List<UIElement> _ContainerState = new List<UIElement>();
			foreach (var item in memento.ContainerState)
			{
				if (!(item is Thumb))
				{
					UIElement newItem = DeepClone(item);
					_ContainerState.Add(newItem);
				}
			}
			return new Memento(_ContainerState);
		}

		private UIElement DeepClone(UIElement element)
		{
			string shapeString = XamlWriter.Save(element);
			StringReader stringReader = new StringReader(shapeString);
			XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
			UIElement deepCopyObject = (UIElement) XamlReader.Load(xmlTextReader);
			return deepCopyObject;
		}
	}
}