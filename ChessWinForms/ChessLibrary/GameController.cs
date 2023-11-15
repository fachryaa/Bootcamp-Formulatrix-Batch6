using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ChessLibrary.Enum;
using ChessLibrary.Pieces;
using ChessLibrary.Players;

namespace ChessLibrary;

public class GameController
{
	// XTODO: Create IBoard to store IPosition, BasePiece
	// XIBoard : BoardSize, Dict<IPosition, BasePiece> InitPiece
	// XTODO: In All Piece, change hardcode iteration, use variable value from BoardSize instead
	
	// XTODO: Change Concat to AddRange
	
	private Enum.Color[] _players = new Enum.Color[2];
	private int _currentTurn;
	// private Dictionary<IPosition, BasePiece> _board = new();
	private Board _board;
	public bool IsCheck { get; private set; }
	public bool IsSelect { get; private set; }
	public IPosition? SelectedPos { get; private set; }
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

	/// <summary>
	/// Get current player
	/// </summary>
	/// <returns></returns>
	public Enum.Color GetCurrentPlayer()
	{
		return _players[_currentTurn];
	}

	/// <summary>
	/// Select piece to move
	/// </summary>
	/// <param name="pos"></param>
	public void SelectPiece(IPosition pos)
	{
		SelectedPos = pos;
		IsSelect = true;
	}
		
	/// <summary>
	/// Unselect piece
	/// </summary>
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
	
	/// <summary>
	/// Check if move is en passant
	/// </summary>
	/// <param name="posFrom"></param>
	/// <param name="posTo"></param>
	/// <returns></returns>
	private bool IsEnPassantMove(IPosition? posFrom, IPosition? posTo)
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
		
		BasePiece? enemyPiece = GetPiece(posTo.X + (1*dir), posTo.Y);
		if (enemyPiece is null || enemyPiece.Type != PieceType.Pawn) return false;
		Pawn enemyPawn = (Pawn) enemyPiece;
		
		if (enemyPawn.IsDoubleMove) return true;
		
