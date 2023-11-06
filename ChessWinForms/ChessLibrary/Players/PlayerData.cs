using System.Collections.Generic;
using ChessLibrary.Enum;
using ChessLibrary.Pieces;

namespace ChessLibrary.Players;

public class PlayerData
{
	public List<BasePiece> Pieces = new();
	
	public PlayerData(Enum.Color color)
	{
		InitPiece(color);
	}

	public void InitPiece(Enum.Color color)
	{
        // TODO: Add pieces to list
        int sidePawn = color == Enum.Color.White ? 1 : 6;
        int sidePiece = color == Enum.Color.White ? 0 : 7;

        // Add Pawn
        for (int i = 0; i < 8; i++)
        {
            Pieces.Add(new Pawn(color));
        }

        // Add another pieces
        Pieces.Add(new Rook(color));
        Pieces.Add(new Rook(color));

        Pieces.Add(new Knight(color));
        Pieces.Add(new Knight(color));
        
        Pieces.Add(new Bishop(color));
        Pieces.Add(new Bishop(color));
        
        Pieces.Add(new Bishop(color));
        Pieces.Add(new Bishop(color));

        Pieces.Add(new Queen(color));
        Pieces.Add(new King(color));
    }
}
