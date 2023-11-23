namespace ChessLibrary;

public interface IPosition
{
	int X { get; }
	int Y { get; }
	
	/// <summary>
	/// Returns true if the position is equal to the given position.
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	bool Equals(IPosition position);
}
