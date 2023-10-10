namespace LivingBeing;

public class Fish : Animal
{
	public string? habitat;
	public Fish(string name, int age, string habitat) : base(name, age, false)
	{
		this.habitat = habitat;
		Console.WriteLine("Instance Fish was created");
	}
}
