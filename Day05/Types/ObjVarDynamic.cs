namespace Day05;

static class ObjVarDynamic
{
  public static void Run()
  {
    // var
		var x = 1;
		//! x = "test";	Error
		x = int.Parse("10");

    // object
		int myInt = 1;
		object myObj = myInt;
		Console.WriteLine(myObj);
		
		int myInt2 = 2;
		object myObj2 = myInt2;	// boxing
		float myFloat = (int)myObj2; // unboxing

		Add(3, 3);
		Add(new Car(), new Car());

		// Dynamic (dont use this)
		dynamic myDynamic = 3;
		myDynamic = "tiga";
		myDynamic = true;
		// myDynamic.Mboh(); // OK
		// myDynamic.Wkwk(); // OK
  }

  static void Add(object x, object y)
	{
		if (x is int && y is int)
		{
			int a = (int)x;
			int b = (int)y;
		}

		if (x is Car)
		{
			Console.WriteLine("Tidak masuk akal");
		}
	}
}

class Car
{

}