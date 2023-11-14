namespace ChessLibrary;

public interface IPosition
{
	int X { get; set; }
	int Y { get; set; }
	
	bool Equals(IPosition position);
}
