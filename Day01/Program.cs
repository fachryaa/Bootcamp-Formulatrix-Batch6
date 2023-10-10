using Day01;

internal class Program
{
	private static void Main(string[] args)
	{
		Cat Oyen = new Cat();

		Oyen.Name = "Oyen";
		Oyen.Colour = "Orange";
		Oyen.Leg = 5;
		Oyen.IsTailLong = true;
		Oyen.Weight = 100;
		Oyen.Height = 50;

		Console.Write("Name : ");
		Console.WriteLine(Oyen.Name);
		Console.Write("Colour : ");
		Console.WriteLine(Oyen.Colour);
		Console.Write("Leg : ");
		Console.WriteLine(Oyen.Leg);
		Console.Write("Is Tail Long : ");
		Console.WriteLine(Oyen.IsTailLong);
		Console.Write("Weight : ");
		Console.WriteLine(Oyen.Weight);
		Console.Write("Height : ");
		Console.WriteLine(Oyen.Height);

		Oyen.Jump();

		Console.WriteLine();

		Cat Bambang = new Cat();

		Bambang.Name = "Bambang";
		Bambang.Colour = "Black";
		Bambang.Leg = 10;
		Bambang.IsTailLong = false;
		Bambang.Weight = 500;
		Bambang.Height = 10;

		Console.Write("Name : ");
		Console.WriteLine(Bambang.Name);
		Console.Write("Colour : ");
		Console.WriteLine(Bambang.Colour);
		Console.Write("Leg : ");
		Console.WriteLine(Bambang.Leg);
		Console.Write("Is Tail Long : ");
		Console.WriteLine(Bambang.IsTailLong);
		Console.Write("Weight : ");
		Console.WriteLine(Bambang.Weight);
		Console.Write("Height : ");
		Console.WriteLine(Bambang.Height);

		Bambang.Run();
		
		Console.WriteLine("test");
	}
}