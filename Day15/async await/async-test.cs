namespace Day15;

public class asyncTest
{
	public async static Task Run()
	{
		Console.WriteLine($"Starting program");
		
		await DatabaseCRUD();
		
		 Task<int> result = Add(1,2);
		 await result;
		 Console.WriteLine($"Result : {result.Result}");
		 
	}
	
	public async static Task DatabaseCRUD()
	{
		await Task.Delay(1000);
	}
	
	public async static Task<int> Add(int a, int b)
	{
		Console.WriteLine($"Calculating");
		await Task.Delay(1000);
		return a + b;
	}
}
