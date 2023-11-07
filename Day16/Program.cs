
namespace Day16;

public class Program
{
	public static void Main()
	{
		CondTest.Run();		
		
		int[] arr = new int[] {1, 2, 3};
		
		Dictionary<Position,int> dict = new Dictionary<Position, int>();
		dict.Add(new Position { X = 1, Y = 2 }, 1);
		dict.Add(new Position { X = 2, Y = 3 }, 2);
		dict.Add(new Position { X = 3, Y = 4 }, 3);
	}
}

public class Position
{
	public int X { get; set; }
	public int Y { get; set; }
}