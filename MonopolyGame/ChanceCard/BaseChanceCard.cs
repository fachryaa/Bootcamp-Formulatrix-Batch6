using MonopolyGame.Enum;
using MonopolyGame.Game;

namespace MonopolyGame.ChanceCard;

public abstract class BaseChanceCard
{
	public readonly ChanceCardType CardType;
	public virtual void ChanceAction(GameController game){}
}
