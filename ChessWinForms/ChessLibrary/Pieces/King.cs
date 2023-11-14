using System.Collections.Generic;
using ChessLibrary.Enum;

namespace ChessLibrary.Pieces;

public class King : BasePiece
{
	public bool IsFirstMove;
	public King(Enum.Color color) : base(Enum.PieceType.King, color)
	{
		IsFirstMove = true;
	}
	
	private List<Position> GetCastlePosition(GameController game)
	{
		if (!IsFirstMove || game.IsCheck) return new();
		
		List<Position> result = new();
		Dictionary<IPosition,BasePiece> board = game.GetBoard();
		Position myPos = game.GetKingPos(Color);
		
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
					game.MovePiece(myPos, new(myPos.X, y), simulate:true);
					// cek if king is safe
					if (!game.IsKingSafe(Color))
					{
						// king not safe
						// rewind
						game.MovePiece(new(myPos.X, y), myPos, simulate:true);
						break;
					}
					game.MovePiece(new(myPos.X, y), myPos, simulate:true);
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
					game.MovePiece(myPos, new(myPos.X, y), simulate:true);
					// cek if king is safe
					if (!game.IsKingSafe(Color))
					{
						// king not safe
						// rewind
						game.MovePiece(new(myPos.X, y), myPos, simulate:true);
						break;
					}
					game.MovePiece(new(myPos.X, y), myPos, simulate:true);
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
	
	public void CastleMove(GameController game, bool isLeft)
	{
		Position rookFrom;
		Position rookTo;
		if(Color == Enum.Color.White)
		{
			if (isLeft) {
				rookFrom = new Position(0,0);
				rookTo = new Position(0,Board.BoardSize-5);
			}
			else {
				rookFrom = new Position(0,Board.BoardSize-1);
				rookTo = new Position(0,Board.BoardSize-2);
			}
		}
		else // black
		{
			if (isLeft) {
				rookFrom = new Position(Board.BoardSize-1,0);
				rookTo = new Position(Board.BoardSize-1,Board.BoardSize-5);
			}
			else {
				rookFrom = new Position(Board.BoardSize-1,Board.BoardSize-1);
				rookTo = new Position(Board.BoardSize-1,Board.BoardSize-2);
			}	
		}
		
		game.MovePiece(rookFrom, rookTo);
		
	} 

	public override List<Position> GetAvailableMoves(Position position, GameController game, bool forAttack=false)
	{
		List<Position> result = new();
		int x = position.X+1;
		int y = position.Y;
		Position pos = new Position(x,y);
		BasePiece piece = game.GetPiece(x,y);
		
		if (position.X < Board.BoardSize-1)
		{
			// up
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);

			// up right
			if (position.Y < Board.BoardSize-1)
			{
				x = position.X+1;
				y = position.Y+1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
			
			// up left
			if (position.Y > 0)
			{
				x = position.X+1;
				y = position.Y-1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
		}
		
		if (position.X > 0)
		{
			// down
			x = position.X-1;
			y = position.Y;
			pos = new Position(x,y);
			piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);
			
			// down right
			if (position.Y < 7)
			{
				x = position.X-1;
				y = position.Y+1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
			
			// down left
			if (position.Y > 0)
			{
				x = position.X-1;
				y = position.Y-1;
				pos = new Position(x,y);
				piece = game.GetPiece(x,y);
				if (piece != null)
				{
					if (piece.Color != Color) result.Add(pos);
				}
				else result.Add(pos);
			}
		}
		
		// right
		if (position.Y < Board.BoardSize-1)
		{
			x = position.X;
			y = position.Y+1;
			pos = new Position(x,y);
			piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);
		}
		
		// left
		if (position.Y > 0)
		{
			x = position.X;
			y = position.Y-1;
			pos = new Position(x,y);
			piece = game.GetPiece(x,y);
			if (piece != null)
			{
				if (piece.Color != Color) result.Add(pos);
			}
			else result.Add(pos);
		}
		
		// castle position
		if (!forAttack)
		{
			var castlePos = GetCastlePosition(game);
			if (castlePos.Count != 0 && castlePos != null)
			{
				result = result.Concat(castlePos).ToList();
			}
		}
		
		return result;
	}

}
