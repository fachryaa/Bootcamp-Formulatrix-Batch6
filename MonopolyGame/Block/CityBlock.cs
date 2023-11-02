using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public class CityBlock : BuildableBlock
    {
        private bool _isColorCompletion;

        public CityBlock(Button button, int id, string name, BlockColor color, int price) { 
            BaseButton = button;
            Id = id;
            Name = name;
            Color = color;
            Line = (int)Math.Ceiling((float)Id / 8);
            Type = BlockType.City;
            NextTurnAction = false;
            Color = color;
            BasePrice = price;
            Status = PropertyType.Land;
            Effect = BuildingEffect.None;
            EffectCount = 0;
            _isColorCompletion = false;
        }

        public void BlockAction(GameController game)
        {
           
        }

        public override int GetPropertyRent()
        {
            int multiply = _isColorCompletion ? 2 : 1;

            return multiply * base.GetPropertyRent();
        }
    }
}
