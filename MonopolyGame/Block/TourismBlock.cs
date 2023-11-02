using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public class TourismBlock : BuildableBlock
    {
        private int _countSameColor;

        public TourismBlock(Button button, int id, string name, BlockColor color) {
            BaseButton = button;
            Id = id;
            Name = name;
            Type = BlockType.Tourism;
            Color = color;
            Line = (int)Math.Ceiling((float)Id / 8);
            NextTurnAction = false;
            Color = color;
            BasePrice = 300;
            Status = PropertyType.Land;
            Effect = BuildingEffect.None;
            EffectCount = 0;
            _countSameColor = 1;
        }

        public void BlockAction(GameController game)
        {

        }

        public override int GetPropertyRent()
        {
            return _countSameColor * base.GetPropertyRent();
        }
    }
}
