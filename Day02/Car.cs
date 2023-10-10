using CarComponent;

namespace Vehicle;
class Car 
{
	public string? name;
	public string? color;
	public int maxSpeed;
	public int speed;
	
	public Engine engine;
	public Tire tire;
	public Lamp lamp;
	
	public Car(Engine engine, Tire tire, Lamp lamp)
	{
		this.engine = engine;
		this.tire = tire;
		this.lamp = lamp;
	}
	
	public void Speeding(int s)
	{
		speed += s;
		Console.WriteLine($"The {name} car is speeding by {s}");
	}
	public void Turn(string direction)
	{
		Console.WriteLine($"The {name} car is turning {direction}");
	}
	
	public string Details()
	{
		return $"Name\t: {name}\n" +
				$"Color\t: {color}\n" +
				$"Speed\t: {speed}\n" +
				$"MaxSpeed: {maxSpeed}";
	}
	
	public string EngineDetails()
	{
		return $"Engine Type\t: {engine.engineType}\n" +
				$"Engine Brand\t: {engine.engineBrand}\n";
	}
	
}