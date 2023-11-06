using MonopolyGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyGame.Block;
using MonopolyGame.ChanceCard;

namespace MonopolyGame.Players
{
    public class PlayerData
    {
        public int Balance { get; set; }
        public int TotalAssets { get; set; }
        public int Turn { get; set; }
        public PlayerStatus Status { get; set; }
        public List<BuildableBlock> Buildings;
        public int Position { get; set; }
        public int PrisonCount { get; set; }
        // public IDeffenseCard DeffenseCard { get; set; }
        public Label Label { get; set; }
        
        public PlayerData(Label label, int balance, int turn)
        {
            Label = label;
            Balance = balance;
            TotalAssets = 0;
            Turn = turn;
            Status = PlayerStatus.Playing;
            Buildings = new List<BuildableBlock>();
            Position = 0;
            PrisonCount = 0;
        }
    }
}
