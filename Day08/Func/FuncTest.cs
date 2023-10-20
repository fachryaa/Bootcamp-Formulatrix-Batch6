using System.Security.AccessControl;

namespace Day08;

public class FuncTest
{
	public static void Run()
	{
		// Create Func
		// input, input, output
		Func<int, int, int> ops = Add;
		ops += Substract;
		
		var opss = ops.GetInvocationList();
		
		foreach (Func<int,int,int> item in opss)
		{
			int x = item(1,2);
			Console.WriteLine(x);
		}
	}
	
	public static int Add(int left, int right)
	{
		return left + right;
	}
	
	public static int Substract(int left, int right)
	{
		return left - right;
	}
	
}
