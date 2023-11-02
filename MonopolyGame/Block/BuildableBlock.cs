using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame.Block
{
    public abstract class BuildableBlock : BaseBlock
    {
        public BlockColor Color;
        public int BasePrice;
        public int OwnerId;
        public PropertyType Status;
        public BuildingEffect Effect;
        public int EffectCount;

        public virtual int GetPropertyRent() {
            return BasePrice * (int)Status * ((int)Effect/100);
        }
    }
}
