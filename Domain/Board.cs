using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Domain
{
    public class Board
    {
        private char[,] _cells;
        private int _boardSize;

        public Board(int size)
        {
            _boardSize = size;
            _cells = new char[size, size];
        }

        public char[,] Cells { get => _cells;}

        public int BoardSize { get => _boardSize; }

        public void InitializeBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Cells[row, col] = '.';
                }
            }
        }
        public void AssignMine(int row, int col)
        {
            _cells[row, col] = '*';
        }

    }
}
