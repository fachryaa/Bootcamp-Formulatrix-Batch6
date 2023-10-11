namespace Day03;

public class Cat : Animal
{
	private string _species = "none";
	
	
	
	public string GetSpecies()
	{
		return _species;
	}
	public void SetSpecies(string species)
	{
		_species = species;
	}
	
	public void Mam()
	{
		Eat();
	}

	public string Details()
	{
		return $"Name\t: {Name} \nSpecies\t: {_species} \nAge\t: {Age}";
	}

	// Overloading
	public Cat(string name) : base(name)
	{
		Console.WriteLine($"Cat was created");
	}
	public Cat(string name, string species, int age) : base(name, age)
	{
		Console.WriteLine($"Cat was created");
		_species = species;
	}


    // Overriding
    public override void MakeSound()
    {
        Console.WriteLine($"Meowww....");
		
    }








    public void checkVarParent()
	{
		// Error
		// string a = _animalPrivate;
		
		// Error
		// test();
	}
}
