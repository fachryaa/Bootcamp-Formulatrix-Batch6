using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class FormFinish : Form
    {
        Game game = new();
        public FormFinish(Game g)
        {
            InitializeComponent();

            game = g;
        }

        private void ResetGame(object sender, EventArgs e)
        {
            game.ResetGame();
            this.Close();
        }
    }
}
