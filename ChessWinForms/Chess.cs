using ChessLibrary;
using ChessLibrary.Pieces;
using ChessLibrary.Enum;

namespace ChessWinForms
{
	public partial class Chess : Form
	{
		private GameController game = new GameController(new Board(boardSize : 8));

		public readonly Dictionary<Position, Button> buttons = new();
		public readonly Dictionary<Position, PictureBox> dots = new();
		private BasePiece? choosed;
		private Position? choosedPos;
				public Chess()
				{
					InitializeComponent();
					InitButtonsAndDots();

					UpdateBoard();
					// TODO : selected piece, isSelect

					IEnumerable<IPosition> playerStartPiece = game.GetMoveablePiecePos(game.GetCurrentPlayer());
					SetEnabledButtons(playerStartPiece);

		            choosed = null;
		            choosedPos = null;
				}

		public void InitButtonsAndDots()
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

			// Init dots
			dots.Add(new Position(0, 0), dot1);
			dots.Add(new Position(0, 1), dot2);
			dots.Add(new Position(0, 2), dot3);
			dots.Add(new Position(0, 3), dot4);
			dots.Add(new Position(0, 4), dot5);
			dots.Add(new Position(0, 5), dot6);
			dots.Add(new Position(0, 6), dot7);
			dots.Add(new Position(0, 7), dot8);

			dots.Add(new Position(1, 0), dot9);
			dots.Add(new Position(1, 1), dot10);
			dots.Add(new Position(1, 2), dot11);
			dots.Add(new Position(1, 3), dot12);
			dots.Add(new Position(1, 4), dot13);
			dots.Add(new Position(1, 5), dot14);
			dots.Add(new Position(1, 6), dot15);
			dots.Add(new Position(1, 7), dot16);

			dots.Add(new Position(2, 0), dot17);
			dots.Add(new Position(2, 1), dot18);
			dots.Add(new Position(2, 2), dot19);
			dots.Add(new Position(2, 3), dot20);
			dots.Add(new Position(2, 4), dot21);
			dots.Add(new Position(2, 5), dot22);
			dots.Add(new Position(2, 6), dot23);
			dots.Add(new Position(2, 7), dot24);

			dots.Add(new Position(3, 0), dot25);
			dots.Add(new Position(3, 1), dot26);
			dots.Add(new Position(3, 2), dot27);
			dots.Add(new Position(3, 3), dot28);
			dots.Add(new Position(3, 4), dot29);
			dots.Add(new Position(3, 5), dot30);
			dots.Add(new Position(3, 6), dot31);
			dots.Add(new Position(3, 7), dot32);

			dots.Add(new Position(4, 0), dot33);
			dots.Add(new Position(4, 1), dot34);
			dots.Add(new Position(4, 2), dot35);
			dots.Add(new Position(4, 3), dot36);
			dots.Add(new Position(4, 4), dot37);
			dots.Add(new Position(4, 5), dot38);
			dots.Add(new Position(4, 6), dot39);
			dots.Add(new Position(4, 7), dot40);

			dots.Add(new Position(5, 0), dot41);
			dots.Add(new Position(5, 1), dot42);
			dots.Add(new Position(5, 2), dot43);
			dots.Add(new Position(5, 3), dot44);
			dots.Add(new Position(5, 4), dot45);
			dots.Add(new Position(5, 5), dot46);
			dots.Add(new Position(5, 6), dot47);
			dots.Add(new Position(5, 7), dot48);

			dots.Add(new Position(6, 0), dot49);
			dots.Add(new Position(6, 1), dot50);
			dots.Add(new Position(6, 2), dot51);
			dots.Add(new Position(6, 3), dot52);
			dots.Add(new Position(6, 4), dot53);
			dots.Add(new Position(6, 5), dot54);
			dots.Add(new Position(6, 6), dot55);
			dots.Add(new Position(6, 7), dot56);

			dots.Add(new Position(7, 0), dot57);
			dots.Add(new Position(7, 1), dot58);
			dots.Add(new Position(7, 2), dot59);
			dots.Add(new Position(7, 3), dot60);
			dots.Add(new Position(7, 4), dot61);
			dots.Add(new Position(7, 5), dot62);
			dots.Add(new Position(7, 6), dot63);
			dots.Add(new Position(7, 7), dot64);

