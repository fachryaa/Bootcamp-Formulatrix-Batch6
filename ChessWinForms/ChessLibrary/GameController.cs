using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ChessLibrary.Enum;
using ChessLibrary.Pieces;
using ChessLibrary.Players;

namespace ChessLibrary;

public class GameController
{
	// TODO: Create IBoard to store Position, BasePiece
	// IBoard : BoardSize, Dict<IPosition, BasePiece> InitPiece
	// TODO: In All Piece, change hardcode iteration, use variable value from BoardSize instead
	
	// TODO: Change Concat to AddRange
	
	// TODO: Use hashcode to get value
	private Enum.Color[] _players = new Enum.Color[2];
	private int _currentTurn;
	private Dictionary<Position, BasePiece> _board = new();
	public bool IsCheck { get; private set; }
	public bool IsSelect { get; private set; }
	public Position SelectedPos { get; private set; }
	public Status Status { get; private set; }
	public Enum.Color Winner { get; private set; }
	
	public GameController()
	{
		_players[0] = Enum.Color.White;
		_players[1] = Enum.Color.Black;

		_currentTurn = 0;
		
		IsCheck = false;
		IsSelect = false;
		
		Status = Status.Playing;

		InitBoard();

		InitPiece(_players[0]);
		InitPiece(_players[1]);
	}

	public void InitBoard()
	{
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
		SelectedPos = pos;
		IsSelect = true;
	}
	
	public void SelectPiece(int x, int y)
	{
		SelectedPos = new Position(x,y);
		IsSelect = true;
	
	}
	
	public void UnSelect()
	{
		BasePiece selectedPiece = GetPiece(SelectedPos);
		if (selectedPiece.Type == PieceType.Pawn)
		{
			Pawn pawn = (Pawn) selectedPiece;
			if (pawn.Color == Enum.Color.White && SelectedPos.X == 1)
			{
				pawn.IsFirstMove = true;
			}
			if (pawn.Color == Enum.Color.Black && SelectedPos.X == 6)
			{
				pawn.IsFirstMove = true;
			}
		}
		else if(selectedPiece.Type == PieceType.King)
		{
			King king = (King) selectedPiece;
			if(king.IsFirstMove) king.IsFirstMove = true;
		}
		else if(selectedPiece.Type == PieceType.Rook)
		{
			Rook rook = (Rook) selectedPiece;
			if(rook.IsFirstMove)rook.IsFirstMove = true;
		}
		SelectedPos = null;
		IsSelect = false;
	}
	
	private bool IsEnPassantMove(Position posFrom, Position posTo)
	{		
		// if not attack
		if (posFrom.Y == posTo.Y) return false;
		
		BasePiece enemy = GetPiece(posTo);
		if (enemy != null) return false;
				
		BasePiece myPiece = GetPiece(posFrom);
		Pawn pawn = (Pawn) myPiece;
		Enum.Color colorPawn = pawn.Color;
		
		int dir = colorPawn == Enum.Color.White ? -1 : 1;
		
		BasePiece enemyPiece = GetPiece(posTo.X + (1*dir), posTo.Y);
		if (enemyPiece.Type != PieceType.Pawn) return false;
		Pawn enemyPawn = (Pawn) enemyPiece;
		
		if (enemyPawn.IsDoubleMove) return true;
		
		return false;
	}
	
	private void DisableAllPawnDoubleMove(Enum.Color color)
	{
		foreach (var kvp in _board)
		{
			if (kvp.Value == null) continue;
			if (kvp.Value.Type == PieceType.Pawn && kvp.Value.Color == color)
			{
				Pawn pawn = (Pawn) kvp.Value;
				pawn.IsDoubleMove = false;
			}
		}
	}
	
