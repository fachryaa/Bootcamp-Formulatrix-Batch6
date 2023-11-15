using ChessLibrary;

namespace ChessWinForms.ChessLibrary.Pieces;

public interface IMoveable
{
	void AddMoveToResult(GameController game, List<IPosition> result, IPosition position);
}
