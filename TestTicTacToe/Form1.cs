using Eagle.TicTacToe;

namespace TestTicTacToe
{
    public partial class Form1 : Form
    {
        TicTacToeGame game;
        public Form1()
        {
            InitializeComponent();
            InitGame();
        }
        public void InitGame()
        {
            game = new TicTacToeGame(3);
            game.ComputerMoveEvents += Game_ComputerMoveEvents;
            game.GameFinishEvents += Game_GameFinishEvents;

            label1.Text = "O";
            label2.Text = "O";
            label3.Text = "O";
            label4.Text = "O";
            label5.Text = "O";
            label6.Text = "O";
            label7.Text = "O";
            label8.Text = "O";
            label9.Text = "O";
        }

        private void Game_GameFinishEvents(object? sender, EventArgs e)
        {
            InitGame();
        }

        private void Game_ComputerMoveEvents(object? sender, EventArgs e)
        {
            Coordinate coordinate = (Coordinate)sender;

            ChangedItem(coordinate, "C");
        }

        private void Click(int x, int y)
        {
            game.MovePlayer(x, y);
            var coordinate = new Coordinate();
            coordinate.dX = x;
            coordinate.dY = y;

            ChangedItem(coordinate, "P");
        }

        private void ChangedItem(Coordinate coordinate, string text)
        {
            if (coordinate.dX == 0 && coordinate.dY == 0)
            {
                label1.Text = text;
            }
            if (coordinate.dX == 0 && coordinate.dY == 1)
            {
                label2.Text = text;
            }
            if (coordinate.dX == 0 && coordinate.dY == 2)
            {
                label3.Text = text;
            }
            if (coordinate.dX == 1 && coordinate.dY == 0)
            {
                label4.Text = text;
            }
            if (coordinate.dX == 1 && coordinate.dY == 1)
            {
                label5.Text = text;
            }
            if (coordinate.dX == 1 && coordinate.dY == 2)
            {
                label6.Text = text;
            }
            if (coordinate.dX == 2 && coordinate.dY == 0)
            {
                label7.Text = text;
            }
            if (coordinate.dX == 2 && coordinate.dY == 1)
            {
                label8.Text = text;
            }
            if (coordinate.dX == 2 && coordinate.dY == 2)
            {
                label9.Text = text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Click(0, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Click(0, 1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Click(0, 2);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Click(1, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Click(1, 1);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Click(1, 2);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Click(2, 0);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Click(2, 1);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Click(2, 2);
        }
    }
}