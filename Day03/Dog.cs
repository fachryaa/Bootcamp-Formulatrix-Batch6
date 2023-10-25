namespace Day03;

public class Dog : Animal
{
	public Dog(string name) : base(name)
	{
		Console.WriteLine($"Dog was created");
		
	}
	
	// Overriding method from parent class using new keyword
	public new void Eat()
	{
		// Call method from parent
		base.Eat();
		Console.WriteLine("new method Eat");
	}
}
