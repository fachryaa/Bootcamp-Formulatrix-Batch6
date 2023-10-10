namespace Animal;

public class Cat
{
	public string name;
	public string color;
	public int age;
	
	public Cat(string name, string color, int age)
	{
		this.name = name;
		this.color = color;
		this.age = age;
	}
	
	public string Details()
	{
		return $"Name: {name} \nColor: {color} \nAge: {age}";
	}
	
	public string Meow()
	{
		return "MEEOOOWWWWWWWW.....";
	}
}
