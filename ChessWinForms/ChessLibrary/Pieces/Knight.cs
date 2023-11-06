using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Knight : BasePiece
{
	
	public Knight(Enum.Color color) : base(Enum.PieceType.Knight, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(GameController game)
    {
        throw new System.NotImplementedException();
    }

}