	public void MovePiece(Position pos)
	{
		var posTo = GetPos(pos);
		var posFrom = GetPos(SelectedPos);
				
		// cek king and rook
		BasePiece myPiece = GetPiece(posFrom);
		if (myPiece.Type == PieceType.King)
		{
			King king = (King)myPiece;
			king.IsFirstMove = false;
			
			// cek if castle
			if (posFrom.Y - posTo.Y == 2) king.CastleMove(this, isLeft:true);
			else if (posTo.Y - posFrom.Y == 2) king.CastleMove(this, isLeft:false);
			
			// disable pawn double move
			DisableAllPawnDoubleMove(GetCurrentPlayer());
		}
		else if (myPiece.Type == PieceType.Rook)
		{
			Rook rook = (Rook)myPiece;
			rook.IsFirstMove = false;
			
			DisableAllPawnDoubleMove(GetCurrentPlayer());
		}
		else if (myPiece.Type == PieceType.Pawn)
		{
			// cek if pawn is double move
			Pawn pawn = (Pawn)myPiece;
			if (pawn.IsFirstMove && !pawn.IsDoubleMove && Math.Abs(posFrom.X - posTo.X) == 2)
			{
				pawn.IsDoubleMove = true;
			}
			else
			{
				DisableAllPawnDoubleMove(GetCurrentPlayer());
			}
			
			// if attack en passant
			if (IsEnPassantMove(posFrom, posTo))
			{
				int dir = pawn.Color == Enum.Color.White ? -1 : 1;
				Position enemyPos = GetPos(posTo.X + (1*dir), posTo.Y);
				_board[enemyPos] = null;
			}
			
			pawn.IsFirstMove = false;
		}
		else 
		{
			DisableAllPawnDoubleMove(GetCurrentPlayer());
		}

		_board[posTo] = _board[posFrom];
		_board[posFrom] = null;
		IsSelect = false;
	}
	
	public bool IsUnSelect(Position from, Position to)
	{
		return (from.X == to.X) && (from.Y == to.Y);
	}
	
	public bool MovePiece(Position from, Position to, bool simulate=false)
	{
		var posFrom = GetPos(from.X, from.Y);
		var posTo = GetPos(to.X, to.Y);
		
		_board[posTo] = _board[posFrom];
		_board[posFrom] = null;

		if (!simulate)
		{
			IsSelect = false;
		}

		return true;
	}
	
	private bool IsPiecePinned(Position piecePos, Position to)
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
	
	public bool IsPawnGotPromotion(Position position)
	{
		var piece = GetPiece(position);
		if (piece == null) return false;
		
		if (piece.Type == PieceType.Pawn)
		{
			if (piece.Color == Enum.Color.White && position.X == 7) return true;
			else if (piece.Color == Enum.Color.Black && position.X == 0) return true;
		}
		
		return false;
	}

	public void PawnPromotion(Position position, BasePiece promotedPiece)
	{
		var piece = GetPiece(position);
		
		if (piece is null) return;
		
		if (piece.Type != PieceType.Pawn) return;
		
		if (IsPawnGotPromotion(position))
		{
			_board[GetPos(position)] = promotedPiece;
		}
	}
	
	public void ChangeTurn()
	{
		_currentTurn = _currentTurn == 0 ? 1 : 0;
		
		// Update Status
		UpdateStatus();
	}	
	
	private void UpdateStatus()
	{
		IsCheck = !IsKingSafe(GetCurrentPlayer());
		
		Status = Status.Playing;
		Winner = default;
		if (IsCheck) Status = Status.Check;
		if (IsCheckMate())
		{
			Winner = GetCurrentPlayer() == Enum.Color.White ? Enum.Color.Black : Enum.Color.White;
			Status = Status.Checkmate;
		}
		if (IsStalemate())
		{
			Status = Status.Stalemate;
		}
	}
	
	private List<Position> GetPieceAttackArea(Position position)
	{		
		BasePiece? piece = GetPiece(position);
		List<Position> result = piece.GetAvailableMoves(position, this, true);
		
		return result;
	}
	
