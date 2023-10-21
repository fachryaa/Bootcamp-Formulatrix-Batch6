namespace Day08;

public enum HTTPResponse
{
	NotFound = 404,
	Forbidden = 403,
	OK = 200
}
public class EnumTest
{
	public static void Run()
	{
		int status = WebAccess.ContinueAccess(HTTPResponse.OK);
		Console.WriteLine($"status : {status}");
	}
}

public class WebAccess
{
	public static int ContinueAccess(HTTPResponse status)
	{
		switch (status)
		{
			case HTTPResponse.NotFound :
				return (int)status;
			case HTTPResponse.Forbidden :
				return (int)status;
			case HTTPResponse.OK :
				return (int)status;
			default:
				return (int)status;
		}	
	}
}
