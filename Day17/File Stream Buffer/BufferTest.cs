using System.Text;

namespace Day17;

public class BufferTest
{
	public static void Run()
	{
		string path = @"./File Stream/text.txt";
		using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			// Read using buffer
			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);
			
			string result = Encoding.UTF8.GetString(buffer);
			Console.WriteLine($"{result}");			
			
			// write
			byte[] data = Encoding.UTF8.GetBytes("\nEEEEEEE");
			fs.Write(data);
			
			// read again
			byte[] buffer2 = new byte[fs.Length];
			fs.Read(buffer2, 0, buffer.Length);
			
			string result2 = Encoding.UTF8.GetString(buffer2);
			Console.WriteLine($"{result2}");			
			
		}
	}
}
