using System.Text.Unicode;

namespace Day17;

public class FileStreamTest
{
	public static void Run()
	{
		string path = @"./File Stream/text.txt";
		using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
		{
			// Read using StreamReader
			// using (StreamReader sr = new StreamReader(fs))
			// {
			// 	string? result = sr.ReadLine();
			// 	result = sr.ReadLine();
			// 	result = sr.ReadToEnd();
			// 	Console.WriteLine($"{result}");
			// }
			
			// Write using StreamWriter
			// using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Open, FileAccess.ReadWrite)))
			// {
			// 	string textToAdd = "FFFFFFFFFF";
			// 	sw.WriteLine(textToAdd);
			// }
			
			// read again
			// using (StreamReader sr = new StreamReader(fs))
			// {
			// 	string? result = sr.ReadLine();
			// 	result = sr.ReadLine();
			// 	result = sr.ReadToEnd();
			// 	Console.WriteLine($"{result}");
			// }
			
			// Write using StreamWriter
			
		}
		
		
	}
}
