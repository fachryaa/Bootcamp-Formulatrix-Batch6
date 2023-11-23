using ChessLibrary.Pieces;

namespace ChessLibrary;

public interface IBoard
{
	protected static int BoardSize { get; set; }
	protected Dictionary<IPosition, BasePiece?> Board { get; set; }
	
}
