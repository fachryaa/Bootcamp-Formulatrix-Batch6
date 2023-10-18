namespace Day06.Delegate;

public class PubSub
{
	public static void Run()
	{
		Publisher publisher1 = new Publisher("Publisher1");
		Publisher publisher2 = new Publisher("Publisher2");
		
		Subscriber subscriber1 = new Subscriber("Subscriber1");
		Subscriber subscriber2 = new Subscriber("Subscriber2");
		
		subscriber1.SubscriberTo(publisher1);
		subscriber2.SubscriberTo(publisher1);
		
		subscriber1.SubscriberTo(publisher2);
		
		publisher1.UploadVideo();
		publisher2.UploadVideo();
		
		subscriber1.UnSubscribe(publisher1);
		
		publisher1.UploadVideo();
	}
}

class Publisher
{
	public string Name { get; set; }
	public Publisher(string name)
	{
		Name = name;
	}
	public delegate void MySubscribers(string message);
	public MySubscribers mySubscribers;

	public void AddSubscriber(Subscriber subscriber)
	{
		mySubscribers += subscriber.ReceiveNotification;
	}
	public void UploadVideo()
	{
		Console.WriteLine($"{Name} Uploading video...");
		mySubscribers.Invoke($"{Name} uploaded a new video!");
	}
	public void RemoveSubscriber(Subscriber subscriber)
	{
		mySubscribers -= subscriber.ReceiveNotification;
	}
}

class Subscriber
{
	private string _name;
	public Subscriber(string name)
	{
		_name = name;
	}
	public Publisher[] publishers = new Publisher[10];
	public void SubscriberTo(Publisher publisher)
	{
		publisher.AddSubscriber(this);
	}
	public void ReceiveNotification(string message)
	{
		Console.WriteLine($"{_name} received notification: {message}");
	}
	public void UnSubscribe(Publisher publisher)
	{
		Console.WriteLine($"{_name} unsubscribed from {publisher.Name}");
		publisher.RemoveSubscriber(this);
	}
}