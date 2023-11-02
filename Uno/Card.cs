namespace Uno;

public abstract class BaseCard
{
	public readonly Colour colour; //Yellow
	public readonly CardType type; //PlusFour
	public abstract void CardFunction();
}
public class Card : BaseCard //.cs
{
	public override void CardFunction() 
	{
		
	}
}
public class SkipCard : BaseCard //.cs
{
	public override void CardFunction() 
	{
		//..Skip
	}
}
public class PlusTwoCard : BaseCard //.cs
{
	public override void CardFunction() 
	{
		//..PlusTwo
	}
}