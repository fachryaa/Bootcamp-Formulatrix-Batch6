using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Pawn : BasePiece
{
	public bool IsFirstMove { get ; set; }
	public bool IsDoubleMove { get; set; }
	
	public Pawn(Enum.Color color) : base(Enum.PieceType.Pawn, color)
	{
		IsFirstMove = true;
		IsDoubleMove = false;
	}
	
	/// <summary>
	/// Returns true if the pawn can do en passant move
	/// </summary>
	/// <param name="game"></param>
	/// <param name="enemyPos"></param>
	/// <returns></returns>
	public bool IsCanEnPassant(GameController game, Position enemyPos)
	{
		BasePiece enemyPiece = game.GetPiece(enemyPos);
		if (enemyPiece == null || enemyPiece.Type != PieceType.Pawn || enemyPiece.Color == Color) return false;
		
		Pawn enemyPawn = (Pawn) enemyPiece;
		
		if (!enemyPawn.IsDoubleMove) return false;
		
		// TODO: Add en passant move condition -> static method return bool isEnPassantMove(from, to)
		
		
		
		return true;
	}

	/// <summary>
	/// Returns a list of attack moves for the pawn
	/// </summary>
	/// <param name="position"></param>
	/// <param name="game"></param>
	/// <param name="isForMoving"></param>
	/// <returns></returns>
	public List<Position> GetAttackMoves(IPosition position, GameController game, bool isForMoving=true)
	{
		List<Position> result = new();
		int dir = Color == Enum.Color.White ? 1 : -1;
		
		// if paling kiri
		if (position.Y == 0)
		{
			Position frontSidePos = new Position(position.X + 1*dir, position.Y + 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
			
			// for en passant
			if (IsCanEnPassant(game,new Position(position.X, position.Y+1*dir)))
			{
				result.Add(frontSidePos);
			}
		}
		// if paling kanan
		else if (position.Y == Board.BoardSize-1)
		{
			Position frontSidePos = new Position(position.X + 1*dir, position.Y - 1);
			BasePiece enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
			
			// for en passant
			if (IsCanEnPassant(game,new Position(position.X, position.Y-1*dir)))
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
			// for en passant
			if (IsCanEnPassant(game,new Position(position.X, position.Y+1*dir)))
			{
				result.Add(frontSidePos);
			}
			
			frontSidePos = new Position(position.X + 1*dir, position.Y - 1*dir);
			enemyPiece = game.GetPiece(frontSidePos);
			if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
			{
				result.Add(frontSidePos);
			}
			// for en passant
			if (IsCanEnPassant(game,new Position(position.X, position.Y-1*dir)))
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
			Position? pos2 = position.X < Board.BoardSize-1 ? new Position(position.X + 2*dir, position.Y) : default;
			if (game.GetPiece(pos2) == null)
			{
				BasePiece frontPos2 = game.GetPiece(pos1);
				if (pos2 != null && frontPos2 == null)
				{
					result.Add(pos2);
				}
			}

			// IsFirstMove = false;
		}

		// add attack moves positions
		result = result.Concat(GetAttackMoves(position, game)).ToList();
		
		return result;
	}
	

}
