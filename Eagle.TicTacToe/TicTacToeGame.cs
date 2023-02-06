using System.Reflection.PortableExecutable;

namespace Eagle.TicTacToe
{
    public class TicTacToeGame
    {
        private int[,] _board;
        private int _size;

        public event EventHandler ComputerMoveEvents;
        public event EventHandler GameFinishEvents;

        public TicTacToeGame(int size)
        {
            this._board = new int[size, size];
            this._size = size;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _board[i, j] = (int)SymbolTicTacToe.Undefined;
                }
            }
        }

        public void MovePlayer(int x, int y)
        {
            this.InternalMovePlayer(x, y);
        }
        private bool AddToBoard(int x, int y, SymbolTicTacToe symbolTicTacToe)
        {
            _board[x, y] = (int)symbolTicTacToe;
            bool isFinish = IsFinish();
            if (isFinish)
            {
                //GameFinishEvents.Invoke(_board, new EventArgs());
            }
            return isFinish;
        }
        public bool IsFinish()
        {

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_board[i, j] == (int)SymbolTicTacToe.Undefined)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void InternalMovePlayer(int x, int y)
        {
            var isFinish = AddToBoard(x, y, SymbolTicTacToe.Player);
            if (isFinish)
            {
                return;
            }

            Coordinate coordinate;

            var potentialAttackCoordinates = CheckPotentialAttack();
            var filterPotentialAttackCoordinates = potentialAttackCoordinates
                .Where(x => x.dX >= 0 &&
                            x.dX < _size &&
                            x.dY >= 0 &&
                            x.dY < _size &&
                            _board[x.dX, x.dY] == (int)SymbolTicTacToe.Undefined)
                .ToList();

            if (filterPotentialAttackCoordinates.Count != 0)
            {
                if (filterPotentialAttackCoordinates.Count == 1)
                {
                    coordinate = filterPotentialAttackCoordinates.First();
                }
                else
                {
                    coordinate = null;
                }

            }
            else
            {
                var dangerCoordinates = CheckDanger();

                var filterDangerCoordinates = dangerCoordinates
                    .Where(x => x.dX >= 0 &&
                                x.dX < _size &&
                                x.dY >= 0 &&
                                x.dY < _size &&
                                _board[x.dX, x.dY] == (int)SymbolTicTacToe.Undefined)
                    .ToList();
                if (filterDangerCoordinates.Count != 0)
                {
                    coordinate = filterDangerCoordinates!.First();
                }
                else
                {
                    coordinate = null;
                }
            }


            
            RunComputer(coordinate);
        }

        private void RunComputer(Coordinate coordinate)
        {
            bool isFinish = AddToBoard(coordinate.dX, coordinate.dY, SymbolTicTacToe.Computer);
            if (isFinish)
            {
                return;
            }
            ComputerMoveEvents.Invoke(coordinate, new EventArgs());
        }


        private List<Coordinate> CheckDanger()
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            for(int i = 0; i< _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var item = _board[i, j];

                    if(item == (int)SymbolTicTacToe.Computer || item == (int)SymbolTicTacToe.Undefined)
                    {
                        continue;
                    }
                    if (i != 0 && j != 0)
                    {
                        if (_board[i - 1, j - 1] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i + 1;
                            coordinate.dY = j + 1;
                            coordinate.Direction = Direction.DiagonalLeftToRight;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (j != 0)
                    {
                        if (_board[i, j - 1] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i;
                            coordinate.dY = j + 1;
                            coordinate.Direction = Direction.HorizontalLeftToRight;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (j != 0 && i != (_size - 1))
                    {
                        if (_board[i + 1, j - 1] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i - 1;
                            coordinate.dY = j + 1;
                            coordinate.Direction = Direction.ReverseDiagonalLeftToRight;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != (_size - 1))
                    {
                        if (_board[i + 1, j] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i - 1;
                            coordinate.dY = j;
                            coordinate.Direction = Direction.VerticalBottomToTop;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != (_size - 1) && j != (_size - 1))
                    {
                        if (_board[i + 1, j + 1] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i - 1;
                            coordinate.dY = j - 1;
                            coordinate.Direction = Direction.DiagonalRightToLeft;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (j != (_size - 1))
                    {
                        if (_board[i, j + 1] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i;
                            coordinate.dY = j - 1;
                            coordinate.Direction = Direction.HorizontalRightToLeft;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != 0 && j != (_size - 1))
                    {
                        if (_board[i - 1, j + 1] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i + 1;
                            coordinate.dY = j - 1;
                            coordinate.Direction = Direction.ReverseDiagonalRightToLeft;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != 0)
                    {
                        if (_board[i - 1, j] == (int)SymbolTicTacToe.Player)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i + 1;
                            coordinate.dY = j;
                            coordinate.Direction = Direction.VerticalTopToBottom;

                            coordinates.Add(coordinate);
                        }
                    }
                }
            }


            return coordinates;
        }

        private List<Coordinate> CheckPotentialAttack()
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var item = _board[i, j];

                    if (item == (int)SymbolTicTacToe.Player || item == (int)SymbolTicTacToe.Undefined)
                    {
                        continue;
                    }
                    if (i != 0 && j != 0)
                    {
                        if (_board[i - 1, j - 1] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i + 1;
                            coordinate.dY = j + 1;
                            coordinate.Direction = Direction.DiagonalLeftToRight;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (j != 0)
                    {
                        if (_board[i, j - 1] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i;
                            coordinate.dY = j + 1;
                            coordinate.Direction = Direction.HorizontalLeftToRight;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (j != 0 && i != (_size - 1))
                    {
                        if (_board[i + 1, j - 1] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i - 1;
                            coordinate.dY = j + 1;
                            coordinate.Direction = Direction.ReverseDiagonalLeftToRight;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != (_size - 1))
                    {
                        if (_board[i + 1, j] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i - 1;
                            coordinate.dY = j;
                            coordinate.Direction = Direction.VerticalBottomToTop;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != (_size - 1) && j != (_size - 1))
                    {
                        if (_board[i + 1, j + 1] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i - 1;
                            coordinate.dY = j - 1;
                            coordinate.Direction = Direction.DiagonalRightToLeft;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (j != (_size - 1))
                    {
                        if (_board[i, j + 1] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i;
                            coordinate.dY = j - 1;
                            coordinate.Direction = Direction.HorizontalRightToLeft;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != 0 && j != (_size - 1))
                    {
                        if (_board[i - 1, j + 1] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i + 1;
                            coordinate.dY = j - 1;
                            coordinate.Direction = Direction.ReverseDiagonalRightToLeft;

                            coordinates.Add(coordinate);
                        }
                    }
                    if (i != 0)
                    {
                        if (_board[i - 1, j] == (int)SymbolTicTacToe.Computer)
                        {
                            Coordinate coordinate = new Coordinate();
                            coordinate.X = i;
                            coordinate.Y = j;

                            coordinate.dX = i + 1;
                            coordinate.dY = j;
                            coordinate.Direction = Direction.VerticalTopToBottom;

                            coordinates.Add(coordinate);
                        }
                    }
                }
            }


            return coordinates;
        }

        private Coordinate FindAttack()
        {

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_board[i, j] == (int)SymbolTicTacToe.Undefined)
                    {
                        return new Coordinate()
                        {
                            dX = i,
                            dY = j
                        };
                    }
                }
            }
            return null;
        }
    }
}
