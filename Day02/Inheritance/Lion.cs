namespace LivingBeing;

public class Lion : Animal
{
	public string species;
	public Lion(string name, int age, string species) : base(name, age, true)
	{
		this.species = species;
		Console.WriteLine("Instance Lion was created");
	}
	public void Roar()
	{
		Console.WriteLine($"The {name} Lion Roars");
	}
}
