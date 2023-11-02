using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public class StartBlock : BaseBlock
    {
        private int _salary;

        public StartBlock(Button button, int id, int salary)
        {
            Name = BlockType.Start.ToString();
            Type = BlockType.Start;
            Line = (int)Math.Ceiling((float)Id / 8);
            NextTurnAction = false;
            _salary = salary;
            BaseButton = button;
            Id = id;
        }
        public void BlockAction(GameController game)
        {

        }
        public int GetSalary()
        {
            return _salary;
        }
    }
}
