namespace Day03;

public class Bird : Animal
{
	public Bird(string name) : base(name)
	{
		Console.WriteLine($"Bird was created");
		
	}
	
	public new void MakeSound()
	{
		Console.WriteLine($"Chip...");
		
	}
}
