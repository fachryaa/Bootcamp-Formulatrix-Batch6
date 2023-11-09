using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace Day18;



public class XMLSerializationTest
{
	public static void Run()
	{
		Person person = new Person
		{
			Name = "test",
			Age = 1
		};
		
		Type type = typeof(Person);
		
		XmlSerializer serializer = new XmlSerializer(type);
		
		// Serialize to XML
		using (StreamWriter writer = new StreamWriter("person.xml"))
		{
			serializer.Serialize(writer, person);
		}
		
		Person deserializedPerson = new();
		
		// Deserialize to object Person
		using (StreamReader reader = new StreamReader("person.xml"))
		{
			deserializedPerson = (Person)serializer.Deserialize(reader);
		}
		
		Console.WriteLine($"Name : {deserializedPerson.Name}\nAge : {deserializedPerson.Age}");
	}
}
