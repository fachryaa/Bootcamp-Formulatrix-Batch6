using System.Diagnostics;
using System.Text;

namespace Day05;

class Program
{
	static void Main(string[] Args)
	{
		// Types
		// Value type and Reference type
		
		// Value type
		int a = 5;
		int b = a;
		a = 3;
		Console.WriteLine($"a = {a}");
		Console.WriteLine($"b = {b}");		
		/*	Output :
			a = 3
			b = 5
		*/
		Console.WriteLine();
		
		// Reference type
		Data data1 = new Data(5);
		Data data2 = data1;
		data1.value = 3;
		Console.WriteLine($"data1.value = {data1.value}");
		Console.WriteLine($"data2.value = {data2.value}");
		/*	Output :
			data1.value = 3
			data2.value = 3
		*/
		Console.WriteLine();
		
		// string termasuk Reference type, namun immutable
		string str1 = "Hello";
		string str2 = str1;
		str1 = "World";
		Console.WriteLine($"str1 = {str1}");
		Console.WriteLine($"str2 = {str2}");
		/*	Output :
			str1 = World
			str2 = Hello
		*/
		Console.WriteLine();
		
		// jenis string yang mutable yaitu StringBuilder
		// proses waktu compile dari mutable akan jauh lebih cepat dari immutable
		// untuk mengetes nya bisa menggunakan class stopwatch dari System.Diagnostic
		Stopwatch stopwatch = new Stopwatch();
		const int IT = 1000000;
		
		// menggunakan string - immutable
		string str3 = string.Empty;
		stopwatch.Start();
		for(int i=0 ; i<IT ; i++)
		{
			str3 += "Hello";
		}
		stopwatch.Stop();
		Console.WriteLine($"String : {stopwatch.ElapsedMilliseconds} ms");
		
		// Menggunakan StringBuilder - mutable
		StringBuilder strb1 = new StringBuilder();
		
		stopwatch.Restart();
		for(int i=0 ; i<IT ; i++)
		{
			strb1.Append("Hello");
		}
		stopwatch.Stop();
		Console.WriteLine($"StringBuilder : {stopwatch.ElapsedMilliseconds} ms");
		
		
		// var, object, dynamic
		// 
		var x = 1;
		//! x = "test";	Error
		x = int.Parse("10");
	}
}