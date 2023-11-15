using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Bishop : BasePiece, IMoveable
{
	
	public Bishop(Enum.Color color) : base(Enum.PieceType.Bishop, color)
	{
		
	}

	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new();
		int x = position.X;
		int y = position.Y;
		
		// up right
		while(x < Board.BoardSize-1 && y < Board.BoardSize-1)
		{
			x++;
			y++;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		x = position.X;
		y = position.Y;
		// up left
		while(x < Board.BoardSize-1 && y > 0)
		{
			x++;
			y--;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		x = position.X;
		y = position.Y;
		// down right
		while(x > 0 && y < Board.BoardSize-1)
		{
			x--;
			y++;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		x = position.X;
		y = position.Y;
		// down left
		while(x > 0 && y > 0)
		{
			x--;
			y--;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		return result;
	}
	
	public bool AddMoveToResult(GameController game, List<IPosition> result, IPosition position)
	{
		BasePiece? piece = game.GetPiece(position);
		if (piece != null)
		{
			if (piece.Color != Color) result.Add(position);
			return false;
		}
		else result.Add(position);
		
		return true;
	}

}
