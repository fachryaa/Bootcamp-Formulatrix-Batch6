using MonopolyGame.Block;
using MonopolyGame.Enum;

namespace MonopolyGame
{
    public partial class GameController : Form
    {
        private BaseBlock[] _board = new BaseBlock[32];
        private int[] _dice = new int[2];
        private Label diceLabel1 = new Label();
        private Label diceLabel2 = new Label();
        private Random random = new Random();
        public GameController()
        {
            InitializeComponent();
            diceLabel1 = DiceLabel1;
            diceLabel2 = DiceLabel2;
        }

        public void SetUpBlock()
        {
            StartBlock startBlock = new(StartButton, 1, 3000);
            CityBlock cityBlock1 = new(CityButton1, 2, "Beijing", BlockColor.Pink, 100);
            CityBlock cityBlock2 = new(CityButton2, 3, "Bandung", BlockColor.Pink, 200);
            CityBlock cityBlock3 = new(CityButton3, 4, "Jakarta", BlockColor.Pink, 300);
            ChanceBlock chanceBlock1 = new(ChanceButton1, 5);
            TourismBlock tourismBlock1 = new(TourismButton1, 6, "Phuket", BlockColor.Blue);
            CityBlock cityBlock4 = new(CityButton4, 7, "New Delhi", BlockColor.Yellow, 400);
            CityBlock cityBlock5 = new(CityButton5, 8, "Seoul", BlockColor.Yellow, 500);
            PrisonBlock prisonBlock = new(PrisonButton, 9);
            TourismBlock tourismBlock2 = new(TourismButton2, 10, "Bali", BlockColor.Red);
            CityBlock cityBlock6 = new(CityButton6, 11, "Tokyo", BlockColor.Green, 600);
            CityBlock cityBlock7 = new(CityButton7, 12, "Sydney", BlockColor.Green, 700);
            ChanceBlock chanceBlock2 = new(ChanceButton2, 13);
            CityBlock cityBlock8 = new(CityButton8, 14, "Singapore", BlockColor.Cyan, 800);
            TourismBlock tourismBlock3 = new(TourismButton3, 15, "Hawaii", BlockColor.Blue);
            CityBlock cityBlock9 = new(CityButton9, 16, "Sao Paulo", BlockColor.Cyan, 900);
            FestivalBlock festivalBlock = new(FestivalButton, 17);
            CityBlock cityBlock10 = new(CityButton10, 18, "Prague", BlockColor.OceanBlue, 1000);
            TourismBlock tourismBlock4 = new(TourismButton4, 19, "Bintan", BlockColor.Blue);
            CityBlock cityBlock11 = new(CityButton11, 20, "Berlin", BlockColor.OceanBlue, 1100);
            ChanceBlock chanceBlock3 = new(ChanceButton3, 21);
            CityBlock cityBlock12 = new(CityButton12, 22, "Moscow", BlockColor.Pink, 1200);
            CityBlock cityBlock13 = new(CityButton13, 23, "Geneva", BlockColor.Pink, 1300);
            CityBlock cityBlock14 = new(CityButton14, 24, "Rome", BlockColor.Pink, 1400);
            TravelingBlock travelingBlock = new(TravelButton, 25);
            TourismBlock tourismBlock5 = new(TourismButton5, 26, "Kota Kinabalu", BlockColor.Red);
            CityBlock cityBlock15 = new(CityButton15, 27, "London", BlockColor.Orange, 1500);
            CityBlock cityBlock16 = new(CityButton16, 28, "Paris", BlockColor.Orange, 1600);
            ChanceBlock chanceBlock4 = new(ChanceButton4, 29);
            CityBlock cityBlock17 = new(CityButton17, 30, "New York", BlockColor.Brown, 1700);
            TaxBlock taxBlock = new(TaxButton, 31);
            CityBlock cityBlock18 = new(CityButton18, 32, "Bangkik", BlockColor.Brown, 1800);

            _board[0] = startBlock;

        }

        private void RollDice(object sender, EventArgs e)
        {
            _dice[0] = random.Next(1, 7);
            _dice[1] = random.Next(1, 7);

            int result = _dice[0] + _dice[1];

            diceLabel1.Text = _dice[0].ToString();
            diceLabel2.Text = _dice[1].ToString();

            Label player1 = Player1;
            Point startPoint = CityButton5.Location;

            player1.Location = new Point(startPoint.X - 70, startPoint.Y);
        }

        private int GetDice()
        {
            return _dice[0] + _dice[1];
        }

        private void PlayerMove()
        {

        }
    }
}