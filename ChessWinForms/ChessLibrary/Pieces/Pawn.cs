using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Pawn : BasePiece
{
	public bool IsFirstMove { get ; set; }
	
	public Pawn(Enum.Color color) : base(Enum.PieceType.Pawn, color)
	{
		IsFirstMove = true;
	}

	public List<Position> GetAttackMoves(Position position, GameController game, bool isForMoving=true)
	{
		List<Position> result = new();
		int dir = Color == Enum.Color.White ? 1 : -1;
		
		if (position.Y == 0)
		{
			Position frontSidePos = new Position(position.X + 1*dir, position.Y + 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
		}
		else if (position.Y == 7)
		{
			Position frontSidePos = new Position(position.X + 1*dir, position.Y - 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
		}
		else
		{
			Position frontSidePos = new Position(position.X + 1*dir, position.Y + 1*dir);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
			frontSidePos = new Position(position.X + 1*dir, position.Y - 1*dir);
			enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
		}
		
		return result;
	}
	public override List<Position> GetAvailableMoves(Position position, GameController game, bool forAttack=false)
	{
		List<Position> result = new();
		int dir = Color == Enum.Color.White ? 1 : -1;

		Position pos1 = position.X < 7 ? new Position(position.X + 1*dir, position.Y) : default;
		BasePiece frontPos1 = game.GetPiece(pos1);
		if (pos1 != null && frontPos1 == null)
		{
			result.Add(pos1);
		}

		if (IsFirstMove)
		{
			Position? pos2 = position.X < 7 ? new Position(position.X + 2*dir, position.Y) : default;
			if (game.GetPiece(pos2) == null)
			{
				BasePiece frontPos2 = game.GetPiece(pos1);
				if (pos2 != null && frontPos2 == null)
				{
					result.Add(pos2);
				}
			}

			IsFirstMove = false;
		}

		// add attack moves positions
		result = result.Concat(GetAttackMoves(position, game)).ToList();
		
		return result;
	}
	

}
