using System.Collections.Generic;

class Program
{
	public static void Main()
	{
		Dictionary<Position, Piece> board = new();
		board.Add(new Position(0, 0), new Piece("test"));
		
		// print (0,0) piece name
		Position x = board.FirstOrDefault(x => x.Key.X == 0 && x.Key.Y == 0).Key;
		Console.WriteLine(board[x].Name);
		
		var y = new Position(0, 0);
		var z = new Position(0, 0);
		
		Console.WriteLine(y.Id);
	}
}

class Position
{
	public static int count = 0;
	public int Id;
	public int X { get; set; }
	public int Y { get; set; }
	public Position(int x, int y)
	{
		Id = count++;
		X = x;
		Y = y;
	}
}

class Piece
{
	public string Name { get; set; }
	public Piece(string name)
	{
		Name = name;
	}
}