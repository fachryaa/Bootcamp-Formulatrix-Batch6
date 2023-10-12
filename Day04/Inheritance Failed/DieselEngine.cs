namespace Day04;

public class DieselEngine : Engine
{
	public override void Run()
	{
		Console.WriteLine($"Diesel Engine Run...");	
	}
	
	public void WarmUp()
	{
		Console.WriteLine($"Diesel Engine Warm Up...");
	}
}
