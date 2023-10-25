namespace Day03;

class Program
{
	static void Main(string[] Args)
	{
		Cat cat = new Cat("Oyen");
		
		cat.Age = -99;
		cat.SetSpecies("Persia");
		
		Console.WriteLine(cat.Details());
		Console.WriteLine();
		
		cat.Age = 10;
		Console.WriteLine(cat.Details());
		Console.WriteLine();
		
		cat.Mam();
		
		Console.WriteLine();
		Cat cat2 = new Cat("Dinyul", "Calico", 10);
		Console.WriteLine(cat2.Details());
		Console.WriteLine();
		
		
		// test overriding
		Cat cat3 = new Cat("rycul", "Oyen", 5);
		cat3.MakeSound();
		Animal parentCat3 = new Animal("Parent Rycul");
		parentCat3.MakeSound();
		Console.WriteLine();
		
		Dog dog = new Dog("Tom");
		dog.MakeSound();
		Animal parentDog = new Animal("Parent Tom");
		parentDog.MakeSound();
		Console.WriteLine();
		
		Bird bird = new Bird("Kakatua");
		bird.MakeSound();
		Animal parentBird = new Animal("Parent Kakatua");
		parentBird.MakeSound();
		Console.WriteLine();
		
		// Test AM protected
		Animal a = new("test");
		//! a.Eat(); Error
	}
}