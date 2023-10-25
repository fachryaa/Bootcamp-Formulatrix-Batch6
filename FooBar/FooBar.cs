using System.Text;
namespace FooBar;

public static class FooBar
{
	private static Dictionary<int, string> _conditions = new Dictionary<int, string>()
	{
		{3, "Foo"},
		{5, "Bar"}
	};
	
	public static void AddCondition(int key, string value)
	{
		// check if key already exists
		if (_conditions.ContainsKey(key))
		{
			_conditions[key] = value;
		}
		else
		{
			_conditions.Add(key,value);
		}
	}
	
	public static StringBuilder Decide(int num)
	{
		// create StringBuilder
		StringBuilder result = new();
		
		// return 0 if num=0
		if (num == 0) return new StringBuilder("0");
		
		// check all condition using foreach
		int counter = 0; // counter to check at least one condition is true
		foreach (var condition in _conditions)
		{
			// if condition is true, append the value
			if (num % condition.Key == 0)
			{
				result.Append(condition.Value);
				counter++;
			}
		}
		
		// if no condition is true, return num
		if (counter == 0) result.Append(num);		
		
		return result;
	}
	private static StringBuilder _result = new StringBuilder();

	
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
