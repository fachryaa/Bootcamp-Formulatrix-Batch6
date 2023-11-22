using ChessLibrary.Enum;
using ChessLibrary.Pieces;

namespace ChessLibrary;

public class Board : IBoard
{
	public static int BoardSize { get; set; }
	public Dictionary<IPosition, BasePiece?> _board { get; set; }

	public Board(int boardSize = 8)
	{
		_board = new();
		BoardSize = boardSize;
		InitBoard();
		InitPiece(Enum.Color.White);
		InitPiece(Enum.Color.Black);
	}
	
	public Dictionary<IPosition, BasePiece?> GetBoard()
	{
		return _board;
	}
	
	public void InitBoard()
	{
		// Init all board position
		for (int i = 0; i < BoardSize; i++)
		{
			for (int j = 0; j < BoardSize; j++)
			{
				_board.Add(new Position(i, j), null);
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
			_board[new Position(sidePawn, i)] = new Pawn(color);
		}

		// init another piece
		// update board
		_board[new Position(sidePiece, 0)] = BasePiece.Create(PieceType.Rook, color);
		_board[new Position(sidePiece, BoardSize-1)] = BasePiece.Create(PieceType.Rook, color);
		
		_board[new Position(sidePiece, 1)] = BasePiece.Create(PieceType.Knight, color);
		_board[new Position(sidePiece, BoardSize-2)] = BasePiece.Create(PieceType.Knight, color);
		
		_board[new Position(sidePiece, 2)] = BasePiece.Create(PieceType.Bishop, color);
		_board[new Position(sidePiece, BoardSize-3)] = BasePiece.Create(PieceType.Bishop, color);
		
		_board[new Position(sidePiece, 3)] = BasePiece.Create(PieceType.Queen, color);
		_board[new Position(sidePiece, BoardSize-4)] = BasePiece.Create(PieceType.Queen, color);
	}
	
	public BasePiece? GetPiece(IPosition position)
	{
		if (IsOutOfBound(position)) return null;
		
		return _board[(Position)position];
	}
	
	public void SetPiece(IPosition position, BasePiece? piece)
	{
		_board[position] = piece;
	}

	public void ResetBoard()
	{
		_board = new();
		InitBoard();
		InitPiece(Enum.Color.White);
		InitPiece(Enum.Color.Black);
	}

	private bool IsOutOfBound(IPosition position)
	{
		return position.X < 0 || position.Y < 0 || position.X >= BoardSize || position.Y >= BoardSize;
	}
	

}
