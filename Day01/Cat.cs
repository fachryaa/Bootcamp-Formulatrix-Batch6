namespace Day01;
public class Cat
{
    public string Name;
    public string Colour;
    public int Leg;
    public bool IsTailLong;
    public int Weight;
    public int Height;

    public void Jump()
    {
        Console.WriteLine($"{Name} is jumping");
    }

    public void Run()
    {
        Console.WriteLine($"{Name} is running");
    }

    public void Eat()
    {
        Console.WriteLine($"{Name}is eating");
    }

    public void Drop()
    {
        Console.WriteLine("Drop");
    }
}