namespace Day04;

public class Car
{
	private Engine _engine;
	public Car(Engine engine)
	{
		_engine = engine;
	}
	
	public void CarStart()
	{
		_engine.Run();
		_engine.EngineStart();
	}
}
