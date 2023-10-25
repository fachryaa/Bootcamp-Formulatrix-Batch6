namespace Day11;

public class StackTest
{
	public static void Run()
	{
		Stack<int> myStack = new();
		
		// Push
		myStack.Push(1);
		myStack.Push(2);
		myStack.Push(3);
		myStack.Push(4);
		myStack.Push(5);
		
		/*
			Stack :	5
					4
					3
					2
					1
		*/
		
		// Pop
		int popped = myStack.Pop();
		Console.WriteLine($"Popped: {popped}");
		
		/*
			Stack :	4
					3
					2
					1
		*/
		
		// Peek
		int peeked = myStack.Peek();
		Console.WriteLine($"Peeked: {peeked}");
		
		/*
			Stack :	4
					3
					2
					1
		*/
	}
}