	private bool IsStalemate()
	{
		if (IsCheck) return false;
		List<Position> moveablePos = GetMoveablePiecePos(GetCurrentPlayer());
		foreach (var pos in moveablePos)
		{
			List<Position> legalPos = GetLegalMove(pos);
			if (legalPos.Count > 0) return false;
		}
		
		return true;
	}
	
	private List<Position> GetAllAttackArea(Enum.Color color)
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
				
				// foreach (var pos in x)
				// {
				// 	result.Add(pos);
				// }
				result.AddRange(x);
				// result = result.Concat(x).ToList();
			}
		}
		
		return result;
	}
	
	public Position GetKingPos(Enum.Color color)
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
	
	public bool IsCheckMate()
	{
		if (!IsCheck) return false;
		
		List<Position> moveablePiece = GetMoveablePiecePos(_players[_currentTurn]);
		
		foreach (Position piece in moveablePiece)
		{
			List<Position> legalMove = GetLegalMove(piece);
			if (legalMove.Count > 0) return false;
		}
		
		Status = Status.Checkmate;
		return true;
	}
	
	public BasePiece GetPiece(int x, int y)
	{
		// Find piece by position
		foreach (var piece in _board)
		{
			if (piece.Key.Equals(new(x,y))) return piece.Value;
		}
		
		return null;
		// BasePiece result = _board.FirstOrDefault(dict => dict.Key.X == x && dict.Key.Y == y).Value;

	}
	
	// TODO : GetPos and GetPiece by HashCode
	public BasePiece? GetPiece(Position pos)
	{
		// Find piece by position
		foreach (var piece in _board)
		{
			if (piece.Key.Equals(pos)) return piece.Value;
		}
		
		return null;
		// BasePiece result = _board.FirstOrDefault(dict => dict.Key.X == pos.X && dict.Key.Y == pos.Y).Value;
	}
	public Position? GetPos(int x, int y)
	{
		// Find pos by position
		foreach (var piece in _board)
		{
			if (piece.Key.Equals(new(x,y))) return piece.Key;
		}
		// Position result = _board.FirstOrDefault(dict => dict.Key.X == x && dict.Key.Y == y).Key;
		return null;
	}
	public Position? GetPos(Position pos)
	{
		// Find piece by position
		foreach (var piece in _board)
		{
			if (piece.Key.Equals(pos)) return piece.Key;
		}
		
		return null;
		// Position result = _board.FirstOrDefault(dict => dict.Key.X == pos.X && dict.Key.Y == pos.Y).Key;

		// return result;
	
	}
	
	public Position? GetPosById(int id)
	{
		// Find piece by position
		foreach (var piece in _board)
		{
			if (piece.Value.Id == id) return piece.Key;
		}
		
		return null;
		// Position result = _board.FirstOrDefault(dict => dict.Value != null && dict.Value.Id == id).Key;

		// return result;
	}
	public Dictionary<Position, BasePiece> GetBoard()
	{
		return _board;
	}
	
	public void ResetGame()
	{
		IsSelect = false;
		_currentTurn = 0;
		SelectedPos = null;
		IsCheck = false;
		Status = Status.Playing;

		_board = new();
		InitBoard();

		InitPiece(_players[0]);
		InitPiece(_players[1]);
	}
}

public class Position
{
	public int X{ get; private set; }
	public int Y{ get; private set; }

	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}
	
	public bool Equals(Position pos)
	{
		return this.X == pos.X && this.Y == pos.Y;
	}

	// TODO: change GetPos to this
	// public override int GetHashCode()
	// {
	//     return (X | Y).GetHashCode();
	// }
	// public override bool Equals(object obj)
	// {
	//     if (obj == null || GetType() != obj.GetType())
	//     {
	//         return false;
	//     }
	//     Position other = (Position)obj;
	//     return (X | Y) == (other.X | other.Y);
	// }
	
	// TODO: 
}