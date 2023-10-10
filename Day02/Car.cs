namespace Vehicle;
class Car 
{
	public string? name;
	public string? color;
	public int maxSpeed;
	public int speed;
	
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
}