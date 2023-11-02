using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyGame.Enum;

namespace MonopolyGame.Block
{
    public class TaxBlock : BaseBlock
    {
        public TaxBlock(Button button, int id)
        {
            Name = BlockType.Tax.ToString();
            Type = BlockType.Tax;
            Line = (int)Math.Ceiling((float)Id / 8);
            NextTurnAction = false;
            BaseButton = button;
            Id = id;
        }
        public override void BlockAction(GameController game)
        {

        }
    }
}
