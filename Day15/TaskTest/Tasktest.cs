using System.Threading.Tasks;
using System.Threading;
namespace Day15;
public class TaskTest
{
	public static void Run()
	{
		// Task Creation
		Task task = new Task(() => Console.WriteLine("Hello"));
		
		TaskStatus x = task.Status;
		
		// Start task
		task.Start();
		
		// wait until task is finished
		task.Wait();
		
		// Task Method
		Console.WriteLine($" IsCompleted : {task.IsCompleted}");
		Console.WriteLine($" IsCanceled : {task.IsCanceled}");
		Console.WriteLine($" IsFaulted : {task.IsFaulted}");
		
		// Task with return value
		Task<int> t2 = Task.Run(() => Add(1,2));
		Console.WriteLine($"Result : {t2.Result}");
		
		// Test with sleep
		Task t3 = Task.Run(() => test("t3"));
		t3.Wait();
		
		// Task continue with
		Task continuation = t3.ContinueWith(x => test("cont"));
		continuation.Wait();
		
		Console.WriteLine($"Program stopped");
	}
	
	public static int Add(int a, int b)
	{
		return a + b;
	}
	
	public static void test(string x)
	{
		Console.WriteLine($"From : {x} Started");
		Thread.Sleep(2000);
		Console.WriteLine($"Finished");
		
	}

}
