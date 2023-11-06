using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Queen : BasePiece
{
	
	public Queen(Enum.Color color) : base(Enum.PieceType.Queen, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(GameController game)
    {
        throw new System.NotImplementedException();
    }

}
