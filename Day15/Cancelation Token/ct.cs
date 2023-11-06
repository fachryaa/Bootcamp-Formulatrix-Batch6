namespace Day15;

public class ct
{
	public static void Run()
	{
		CancellationTokenSource cts = new CancellationTokenSource();
		CancellationToken ct = cts.Token;

		Task.Run(() =>
		{
			while (true)
			{
				if (ct.IsCancellationRequested)
				{
					Console.WriteLine("Cancelation requested");
					break;
				}
				else
				{
					Console.WriteLine("Task is running");
					Thread.Sleep(1000);
				}
			}
		}, ct);

		Console.WriteLine("Press any key to cancel");
		Console.ReadKey();
		cts.Cancel();
	}
	
	public static async Task DoAsync()
	{
		for (int i=0 ; i<10 ; i++)
		{
			Console.WriteLine($"Progress {i}");
			await Task.Delay(1000);
		}
	}
}
