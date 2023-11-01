using System.Text;

namespace Day12;

public class Program
{
	public static void Main()
	{
		string result = String.Empty;
		int iteration = 100000;
		
		for (int i = 0; i < iteration; i++)
		{
			result += "a";
			result += "b";
		}
		Console.WriteLine(result);
	}
}