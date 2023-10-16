namespace Day05.Generic;

static class GenericCollector
{
	public static void Run()
	{
		// Generic Collection
		GenericCollection<int> collection = new();
		collection.Add(10);
		collection.Add(9);
		collection.Add(8);

		int first = collection.myCollection[0];
		Console.WriteLine(first);

		GenericCollection<string> collection1 = new();
		collection1.Add("test");
		collection1.Add("test");
		collection1.Add("test");

		var first1 = collection1.myCollection[0];
		Console.WriteLine(first1);
		
		// Multiple Generic
		GenericCollection2<int, string> collection2 = new();
		collection2.Add(0, "Nol");
		collection2.Add(1, "Satu");
		collection2.Add(2, "Dua");
		
		collection2.GetData(0);
		
		//Generic With Abstraction
		List<ITransport> myList = new List<ITransport>();
		myList.Add(new Car());
		myList.Add(new Truck());
		myList.Add(new Plane());
	}
}

class GenericCollection<T>
{
	public T[] myCollection = new T[100];
	public int counter = 0;

	public bool Add(T input)
	{
		myCollection[counter] = input;
		counter++;
		return true;
	}
}

class GenericCollection2<T1, T2>
{
	public T1[] collection1 = new T1[100];
	public T2[] collection2 = new T2[100];
	private int _counter = 0;
	
	public void Add(T1 first, T2 second)
	{
		collection1[_counter] = first;
		collection2[_counter] = second;
		_counter++;
	}
	
	public void GetData(int index)
	{
		Console.WriteLine($"{collection1[index]} : {collection2[index]}");
	}
}

public interface ITransport {}
class Car : ITransport {}
class Truck : ITransport {}
class Plane : ITransport {}