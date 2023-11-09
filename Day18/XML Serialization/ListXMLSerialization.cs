using System.Xml.Serialization;

namespace Day18;

public class ListXMLSerialization
{
	public static void Run()
	{
		List<Person> people = new List<Person>
		{
			new Person{ Name="Joko", Age=1},
			new Person{ Name="Joki", Age=2},
			new Person{ Name="Jiki", Age=3}
		};
		
		Type type= people.GetType();
		
		XmlSerializer serializer = new XmlSerializer(type);
		
		// Serialize to XML
		using (StreamWriter writer = new StreamWriter("ListPerson.xml"))
		{
			serializer.Serialize(writer,people);
		}
		
		List<Person> deList;
		
		// Deserialize to List
		using (StreamReader reader = new StreamReader("ListPerson.xml"))
		{
			deList = (List<Person>)serializer.Deserialize(reader);
		}
		
		// print out
		foreach (var person in deList)
		{
			Console.WriteLine($"Name : {person.Name}\nAge : {person.Age}");
		}
	}
}
