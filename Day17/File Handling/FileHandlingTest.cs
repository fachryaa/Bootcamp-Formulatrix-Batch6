namespace Day17;

public class FileHandlingTest
{
	public static void Run()
	{
		// string escape using @
		int fileName = 1;
		string path = $@".\File Handling\FileTest\text{fileName}.txt";
		try
		{
			using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
			{
				
			}
		}
		catch (Exception)
		{
			fileName++;
			path = $@".\File Handling\FileTest\text{fileName}.txt";
			using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
			{
				
			}
			
			Console.WriteLine($"{fileName} created");
		}
	}
}
