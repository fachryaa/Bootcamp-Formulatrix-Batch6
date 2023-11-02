namespace Day06;

public class RefInOut
{
	public static void Run()
	{
		// ref
		int num = 10;
		Console.WriteLine($"num : {num}");
		AddTwo(ref num);
		Console.WriteLine($"num after pass by ref: {num}");
		Console.WriteLine();

		// Out
		AddTwoOut(out int num2);
		Console.WriteLine($"num2 : {num2}");
		Console.WriteLine();

		// In
		int num3 = 10;
		int num4 = AddTwoIn(num3);
		Console.WriteLine($"num4 : {num4}");
		Console.WriteLine();
		
		// Reference type doesnt need ref
		Car car = new(1000);
		Console.WriteLine($"Price Car : {car.price}");
		MultiplyCar(car);
		Console.WriteLine($"Price Car After Multiply : {car.price}");
		
		// String termasuk reference type, tapi immutable. Sehingga memerlukan ref
		string myStr = "Hello";
		Console.WriteLine($"myStr : {myStr}");
		StringChange(myStr);
		Console.WriteLine($"myStr after change without ref: {myStr}");
		StringChangeRef(ref myStr);
		Console.WriteLine($"myStr after change with ref: {myStr}");
	}

	static void StringChangeRef(ref string s)
	{
		s += "World";
	}
	static void StringChange(string s)
	{
		s += "World";
	}
	static void AddTwo(ref int x)
	{
		x += 2;
	}

	static void AddTwoOut(out int x)
	{
		x = 10;
		x += 2;
	}

	static int AddTwoIn(in int x)
	{
		//! x = 10; Error karena in read-only
		return x + 2;
	}
	
	static void MultiplyCar(Car car)
	{
		car.price *= 2;
	}
}

class Vehicle
{
	public VehicleType t;
	public Vehicle(VehicleType t)
	{
		this.t = t;
	}
}

class Car : Vehicle
{
	public int price = 1000;
	public Car(int price) : base(VehicleType.Car)
	{
		this.price = price;
	}
}

static class Test
{
	public static void Run()
	{
		Car c = new(2000);
		
		unboxing(c);
	}
	public static void unboxing(Vehicle v)
	{
		if (v.t == VehicleType.Car)
		{
			v = (Car) v;
		}
	}
}

enum VehicleType
{
	Car,
	Bike
}