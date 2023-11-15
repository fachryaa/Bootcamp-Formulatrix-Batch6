namespace ChessLibrary.Pieces;

public class Queen : BasePiece, IMoveable
{
	
	public Queen(Enum.Color color) : base(Enum.PieceType.Queen, color)
	{
		
	}

	public override IEnumerable<IPosition> GetAvailableMoves(IPosition position, GameController game, bool forAttack=false)
	{
		List<IPosition> result = new();
		
		// bishop moves
		int x = position.X;
		int y = position.Y;
		
		// up right
		while(x < Board.BoardSize-1 && y < Board.BoardSize-1)
		{
			x++;
			y++;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		x = position.X;
		y = position.Y;
		// up left
		while(x < Board.BoardSize-1 && y > 0)
		{
			x++;
			y--;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		x = position.X;
		y = position.Y;
		// down right
		while(x > 0 && y < Board.BoardSize-1)
		{
			x--;
			y++;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		x = position.X;
		y = position.Y;
		// down left
		while(x > 0 && y > 0)
		{
			x--;
			y--;
			if (!AddMoveToResult(game, result, new Position(x,y))) break;
		}
		
		// rook moves
		// vertical up
		for (int i=position.X+1; i < Board.BoardSize; i++)
		{
			if (!AddMoveToResult(game, result, new Position(i, position.Y))) break;
		}
		
		// vertical down
		for (int i=position.X-1; i >= 0; i--)
		{
			if (!AddMoveToResult(game, result, new Position(i, position.Y))) break;
		}
		
		// horizontal left
		for (int i=position.Y-1; i >= 0; i--)
		{
			if (!AddMoveToResult(game, result, new Position(position.X, i))) break;
		}
		
		// horizontal right
		for (int i=position.Y+1; i < Board.BoardSize; i++)
		{
			if (!AddMoveToResult(game, result, new Position(position.X, i))) break;
		}		
		
		return result;
		
	}
	
	public bool AddMoveToResult(GameController game, List<IPosition> result, IPosition pos)
	{
		var piece = game.GetPiece(pos);

		if (piece != null)
		{
			if (piece.Color != Color) result.Add(pos);
			return false;
		}
		else result.Add(pos);
		
		return true;
	}

}
