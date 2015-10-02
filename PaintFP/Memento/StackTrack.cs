using System.Collections.Generic;
using System.Windows;

namespace PaintFP.Memento
{
	public class StackTrack
	{
		Stack<Memento> UndoStack = new Stack<Memento>();
		Stack<Memento> RedoStack = new Stack<Memento>();

		public Memento GetUndoMemento()
		{
			if (UndoStack.Count >= 2)
			{
				RedoStack.Push(UndoStack.Pop());
				return UndoStack.Peek();
			}
				return default(Memento);
		}

		public Memento GetRedoMemento()
		{
			if (RedoStack.Count != 0)
			{
				Memento memento = RedoStack.Pop();
				UndoStack.Push(memento);
				return memento;
			}
			return default(Memento);
		}

		public void InsertMementoUndoRedo(Memento memento)
		{
			if (memento != null)
			{
				UndoStack.Push(memento);
				RedoStack.Clear();
			}
		}

		public bool IsUndoPossible()
		{
			if (UndoStack.Count >= 2)
			{
				return true;
			}
			return false;
		}
		public bool IsRedoPossible()
		{
			if (RedoStack.Count != 2)
			{
				return true;
			}
			return false;
		}

	}
}