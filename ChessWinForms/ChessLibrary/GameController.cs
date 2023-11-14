using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ChessLibrary.Enum;
using ChessLibrary.Pieces;
using ChessLibrary.Players;

namespace ChessLibrary;

public class GameController
{
	// TODO: In All Piece, change hardcode iteration, use variable value from BoardSize instead
	
	private Enum.Color[] _players = new Enum.Color[2];
	private int _currentTurn;
	// private Dictionary<Position, BasePiece> _board = new();
	private Board _board;
	public bool IsCheck { get; private set; }
	public bool IsSelect { get; private set; }
	public Position? SelectedPos { get; private set; }
	public Status Status { get; private set; }
	public Enum.Color Winner { get; private set; }
	
	public GameController(Board board)
	{
		_board = board;
		
		_players[0] = Enum.Color.White;
		_players[1] = Enum.Color.Black;

		_currentTurn = 0;
		
		IsCheck = false;
		IsSelect = false;
		
		Status = Status.Playing;
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
		BasePiece? selectedPiece = GetPiece(SelectedPos);
		if (selectedPiece?.Type == PieceType.Pawn)
		{
			Pawn pawn = (Pawn) selectedPiece;
			if (pawn.Color == Enum.Color.White && SelectedPos?.X == 1)
			{
				pawn.IsFirstMove = true;
			}
			if (pawn.Color == Enum.Color.Black && SelectedPos?.X == 6)
			{
				pawn.IsFirstMove = true;
			}
		}
		else if(selectedPiece?.Type == PieceType.King)
		{
			King king = (King) selectedPiece;
			if(king.IsFirstMove) king.IsFirstMove = true;
		}
		else if(selectedPiece?.Type == PieceType.Rook)
		{
			Rook rook = (Rook) selectedPiece;
			if(rook.IsFirstMove)rook.IsFirstMove = true;
		}
		SelectedPos = null;
		IsSelect = false;
	}
	
	private bool IsEnPassantMove(Position? posFrom, Position? posTo)
	{		
		// if not attack
		if (posFrom == null || posTo == null) return false;
		if (posFrom.Y == posTo.Y) return false;
		
		BasePiece? enemy = GetPiece(posTo);
		if (enemy != null) return false;
				
		BasePiece? myPiece = GetPiece(posFrom);
		if (myPiece is null) return false;
		
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
		foreach (var kvp in _board.GetBoard())
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
		var posTo = pos;
		var posFrom = SelectedPos;
				
		// cek king and rook
		BasePiece? myPiece = GetPiece(posFrom);
		if (myPiece?.Type == PieceType.King)
		{
			King king = (King)myPiece;
			king.IsFirstMove = false;
			
			// cek if castle
			if (posFrom?.Y - posTo.Y == 2) king.CastleMove(this, isLeft:true);
			else if (posTo.Y - posFrom?.Y == 2) king.CastleMove(this, isLeft:false);
			
			// disable pawn double move
			DisableAllPawnDoubleMove(GetCurrentPlayer());
		}
		else if (myPiece?.Type == PieceType.Rook)
		{
			Rook rook = (Rook)myPiece;
			rook.IsFirstMove = false;
			
			DisableAllPawnDoubleMove(GetCurrentPlayer());
		}
		else if (myPiece?.Type == PieceType.Pawn)
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
				Position enemyPos = new Position(posTo.X + (1*dir), posTo.Y);
				_board.SetPiece(enemyPos, null);
			}
			
			pawn.IsFirstMove = false;
		}
		else 
		{
			DisableAllPawnDoubleMove(GetCurrentPlayer());
		}

		BasePiece? pieceFrom = _board.GetPiece(posFrom);
		_board.SetPiece(posTo, pieceFrom);
		_board.SetPiece(posFrom, null);
		IsSelect = false;
	}
	
	public bool IsUnSelect(Position from, Position to)
	{
		return (from.X == to.X) && (from.Y == to.Y);
	}
	
	public bool MovePiece(Position from, Position to, bool simulate=false)
	{
		var posFrom = new Position(from.X, from.Y);
		var posTo = new Position(to.X, to.Y);
		
		BasePiece? pieceFrom = _board.GetPiece(posFrom);
		_board.SetPiece(posTo, pieceFrom);
		_board.SetPiece(posFrom, null);

		if (!simulate)
		{
			IsSelect = false;
		}

		return true;
	}
	
	private bool IsPiecePinned(Position piecePos, Position to)
	{
		bool result = false;
		BasePiece? piece = GetPiece(piecePos);
		
		// temp to keep piece
		BasePiece? tempPiece = GetPiece(to);
		Position? tempPos = to;
		
		// move piece
		MovePiece(piecePos, to, simulate:true);
		
		// cek if king is safe
		Enum.Color color = piece.Color;
		result = !IsKingSafe(color);
		
		// rewind
		MovePiece(to, piecePos, simulate:true);
		if (tempPiece != null)
		{
			_board.SetPiece(tempPos, tempPiece);
		}
		
		return result;
	}
	public List<Position>? GetLegalMove(Position position)
	{
		BasePiece? piece = GetPiece(position);
		if (piece is null) return null;
		
		List<Position> result = piece.GetAvailableMoves(position, this);
		
		result.RemoveAll(pos => IsPiecePinned(position, pos));

		return result;
	}
	
	public List<Position> GetMoveablePiecePos(Enum.Color color)
	{
		List<Position> result = new();

		for(int i=0; i<Board.BoardSize; i++)
		{
			for(int j=0; j<Board.BoardSize; j++)
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
			_board.SetPiece(position, promotedPiece);
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
	
	private List<Position> GetPieceAttackArea(IPosition position)
	{		
		BasePiece? piece = GetPiece(position);
		List<Position> result = piece.GetAvailableMoves((Position)position, this, true);
		
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
		
		foreach (var dict in _board.GetBoard())
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
				
				result.AddRange(x);
			}
		}
		
		return result;
	}
	
	public Position? GetKingPos(Enum.Color color)
	{
		foreach (var piece in _board.GetBoard())
		{
			if (piece.Value == null) continue;
			if (piece.Value.Color == color & piece.Value.Type == Enum.PieceType.King)
			{
				return (Position)piece.Key;
			}
		}
		return null;
	}
	
	public bool IsKingSafe(Enum.Color color)
	{
		bool result = true;
		
		Position? kingPos = GetKingPos(color);
		
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
			List<Position>? legalMove = GetLegalMove(piece);
			if (legalMove.Count > 0) return false;
		}
		
		Status = Status.Checkmate;
		return true;
	}
	
	public BasePiece GetPiece(int x, int y)
	{
		// Find piece by position
		foreach (var piece in _board.GetBoard())
		{
			if (piece.Key.Equals(new Position(x,y))) return piece.Value;
		}
		
		return null;
		// BasePiece result = _board.FirstOrDefault(dict => dict.Key.X == x && dict.Key.Y == y).Value;

	}
	
	// TODO : GetPos and GetPiece by HashCode
	public BasePiece? GetPiece(IPosition? pos)
	{
		return _board.GetPiece(pos);
	}
	
	public Dictionary<IPosition, BasePiece?> GetBoard()
	{
		return _board.GetBoard();
	}
	
	public void ResetGame()
	{
		IsSelect = false;
		_currentTurn = 0;
		SelectedPos = null;
		IsCheck = false;
		Status = Status.Playing;

		_board = new();
		_board.ResetBoard();
	}
}