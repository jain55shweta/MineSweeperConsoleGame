using NUnit.Framework;
using Models;
using Services;
using Domain;

namespace TestProject1
{
    public class BoardServiceTest
    {
        private IBoardService _boardService;
        private BoardDTO _boardDto;

        [SetUp]
        public void Setup()
        {
            _boardService = new BoardService(new Board(8));
            _boardDto = _boardService.CreateBoard();
            Assert.AreEqual(_boardDto.Rows, 8);
            Assert.AreEqual(_boardDto.Columns, 8);
        }

        [Test]
        public void CreateBoardShouldInitializeWithCorrectChar()
        {
            //Assign Expected Data
            var expectedChar = '.';
            // Action
            var board = _boardDto;
            //Assert
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    Assert.AreEqual(expectedChar, board.Grid[i, j]);
                }
            }
        }

        [TestCase]
        public void SetMinesShouldPlaceCorrectNumberOfMine()
        {
            // Assign Expected Data
            var noOfMines = 10;
            // Action
            var minesCount = 0;

            _boardService.PlaceMines(_boardDto, noOfMines);

            // Assert
            for (int i = 0; i < _boardDto.Rows; i++)
            {
                for (int j = 0; j < _boardDto.Columns; j++)
                {
                    if (_boardDto.Grid[i, j] == '*')
                    {
                        minesCount++;
                        Assert.IsTrue(IsValidLocation(i,j));
                    }
                }
            }
            Assert.AreEqual(noOfMines, minesCount);
        }

        [TestCase]
        public void IsMineShouldRetunrnTrueIfMineExist()
        {
            var boardSize = 8;
            // Action
            _boardDto.Grid[0, 1] = '*';
            var isMine = _boardService.IsMine(0, 1);

            // Assert
            Assert.AreEqual(true, isMine);
        }
        private bool IsValidLocation(int row, int column)
        {
            var isInValidCondition = (row == 0 && column == 0)
                                      || (row == 0 && column == 1)
                                      || (row == 1 && column == 0);
            return !isInValidCondition;
        }
    }
}