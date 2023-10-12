using Day04.Abstract;
using Day04.Interface;

namespace Day04;

class Program
{
	static void InheritanceFailed()
	{
		DieselEngine dieselEngine = new DieselEngine();
		ElectricEngine electricEngine = new ElectricEngine();
		Engine engine = new Engine();
		
		//! Error karena class beda dan bukan inheritance dari engine
		// CarDiesel carDiesel = new CarDiesel(electricEngine);
		
		// OK
		CarDiesel carDiesel = new CarDiesel(dieselEngine);
		
		// OK
		Engine dieselEngine2 = new DieselEngine();
		Engine electricEngine2 = new DieselEngine();
		
		//! Error, tidak bisa dibalik
		// DieselEngine dieselEngine3 = new Engine();
		
		
		// OK
		Car carElectric = new Car(electricEngine);
		Car carDiesel2 = new Car(dieselEngine);
		Car carGeneral = new Car(engine);
	}
	static void Abstract()
	{
		//! Error karena abstract class tidak bisa dibuat objek
		// Animal animal = new Animal();
		
		// OK, karena abstract Animal sudah diimplementasi oleh Tiger
		Animal animal2 = new Tiger();
		animal2.Sound();
	}
	
	
	static void Main(string[] Args)
	{
		Human human = new Human();
		human.Kerja();
		human.Kuliah();
		human.Nikah();
		Console.WriteLine($"Sudah nikah : {human.SudahNikah(1)}");
		human.MainGame();
		
		Console.WriteLine();
		
		IPermintaanOrtu permintaanOrtu = human;
		permintaanOrtu.Kerja();
		permintaanOrtu.Kuliah();
		permintaanOrtu.Nikah();
		Console.WriteLine($"Sudah nikah : {permintaanOrtu.SudahNikah(1)}");
		//! Error karena tidak ada method MainGame() di interface IPermintaanOrtu, hanya ada di class human
		// permintaanOrtu.MainGame();
		
		HumanSudahMenikah humanSudahMenikah = new HumanSudahMenikah();
		IPermintaanAnak permintaanAnak = humanSudahMenikah;
		permintaanAnak.Jajan();		
		
	}
}