using ChessLibrary.Pieces;

namespace ChessLibrary;

public interface IBoard
{
	protected static int BoardSize { get; set; }
	protected Dictionary<IPosition, BasePiece?> _board { get; set; }
	
	void InitBoard();
	void InitPiece(Enum.Color color);
	Dictionary<IPosition, BasePiece?> GetBoard();
	BasePiece? GetPiece(IPosition position);
	void SetPiece(IPosition position, BasePiece? piece);
	void ResetBoard();
}