			// set dot location to button
			foreach (var dot in dots)
			{
				dot.Value.Location = GetButtonByPos(dot.Key).Location;
				dot.Value.Location = new Point(dot.Value.Location.X + 20, dot.Value.Location.Y + 17);
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
		public Button GetButtonByPos(IPosition position)
		{
			// TODO : get button by loc
			Button result = buttons.FirstOrDefault(x => x.Key.X == position.X && x.Key.Y == position.Y).Value;

			return result;
		}

		public PictureBox GetDotByPos(IPosition position)
		{
			// TODO : get button by loc
			PictureBox result = dots.FirstOrDefault(x => x.Key.X == position.X && x.Key.Y == position.Y).Value;

			return result;
		}

		private Bitmap? GetPieceImg(IPosition position)
		{
			var piece = game.GetPiece(position);
			if (piece == null) return null;


			if (piece.Color == ChessLibrary.Enum.Color.White)
			{
				switch (piece.Type)
				{
					case PieceType.Pawn : return Properties.Resources.Chess_plt45;
					case PieceType.Rook : return Properties.Resources.Chess_rlt45;
					case PieceType.Knight : return Properties.Resources.Chess_nlt45;
					case PieceType.Bishop : return Properties.Resources.Chess_blt45;
					case PieceType.Queen : return Properties.Resources.Chess_qlt45;
					case PieceType.King : return Properties.Resources.Chess_klt45;
					default : return Properties.Resources.Chess_plt45;
				}
			}
			else if (piece.Color == ChessLibrary.Enum.Color.Black)
			{
				switch (piece.Type)
				{
					case PieceType.Pawn : return Properties.Resources.Chess_pdt45;
					case PieceType.Rook : return Properties.Resources.Chess_rdt45;
					case PieceType.Knight : return Properties.Resources.Chess_ndt45;
					case PieceType.Bishop : return Properties.Resources.Chess_bdt45;
					case PieceType.Queen : return Properties.Resources.Chess_qdt45;
					case PieceType.King : return Properties.Resources.Chess_kdt45;
					default : return Properties.Resources.Chess_plt45;
				}
			}
			
			return null;
		}

		public void UpdateBoard()
		{
			// TODO : update board
			Dictionary<IPosition, BasePiece?> board = game.GetBoard();
			foreach (var piece in board)
			{
				buttons[GetPosXY((Position)piece.Key)].BackgroundImage = GetPieceImg((Position)piece.Key);
			}
		}

		private void SetEnabledButtons(IEnumerable<IPosition> positions, bool isMoveTo = false)
		{
			foreach (var b in buttons)
			{
				b.Value.Enabled = false;
			}

			foreach (var pos in positions)
			{
				GetButtonByPos(pos).Enabled = true;
			}

			if (isMoveTo)
			{
				foreach (var d in dots)
				{
					d.Value.Visible = false;
				}

				foreach (var pos in positions)
				{
					GetDotByPos(pos).Visible = true;
				}
			}
		}

		private void ChangeBackColorPlayerLabel(ChessLibrary.Enum.Color color)
		{
			if (color == ChessLibrary.Enum.Color.White)
			{
				player1Label.BackColor = System.Drawing.Color.SkyBlue;
				player2Label.BackColor = default;
			}
			else
			{
				player2Label.BackColor = System.Drawing.Color.SkyBlue;
				player1Label.BackColor = default;
			}
		}

		private void ChangeStatus()
		{
			string status = game.Status.ToString();
			statusLabel.Text = status;
			
			if (game.Status == Status.Check) 
			{
				statusLabel.BackColor = System.Drawing.Color.Orange;
			}
			else if (game.Status == Status.Checkmate) 
			{
				string winner = game.Winner == ChessLibrary.Enum.Color.White ? "Player 1 Win" : "Player 2 Win";
				statusLabel.Text += $" - {winner}";
				statusLabel.BackColor = System.Drawing.Color.Red;
			}
			else if (game.Status == Status.Stalemate) 
			{
				statusLabel.Text += " - Draw";
				statusLabel.BackColor = System.Drawing.Color.Green;
			}
			else statusLabel.BackColor = default;
		}
		
		private void SetChooseButton(bool visible)
		{
			ChessLibrary.Enum.Color color = game.GetCurrentPlayer();
			if (color == ChessLibrary.Enum.Color.White)
			{
				chooseRookButton.BackgroundImage = Properties.Resources.Chess_rlt45;
				chooseKnightButton.BackgroundImage = Properties.Resources.Chess_nlt45;
				chooseBishopButton.BackgroundImage = Properties.Resources.Chess_blt45;
				chooseQueenButton.BackgroundImage = Properties.Resources.Chess_qlt45;
			}
			else
			{
				chooseRookButton.BackgroundImage = Properties.Resources.Chess_rdt45;
				chooseKnightButton.BackgroundImage = Properties.Resources.Chess_ndt45;
				chooseBishopButton.BackgroundImage = Properties.Resources.Chess_bdt45;
				chooseQueenButton.BackgroundImage = Properties.Resources.Chess_qdt45;
			}
			chooseRookButton.Visible = visible;
			chooseKnightButton.Visible = visible;
			chooseBishopButton.Visible = visible;
			chooseQueenButton.Visible = visible;
		}
		private void ButtonClick(object sender, EventArgs e)
		{
			Button button = (Button)sender;

			if (!game.IsSelect)
			{
				Position position = GetPosByButton(button);
				game.SelectPiece(position);

				// set Enable to false
				IEnumerable<IPosition> forEnables = game.GetLegalMove(position);
				forEnables.ToList().Add(position);
				SetEnabledButtons(forEnables, isMoveTo: true);

			}

			else
			{
				// if Unselect piece
				if (game.IsUnSelect(game.SelectedPos!, GetPosByButton(button)))
				{
					game.UnSelect();
					IEnumerable<IPosition> moveablePiece = game.GetMoveablePiecePos(game.GetCurrentPlayer());
					SetEnabledButtons(Enumerable.Empty<IPosition>(), true);
					SetEnabledButtons(moveablePiece);
					return;
				}
				game.MovePiece(GetPosByButton(button));

				// Cek promotion pawn
				if (game.IsPawnGotPromotion(GetPosByButton(button)))
				{
					choosedPos = GetPosByButton(button);
					SetChooseButton(true);
					return;
				}
				
				SetChooseButton(false);
				
				SetEnabledButtons(Enumerable.Empty<IPosition>(), true);

				game.OnChangeTurn.Invoke(sender,e);

				// change turn label color
				ChangeBackColorPlayerLabel(game.GetCurrentPlayer());

				// change status
				ChangeStatus();

				IEnumerable<IPosition> changeTurnPos = game.GetMoveablePiecePos(game.GetCurrentPlayer());
				SetEnabledButtons(changeTurnPos);
			}

			UpdateBoard();
		}

		private void ButtonReset(object sender, EventArgs e)
		{
			game.ResetGame();
			
			
			IEnumerable<IPosition> changeTurnPos = game.GetMoveablePiecePos(game.GetCurrentPlayer());
			SetEnabledButtons(Enumerable.Empty<IPosition>(), true);
			SetEnabledButtons(changeTurnPos);
			
			ChangeStatus();
			
			ChangeBackColorPlayerLabel(game.GetCurrentPlayer());

			UpdateBoard();
		}

		private void ChooseRook(object sender, EventArgs e)
		{
			Choosing(ChessLibrary.Enum.PieceType.Rook, game.GetCurrentPlayer());
		}

		private void ChooseKnight(object sender, EventArgs e)
		{
			Choosing(ChessLibrary.Enum.PieceType.Knight, game.GetCurrentPlayer());
			
		}

		private void ChooseBishop(object sender, EventArgs e)
		{
			Choosing(ChessLibrary.Enum.PieceType.Bishop, game.GetCurrentPlayer());

		}

		private void ChooseQueen(object sender, EventArgs e)
		{
			Choosing(ChessLibrary.Enum.PieceType.Queen, game.GetCurrentPlayer());

		}
		
		private void Choosing(ChessLibrary.Enum.PieceType type, ChessLibrary.Enum.Color color)
		{
			if (type == ChessLibrary.Enum.PieceType.Rook) choosed = BasePiece.Create(PieceType.Rook, color);
			else if (type == ChessLibrary.Enum.PieceType.Knight) choosed = BasePiece.Create(PieceType.Knight, color);
			else if (type == ChessLibrary.Enum.PieceType.Bishop) choosed = BasePiece.Create(PieceType.Bishop, color);
			else if (type == ChessLibrary.Enum.PieceType.Queen) choosed = BasePiece.Create(PieceType.Queen, color);

			game.PawnPromotion(choosedPos!, choosed!);
			
			SetChooseButton(false);
				
			SetEnabledButtons(Enumerable.Empty<IPosition>(), true);

			game.OnChangeTurn.Invoke(null, EventArgs.Empty);

			// change turn label color
			ChangeBackColorPlayerLabel(game.GetCurrentPlayer());

			// change status
			ChangeStatus();

			IEnumerable<IPosition> changeTurnPos = game.GetMoveablePiecePos(game.GetCurrentPlayer());
			SetEnabledButtons(changeTurnPos);
			
			UpdateBoard();
		}
	}



}