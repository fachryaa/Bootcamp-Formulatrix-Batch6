using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Queen : BasePiece
{
	
	public Queen(Enum.Color color) : base(Enum.PieceType.Queen, color)
	{
		
	}

	public override List<Position> GetAvailableMoves(Position position, GameController game)
	{
		List<Position> result = new();
		
		// bishop moves
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
		
		// rook moves
				// vertical up
		for (int i=position.X+1; i < 8; i++)
		{
			Position pos = new(i, position.Y);
			var piece = game.GetPiece(pos);

            if (piece != null)
            {
                if (piece.Color != Color) result.Add(pos);
                break;
            }
            else result.Add(pos);
		}
		
		// vertical down
		for (int i=position.X-1; i >= 0; i--)
		{
			Position pos = new(i, position.Y);
			var piece = game.GetPiece(pos);

            if (piece != null)
            {
                if (piece.Color != Color) result.Add(pos);
                break;
            }
            else result.Add(pos);
		}
		
		// horizontal left
		for (int i=position.Y-1; i >= 0; i--)
		{
			Position pos = new(position.X, i);
			var piece = game.GetPiece(pos);

			if (piece != null)
			{
				if(piece.Color != Color) result.Add(pos);
				break;
			}
			else result.Add(pos);
		}
		
		// horizontal right
		for (int i=position.Y+1; i < 8; i++)
		{
			Position pos = new(position.X, i);
			var piece = game.GetPiece(pos);

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
