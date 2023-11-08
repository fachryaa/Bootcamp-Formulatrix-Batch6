using System.Collections.Generic;

class Program
{
	public static void Main()
	{
		List<int> a = new List<int>(){1,2,3};
		
		List<int> b = new List<int>(){1,2,3};
		
		List<int> c = new List<int>(){1,2,3};
		
		List<int> result = new();
		result = result.Concat(a).ToList();
		result = result.Concat(b).ToList();
		
		Console.WriteLine($"{result.Count}");
		
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