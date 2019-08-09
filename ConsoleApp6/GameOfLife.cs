namespace ConsoleApp6
{
    public class GameOfLife
    {
        private int[,] _matrix;
        private int _m, _n;

        public Cell[,] Board { get; private set; }

        public GameOfLife(int[,] matrix)
        {
            _matrix = matrix;
            _m = matrix.GetLength(0);
            _n = matrix.GetLength(1);
            InitBoard();
        }

        public void GetNextGeneration()
        {
            Cell[,] newGeneration = new Cell[_m, _n];

            for (int i = 0; i < _m; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    Board[i, j].Evolve();
                    newGeneration[i, j] = new Cell { State = Board[i, j].State };
                }
            }

            Board = newGeneration;
            SetNeighboursCounts();
        }

        private void InitBoard()
        {
            Board = new Cell[_m, _n];

            for (int i = 0; i < _m; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    Cell cell = new Cell { State = _matrix[i, j] == 1 };
                    Board[i, j] = cell;
                }
            }

            SetNeighboursCounts();
        }

        private void SetNeighboursCounts()
        {
            for (int i = 0; i < _m; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    Board[i, j].Neighbours = CountLiveNeighbours(i, j);
                }
            }
        }

        private int CountLiveNeighbours(int i, int j)
        {
            int count = 0;

            count += (i >= 1 && j >= 1 && Board[i - 1, j - 1].State) ? 1 : 0;
            count += (i >= 1 && Board[i - 1, j].State) ? 1 : 0;
            count += (i >= 1 && j < _n - 1 && Board[i - 1, j + 1].State) ? 1 : 0;
            count += (j >= 1 && Board[i, j - 1].State) ? 1 : 0;
            count += (j < _n - 1 && Board[i, j + 1].State) ? 1 : 0;
            count += (i < _m - 1 && j >= 1 && Board[i + 1, j - 1].State) ? 1 : 0;
            count += (i < _m - 1 && Board[i + 1, j].State) ? 1 : 0;
            count += (i < _m - 1 && j < _n - 1 && Board[i + 1, j + 1].State) ? 1 : 0;

            return count;
        }
    }
}
