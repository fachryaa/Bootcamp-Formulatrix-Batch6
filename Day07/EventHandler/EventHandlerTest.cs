namespace Day07;

public class EventHandlerTest
{
	public static void Run()
	{
		Publisher2 pub = new("Joko");
		
		Subscriber2 sub = new("Sub1");
		Subscriber2 sub2 = new("Sub2");
		
		pub.eventHandler = sub.Notification;
		pub.SendNotification();
	}
}

class Publisher2
{
	private string _name;
	public EventHandler? eventHandler;
	public Publisher2(string name) { _name = name; }
	public void SendNotification() 
	{
		eventHandler?.Invoke(this, EventArgs.Empty);
	}
	public override string ToString()
	{
		return _name;
	}
}

class Subscriber2
{
	public string Name { get; set; }
	public Subscriber2 (string name) { Name = name; }
	public void Notification(object? sender, EventArgs e)
	{
		Console.WriteLine($"{Name} Got Notif from {sender} ");
	}
}