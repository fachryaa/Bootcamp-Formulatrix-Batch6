using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Pawn : BasePiece
{
	
	public Pawn(Enum.Color color) : base(Enum.PieceType.Pawn, color)
	{
		
	}

    public override List<Position> GetAvailableMoves()
    {
        throw new System.NotImplementedException();
    }

}
