using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class Rook : BasePiece
{
	
	public Rook(Enum.Color color) : base(Enum.PieceType.Rook, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(Position position, GameController game)
    {
        throw new System.NotImplementedException();
    }

}
