namespace Day07;

public class EventHandlerGeneric
{
	public static void Run()
	{
		Publisher3 pub = new("Jokoyanto", 2000);
		Subscriber3 sub = new("Sub1");
		
		pub.eventHandler = sub.Notification;
		pub.SendNotification();
	}
}

class Publisher3
{
	private string? _name;
	private int _price;
	public Publisher3(string name, int price)
	{
		_name = name;
		_price = price;
	}
	public EventHandler<EventData>? eventHandler;
	
	public void SendNotification()
	{
		eventHandler?.Invoke(this, new EventData
		{
			Name = _name,
			Price = _price
		});
	}
}

class Subscriber3
{
	private string? _name;
	public Subscriber3(string name)
	{
		_name = name;
	}	
	public void Notification(object? sender, EventData e)
	{
		Console.WriteLine($"{_name} Got Notif from {e.Name} and the price is {e.Price}");
	}
}

class EventData : EventArgs
{
	public string? Name { get; set; }
	public int Price { get; set; }
}