using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class King : BasePiece
{
	
	public King(Enum.Color color) : base(Enum.PieceType.King, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(Position position, GameController game)
    {
        throw new System.NotImplementedException();
    }

}
