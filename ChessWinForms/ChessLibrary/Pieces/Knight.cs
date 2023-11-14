using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Knight : BasePiece
{
	
	public Knight(Enum.Color color) : base(Enum.PieceType.Knight, color)
	{
		
	}

	public override List<Position> GetAvailableMoves(Position position, GameController game, bool forAttack=false)
	{
		List<Position> result = new();
		
		if (position.X <= Board.BoardSize-3)
		{
			if (position.Y >= 1)
			{
				Position pos = new(position.X+2, position.Y-1);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
			
			if (position.Y <= Board.BoardSize-2)
			{
				Position pos = new(position.X+2, position.Y+1);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
		}
		
		if (position.X <= Board.BoardSize-2)
		{
			if (position.Y >=  2)
			{
				Position pos = new(position.X+1, position.Y-2);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
			
			if (position.Y <= Board.BoardSize-3)
			{
				Position pos = new(position.X+1, position.Y+2);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
		}
		
		if (position.X >= 2)
		{
			if (position.Y >= 1)
			{
				Position pos = new(position.X-2, position.Y-1);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
			
			if (position.Y <= Board.BoardSize-2)
			{
				Position pos = new(position.X-2, position.Y+1);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
		}
		
		if (position.X >= 1)
		{
			if (position.Y >= 2)
			{
				Position pos = new(position.X-1, position.Y-2);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
			
			if (position.Y <= Board.BoardSize-3)
			{
				Position pos = new(position.X-1, position.Y+2);
				BasePiece piece = game.GetPiece(pos);
				if (piece == null) result.Add(pos);
				if(piece != null && piece.Color != Color) result.Add(pos);
			}
		}
		
		return result;
	}

}
