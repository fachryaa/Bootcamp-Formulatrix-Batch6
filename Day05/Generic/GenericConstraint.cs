using System.Numerics;

namespace Day05.Generic;

public class GenericConstraint
{
	public static void Run()
	{
		// Generic Constraint
		Combiner<int> combineInt = new();
		var result = combineInt.Add(2,3);
		Console.WriteLine($"Result combineInt = {result}");
		
		//! Combiner<string> combiner2 = new(); Error karena string tidak termasuk IAdditionOperators
		
		Item item1 = new(1000);
		Item item2 = new(2000);
		Combiner<Item> combine = new();
		// var item3 = new Item(1000) + new Item(2000);
		var item3 = combine.Add(item1, item2);
		Console.WriteLine($"item1.Price = {item1.Price}");
		Console.WriteLine($"item2.Price = {item2.Price}");
		Console.WriteLine($"Result item3.Price = {item3.Price}");
	}
}

class Combiner<T> where T : IAdditionOperators<T,T,T>
{
	public T Add(T a, T b)
	{
		return a + b;
	}
}

class Item : IAdditionOperators<Item, Item, Item>
{
	public Item(int price)
	{
		Price = price;
	}
	
	public int Price { get; set; }
	
	public static Item operator +(Item left, Item right)
	{
		return new Item(left.Price + right.Price);
	}
	public static Item operator -(Item left, Item right)
	{
		return new Item(left.Price - right.Price);
	}

}
