namespace Day08;

public class AnonymousTest
{
	public static void Run()
	{
		// Lambda Expression
		// (parameter) => (return);
		var add = (int x, int y) => (x+y).ToString();
		
		// or
		// func
		Func<int,int,string> add2 = (int x, int y) => (x+y).ToString();
		
		string result = add(1,2);
		Console.WriteLine($"result : {result}");
	}
}
