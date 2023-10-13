namespace Day04.MobileLegend;

public class GameController
{
	public IOnlinePlayer player;
	public GameController(IOnlinePlayer player)
	{
		this.player = player;
	}
}
