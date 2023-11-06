using System.Collections.Generic;
using ChessGame.ChessLibrary.Enum;

namespace ChessGame.ChessLibrary.Pieces;

public class Knight : BasePiece
{
	
	public Knight(Position? position, PieceType type, Color color) : base(position, type, color)
	{
		
	}

    public override List<Position> GetAvailableMoves(GameController game)
    {
        throw new System.NotImplementedException();
    }

}
