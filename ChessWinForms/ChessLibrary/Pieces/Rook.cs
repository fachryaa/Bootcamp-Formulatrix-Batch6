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
		for (int i=position.X+1; i < ChessBoard.BoardSize; i++)
		{
			if (!AddMoveToResult(game, result, new Position(i, position.Y))) break;
		}
		
		// vertical down
		for (int i=position.X-1; i >= 0; i--)
		{
			if (!AddMoveToResult(game, result, new Position(i, position.Y))) break;
		}
		
		// horizontal left
		for (int i=position.Y-1; i >= 0; i--)
		{
			if (!AddMoveToResult(game, result, new Position(position.X, i))) break;
		}
		
		// horizontal right
		for (int i=position.Y+1; i < ChessBoard.BoardSize; i++)
		{
			if (!AddMoveToResult(game, result, new Position(position.X, i))) break;
		}

		return result;
	}
	
	public override bool AddMoveToResult(GameController game, List<IPosition> result, IPosition pos)
	{
		var piece = game.GetPiece(pos);

		if (piece != null)
		{
			if (piece.Color != Color) result.Add(pos);
			return false;
		}
		else result.Add(pos);
		
		return true;
	}

}
