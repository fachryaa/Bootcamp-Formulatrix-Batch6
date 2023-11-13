using ChessLibrary;
using ChessLibrary.Pieces;

namespace ChessLibrary;

public class Board : IBoard
{
	public int BoardSize { get; set; }
	Dictionary<Position, BasePiece> IBoard.Board { get; set; }


}
