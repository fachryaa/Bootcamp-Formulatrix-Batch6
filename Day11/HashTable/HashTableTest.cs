using System.Collections;

namespace Day11;

public class HashTableTest
{
	public static void Run()
	{
		Hashtable hashtable = new();
		
		// Add
		hashtable.Add(1, "one");
		hashtable.Add("two", 2);
		hashtable.Add(true, 3.0f);
		
		// Hashtable is not generic, so it can store any type of data
		// But it is not recommended to store different types of data in a Hashtable
		// Because it is not type safe
		// So, it is recommended to use a generic Dictionary instead of a Hashtable
	}
}
