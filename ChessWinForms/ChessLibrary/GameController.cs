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
	
	public GameController()
	{
		_players[0] = Enum.Color.White;
		_players[1] = Enum.Color.Black;

		_currentTurn = 0;

		InitPiece(_players[0]);
		InitPiece(_players[1]);
	}

	public void InitPiece(Enum.Color color)
	{
		// TODO : init piece
		// Init all board position
		for (int i=0; i<8; i++)
		{
			for (int j=0; j<8; j++)
			{
				_board.Add(new Position(i,j),default);
			}
		}
		int sidePawn = color == Enum.Color.White ? 1 : 6;
		int sidePiece = color == Enum.Color.White ? 0 : 7;

		// init pawn to board
		for (int i=0; i<8; i++)
		{
			_board.Add(new Position(sidePawn,i),new Pawn(color));
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
	public void MovePiece(Position pos)
	{
		_board[GetPos(pos)] = _board[GetPos(selectedPos)];
		_board[GetPos(selectedPos)] = default;
		isSelect = false;
	}
	
	public void MovePiece(int x, int y)
	{
		_board[GetPos(x,y)] = _board[GetPos(selectedPos)];
		_board[GetPos(selectedPos)] = default;
		isSelect = false;
	}
	
	public List<Position> GetLegalMove(Position position)
	{
		List<Position> result = new();
		BasePiece piece = GetPiece(position);
		
		switch (piece.Type)
		{
			case PieceType.Pawn:
				result = piece.GetAvailableMoves(position, this);
				
				break;
			default :
				break;
		}
		
		return result;
	}
	public List<Position> GetMoveablePiecePos(Enum.Color color)
	{
		List<Position> result = new();

		for(int i=0; i<7; i++)
		{
			for(int j=0; i<7; i++)
			{
				if (GetPiece(i,j).Color == color)
				{
					result.Add(new Position(i,j));
				}
			}
		}

		return result;
	}
	
	public bool MovePiece(Position from, Position to)
	{
		var posFrom = GetPos(from.X, from.Y);
		var posTo = GetPos(to.X, to.Y);
		
		_board[posTo] = _board[posFrom];
		_board[posFrom] = default;

		return true;
	}
	
	public void CapturePiece(BasePiece piece)
	{
		
	}
	
	public void ChangeTurn()
	{
		
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
	public BasePiece GetPiece(Position pos)
	{
		// Find piece by position
		BasePiece result = _board.FirstOrDefault(dict => dict.Key.X == pos.X && dict.Key.Y == pos.Y).Value;

		return result;
	}
	public Position GetPos(int x, int y)
	{
		// Find piece by position
		Position result = _board.FirstOrDefault(dict => dict.Key.X == x && dict.Key.Y == y).Key;

		return result;
	}
	public Position GetPos(Position pos)
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