using Domain;
using Models;
using System.Data.Common;
using System.Xml.Linq;

namespace Services
{
    public class PlayerService : IPlayerService
    {
        private Player _player;
        public PlayerService() {
        }

        public PlayerDTO CreatePlayer(int lives)
        {
            _player = new Player(lives);
            var player = new PlayerDTO(_player.Row, _player.Column, _player.Lives, _player.Moves);
            return player;
        }

        public void UpdatePlayerMove(PlayerDTO playerDto, string direction, int boardSize)
        {
            switch (direction)
            {
                case "up":
                    if (playerDto.Row > 0) playerDto.Row = _player.MoveUp();
                    break;
                case "down":
                    if (playerDto.Row < boardSize - 1) playerDto.Row = _player.MoveDown();
                    break;
                case "left":
                    if (playerDto.Column > 0) playerDto.Column = _player.MoveLeft();
                    break;
                case "right":
                    if (playerDto.Column < boardSize - 1) playerDto.Column = _player.MoveRight();
                    break;
                default:
                    break;
            }
            playerDto.Moves = _player.Moves;
        }

        public bool IsValidMove(PlayerDTO playerDto, string direction, int boardSize)
        {
            switch (direction)
            {
                case "up":
                    if (!(playerDto.Row > 0)) return false;
                    break;
                case "down":
                    if (!(playerDto.Row < boardSize - 1))  return false;
                    break;
                case "left":
                    if (!(playerDto.Column > 0)) return false;
                    break;
                case "right":
                    if (!(playerDto.Column < boardSize - 1)) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public void UpdatePlayerLives(PlayerDTO playerDto)
        {
            playerDto.Lives = _player.DecreaseLive();
        }

    }
}
