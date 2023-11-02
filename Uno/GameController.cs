namespace Uno;

public class GameController
{
	public List<BaseCard> _cardOnDeck;
	private Player _currentPlayer;
	private Dictionary<Player, Status> _playerStatus;
	private bool _isClockwise;
	private Dictionary<Player, List<BaseCard>> _players;
	//Dict<Player,PlayerData> 
	private BaseCard _lastCard;
	public GameController(Player player, List<BaseCard> deck) 
	{
		_cardOnDeck = new();
		_playerStatus = new();
		_players = new();
	}
	public List<Player> GetPlayers() 
	{
		return _players.Select(p => p.Key).ToList();
	}
	public BaseCard GetLastCard() 
	{
		return _lastCard;
	}
	public List<BaseCard> GetCards(Player p) {
		return _players[p];
	}
	public BaseCard DrawCard() 
	{
		Random ran = new Random();
		return _cardOnDeck[ran.Next(0, _cardOnDeck.Count)];
	}
	
	public void AssignCard(Player player, BaseCard card) {
		_players[player].Add(card);
	}
}
