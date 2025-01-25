using Models;

namespace Services
{
    public interface IPlayerService
    {
        PlayerDTO CreatePlayer(int lives);
        void UpdatePlayerMove(PlayerDTO playerDto, string direction, int boardSize);
        bool IsValidMove(PlayerDTO playerDto, string direction, int boardSize);
        public void UpdatePlayerLives(PlayerDTO playerDto);
    }
}
