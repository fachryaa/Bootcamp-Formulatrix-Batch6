using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class King : BasePiece, IMoveable
{
	public bool IsFirstMove;
	public King(Enum.Color color) : base(Enum.PieceType.King, color)
	{
		IsFirstMove = true;
	}
	
	/// <summary>
	/// check and get the position of the king for castling
	/// </summary>
	/// <param name="game"></param>
	/// <returns></returns>
	private IEnumerable<IPosition> GetCastlePosition(GameController game)
	{
		if (!IsFirstMove || game.IsCheck) return Enumerable.Empty<IPosition>();
		
		List<IPosition> result = new();
		Dictionary<IPosition,BasePiece?> board = game.GetBoard();
		IPosition myPos = game.GetKingPos(Color);
		
		// cek left
		int y = myPos.Y - 1;		
		
		while (y >= 0)
		{
			var piece = board[new Position(myPos.X, y)];
			if (piece == null) 
			{
				// cek if the pos is safe
				if (y == myPos.Y-1)
				{					
					// simulate move piece
					game.MovePiece(myPos, new Position(myPos.X, y), simulate:true);
					// cek if king is safe
					if (!game.IsKingSafe(Color))
					{
						// king not safe
						// rewind
						game.MovePiece(new Position(myPos.X, y), myPos, simulate:true);
						break;
					}
					game.MovePiece(new Position(myPos.X, y), myPos, simulate:true);
				}
				y--;
				continue;
			}
			
			if (piece.Type != Enum.PieceType.Rook || y != 0) break;
			
			if (y == 0 && piece.Type == PieceType.Rook)
			{
				Rook rook = (Rook)piece;
				if (rook.IsFirstMove)
				{
					result.Add(new Position(myPos.X, myPos.Y - 2));
				}
			}
			y--;
		}
		
		// cek right
		y = myPos.Y + 1;
		while (y <= 7)
		{
			var piece = board[new Position(myPos.X, y)];
			if (piece == null) 
			{
				// cek if the pos is safe
				if (y == myPos.Y+1)
				{					
					// simulate move piece
					game.MovePiece(myPos, new Position(myPos.X, y), simulate:true);
					// cek if king is safe
					if (!game.IsKingSafe(Color))
					{
						// king not safe
						// rewind
						game.MovePiece(new Position(myPos.X, y), myPos, simulate:true);
						break;
					}
					game.MovePiece(new Position(myPos.X, y), myPos, simulate:true);
				}
				y++;
				continue;
			}
			
			if (piece.Type != Enum.PieceType.Rook || y != 7) break;
			
			if (y == 7 && piece.Type == PieceType.Rook)
			{
				Rook rook = (Rook)piece;
				if (rook.IsFirstMove)
				{
					result.Add(new Position(myPos.X, myPos.Y + 2));
				}
			}
			y++;
		}
		
		return result;
	}
	
	/// <summary>
	/// Move the rook when castling
	/// </summary>
	/// <param name="game"></param>
	/// <param name="isLeft"></param>
	public void CastleMove(GameController game, bool isLeft)
	{
		Position rookFrom;
		Position rookTo;
		if(Color == Enum.Color.White)
		{
			if (isLeft) {
				rookFrom = new Position(0,0);
				rookTo = new Position(0,ChessBoard.BoardSize-5);
			}
			else {
				rookFrom = new Position(0,ChessBoard.BoardSize-1);
				rookTo = new Position(0,ChessBoard.BoardSize-3);
			}
		}
		else // black
		{
			if (isLeft) {
				rookFrom = new Position(ChessBoard.BoardSize-1,0);
				rookTo = new Position(ChessBoard.BoardSize-1,ChessBoard.BoardSize-5);
			}
			else {
				rookFrom = new Position(ChessBoard.BoardSize-1,ChessBoard.BoardSize-1);
				rookTo = new Position(ChessBoard.BoardSize-1,ChessBoard.BoardSize-3);
			}	
		}
		
		game.MovePiece(rookFrom, rookTo);
		
	} 

	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new();
		int x = position.X+1;
		int y = position.Y;
		Position pos = new Position(x,y);
		BasePiece? piece = game.GetPiece(x,y);
		
		if (position.X < ChessBoard.BoardSize-1)
		{
			// up
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);

			// up right
			if (position.Y < ChessBoard.BoardSize-1)
			{
				x = position.X+1;
				y = position.Y+1;
				AddMoveToResult(game, result, new Position(x,y));
			}
			
			// up left
			if (position.Y > 0)
			{
				x = position.X+1;
				y = position.Y-1;
				AddMoveToResult(game, result, new Position(x,y));
			}
		}
		
		if (position.X > 0)
		{
			// down
			x = position.X-1;
			y = position.Y;
			AddMoveToResult(game, result, new Position(x,y));
			
			// down right
			if (position.Y < 7)
			{
				x = position.X-1;
				y = position.Y+1;
				AddMoveToResult(game, result, new Position(x,y));
			}
			
			// down left
			if (position.Y > 0)
			{
				x = position.X-1;
				y = position.Y-1;
				AddMoveToResult(game, result, new Position(x,y));
			}
		}
		
		// right
		if (position.Y < ChessBoard.BoardSize-1)
		{
			x = position.X;
			y = position.Y+1;
			AddMoveToResult(game, result, new Position(x,y));
		}
		
		// left
		if (position.Y > 0)
		{
			x = position.X;
			y = position.Y-1;
			AddMoveToResult(game, result, new Position(x,y));
		}
		
		// castle position
		if (!forAttack)
		{
			var castlePos = GetCastlePosition(game).ToList();
			if (castlePos.Count != 0 && castlePos != null)
			{
				result.AddRange(castlePos);
			}
		}
		
		return result;
	}

	public override bool AddMoveToResult(GameController game, List<IPosition> result, IPosition position)
	{
		BasePiece? piece = game.GetPiece(position);
		if (piece != null)
		{
			if (piece.Color != Color) result.Add(position);
		}
		else result.Add(position);
		
		return true;
	}
}
