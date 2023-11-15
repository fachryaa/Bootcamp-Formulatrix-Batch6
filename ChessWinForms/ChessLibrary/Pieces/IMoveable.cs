namespace ChessLibrary.Pieces;

public interface IMoveable
{
	IEnumerable<IPosition> GetAvailableMoves(IPosition pos, GameController game, bool forAttack=false);

	bool AddMoveToResult(GameController game, List<IPosition> result, IPosition position);
}
