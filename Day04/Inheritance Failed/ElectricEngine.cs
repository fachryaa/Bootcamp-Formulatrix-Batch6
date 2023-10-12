namespace Day04;

public class ElectricEngine : Engine
{
	public override void Run()
	{
		Console.WriteLine($"Electric Engine Run...");	
	}
	
	public void WarmUp()
	{
		Console.WriteLine($"Electric Engine Warm Up...");
	}
}
