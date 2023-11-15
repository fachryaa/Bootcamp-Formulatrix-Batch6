using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Rook : BasePiece
{
	public bool IsFirstMove { get; set; }
	public Rook(Enum.Color color) : base(Enum.PieceType.Rook, color)
	{
		IsFirstMove = true;
	}

	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new List<IPosition>();

		// vertical up
		for (int i=position.X+1; i < Board.BoardSize; i++)
		{
			AddMoveToResult(game, result, new Position(i, position.Y));
		}
		
		// vertical down
		for (int i=position.X-1; i >= 0; i--)
		{
			AddMoveToResult(game, result, new Position(i, position.Y));
		}
		
		// horizontal left
		for (int i=position.Y-1; i >= 0; i--)
		{
			AddMoveToResult(game, result, new Position(position.X, i));
		}
		
		// horizontal right
		for (int i=position.Y+1; i < Board.BoardSize; i++)
		{
			AddMoveToResult(game, result, new Position(position.X, i));
		}

		return result;
	}
	
	private void AddMoveToResult(GameController game, List<IPosition> result, IPosition pos)
	{
		var piece = game.GetPiece(pos);

		if (piece != null)
		{
			if (piece.Color != Color) result.Add(pos);
			return;
		}
		else result.Add(pos);
	}

}
