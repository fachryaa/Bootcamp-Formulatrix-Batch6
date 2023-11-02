using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyGame.Enum;

namespace MonopolyGame.Block
{
    public class TravelingBlock : BaseBlock
    {
        public TravelingBlock(Button button, int id)
        {
            Name = BlockType.Traveling.ToString();
            Type = BlockType.Traveling;
            Line = (int)Math.Ceiling((float)Id / 8);
            NextTurnAction = true;
            BaseButton = button;
            Id = id;
        }
        public void BlockAction(GameController game)
        {

        }
    }
}
