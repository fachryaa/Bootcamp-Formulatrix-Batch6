using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Bishop : BasePiece
{
	
	public Bishop(Enum.Color color) : base(Enum.PieceType.Bishop, color)
	{
		
	}

	public override List<Position> GetAvailableMoves(Position position, GameController game, bool forAttack=false)
	{
		List<Position> result = new();
		int x = position.X;
		int y = position.Y;
		
		// up right
		while(x < 7 && y < 7)
		{
			x++;
			y++;
			Position pos = new Position(x,y);
			BasePiece piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
				break;
			}
			else result.Add(pos);
		}
		
		x = position.X;
		y = position.Y;
		// up left
		while(x < 7 && y > 0)
		{
			x++;
			y--;
			Position pos = new Position(x,y);
			BasePiece piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
				break;
			}
			else result.Add(pos);
		}
		
		x = position.X;
		y = position.Y;
		// down right
		while(x > 0 && y < 7)
		{
			x--;
			y++;
			Position pos = new Position(x,y);
			BasePiece piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
				break;
			}
			else result.Add(pos);
		}
		
		x = position.X;
		y = position.Y;
		// down left
		while(x > 0 && y > 0)
		{
			x--;
			y--;
			Position pos = new Position(x,y);
			BasePiece piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
				break;
			}
			else result.Add(pos);
		}
		
		return result;
	}

}
