using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Rook : BasePiece
{
	public bool IsFirstMove { get; set; }
	public Rook(Enum.Color color) : base(Enum.PieceType.Rook, color)
	{
		IsFirstMove = true;
	}
	
	public Rook(BasePiece promoted, Enum.Color color) : base(promoted, Enum.PieceType.Rook, color)
	{
		IsFirstMove = true;
	}



    public override List<Position> GetAvailableMoves(Position position, GameController game, bool forAttack=false)
    {
        List<Position> result = new List<Position>();

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
