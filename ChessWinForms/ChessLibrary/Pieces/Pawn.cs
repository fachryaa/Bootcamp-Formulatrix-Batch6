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

	public override List<Position> GetAvailableMoves(Position position, GameController game)
	{
		List<Position> result = new();

		if(Color == Enum.Color.White)
		{
			Position pos1 = position.X < 7 ? new Position(position.X + 1, position.Y) : default;
			BasePiece frontPos1 = game.GetPiece(pos1);
			if (pos1 != null && frontPos1 == null)
			{
				result.Add(pos1);
			}

			if (IsFirstMove)
			{
				Position? pos2 = position.X < 7 ? new Position(position.X + 2, position.Y) : default;
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
		}
		else
		{
			Position pos1 = position.X > 0 ? new Position(position.X - 1, position.Y) : default;
			BasePiece frontPos1 = game.GetPiece(pos1);
			if (pos1 != null && frontPos1 == null)
			{
				result.Add(pos1);
			}

			if (IsFirstMove)
			{
				Position pos2 = position.X > 0 ? new Position(position.X - 2, position.Y) : default;
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

			if (position.Y == 0)
			{
				Position frontSidePos = new Position(position.X - 1, position.Y + 1);
				BasePiece enemyPiece = game.GetPiece(frontSidePos);
				if (enemyPiece != null && enemyPiece.Color != Color)
				{
					result.Add(frontSidePos);
				}
			}
			else if (position.Y == 7)
			{
				Position frontSidePos = new Position(position.X - 1, position.Y - 1);
				BasePiece enemyPiece = game.GetPiece(frontSidePos);
				if (enemyPiece != null && enemyPiece.Color != Color)
				{
					result.Add(frontSidePos);
				}
			}
			else
			{
				Position frontSidePos = new Position(position.X - 1, position.Y - 1);
				BasePiece enemyPiece = game.GetPiece(frontSidePos);
				if (enemyPiece != null && enemyPiece.Color != Color)
				{
					result.Add(frontSidePos);
				}
				frontSidePos = new Position(position.X - 1, position.Y + 1);
				enemyPiece = game.GetPiece(frontSidePos);
				if (enemyPiece != null && enemyPiece.Color != Color)
				{
					result.Add(frontSidePos);
				}
			}
		}
		
		
		return result;
	}
	

}
