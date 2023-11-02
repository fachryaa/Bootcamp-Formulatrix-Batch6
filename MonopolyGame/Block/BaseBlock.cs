using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public abstract class BaseBlock
    {
        public Button BaseButton { get; set; }
        public int Id;
        public string Name;
        public int Line;
        public BlockType Type;
        public bool NextTurnAction;
        
        public virtual void BlockAction(GameController game) { }
    }
}
