namespace FooBar;

static class Program
{
	static void Main(string[] Args)
	{		
		// Input num
		InputNum(out int num);		
		
		// Add condition
		FooBar.AddCondition(9, "Fizz");
		FooBar.AddCondition(11, "Buzz");
		
		// Run the library
		string result = FooBar.Run(num);
		
		Console.WriteLine(result);
	}
	
	static void InputNum(out int num)
	{
		do 
		{
			Console.Write("Masukkan angka: ");
		} while (!int.TryParse(Console.ReadLine(), out num) || num < 0);
	}
}