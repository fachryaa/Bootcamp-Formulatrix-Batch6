using Vehicle;
using Animal;
class Program
{
	static void Main(string[] Args)
	{
		// Car c = new Car();
		
		// c.name = "Supra";
		// c.color = "Red";
		// c.maxSpeed = 200;
		// c.speed = 10;
		
		// c.Speeding(5);
		// c.Turn("Right");
		
		// string detailCar = c.Details();
		// Console.WriteLine(detailCar);
		
		Cat cat = new Cat("Oyen", "Orange", 10);
		Console.WriteLine(cat.Details());
		Console.WriteLine(cat.Meow());
	}
}