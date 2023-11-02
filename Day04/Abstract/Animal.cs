namespace Day04.Abstract;

abstract public class Animal
{
	public int Name { get; set; }
	abstract public void Sound();
	public void Run()
	{
		Console.WriteLine($"Animal Run...");
		
	}
}

abstract public class FlyAnimal : Animal
{
	abstract public void Fly();
}

class Test : FlyAnimal
{
    public override void Fly()
    {
        throw new NotImplementedException();
    }

    public override void Sound()
    {
        throw new NotImplementedException();
    }
}