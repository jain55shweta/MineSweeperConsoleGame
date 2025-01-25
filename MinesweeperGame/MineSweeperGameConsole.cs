using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame
{
    public class MineSweeperGameConsole
    {
        private readonly MinesweeperController _minesweeperController;
        public MineSweeperGameConsole(MinesweeperController minesweeperController) {
            _minesweeperController = minesweeperController;
        }
        public void StartGame()
        {
            Console.WriteLine("MineSweeper Game Welcome!");
            Console.WriteLine("To Win, Player need to move from Top to Down in the board without steping on the mines");
            Console.WriteLine("Player will get 3 lives");
            var boardDto = _minesweeperController.CreateBoard();

            _minesweeperController.PlaceMines(noOfMine: 10);

            var playerDto = _minesweeperController.CreatePlayer(lives: 3);

            _minesweeperController.ShowBoard();

            while (IsPlayerLiveAvailable(playerDto) && IsPlayerNotReached(boardDto, playerDto))
            {
                Console.Write("Enter move (up, down, left, right): ");

                string move = Console.ReadLine().ToLower();

                _minesweeperController.UpdateBoard(move: move);
            }
            if (IsPlayerLiveAvailable(playerDto))
            {
                Console.WriteLine("Congratulations! You reached the other side in " + playerDto.Moves + " moves.");
            }
            else
            {
                Console.WriteLine("Game Over! You ran out of lives.");
            }
        }

        private static bool IsPlayerNotReached(BoardDTO boardDto, PlayerDTO playerDto)
        {
            return (playerDto.Row < boardDto.Rows - 1);
        }

        private static bool IsPlayerLiveAvailable(PlayerDTO playerDto)
        {
            return playerDto.Lives > 0;
        }

        
    }
}
