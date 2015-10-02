using System;
using System.Windows.Controls;

namespace PaintFP.Memento
{
	public class UndoRedo : IUndoRedo
	{
		private StackTrack _stackTrack = new StackTrack();
		private MementoOrigin _mementoOrigin = default(MementoOrigin);
		public event EventHandler EnableDisableUndoRedoFeature;

		public UndoRedo(Canvas canvas)
		{
			_mementoOrigin = new MementoOrigin(canvas);
		}
		public void Undo(int level)
		{
			Memento memento = null;
			for (int i = 1; i <= level; i++)
			{
				memento = _stackTrack.GetUndoMemento();
			}
			if (memento != null)
			{
				_mementoOrigin.SetMemento(memento);
			}
			if (EnableDisableUndoRedoFeature != null)
			{
				EnableDisableUndoRedoFeature(null, null);
			}
		}

		public void Redo(int level)
		{
			Memento memento = null;
			for (int i = 1; i <= level; i++)
			{
				memento = _stackTrack.GetRedoMemento();
			}
			if (memento != null)
			{
				_mementoOrigin.SetMemento(memento);
			}
			if (EnableDisableUndoRedoFeature != null)
			{
				EnableDisableUndoRedoFeature(null, null);
			}
		}

		public void SetStateForUndoRedo()
		{
			Memento memento = _mementoOrigin.GetMemento();
			_stackTrack.InsertMementoUndoRedo(memento);
			if (EnableDisableUndoRedoFeature != null)
			{
				EnableDisableUndoRedoFeature(null, null);
			}
		}

		public bool IsUndoPossible()
		{
			return _stackTrack.IsUndoPossible();
		}
		public bool IsRedoPossible()
		{
			return _stackTrack.IsRedoPossible();
		}
	}
}