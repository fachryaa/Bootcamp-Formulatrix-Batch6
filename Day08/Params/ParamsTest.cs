namespace Day08;

public class ParamsTest
{
	public static void Run()
	{
		int[] ints = {1,2,3};
		int result1 = AddNums(ints);
		
		Console.WriteLine($"Result1 : {result1}");
		
		int result2 = AddNums(1,2,3,4,5);
		Console.WriteLine($"Result2 : {result2}");
	}
	
	public static int AddNums(params int[] paramInt)
	{
		int result = 0;
		foreach (var item in paramInt)
		{
			result += item;
		}
		if (result == 1)
		{
			
		}
		
		return result;
	}
}
