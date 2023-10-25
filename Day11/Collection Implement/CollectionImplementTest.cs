namespace Day11;

public class CollectionImplementTest
{
	public static void Run()
	{
		Dictionary<Player, Data> dictPlayer = new();
		Player player1 = new();
		
		dictPlayer.Add(player1, new Data(Color.Black, 0,0));
		
		Data result = dictPlayer[player1];
		
		foreach (var e in result.GetCard())
		{
			// do something
		}
		
		Color colorPlayer = result.GetColor();
	}
}

class Data
{
	private List<Card> _playerCards;
	private Color _playerColor;
	private int _score;
	private int _bet;
	
	public Data(Color initColor, int score, int bet)
	{
		_playerCards = new();
		_playerColor = initColor;
		_score = score;
		_bet = bet;
	}
	
	public bool AddCard(Card card)
	{
		_playerCards.Add(card);
		return true;
	}
	
	public List<Card> GetCard()
	{
		return _playerCards;
	}
	
	public Color GetColor()
	{
		return _playerColor;
	}
}

public enum Color
{
	Black,
	White
}

class Player
{
	
}

class Card
{
	
}