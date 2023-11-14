using ChessLibrary;
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
		_board[new Position(sidePiece, 0)] = new Rook(color);
		_board[new Position(sidePiece, BoardSize-1)] = new Rook(color);
		
		_board[new Position(sidePiece, 1)] = new Knight(color);
		_board[new Position(sidePiece, BoardSize-2)] = new Knight(color);
		
		_board[new Position(sidePiece, 2)] = new Bishop(color);
		_board[new Position(sidePiece, BoardSize-3)] = new Bishop(color);
		
		_board[new Position(sidePiece, 3)] = new Queen(color);
		_board[new Position(sidePiece, BoardSize-4)] = new King(color);
	}
	
	public BasePiece? GetPiece(IPosition? position)
	{
		if (position is null) return null;
		try
		{
			return _board[(Position)position];
		}
		catch (System.Collections.Generic.KeyNotFoundException)
		{
			return null;
			throw;
		}
	}
	
	public void SetPiece(IPosition? position, BasePiece? piece)
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

	

}
