namespace Eagle.TicTacToe
{
    public class Coordinate
    {
        public Coordinate()
        {
        }

        public Direction Direction;
        public bool IsDanger { get; set; } = false;
        public int X { get; set; }
        public int Y { get; set; }

        public int dX { get; set; }
        public int dY { get; set; }

    }
}
