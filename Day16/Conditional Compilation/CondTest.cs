#define RELEASE

namespace Day16;
public class CondTest
{
	public static void Run()
	{
		// jika di run akan keluar DEBUG
		// harus di run menggunakan dotnet run --configuration Release
		#if RELEASE
			Console.WriteLine("RELEASE");
		#elif DEBUG
			Console.WriteLine("DEBUG");
		#endif
	}
}
