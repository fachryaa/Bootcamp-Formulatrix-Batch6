using System.Text.Json;

namespace Day18;

public class JsonSerializationTest
{
	public static void Run()
	{
		Person person = new Person
		{
			Name = "fachry",
			Age = 22
		};
		
		string jsonString = JsonSerializer.Serialize(person);
		Console.WriteLine(jsonString); // result
		
		
		// write string to json file
		using (StreamWriter writer = new StreamWriter("person.json"))
		{
			writer.Write(jsonString);
		}
		
		// Read json file and attach to object Person
		string stringJsonResult;
		using (StreamReader reader = new StreamReader("person.json"))
		{
			stringJsonResult = reader.ReadToEnd();
		}
		
		Person dePerson = JsonSerializer.Deserialize<Person>(stringJsonResult);
		Console.WriteLine($"Name : {dePerson.Name}\nAge : {dePerson.Age}");
	}
}
