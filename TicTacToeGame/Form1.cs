namespace TicTacToeGame
{
    public partial class Game : Form
    {
        public enum Player
        {
            X,
            O
        }

        Player currentPlayer;
        Random random = new Random();

        int playerWinCount = 0;
        int compWinCount = 0;

        Label playerWinLabel = new Label();
        Label compWinLabel = new Label();

        List<Button> buttons;

        public Game()
        {
            InitializeComponent();
            ResetGame();

            playerWinLabel = label3;
            compWinLabel = label4;

            playerWinLabel.Text = playerWinCount.ToString();
            compWinLabel.Text = compWinCount.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CompMove(object sender, EventArgs e)
        {
            if (buttons.Count < 1) return;

            currentPlayer = Player.O;

            int ran = random.Next(buttons.Count);
            var button = buttons[ran];

            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Red;

            buttons.Remove(button);

            SwitchAllButton(true);

            CheckGame();

            CompTimer.Stop();

        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;

            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Green;

            SwitchAllButton(false);

            buttons.Remove(button);
            CheckGame();

            CompTimer.Start();
        }

        private void ResetGame(object sender, EventArgs e)
        {
            ResetGame();
        }

        private List<Button> GetAllButtons()
        {
            return new List<Button> {
                button1, button2, button3, button4, button5, button6, button7, button8, button9
            };
        }

        private void CheckGame()
        {
            var but = GetAllButtons();

            /**
             * 123 456 789 147 258 369 159 357
            **/
            int result = 0;
            if (isSame(but[0], but[1], but[2])) result++;
            else if (isSame(but[3], but[4], but[5])) result++;
            else if (isSame(but[6], but[7], but[8])) result++;
            else if (isSame(but[0], but[3], but[6])) result++;
            else if (isSame(but[1], but[4], but[7])) result++;
            else if (isSame(but[2], but[5], but[8])) result++;
            else if (isSame(but[0], but[4], but[8])) result++;
            else if (isSame(but[2], but[4], but[6])) result++;

            if (result == 0) return;

            buttons = new List<Button>();

            if (currentPlayer == Player.X)
            {
                playerWinCount++;
                playerWinLabel.Text = playerWinCount.ToString();
            }
            else
            {
                compWinCount++;
                compWinLabel.Text = compWinCount.ToString();
            }

            SwitchAllButton(false);

            FormFinish form = new(this);
            form.Show(this);


        }

        private bool isSame(Button b1, Button b2, Button b3)
        {
            if (b1.Text == "?" || b2.Text == "?" || b3.Text == "?") return false;

            return b1.Text == b2.Text && b2.Text == b3.Text;
        }

        public void ResetGame()
        {
            CompTimer.Stop();

            buttons = GetAllButtons();

            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "?";
                button.BackColor = DefaultBackColor;
            }
        }

        private void SwitchAllButton(bool e)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = e;
            }
        }
    }
}