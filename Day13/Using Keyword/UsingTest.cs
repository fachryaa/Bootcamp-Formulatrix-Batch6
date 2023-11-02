namespace Day13.Using;

public class UsingTest
{
	public static void Main()
	{
		using(FileStream fs = new("test.txt", FileMode.OpenOrCreate))
		{
			// Do something with fs
			// ...
			
			// ketika block using selesai, maka fs akan dihapus atau di Dispose			
		}
	}
}
