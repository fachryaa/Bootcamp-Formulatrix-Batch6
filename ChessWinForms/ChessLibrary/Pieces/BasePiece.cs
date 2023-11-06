using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public abstract class BasePiece
{
	public static int count = 1;
	public int Id;
	public PieceType Type;
	public Enum.Color Color;
	public BasePiece(PieceType type, Enum.Color color)
	{
		Id = count++;
		Type = type;
		Color = color;
	}
	
	public void Move(GameController game)
	{
		
	}
	
	public abstract List<Position> GetAvailableMoves(Position pos, GameController game);
	
	public void Capture(GameController game)
	{
		
	}
}
