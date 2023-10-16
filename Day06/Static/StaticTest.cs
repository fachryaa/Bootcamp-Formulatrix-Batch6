namespace Day06;

public class StaticTest
{
	public static void Run()
	{
		int x = 10;
		int y = 20;
		
		// static method
		int result = Calculator.Add(x, y);
		Console.WriteLine($"Result : {result}");
		
		// non static method
		Calculator calculator = new();
		int result2 = calculator.AddNonStatic(x, y);
		Console.WriteLine($"result2 : {result2}");
		Console.WriteLine();
		
		// Static
		Item item = new();
		Item item2 = new();
		
		item.PriceHandler(1000);
		item2.PriceHandler(2000);
		
		Console.WriteLine($"item 1 : {item.GetPrice()}");
		Console.WriteLine($"item 2 : {item2.GetPrice()}");
		Console.WriteLine();
		
		
	}
}

class Calculator
{
	public static int Add(int left, int right)
	{
		return left + right;
	}
	
	public int AddNonStatic(int left, int right)
	{
		return left + right;
	}
}

static class CalculatorStatic
{
	//! public void Add(int left, int right){} Error karena class static membernya harus semuanya static
}

class Item
{
	public static int StaticPrice;
	public int NonStaticPrice;
	public void PriceHandler(int price)
	{
		StaticPrice = price;
	}
	
	//! Error karena static method tidak bisa mengakses variable non static
	// public static int GetPrice()
	// {
	// 	return NonStaticPrice;
	// }
	
	public int GetPrice()
	{
		return StaticPrice;
	}
}