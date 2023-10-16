namespace Day05.Generic;

static class GenericCollector
{
  public static void Run()
  {
    GenericCollection<int> collection = new();
    collection.Add(10);
    collection.Add(9);
    collection.Add(8);

    int first = collection.myCollection[0];
    Console.WriteLine(first);

    GenericCollection<string> collection1 = new();
    collection1.Add("test");
    collection1.Add("test");
    collection1.Add("test");

    var first1 = collection1.myCollection[0];
    Console.WriteLine(first1);
  }
}

class GenericCollection<T>
{
  public T[] myCollection = new T[100];
  public int counter = 0;

  public bool Add(T input)
  {
    myCollection[counter] = input;
    counter++;
    return true;
  }
}