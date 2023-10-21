namespace Day08;

public enum StatusCode
{
	NotFound = 404,
	Forbidden = 403,
	OK = 200
}
public class EnumTest2
{
	public static void Run()
	{
		// Enum -> int
		int numberOfStatus = (int)StatusCode.NotFound;
		Console.WriteLine($"numberOfStatus : {numberOfStatus}");
		
		// int -> enum (undertemine)
		StatusCode statusCode = (StatusCode)404;
		Console.WriteLine($"statusCode : {statusCode}");
		
		StatusCode[] status = (StatusCode[])Enum.GetValues(typeof(StatusCode));
		var status2 = Enum.GetValues(typeof(StatusCode));
		
		Console.WriteLine($"status : {status.PrintArray()}");
		Console.WriteLine($"status2 : {status2.PrintArray()}");
	}
}

static class MyPrint
{
	public static string PrintArray(this Array obj)
	{
		int i = 0;
		string result = "";
		foreach (var item in obj)
		{
			result += $"[{i++}]{item} ";
		}
		
		return result;
	}
}