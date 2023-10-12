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
