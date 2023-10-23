namespace Day09;

public class EnumerableTest
{
	public static void Run()
	{
		List<int> myInt = new List<int> {1,2,3};
		var enumerable = myInt.GetEnumerator();
		
		enumerable.MoveNext();
		enumerable.MoveNext();
		
		int result = enumerable.Current;
		Console.WriteLine($"Result : {result}");
		
		foreach (var item in myInt)
		{
			Console.WriteLine(item);
		}
	}
}
