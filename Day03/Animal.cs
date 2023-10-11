namespace Day03;

public class Animal
{	
	private int _age;
	// Property
	protected string Name { get; set; }
	public int Age 
	{
		get 
		{
			return _age;	
		}
		set 
		{
			if (value > 0) _age = value;
			else _age = 0;
		}
	}
	protected void Eat()
	{
		Console.WriteLine("Protected Method Eat from Animal class was called");
	}
	
	// Overloading
	public Animal(string name)
	{
		Name = name;
		Console.WriteLine($"Animal was created");
		
	}
	
	public Animal(string name, int age)
	{
		Name = name;
		_age = age;
	}
	
	// Overriding
	public virtual void MakeSound()
	{
		Console.WriteLine($"Make Sound...");
	}
	
	
	
	
	private string? _animalPrivate;
	// default private
	void test()
	{
		Eat();
		Console.WriteLine("Test");
	}
	
	public int varA;
	public readonly int varReadOnly = 10;
	public const int varConst = 10;
}

