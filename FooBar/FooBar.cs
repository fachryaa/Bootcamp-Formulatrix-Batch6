using System.Text;
namespace FooBar;

public static class FooBar
{
	private static StringBuilder _result = new StringBuilder();

	private static StringBuilder Decide(int num)
	{
		if (num % 3 == 0 && num % 5 == 0 && num != 0) return new StringBuilder("FooBar");
		else if (num % 3 == 0 && num != 0) return new StringBuilder("Foo");
		else if (num % 5 == 0 && num != 0) return new StringBuilder("Bar");
		else return new StringBuilder(num.ToString());
	}
	
	public static string Run(int num)
	{
		for (int i = 0; i <= num; i++)
		{ 
		  	_result.Append(Decide(i));

		  	// Print koma
		  	if (i != num) _result.Append(", ");
		}
		
		return _result.ToString();
	}
}
