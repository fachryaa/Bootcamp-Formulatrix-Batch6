namespace Day06.Delegate;

public delegate void MyDelegate();
public delegate string MyDelegateString(string s);
public delegate int MyDelegateInt(int a, int b);
public class DelegateTest
{
	public static void Run()
	{
		// Declare delegate
		MyDelegate myDelegate = new MyDelegate(Method1);
		myDelegate += Method2;
		myDelegate += Method3;
		
		// invoke
		myDelegate.Invoke();
		
		// delete Method3 from delegate
		myDelegate -= Method3;
		
		// Declare string delegate
		MyDelegateString myDelegateString = new MyDelegateString(MethodString1);
		myDelegateString += MethodString2;
		myDelegateString += MethodString3;
		
		// invoke
		var result = myDelegateString.Invoke("Hello");
		
		// Declare int delegate
		MyDelegateInt myDelegateInt = new MyDelegateInt(Add);
		myDelegateInt += Sub;
		
		// invoke
		var resultInt = myDelegateInt.Invoke(2,3);
		
	}
	
	public static void Method1()
	{
		Console.WriteLine("Method1");
	}
	public static void Method2()
	{
		Console.WriteLine("Method2");
	}
	public static void Method3()
	{
		Console.WriteLine("Method3");
	}
	public static void Method4()
	{
		Console.WriteLine("Method4");
	}
	
	public static string MethodString1(string s)
	{
		Console.WriteLine($"MethodString1 {s}");
		return s;
	}
	public static string MethodString2(string s)
	{
		Console.WriteLine($"MethodString2 {s}");
		return s;
	}
	public static string MethodString3(string s)
	{
		Console.WriteLine($"MethodString3 {s}");
		return s;
	}
	public static int Add(int a, int b)
	{
		Console.WriteLine($"Add {a} + {b}");
		return a + b;
	}
	public static int Sub(int a, int b)
	{
		Console.WriteLine($"Sub {a} - {b}");
		return a - b;
	}
	
}
