using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Knight : BasePiece
{
	
	public Knight(Enum.Color color) : base(Enum.PieceType.Knight, color)
	{
		
	}

	private void AddMoveToResult(GameController game, List<IPosition> result, int posX, int posY)
	{
		IPosition pos = new Position(posX, posY);
		BasePiece? piece = game.GetPiece(pos);
		if (piece == null) result.Add(pos);
		if(piece != null && piece.Color != Color) result.Add(pos);
	}

	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new();
		
		if (position.X <= Board.BoardSize-3)
		{
			if (position.Y >= 1)
			{	
				AddMoveToResult(game, result, position.X+2, position.Y-1);
			}
			
			if (position.Y <= Board.BoardSize-2)
			{
				AddMoveToResult(game, result, position.X+2, position.Y+1);
			}
		}
		
		if (position.X <= Board.BoardSize-2)
		{
			if (position.Y >=  2)
			{
				AddMoveToResult(game, result, position.X+1, position.Y-2);
			}
			
			if (position.Y <= Board.BoardSize-3)
			{
				AddMoveToResult(game, result, position.X+1, position.Y+2);
			}
		}
		
		if (position.X >= 2)
		{
			if (position.Y >= 1)
			{
				AddMoveToResult(game, result, position.X-2, position.Y-1);
			}
			
			if (position.Y <= Board.BoardSize-2)
			{
				AddMoveToResult(game, result, position.X-2, position.Y+1);
			}
		}
		
		if (position.X >= 1)
		{
			if (position.Y >= 2)
			{
				AddMoveToResult(game, result, position.X-1, position.Y-2);
			}
			
			if (position.Y <= Board.BoardSize-3)
			{
				AddMoveToResult(game, result, position.X-1, position.Y+2);
			}
		}
		
		return result;
	}

}
