using System.Collections;

namespace Day09;

public class EnumeratorTest
{
	public static void Run()
	{
		MyCollectionEnum myCollectionEnum = new(new int[]{1,2,3});
		
		myCollectionEnum.MoveNext();
		
		var result = myCollectionEnum.Current;
		
		Console.WriteLine($"Result : {result}");
		
		
	}
}

class MyCollectionEnum : IEnumerator
{
	public MyCollectionEnum(int[] x)
	{
		myInt = x;
	}
	private int _currentIndex = -1;
	private int[] myInt = new int[5];

	public object Current => myInt[_currentIndex];

	public bool MoveNext()
	{
		if (_currentIndex < myInt.Length-1)
		{
			_currentIndex++;
			return true;
		}
		else
		{
			Reset();
			return false;
		}
	}

	public void Reset()
	{
		_currentIndex = -1;
	}

}