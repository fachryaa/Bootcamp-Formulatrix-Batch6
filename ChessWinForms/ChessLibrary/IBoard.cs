using ChessLibrary.Pieces;

namespace ChessLibrary;

public interface IBoard
{
	protected static int BoardSize { get; set; }
	protected Dictionary<IPosition, BasePiece?> _board { get; set; }
	
	/// <summary>
	/// Init all board position
	/// </summary>
	// void InitBoard();
	
	/// <summary>
	/// Init all piece to board
	/// </summary>
	/// <param name="color"></param>
	// void InitPiece(Enum.Color color);
	
	/// <summary>
	/// Get the board
	/// </summary>
	/// <returns></returns>
	// Dictionary<IPosition, BasePiece?> GetBoard();
	
	/// <summary>
	/// Get the piece at the given position
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	// BasePiece? GetPiece(IPosition position);
	
	/// <summary>
	/// Set the piece at the given position
	/// </summary>
	/// <param name="position"></param>
	/// <param name="piece"></param>
	// void SetPiece(IPosition position, BasePiece? piece);
	
	/// <summary>
	/// Reset the board
	/// </summary>
	// void ResetBoard();
}
