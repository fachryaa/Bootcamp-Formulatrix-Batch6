using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Bishop : BasePiece
{
	
	public Bishop(Enum.Color color) : base(Enum.PieceType.Bishop, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(Position position, GameController game)
    {
        throw new System.NotImplementedException();
    }

}
