namespace Day04.Interface;

public class Human : IPermintaanOrtu
{
	public void Kerja()
	{
		Console.WriteLine($"Kerja di Formulatrix");
	}
	
	public void Kuliah()
	{
		Console.WriteLine($"Kuliah di Universitas Brawijaya");
	}
	
	public void Nikah()
	{
		Console.WriteLine($"Nikah OK");
	}
	
	public bool SudahNikah(int istri)
	{
		return istri > 0;
	}
	
	public void MainGame()
	{
		Console.WriteLine($"Main Game OK");
	}
}
