using System.Collections.Generic;
using ChessLibrary.Enum;
using ChessWinForms.ChessLibrary.Pieces;

namespace ChessLibrary.Pieces;

public class Queen : BasePiece, IMoveable
{
	
	public Queen(Enum.Color color) : base(Enum.PieceType.Queen, color)
	{
		
	}

	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new();
		
		// bishop moves
		int x = position.X;
		int y = position.Y;
		
		// up right
		while(x < Board.BoardSize-1 && y < Board.BoardSize-1)
		{
			x++;
			y++;
			AddMoveToResult(game, result, new Position(x,y));
		}
		
		x = position.X;
		y = position.Y;
		// up left
		while(x < Board.BoardSize-1 && y > 0)
		{
			x++;
			y--;
			AddMoveToResult(game, result, new Position(x,y));
		}
		
		x = position.X;
		y = position.Y;
		// down right
		while(x > 0 && y < Board.BoardSize-1)
		{
			x--;
			y++;
			AddMoveToResult(game, result, new Position(x,y));
		}
		
		x = position.X;
		y = position.Y;
		// down left
		while(x > 0 && y > 0)
		{
			x--;
			y--;
			AddMoveToResult(game, result, new Position(x,y));
		}
		
		// rook moves
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
	
	public void AddMoveToResult(GameController game, List<IPosition> result, IPosition pos)
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
