namespace Day11;

public class DictionaryTest
{
	public static void Run()
	{
		Dictionary<int,string> myDict = new Dictionary<int,string>(){
			{1, "one"},
			{2, "two"},
			{3, "three"},
			{4, "four"},
			{5, "five"}
		};
		
		// Add Dict
		myDict.Add(6, "six");
		
		// Remove Dict
		myDict.Remove(6);
		
		// Update Dict
		myDict[5] = "FIVE";
		
		// Print Dict
		foreach(KeyValuePair<int,string> kvp in myDict)
		{
			Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
		}
		
		// Print Dict Keys
		foreach(int key in myDict.Keys)
		{
			Console.WriteLine($"Key: {key}");
		}
		
		// Print Dict Values
		foreach(string value in myDict.Values)
		{
			Console.WriteLine($"Value: {value}");
		}
		
		// TryAdd
		//! myDict.Add(6, "sixx"); Will throw an exception because key 6 already exists
		myDict.TryAdd(6, "sixx");	// Will not add because key 6 already exists
		
	}
}
