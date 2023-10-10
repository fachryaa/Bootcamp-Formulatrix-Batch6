namespace LivingBeing;

public class Animal
{
	public string name;
	public int age;
	public bool isMammal;
	public void Eat()
	{
		Console.WriteLine($"The {name} is eating");
	}
	public Animal(string name, int age, bool isMammal)
	{
		this.name = name;
		this.age = age;
		this.isMammal = isMammal;
	}
	
	public void checkMammal()
	{
		if (isMammal) Console.WriteLine($"{name} is Mammal");
		else Console.WriteLine($"{name} is not Mammal");
	}
	
	public void Details()
	{
		string d = $"Name\t: {name} \nAge\t: {age} \nMammal\t: {isMammal}";
		Console.WriteLine(d);
	}
}
