namespace PaintFP.Memento
{
	public interface IUndoRedo
	{
			void Undo(int level);
			void Redo(int level);
			void SetStateForUndoRedo();
	}
}