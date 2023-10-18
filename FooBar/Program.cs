namespace FooBar;

static class Program
{
	static void Main(string[] Args)
	{
		int num;
		do 
		{
			Console.Write("Masukkan angka: ");
		} while (!int.TryParse(Console.ReadLine(), out num));
		
		string result = FooBar.Run(num);
		
		Console.WriteLine(result);
	}
}