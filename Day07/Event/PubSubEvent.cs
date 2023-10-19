namespace Day07.Event;

public delegate void MyDelegate(string uploader);
public class PubSubEvent
{
	public static void Run()
	{
		Youtuber yt = new("Yanto");
		Subscriber sub1 = new Subscriber();
		Subscriber2 sub2 = new Subscriber2();

		yt.subscriber += sub1.Notification;
		yt.subscriber += sub2.Notification;
		//! yt.subscriber = sub1.Notification; Error
		yt.UploadVideo();
		yt.EventClear();
	}
}

class Youtuber
{
	public event MyDelegate? subscriber;
	
	private string _name;
	public Youtuber(string name)
	{
		_name = name;
	}
	public void UploadVideo()
	{
		Console.WriteLine("Uploading video...");
		if (subscriber != null)
		{
			subscriber.Invoke(_name);
		}
	}
	public void EventClear() {
		subscriber = null;
	}
}
class Subscriber
{
	public void Notification(string x)
	{
		Console.WriteLine($"Get notif from Youtuber {x}");
	}
}
class Subscriber2
{
	public void Notification(string x)
	{
		Console.WriteLine($"Get notif from Youtuber {x}");
	}
}