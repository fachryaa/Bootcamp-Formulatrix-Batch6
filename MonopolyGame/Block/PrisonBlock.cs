using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public class PrisonBlock : BaseBlock
    {
        public PrisonBlock(Button button, int id)
        {
            Name = BlockType.Prison.ToString();
            Type = BlockType.Prison;
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
