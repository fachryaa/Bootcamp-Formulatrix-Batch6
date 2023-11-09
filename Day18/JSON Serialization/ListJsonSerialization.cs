using System.Runtime.Serialization;
using System.Text.Json;

namespace Day18;



public class ListJsonSerialization
{
	public static void Run()
	{
		List<Person> people = new List<Person>
		{
			new Person{ Name="Joko", Age=1},
			new Person{ Name="Joki", Age=2},
			new Person{ Name="Jiki", Age=3}
		};
		
		string jsonString = JsonSerializer.Serialize(people);
		Console.WriteLine(jsonString);
		
		
		// Serialize dictionary
		Dictionary<Person, Card> personCard = new Dictionary<Person, Card>();
		Person person1 = new Person{ Name= "Joko", Age=1};
		Person person2 = new Person{ Name= "Joku", Age=2};
		Person person3 = new Person{ Name= "Joki", Age=3};
		Card card1 = new Card{ id = 11};
		Card card2 = new Card{ id = 22};
		Card card3 = new Card{ id = 33};
		personCard.Add(person1, card1);
		personCard.Add(person2, card2);
		personCard.Add(person3, card3);
		
		//! string jsonStringDict = JsonSerializer.Serialize(personCard); use DataContract instead
		// Console.WriteLine(jsonStringDict);
		
	}
}
