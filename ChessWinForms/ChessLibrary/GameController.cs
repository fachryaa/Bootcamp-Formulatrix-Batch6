using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
	
	public bool MovePiece(Position from, Position to, bool simulate=false)
	{
		var posFrom = GetPos(from.X, from.Y);
		var posTo = GetPos(to.X, to.Y);
		
		_board[posTo] = _board[posFrom];
		_board[posFrom] = null;

		if (!simulate)
		{
			isSelect = false;

			CheckPawnPromotion(_board[posTo], posTo);
		}

		return true;
	}
	
	public bool IsPiecePinned(Position piecePos, Position to)
	{
		bool result = false;
		BasePiece piece = GetPiece(piecePos);
		
		// temp to keep piece
		BasePiece tempPiece = GetPiece(to);
		Position tempPos = GetPos(to);
		
		// move piece
		MovePiece(piecePos, to, simulate:true);
		
		// cek if king is safe
		Enum.Color color = piece.Color;
		result = !IsKingSafe(color);
		
		// rewind
		MovePiece(to, piecePos, simulate:true);
		if (tempPiece != null)
		{
			_board[tempPos] = tempPiece;
		}
		
		return result;
	}
	public List<Position> GetLegalMove(Position position)
	{
		BasePiece piece = GetPiece(position);
		
		List<Position> result = piece.GetAvailableMoves(position, this);
		
		result.RemoveAll(pos => IsPiecePinned(position, pos));

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
		
		if (IsKingSafe(GetCurrentPlayer()))
		{
			_isCheck = true;
		}
		else
		{
			_isCheck = false;
		}
	}
	
	public List<Position> GetPieceAttackArea(Position position)
	{		
		BasePiece piece = GetPiece(position);
		List<Position> result = piece.GetAvailableMoves(position, this);
		
		return result;
	}
	
	public List<Position> GetAllAttackArea(Enum.Color color)
	{
		List<Position> result = new();
		
		foreach (var dict in _board)
		{
			if (dict.Value == null) continue;
			if (dict.Value.Color == color)
			{
				List<Position> x = new();
				if (dict.Value.Type == PieceType.Pawn)
				{
					Pawn pawn = (Pawn) dict.Value;
					x = pawn.GetAttackMoves(dict.Key, this, false);
				}
				else
				{
					x = GetPieceAttackArea(dict.Key);
				}
				
				result = result.Concat(x).ToList();
			}
		}
		
		return result;
	}
	
	private Position GetKingPos(Enum.Color color)
	{
		foreach (var piece in _board)
		{
			if (piece.Value == null) continue;
			if (piece.Value.Color == color & piece.Value.Type == Enum.PieceType.King)
			{
				return piece.Key;
			}
		}
		return null;
	}
	
	public bool IsKingSafe(Enum.Color color)
	{
		bool result = true;
		
		Position kingPos = GetKingPos(color);
		
		Enum.Color enemyColor = color == Enum.Color.White ? Enum.Color.Black : Enum.Color.White;
		
		List<Position> enemyAttackArea = GetAllAttackArea(enemyColor);
		
		// check if king in attack area
		foreach (var pos in enemyAttackArea)
		{
			if (pos.Equals(kingPos))
			{
				return false;
			}
		}
		
		return result;
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

	public void ResetGame()
	{
		_currentTurn = 0;
		selectedPos = null;
		_capturedPiece = null;
		_isCheck = false;

		// InitBoard();

		InitPiece(_players[0]);
		InitPiece(_players[1]);
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
	
	public bool Equals(Position pos)
	{
		return this.X == pos.X && this.Y == pos.Y;
	}
}