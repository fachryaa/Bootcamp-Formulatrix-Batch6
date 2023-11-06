using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Pawn : BasePiece
{
	
	public Pawn(Enum.Color color) : base(Enum.PieceType.Pawn, color)
	{
		
	}

	public override List<Position> GetAvailableMoves(Position position, GameController game)
	{
		Position pos1 = position.X < 7 ? new Position(position.X + 1, position.Y) : default;
		List<Position> result = new();
		if (pos1 != default)
		{
			result.Add(pos1);
		}
		
		if (position.Y == 0)
		{
			Position frontSidePos = new Position(position.X + 1, position.Y + 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if (enemyPiece != null && enemyPiece.Color != Color)
			{
				result.Add(frontSidePos);
			}
		}
		else if (position.Y == 7)
		{
			Position frontSidePos = new Position(position.X + 1, position.Y - 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if (enemyPiece != null && enemyPiece.Color != Color)
			{
				result.Add(frontSidePos);
			}
		}
		else 
		{
			Position frontSidePos = new Position(position.X + 1, position.Y + 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if (enemyPiece != null && enemyPiece.Color != Color)
			{
				result.Add(frontSidePos);
			}
			frontSidePos = new Position(position.X + 1, position.Y - 1);
			enemyPiece = game.GetPiece(frontSidePos);
			if (enemyPiece != null && enemyPiece.Color != Color)
			{
				result.Add(frontSidePos);
			}
		}
		
		return result;
	}

}
