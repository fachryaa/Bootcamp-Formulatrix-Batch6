namespace ChessLibrary;

public class Position : IPosition
{
	public int X{ get; set; }
	public int Y{ get; set; }

	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}

	public bool Equals(IPosition pos)
	{
		return this.X == pos.X && this.Y == pos.Y;
	}
	
	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
			return false;

		Position other = (Position)obj;
		return X == other.X && Y == other.Y;
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hash = 17;
			hash = hash * 23 + X.GetHashCode();
			hash = hash * 23 + Y.GetHashCode();
			return hash;
		}
	}
}