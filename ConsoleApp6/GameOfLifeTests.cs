using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp6
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void Test_GameOfLife_CreatesGameFromMatrix()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            Assert.IsNotNull(game);
        }


        [TestMethod]
        public void Test_GameOfLife_CreatesBoardFromMatrix()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            Assert.IsNotNull(game.Board);
            Assert.AreEqual(3, game.Board.GetLength(0));
            Assert.AreEqual(3, game.Board.GetLength(1));
        }

        [TestMethod]
        public void Test_GameOfLife_CreatesBoardFromMatrixWithCorrespondingStates()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            var boardToInt = GameBoardToIntBoard(game);

            CollectionAssert.AreEqual(matrix, boardToInt);
        }

        [TestMethod]
        public void Test_GameOfLife_TopLeftCorner_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            Assert.AreEqual(2, game.Board[0, 0].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_TopRightCorner_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            int n = game.Board.GetLength(1);
            Assert.AreEqual(1, game.Board[0, n - 1].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_BottomLeftCorner_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            int m = game.Board.GetLength(0);
            Assert.AreEqual(3, game.Board[m - 1, 0].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_BottomRightCorner_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            int m = game.Board.GetLength(0);
            int n = game.Board.GetLength(1);
            Assert.AreEqual(2, game.Board[m - 1, n - 1].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_TopMiddle_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            Assert.AreEqual(3, game.Board[0, 1].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_BottomMiddle_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            int m = game.Board.GetLength(0);
            Assert.AreEqual(3, game.Board[m - 1, 1].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_LeftMiddle_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            Assert.AreEqual(3, game.Board[1, 0].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_RightMiddle_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            int n = game.Board.GetLength(1);
            Assert.AreEqual(3, game.Board[1, n - 1].Neighbours);
        }

        [TestMethod]
        public void Test_GameOfLife_Middle_SetsNeighbours()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };

            GameOfLife game = new GameOfLife(matrix);

            Assert.AreEqual(4, game.Board[1, 1].Neighbours);
        }

        /*
         * 100 -> 110 -> 110
         * 110    101 -> 001
         * 011    111    101
         */
        [TestMethod]
        public void Test_GetNextGeneration_CellsEvolveCorrectly()
        {
            int[,] matrix = new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };
            GameOfLife game = new GameOfLife(matrix);

            game.GetNextGeneration();

            var boardToInt = GameBoardToIntBoard(game);
            var expectedResult = new int[,] { { 1, 1, 0 }, { 1, 0, 1 }, { 1, 1, 1 } };

            CollectionAssert.AreEqual(expectedResult, boardToInt);
        }

        /*
         * 000000000 -> 
         * 000000000
         * 000010000
         * 000111000
         * 000101000
         * 000010000
         * 000000000
         * 000000000
         */
        [TestMethod]
        public void FancyTest_Get2NextGenerationsFromExploderPattern_CellsEvolveCorrectly()
        {
            int[,] matrix = new int[,]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            GameOfLife game = new GameOfLife(matrix);

            game.GetNextGeneration();

            var boardToInt = GameBoardToIntBoard(game);
            var expectedResult = new int[,]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            CollectionAssert.AreEqual(expectedResult, boardToInt);

            game.GetNextGeneration();

            boardToInt = GameBoardToIntBoard(game);
            expectedResult = new int[,]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 1, 1, 0, 1, 1, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            CollectionAssert.AreEqual(expectedResult, boardToInt);
        }

        private static int[,] GameBoardToIntBoard(GameOfLife game)
        {
            int m = game.Board.GetLength(0);
            int n = game.Board.GetLength(1);
            int[,] boardToInt = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    boardToInt[i, j] = game.Board[i, j].State ? 1 : 0;
                }
            }

            return boardToInt;
        }
    }
}
