using System.Collections.Generic;
using System.Linq;

using ChessLibrary.Enum;
using ChessLibrary.Pieces;
using ChessLibrary.Players;

namespace ChessLibrary;

public class GameController
{
	private Enum.Color[] _players = new Enum.Color[2];
	private int _currentTurn;
	private Dictionary<Position, BasePiece> _board = new();
	private bool _isCheck;
	public bool isSelect;
	public Position selectedPos;
	private List<BasePiece> _capturedPiece = new();
	
	public GameController()
	{
		_players[0] = Enum.Color.White;
		_players[1] = Enum.Color.Black;

		_currentTurn = 0;

		InitBoard();

		InitPiece(_players[0]);
		InitPiece(_players[1]);
	}

	public void InitBoard()
	{
		// TODO : init piece
		// Init all board position
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				_board.Add(new Position(i, j), default);
			}
		}
	}
	public void InitPiece(Enum.Color color)
	{
		int sidePawn = color == Enum.Color.White ? 1 : 6;
		int sidePiece = color == Enum.Color.White ? 0 : 7;

		// init pawn to board
		for (int i=0; i<8; i++)
		{
			_board[GetPos(sidePawn, i)] = new Pawn(color);
		}

		// init another piece
		// update board
		_board[GetPos(sidePiece, 0)] = new Rook(color);
		_board[GetPos(sidePiece, 7)] = new Rook(color);
		
		_board[GetPos(sidePiece, 1)] = new Knight(color);
		_board[GetPos(sidePiece, 6)] = new Knight(color);
		
		_board[GetPos(sidePiece, 2)] = new Bishop(color);
		_board[GetPos(sidePiece, 5)] = new Bishop(color);
		
		_board[GetPos(sidePiece, 3)] = new Queen(color);
		_board[GetPos(sidePiece, 4)] = new King(color);
	}

	public Enum.Color GetCurrentPlayer()
	{
		return _players[_currentTurn];
	}

	public void SelectPiece(Position pos)
	{
		// TODO : select piece
		selectedPos = pos;
		isSelect = true;
	}
	public void SelectPiece(int x, int y)
	{
		// TODO : select piece
		selectedPos = new Position(x,y);
		isSelect = true;
	
	}
	
	public void UnSelect()
	{
		BasePiece selectedPiece = GetPiece(selectedPos);
		if (selectedPiece.Type == PieceType.Pawn)
		{
			Pawn pawn = (Pawn) selectedPiece;
			if (pawn.Color == Enum.Color.White && selectedPos.X == 1)
			{
				pawn.IsFirstMove = true;
			}
			if (pawn.Color == Enum.Color.Black && selectedPos.X == 6)
			{
				pawn.IsFirstMove = true;
			}
		}
		selectedPos = null;
		isSelect = false;
	}
	public void MovePiece(Position pos)
	{
		var posTo = GetPos(pos);
		var posFrom = GetPos(selectedPos);
		
		BasePiece piece = GetPiece(posTo);
		if (piece != null && piece.Color != GetPiece(posFrom).Color)
		{
			CapturePiece(piece);
		}

		_board[posTo] = _board[posFrom];
		_board[posFrom] = null;
		isSelect = false;

		CheckPawnPromotion(_board[posTo], posTo);
	}
	
	public void MovePiece(int x, int y)
	{
		var posTo = GetPos(x, y);
		var posFrom = GetPos(selectedPos);

		_board[posTo] = _board[GetPos(posFrom)];
		_board[posFrom] = null;
		isSelect = false;

		CheckPawnPromotion(_board[posTo], posTo);
	}
	
	public bool MovePiece(Position from, Position to)
	{
		var posFrom = GetPos(from.X, from.Y);
		var posTo = GetPos(to.X, to.Y);
		
		_board[posTo] = _board[posFrom];
		_board[posFrom] = default;

		isSelect = false;

		CheckPawnPromotion(_board[posTo], posTo);

		return true;
	}
	
	public List<Position> GetLegalMove(Position position)
	{
		List<Position> result = new();
		BasePiece piece = GetPiece(position);

		result = piece.GetAvailableMoves(position, this);

		return result;
	}
	public List<Position> GetMoveablePiecePos(Enum.Color color)
	{
		List<Position> result = new();

		for(int i=0; i<8; i++)
		{
			for(int j=0; j<8; j++)
			{
				BasePiece piece = GetPiece(i, j);

				if (piece != null && piece.Color == color)
				{
					result.Add(new Position(i,j));
				}
			}
		}

		return result;
	}

	public void CheckPawnPromotion(BasePiece piece, Position position)
	{
		if (piece.Type != PieceType.Pawn) return;

		if (piece.Color == Enum.Color.White && position.X == 7)
		{
			_board[GetPos(position)] = new Rook(piece, piece.Color);
			
		}
		
		if (piece.Color == Enum.Color.Black && position.X == 0)
		{
			_board[GetPos(position)] = new Rook(piece, piece.Color);
		}
	}
	
	private void CapturePiece(BasePiece piece)
	{
		_capturedPiece.Add(piece);
	}
	
	public List<BasePiece> GetCapturedPiece()
	{
		return _capturedPiece;
	}
	
	public void ChangeTurn()
	{
		_currentTurn = _currentTurn == 0 ? 1 : 0;
	}
	
	public bool IsCheck()
	{
		return _isCheck;
	}
	
	public BasePiece GetPiece(int x, int y)
	{
		// Find piece by position
		BasePiece result = _board.FirstOrDefault(dict => dict.Key.X == x && dict.Key.Y == y).Value;

		return result;
	}
	public BasePiece? GetPiece(Position pos)
	{
		// Find piece by position
		BasePiece result = _board.FirstOrDefault(dict => dict.Key.X == pos.X && dict.Key.Y == pos.Y).Value;

		return result;
	}
	public Position? GetPos(int x, int y)
	{
		// Find piece by position
		Position result = _board.FirstOrDefault(dict => dict.Key.X == x && dict.Key.Y == y).Key;

		return result;
	}
	public Position? GetPos(Position pos)
	{
		// Find piece by position
		Position result = _board.FirstOrDefault(dict => dict.Key.X == pos.X && dict.Key.Y == pos.Y).Key;

		return result;
	
	}
	public Dictionary<Position, BasePiece> GetBoard()
	{
		return _board;
	}
	
	public List<Position> AttackAreaPiece(BasePiece piece)
	{
		return new List<Position>();
	}
}

public class Position
{
	public int X;
	public int Y;

	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}
}