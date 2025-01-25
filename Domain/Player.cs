using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class Player
    {
        private int _row;
        private int _column;
        private int _lives;
        private int _moves;
        public Player(int noOfLives)
        {
              _row = 0;
              _column = 0;;
              _lives = noOfLives;
              _moves = 0;;
        }
        public int Row { get => _row;}
        public int Column { get => _column; }
        public int Lives { get => _lives;}
        public int Moves { get => _moves; }

        public int  MoveUp()
        {
            UpdateMove();
            return _row--;
        }
        public int MoveDown()
        {
            UpdateMove();
            return ++_row;
        }
        public int MoveLeft()
        {
            UpdateMove();
            return --_column;
        }
        public int MoveRight()
        {
            UpdateMove();
            return ++_column;
        }
        public int DecreaseLive()
        {
            return --_lives;
        }
        private void UpdateMove()
        {
            _moves++;
        }

    }
}
