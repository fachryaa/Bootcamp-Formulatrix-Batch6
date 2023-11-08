namespace Day17;

public class FileHandlingTest
{
	public static void Run()
	{
		// string escape using @
		string fileName = "file.txt";
		string path = $@".\File Handling\FileTest\{fileName}";
		try
		{
			using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
			{
				
			}
		}
		catch (Exception e)
		{
			Console.WriteLine($"{e}");
			
			throw;
		}
	}
}
