using System.Collections.Generic;
using ChessGame.ChessLibrary.Enum;

namespace ChessGame.ChessLibrary.Pieces;

public class Queen : BasePiece
{
	
	public Queen(Position? position, PieceType type, Color color) : base(position, type, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(GameController game)
    {
        throw new System.NotImplementedException();
    }

}
