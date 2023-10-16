namespace Day06;

public class ArrayTest
{
  public static void Run()
  {
    int[] myArr = {1, 2, 3};
    char[] myChar = new char[3];
    string[] myString = new string[] {"1", "2", "3"};

    int result = myArr[2];
    myArr[1] = 3;

    int length = myArr.Length;

    Console.WriteLine($"Arr Length : {length}");
  }
}
