using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public class FestivalBlock : BaseBlock
    {
        public FestivalBlock(Button button, int id)
        {
            Name = BlockType.Festival.ToString();
            Type = BlockType.Festival;
            Line = (int)Math.Ceiling((float)Id / 8);
            NextTurnAction = false;
            BaseButton = button;
            Id = id;
        }
        public void BlockAction(GameController game)
        {

        }
    }
}
