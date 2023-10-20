namespace Day08;

public class ExceptionTest
{
	public static void Run()
	{
		int a;
		int b;
		int result = 0;
		try
		{
			Console.WriteLine("Input : ");
			a = int.Parse(Console.ReadLine());
			b = int.Parse(Console.ReadLine());
			result = DivideNum(a, b);
			
		}
		catch (DivideByZeroException e)
		{
			Console.WriteLine(e.Message);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		finally
		{
			Console.WriteLine("Finally...");
			Console.WriteLine($"Result : {result}");
		}
	}
	
	private static int DivideNum(int left, int right)
	{
		Console.WriteLine("DivideNum Method called...");
		return left / right;
	}
}
