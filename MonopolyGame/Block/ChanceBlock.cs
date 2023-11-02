using MonopolyGame.ChanceCard;
using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public class ChanceBlock : BaseBlock
    {
        List<BaseChanceCard> chanceCards;

        public ChanceBlock(Button button, int id) {
            Name = BlockType.Chance.ToString();
            Type = BlockType.Chance;
            Line = (int)Math.Ceiling((float)Id / 8);
            NextTurnAction = false;
            BaseButton = button;
            Id = id;
        }
        public void BlockAction(GameController game)
        {

        }

        public BaseChanceCard GetRandomCard()
        {
            Random random = new Random();
            int index = random.Next(0, chanceCards.Count);
            return chanceCards[index];
        }
    }
}
