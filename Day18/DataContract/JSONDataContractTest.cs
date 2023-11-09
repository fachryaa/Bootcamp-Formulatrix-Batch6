using System.Runtime.Serialization.DataContracts;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Day18;

[DataContract]
public class Person
{
	[DataMember]
	public string? Name { get; set; }
	[DataMember]
	public int Age { get; set; }
}

[DataContract]
public class Card
{
	[DataMember]
	public int id;
}

public class JSONDataContractTest
{
	public static void Run()
	{
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

		DataContractJsonSerializer serializer = new DataContractJsonSerializer(personCard.GetType());
		
		// write to json
		using (FileStream fs = new FileStream("dictPersonCard.json", FileMode.Create))
		{
			using (var writer = JsonReaderWriterFactory.CreateJsonWriter(fs, Encoding.UTF8, true, true, "\t"))
			{
				serializer.WriteObject(writer, personCard);
			}
		}
		
		// read json
		Dictionary<Person, Card> result = new();
		Type type = result.GetType();
		using (FileStream fs = new FileStream("dictPersonCard.json", FileMode.Open))
		{
			result = (Dictionary<Person,Card>) serializer.ReadObject(fs);
		}
		foreach (var item in result)
		{
			// ...
		}
	}
}
