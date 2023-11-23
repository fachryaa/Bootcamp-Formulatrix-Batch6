using ChessLibrary.Enum;
using ChessLibrary.Pieces;

namespace ChessLibrary;

public class ChessBoard : IBoard
{
	public static int BoardSize { get; set; }
	public Dictionary<IPosition, BasePiece?> Board { get; set; }

	public ChessBoard(int boardSize = 8)
	{
		Board = new();
		BoardSize = boardSize;
		InitBoard();
		InitPiece(Enum.Color.White);
		InitPiece(Enum.Color.Black);
	}
	
	public Dictionary<IPosition, BasePiece?> GetBoard()
	{
		return Board;
	}
	
	public void InitBoard()
	{
		// Init all board position
		for (int i = 0; i < BoardSize; i++)
		{
			for (int j = 0; j < BoardSize; j++)
			{
				Board.Add(new Position(i, j), null);
			}
		}
	}
	public void InitPiece(Enum.Color color)
	{
		int sidePawn = color == Enum.Color.White ? 1 : BoardSize-2;
		int sidePiece = color == Enum.Color.White ? 0 : BoardSize-1;

		// init pawn to board
		for (int i=0; i<BoardSize; i++)
		{
			Board[new Position(sidePawn, i)] = new Pawn(color);
		}

		// init another piece
		// update board
		Board[new Position(sidePiece, 0)] = BasePiece.Create(PieceType.Rook, color);
		Board[new Position(sidePiece, BoardSize-1)] = BasePiece.Create(PieceType.Rook, color);
		
		Board[new Position(sidePiece, 1)] = BasePiece.Create(PieceType.Knight, color);
		Board[new Position(sidePiece, BoardSize-2)] = BasePiece.Create(PieceType.Knight, color);
		
		Board[new Position(sidePiece, 2)] = BasePiece.Create(PieceType.Bishop, color);
		Board[new Position(sidePiece, BoardSize-3)] = BasePiece.Create(PieceType.Bishop, color);
		
		Board[new Position(sidePiece, 3)] = BasePiece.Create(PieceType.Queen, color);
		Board[new Position(sidePiece, BoardSize-4)] = BasePiece.Create(PieceType.King, color);
	}
	
	public BasePiece? GetPiece(IPosition position)
	{
		if (IsOutOfBound(position)) return null;
		
		return Board[(Position)position];
	}
	
	public void SetPiece(IPosition position, BasePiece? piece)
	{
		Board[position] = piece;
	}

	public void ResetBoard()
	{
		Board = new();
		InitBoard();
		InitPiece(Enum.Color.White);
		InitPiece(Enum.Color.Black);
	}

	private bool IsOutOfBound(IPosition position)
	{
		return position.X < 0 || position.Y < 0 || position.X >= BoardSize || position.Y >= BoardSize;
	}
	
	public IPosition GetKingPos(Enum.Color color)
	{
		IPosition result = new Position();
		foreach (var piece in Board)
		{
			if (piece.Value == null) continue;
			if (piece.Value.Color == color & piece.Value.Type == PieceType.King)
			{
				result = piece.Key;
			}
		}
		return result;
	}

}
