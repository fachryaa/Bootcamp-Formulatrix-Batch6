using ChessLibrary;
using ChessLibrary.Pieces;

namespace ChessWinForms
{
	public partial class Chess : Form
	{
		private GameController game = new();

		public readonly Dictionary<Position, Button> buttons = new();
		public PictureBox pb = new PictureBox();
		private Button previousButton = new Button();
		public Chess()
		{

			InitializeComponent();
			InitButtons();

			pb = pictureBox1;
			InitPieces();
			// pb.Location = buttons[GetPosXY(new Position(1,1))].Location;
			// TODO : selected piece, isSelect

		}

		public void InitButtons()
		{
			// TODO : init buttons		
			buttons.Add(new Position(0, 0), button1);
			buttons.Add(new Position(0, 1), button2);
			buttons.Add(new Position(0, 2), button3);
			buttons.Add(new Position(0, 3), button4);
			buttons.Add(new Position(0, 4), button5);
			buttons.Add(new Position(0, 5), button6);
			buttons.Add(new Position(0, 6), button7);
			buttons.Add(new Position(0, 7), button8);

			buttons.Add(new Position(1, 0), button9);
			buttons.Add(new Position(1, 1), button10);
			buttons.Add(new Position(1, 2), button11);
			buttons.Add(new Position(1, 3), button12);
			buttons.Add(new Position(1, 4), button13);
			buttons.Add(new Position(1, 5), button14);
			buttons.Add(new Position(1, 6), button15);
			buttons.Add(new Position(1, 7), button16);

			buttons.Add(new Position(2, 0), button17);
			buttons.Add(new Position(2, 1), button18);
			buttons.Add(new Position(2, 2), button19);
			buttons.Add(new Position(2, 3), button20);
			buttons.Add(new Position(2, 4), button21);
			buttons.Add(new Position(2, 5), button22);
			buttons.Add(new Position(2, 6), button23);
			buttons.Add(new Position(2, 7), button24);

			buttons.Add(new Position(3, 0), button25);
			buttons.Add(new Position(3, 1), button26);
			buttons.Add(new Position(3, 2), button27);
			buttons.Add(new Position(3, 3), button28);
			buttons.Add(new Position(3, 4), button29);
			buttons.Add(new Position(3, 5), button30);
			buttons.Add(new Position(3, 6), button31);
			buttons.Add(new Position(3, 7), button32);

			buttons.Add(new Position(4, 0), button33);
			buttons.Add(new Position(4, 1), button34);
			buttons.Add(new Position(4, 2), button35);
			buttons.Add(new Position(4, 3), button36);
			buttons.Add(new Position(4, 4), button37);
			buttons.Add(new Position(4, 5), button38);
			buttons.Add(new Position(4, 6), button39);
			buttons.Add(new Position(4, 7), button40);

			buttons.Add(new Position(5, 0), button41);
			buttons.Add(new Position(5, 1), button42);
			buttons.Add(new Position(5, 2), button43);
			buttons.Add(new Position(5, 3), button44);
			buttons.Add(new Position(5, 4), button45);
			buttons.Add(new Position(5, 5), button46);
			buttons.Add(new Position(5, 6), button47);
			buttons.Add(new Position(5, 7), button48);

			buttons.Add(new Position(6, 0), button49);
			buttons.Add(new Position(6, 1), button50);
			buttons.Add(new Position(6, 2), button51);
			buttons.Add(new Position(6, 3), button52);
			buttons.Add(new Position(6, 4), button53);
			buttons.Add(new Position(6, 5), button54);
			buttons.Add(new Position(6, 6), button55);
			buttons.Add(new Position(6, 7), button56);

			buttons.Add(new Position(7, 0), button57);
			buttons.Add(new Position(7, 1), button58);
			buttons.Add(new Position(7, 2), button59);
			buttons.Add(new Position(7, 3), button60);
			buttons.Add(new Position(7, 4), button61);
			buttons.Add(new Position(7, 5), button62);
			buttons.Add(new Position(7, 6), button63);
			buttons.Add(new Position(7, 7), button64);

		}

		public void InitPieces()
		{
			// TODO : init pieces
			Dictionary<Position, BasePiece> board = game.GetBoard();
			// TODO : add pieces to buttons
			foreach (var piece in board)
			{
				if (piece.Value == null) continue;
				if (piece.Value.Id == 1)
				{
					pb.Location = buttons[GetPosXY(piece.Key)].Location;
				}
			}

		}

		public Position GetPosByButton(Button button)
		{
			// TODO : get loc by button
			Position result = buttons.FirstOrDefault(x => x.Value == button).Key;

			return result;
		}
		public Position GetPosXY(int x, int y)
		{
			// TODO : get loc by x,y
			Position result = buttons.FirstOrDefault(r => r.Key.X == x && r.Key.Y == y).Key;

			return result;
		}
		public Position GetPosXY(Position position)
		{
			// TODO : get loc by pos
			Position result = buttons.FirstOrDefault(x => x.Key.X == position.X && x.Key.Y == position.Y).Key;

			return result;

		}
		public Button GetButtonByPos(Position pos)
		{
			// TODO : get button by loc
			Button result = buttons.FirstOrDefault(x => x.Key == pos).Value;

			return result;
		}

		public void UpdateBoard()
		{
			// TODO : update board
			Dictionary<Position, BasePiece> board = game.GetBoard();
			foreach (var piece in board)
			{
				if (piece.Value == null) continue;

				if (piece.Value.Id == 1) pb.Location = buttons[GetPosXY(piece.Key)].Location;
			}
		}

		private void ButtonClick(object sender, EventArgs e)
		{
			var button = (Button)sender;

			// TODO : move piece
			if (!game.isSelect)
			{
				Position position = GetPosByButton(button);
				game.SelectPiece(position);
				
				// set Enable to false
				// List<Position> forEnables = game.GetLegalMove(position);
				// foreach (var b in buttons)
				// {
				// 	b.Value.Enabled = false;
				// }
				// foreach (var pos in forEnables)
				// {
				// 	GetButtonByPos(pos).Enabled = true;
				// }
				
				previousButton = button;
			}

			else
			{
				game.MovePiece(GetPosByButton(button));
				previousButton.Enabled = true;
			}

			UpdateBoard();
		}
	}



}