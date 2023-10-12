namespace Day04.Interface;

public class HumanSudahMenikah : ISudahMenikah
{
	public void TanggalMenikah()
	{
		Console.WriteLine($"1 Januari 2001");
	}
	public void BayarIuran()
	{
		Console.WriteLine($"Bayar Iuran 200 Ribu");
	}


	public void Jajan()
	{
		Console.WriteLine($"Uang Jajan Anak 100 Ribu");
	}


	public void Kerja()
	{
		Console.WriteLine($"Kerja di Formulatrix jadi Software Developer");
	}

	public void Kuliah()
	{
		Console.WriteLine($"Kuliah di ITB");
	}

	public void Nikah()
	{
		Console.WriteLine($"Nikah OK");
	}

	public bool SudahNikah(int istri)
	{
		return istri > 1;
	}

	void IPermintaanIstri.PulangCepat()
	{
		Console.WriteLine($"Pulang Cepet OK");
	}

	void IPermintaanIstri.UangBulanan()
	{
		Console.WriteLine($"Uang Bulanan 100 OK");
	}
}
