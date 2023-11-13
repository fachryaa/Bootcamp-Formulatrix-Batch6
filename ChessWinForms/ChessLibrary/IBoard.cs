using ChessLibrary.Pieces;

namespace ChessLibrary;

public interface IBoard
{
	int BoardSize { get; set; }
	Dictionary<Position, BasePiece> Board { get; set; }
}
