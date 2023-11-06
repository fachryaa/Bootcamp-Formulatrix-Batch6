using System.Collections.Generic;
using ChessGame.ChessLibrary.Enum;
using ChessGame.ChessLibrary.Pieces;

namespace ChessGame.ChessLibrary.Players;

public class PlayerData
{
	public List<BasePiece> Pieces = new();
	
	public PlayerData(Color color)
	{
		// TODO: Add pieces to list
		for (int i=0 ; i<8 ; i++)
		{
			Pieces.Add(new Pawn(new Position(i, 1), PieceType.Pawn, color));
		}
	}
}
