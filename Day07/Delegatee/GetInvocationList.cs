namespace Day07;

public delegate string MyDelegate();
public class GetInvocationList
{
	public static void Run()
	{
		Test t = new();
		
		// Add method to delegate
		MyDelegate myDelegate = t.Method1;
		myDelegate += t.Method2;
		myDelegate += t.Method3;
		
		// Get Invocation List
		List<string> myListString = new();
		var delegates = myDelegate.GetInvocationList();
		
		// Check if delegates contains a method
		MyDelegate m = t.Method1;
		bool isContain = delegates.Contains(m);
		Console.WriteLine(isContain);
				
		// invoke each delegate and store to list
		foreach (MyDelegate del in delegates)
		{
			myListString.Add(del.Invoke());
		}
		
		// print out list
		foreach (var item in myListString)
		{
			Console.WriteLine(item);
		}
	}	
}

class Test
{
	public string Method1()
	{
		return "Method1";
	}
	public string Method2()
	{
		return "Method2";
	}
	public string Method3()
	{
		return "Method3";
	}
}

