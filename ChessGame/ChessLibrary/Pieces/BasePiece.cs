using System.Collections.Generic;
using ChessGame.ChessLibrary.Enum;

namespace ChessGame.ChessLibrary.Pieces;

public abstract class BasePiece
{
	public static int count = 0;
	public int Id;
	public Position? Position;
	public PieceType Type;
	public Color Color;
	public BasePiece(Position? position, PieceType type, Color color)
	{
		Id = count++;
		Position = position;
		Type = type;
		Color = color;
	}
	
	public void Move(GameController game)
	{
		
	}
	
	public abstract List<Position> GetAvailableMoves(GameController game);
	
	public void Capture(GameController game)
	{
		
	}
}
