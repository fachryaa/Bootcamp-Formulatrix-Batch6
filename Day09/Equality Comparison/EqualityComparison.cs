namespace Day09;

public class EqualityComparison
{
	public static void Run()
	{
		Car carA = new Car(1);
		Car carB = new Car(1);
		
		Mobil mobil = new Mobil();
		
		bool result1 = carA.Equals(carB);
		Console.WriteLine($"result1 : {result1}");
		
		bool result2 = carA.Equals(mobil);
		Console.WriteLine($"result2 : {result2}");
	}
}

class Mobil{}
class Car
{
	public int Id { get; private set; }
	public Car(int id)
	{
		Id = id;
	}

	// Override Equals
	public override bool Equals(object? obj)
	{
		if(obj is Car y)
		{
			var car = obj as  Car;
			return Id == y.Id;
		}
		
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

}