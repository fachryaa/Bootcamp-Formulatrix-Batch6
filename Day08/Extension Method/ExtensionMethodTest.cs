namespace Day08;

public class ExtensionMethodTest
{
	public static void Run()
	{
		string str = "Hello";
		str.PrintSubString("World", "Tsetset", "okay");
	}
}

static class MyExtension
{
	public static void PrintSubString(this string str, params string[] param)
	{
		Console.WriteLine(str);
		foreach (var item in param)
		{
			Console.Write(item);
		}
	}
}

