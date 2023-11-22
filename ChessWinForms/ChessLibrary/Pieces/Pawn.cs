using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Pawn : BasePiece
{
	public bool IsFirstMove { get ; set; }
	public bool IsDoubleMove { get; set; }
	
	public Pawn(Enum.Color color) : base(PieceType.Pawn, color)
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
	public bool IsCanEnPassant(GameController game, IPosition enemyPos)
	{
		BasePiece? enemyPiece = game.GetPiece(enemyPos);
		if (enemyPiece == null || enemyPiece.Type != PieceType.Pawn || enemyPiece.Color == Color) return false;
		
		Pawn enemyPawn = (Pawn) enemyPiece;
		
		if (!enemyPawn.IsDoubleMove) return false;
		
		return true;
	}

	/// <summary>
	/// Returns a list of attack moves for the pawn
	/// </summary>
	/// <param name="position"></param>
	/// <param name="game"></param>
	/// <param name="isForMoving"></param>
	/// <returns></returns>
	public List<IPosition> GetAttackMoves(IPosition position, GameController game, bool isForMoving=true)
	{
		List<IPosition> result = new();
		int dir = Color == Enum.Color.White ? 1 : -1;
		
		IPosition frontSidePos = new Position(position.X + 1*dir, position.Y + 1*dir);
		AddMoveToResult(game, result, frontSidePos, dir, isForMoving);
		
		frontSidePos = new Position(position.X + 1*dir, position.Y - 1*dir);
		AddMoveToResult(game, result, frontSidePos, dir, isForMoving);
		
		return result;
	}
	
	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new();
		int dir = Color == Enum.Color.White ? 1 : -1;

		IPosition pos1 = new Position(position.X + 1*dir, position.Y);
		BasePiece? frontPos1 = game.GetPiece(pos1);
		if (pos1 != null && frontPos1 == null)
		{
			result.Add(pos1);
		}

		if (IsFirstMove)
		{
			IPosition pos2 = new Position(position.X + 2*dir, position.Y);
			if (game.GetPiece(pos2) == null)
			{
				BasePiece? frontPos2 = game.GetPiece(pos1!);
				if (pos2 != null && frontPos2 == null)
				{
					result.Add(pos2);
				}
			}
		}

		// add attack moves positions
		result.AddRange(GetAttackMoves(position, game));
		
		return result;
	}

	public override bool AddMoveToResult(GameController game, List<IPosition> result, IPosition position)
	{
		// TODO: 
		throw new NotImplementedException();
	}
	public bool AddMoveToResult(GameController game, List<IPosition> result, IPosition position, int dir, bool isForMoving)
	{
		BasePiece? enemyPiece = game.GetPiece(position);
		if ((enemyPiece != null && enemyPiece.Color != Color) || !isForMoving)
		{
			result.Add(position);
		}
		// for en passant
		if (IsCanEnPassant(game,new Position(position.X-1*dir, position.Y)))
		{
			result.Add(position);
		}
		
		return true;
	}
}
