namespace Day07;

public delegate void Publish(string x);
public class DuplicateDelegate
{
	static void Run()
	{
		Publisher pub = new();
		Subscriber sub = new();
		pub.AddSubscriber(sub.Notify);
		pub.AddSubscriber(sub.Notify);// duplicate delegate 
		pub.SentNotification();
		
		pub.RemoveSubscriber(sub.Notify);
		pub.SentNotification();
	}
}

class Publisher {
	private Publish? _subscriber;
	public void SentNotification() {
		if(_subscriber != null) 
			_subscriber.Invoke("subs");
	}
	public bool AddSubscriber(Publish sub) {
		if(_subscriber is null || !_subscriber.GetInvocationList().Contains(sub))
		{
		 	_subscriber += sub;
			return true;
		}
		return false;
	}
	public void RemoveSubscriber(Publish sub) {
		_subscriber -= sub;
	}
}
class Subscriber {
	public void Notify(string message) {
		Console.WriteLine(message);
	}
}