		return false;
	}
	
	/// <summary>
	/// Disable all pawn double move
	/// </summary>
	/// <param name="color"></param>
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
	
	/// <summary>
	/// Move piece to position based on selected piece
	/// </summary>
	/// <param name="pos"></param>
	public void MovePiece(IPosition pos)
	{
		var posTo = pos;
		var posFrom = SelectedPos!;
				
		// cek king and rook
		BasePiece? myPiece = GetPiece(posFrom);
		if (myPiece?.Type == PieceType.King)
		{
			King king = (King)myPiece;
			king.IsFirstMove = false;
			
			// cek if castle
			if (posFrom.Y - posTo.Y == 2) king.CastleMove(this, isLeft:true);
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
				IPosition enemyPos = new Position(posTo.X + (1*dir), posTo.Y);
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
	
	/// <summary>
	/// Check if move is unselect
	/// </summary>
	/// <param name="from"></param>
	/// <param name="to"></param>
	/// <returns></returns>
	public bool IsUnSelect(IPosition from, IPosition to)
	{
		return (from.X == to.X) && (from.Y == to.Y);
	}
	
	/// <summary>
	/// Move piece to position based on selected piece, simulate to check if king is safe
	/// </summary>
	/// <param name="from"></param>
	/// <param name="to"></param>
	/// <param name="simulate"></param>
	/// <returns></returns>
	public bool MovePiece(IPosition from, IPosition to, bool simulate=false)
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
	
	/// <summary>
	/// Check if piece is pinned
	/// </summary>
	/// <param name="piecePos"></param>
	/// <param name="to"></param>
	/// <returns></returns>
	private bool IsPiecePinned(IPosition piecePos, IPosition to)
	{
		bool result = false;
		BasePiece piece = GetPiece(piecePos)!;
		
		// temp to keep piece
		BasePiece? tempPiece = GetPiece(to);
		IPosition? tempPos = to;
		
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
	
	/// <summary>
	/// Get legal move of piece
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	public IEnumerable<IPosition> GetLegalMove(IPosition position)
	{
		BasePiece? piece = GetPiece(position);
		if (piece is null) return Enumerable.Empty<IPosition>();
		
		List<IPosition> result = piece.GetAvailableMoves(position, this).ToList();
		
		result.RemoveAll(pos => IsPiecePinned(position, pos));

		return result;
	}
	
	/// <summary>
	/// Get all moveable piece position based on color
	/// </summary>
	/// <param name="color"></param>
	/// <returns></returns>
	public List<IPosition> GetMoveablePiecePos(Enum.Color color)
	{
		List<IPosition> result = new();

		for(int i=0; i<Board.BoardSize; i++)
		{
			for(int j=0; j<Board.BoardSize; j++)
			{
				BasePiece piece = GetPiece(i, j)!;

				if (piece != null && piece.Color == color)
				{
					result.Add(new Position(i,j));
				}
			}
		}

		return result;
	}
	
	/// <summary>
	/// Check if pawn got promotion
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	public bool IsPawnGotPromotion(IPosition position)
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

	/// <summary>
	/// Promote pawn to piece
	/// </summary>
	/// <param name="position"></param>
	/// <param name="promotedPiece"></param>
	public void PawnPromotion(IPosition position, BasePiece promotedPiece)
	{
		var piece = GetPiece(position);
		
		if (piece is null) return;
		
		if (piece.Type != PieceType.Pawn) return;
		
		if (IsPawnGotPromotion(position))
		{
			_board.SetPiece(position, promotedPiece);
		}
	}
	
	/// <summary>
	/// Change turn and update status
	/// </summary>
	public void ChangeTurn()
	{
		_currentTurn = _currentTurn == 0 ? 1 : 0;
		
		// Update Status
		UpdateStatus();
	}	
	
	/// <summary>
	/// Update status of game
	/// </summary>
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
	
	/// <summary>
	/// Get piece attack area
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	private IEnumerable<IPosition> GetPieceAttackArea(IPosition position)
	{		
		BasePiece? piece = GetPiece(position)!;
		List<IPosition> result = piece.GetAvailableMoves(position, this, true).ToList();
		
		return result;
	}
	
	/// <summary>
	/// Check if game is stalemate
	/// </summary>
	/// <returns></returns>
	private bool IsStalemate()
	{
		if (IsCheck) return false;
		IEnumerable<IPosition> moveablePos = GetMoveablePiecePos(GetCurrentPlayer());
		foreach (var pos in moveablePos)
		{
			IEnumerable<IPosition> legalPos = GetLegalMove(pos);
			if (legalPos.Count() > 0) return false;
		}
		
		return true;
	}
	
	/// <summary>
	/// Get all attack area of piece, used to check if king is safe
	/// </summary>
	/// <param name="color"></param>
	/// <returns></returns>
	private IEnumerable<IPosition> GetAllAttackArea(Enum.Color color)
	{
		List<IPosition> result = new();
		
		foreach (var dict in _board.GetBoard())
		{
			if (dict.Value == null) continue;
			if (dict.Value.Color == color)
			{
				List<IPosition> x = new();
				if (dict.Value.Type == PieceType.Pawn)
				{
					Pawn pawn = (Pawn) dict.Value;
					x = pawn.GetAttackMoves(dict.Key, this, false);
				}
				else
				{
					x = GetPieceAttackArea(dict.Key).ToList();
				}
				
				result.AddRange(x);
			}
		}
		
		return result;
	}
	
	/// <summary>
	/// Get king position
	/// </summary>
	/// <param name="color"></param>
	/// <returns></returns>
	public IPosition GetKingPos(Enum.Color color)
	{
		IPosition result = new Position();
		foreach (var piece in _board.GetBoard())
		{
			if (piece.Value == null) continue;
			if (piece.Value.Color == color & piece.Value.Type == Enum.PieceType.King)
			{
				result = piece.Key;
			}
		}
		return result;
	}
	
	/// <summary>
	/// Check if king is safe
	/// </summary>
	/// <param name="color"></param>
	/// <returns></returns>
	public bool IsKingSafe(Enum.Color color)
	{
		bool result = true;
		
		IPosition? kingPos = GetKingPos(color);
		
		Enum.Color enemyColor = color == Enum.Color.White ? Enum.Color.Black : Enum.Color.White;
		
		IEnumerable<IPosition> enemyAttackArea = GetAllAttackArea(enemyColor);
		
		// check if king in attack area
		foreach (var pos in enemyAttackArea)
		{
			if (pos.Equals(kingPos!))
			{
				return false;
			}
		}
		
		return result;
	}
	
	/// <summary>
	/// Check if game is checkmate
	/// </summary>
	/// <returns></returns>
	public bool IsCheckMate()
	{
		if (!IsCheck) return false;
		
		List<IPosition> moveablePiece = GetMoveablePiecePos(_players[_currentTurn]);
		
		foreach (IPosition piece in moveablePiece)
		{
			IEnumerable<IPosition>? legalMove = GetLegalMove(piece);
			if (legalMove.Count() > 0) return false;
		}
		
		Status = Status.Checkmate;
		return true;
	}
	
	/// <summary>
	/// Get piece by position based on x and y
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public BasePiece? GetPiece(int x, int y)
	{
		return _board.GetPiece(new Position(x, y));
	}
	
	/// <summary>
	/// Get piece by position
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	public BasePiece? GetPiece(IPosition? pos)
	{
		return _board.GetPiece(pos);
	}
	
	/// <summary>
	/// Get board
	/// </summary>
	/// <returns></returns>
	public Dictionary<IPosition, BasePiece?> GetBoard()
	{
		return _board.GetBoard();
	}
	
	/// <summary>
	/// Reset game
	/// </summary>
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