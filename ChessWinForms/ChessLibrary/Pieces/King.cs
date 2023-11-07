using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class King : BasePiece
{
	
	public King(Enum.Color color) : base(Enum.PieceType.King, color)
	{
		
	}

	public override List<Position> GetAvailableMoves(Position position, GameController game)
	{
		List<Position> result = new();
		int x = position.X+1;
		int y = position.Y;
		Position pos = new Position(x,y);
		BasePiece piece = game.GetPiece(x,y);
		
		if (position.X < 7)
		{
			// up
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);

			// up right
			if (position.Y < 7)
			{
				x = position.X+1;
				y = position.Y+1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
			
			// up left
			if (position.Y > 0)
			{
				x = position.X+1;
				y = position.Y-1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
		}
		
		if (position.X > 0)
		{
			// down
			x = position.X-1;
			y = position.Y;
			pos = new Position(x,y);
			piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);
			
			// down right
			if (position.Y < 7)
			{
				x = position.X-1;
				y = position.Y+1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
			
			// down left
			if (position.Y > 0)
			{
				x = position.X-1;
				y = position.Y-1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
		}
		
		// right
		if (position.Y < 7)
		{
			x = position.X;
			y = position.Y+1;
			pos = new Position(x,y);
			piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);
		}
		
		// left
		if (position.Y > 0)
		{
			x = position.X;
			y = position.Y-1;
			pos = new Position(x,y);
			piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);
		}
		
		
		
		
		
		
		return result;
	}

}
