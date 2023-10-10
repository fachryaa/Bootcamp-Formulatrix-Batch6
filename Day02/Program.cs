using Vehicle;
using Animal;
using CarComponent;
using LivingBeing;
class Program
{
	static void car1()
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
	}
	
	static void cat1()
	{
		Cat cat = new Cat("Oyen", "Orange", 10);
		Console.WriteLine(cat.Details());
		Console.WriteLine(cat.Meow());
	}
	
	static void car2()
	{
		Engine engine = new Engine("Diesel", "BMW");
		Tire tire = new Tire();
		Lamp lamp = new Lamp();
		
		Car car = new Car(engine, tire, lamp);
		Console.WriteLine(car.EngineDetails());
		
		engine.engineType = "Bensin";
		engine.engineBrand = "Toyota";
		
		Console.WriteLine(car.EngineDetails());
	}
	
	static void Main(string[] Args)
	{
		Lion lion = new Lion("Harimau", 10, "Harimau Sumatra");
		Fish fish = new Fish("Hiu", 30, "Laut");
		
		lion.Details();
		fish.Details();
	}
}