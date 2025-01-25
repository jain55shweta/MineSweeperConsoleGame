using Domain;
using Models;

namespace Services
{
    public class BoardService : IBoardService
    {
        private Board _board;
        public BoardService(Board board)
        {
            _board = board;
        }

        public BoardDTO CreateBoard()
        {
            _board.InitializeBoard();
            var boardDto = new BoardDTO(_board.Cells, _board.BoardSize);
            return boardDto;
        }

        public void PlaceMines(BoardDTO boardDto, int noOfMine)
        {
            var _randomNumber = new Random();
            for (int i = 0; i < noOfMine;)
            {
                int randRow = 0;
                int randColumn = 0;
               
                    randRow = _randomNumber.Next(maxValue: _board.BoardSize);
                    randColumn = _randomNumber.Next(maxValue: _board.BoardSize);
                if (IsValidLocation(randRow, randColumn))
                {
                    _board.AssignMine(randRow, randColumn);
                    i++;
                }
            }
            boardDto.Grid = _board.Cells;
        }

        private bool IsValidLocation(int randRow, int randColumn)
        {
            var isInValidCondition =  _board.Cells[randRow, randColumn] == '*' 
                                      || (randRow == 0 && randColumn == 0)
                                      || (randRow == 0 && randColumn == 1)
                                      || (randRow == 1 && randColumn == 0);
            return !isInValidCondition;
        }

        public bool IsMine(int row, int column)
        {
            return _board.Cells[row, column] == '*';
        }

        public void showBoard(PlayerDTO player, bool isHitMine = false)
        {
            Console.Clear();
            var showChar = 'P';
            if (isHitMine == true)
            {
                Console.WriteLine("Boom! You hit a mine. Lives remaining: " + player.Lives);
                showChar = '*';
            }
            Console.WriteLine("Board:");

            for (int i = 0; i < _board.BoardSize; i++)
            {
                for (int j = 0; j < _board.BoardSize; j++)
                {
                    if (i == player.Row && j == player.Column)
                    {
                            Console.Write(showChar + " ");
                    }
                    else
                    {
                        Console.Write('.' + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Lives: " + player.Lives + " Moves: " + player.Moves);
            Console.WriteLine("Current Position: " + GetChessNotation(player.Row, player.Column));
        }

        private static string GetChessNotation(int row, int column)
        {
            char file = (char)('A' + column);
            int rank = row;
            return $"{file}{rank}";
        }
    }
}
