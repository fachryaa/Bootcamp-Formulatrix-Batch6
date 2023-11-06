using System.Collections.Generic;
using ChessGame.ChessLibrary.Enum;
using ChessGame.ChessLibrary.Pieces;
using ChessGame.ChessLibrary.Players;

namespace ChessGame.ChessLibrary;

public class GameController
{
	private Dictionary<Color,PlayerData> _players = new();
	private Color _firstTurn;
	private Color _currentTurn;
	private BasePiece[,] _board = new BasePiece[8,8];
	private bool _isCheck;
	
	public GameController(Color firstTurn)
	{
		_players.Add(Color.White, new PlayerData(Color.White));
		_players.Add(Color.Black, new PlayerData(Color.Black));
		
		_firstTurn = firstTurn;
		_currentTurn = firstTurn;
	}
	
	public bool MovePiece(Position from, Position to)
	{
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
	
	public BasePiece GetPiece(Position position)
	{
		return _board[position.X, position.Y];
	}
	
	public List<Position> AttackAreaPiece(BasePiece piece)
	{
		return new List<Position>();
	}
	
}
