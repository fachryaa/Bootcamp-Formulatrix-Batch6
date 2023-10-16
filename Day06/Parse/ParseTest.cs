namespace Day06;

public class ParseTest
{
	public static void Run()
	{
		// parsing string to int
		string myStr = "10";
		int myInt = int.Parse(myStr);
		
		
		string myStr2 = "10x";
		//! int myInt2 = int.Parse(myStr2); Akan memunculkan exception
		bool isNumeric = int.TryParse(myStr2, out int myInt2);
		
		if(isNumeric)
		{
			Console.WriteLine($"myInt2 : {myInt2}");
		}
		else
		{
			Console.WriteLine($"myStr2 is not numeric");
		}
	}
}
