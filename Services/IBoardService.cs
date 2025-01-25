using Models;

namespace Services
{
    public interface IBoardService
    {
        BoardDTO CreateBoard();
        void PlaceMines(BoardDTO boardDto, int noOfMine);
        void showBoard(PlayerDTO player, bool isHitMine = false);
        bool IsMine(int row, int column);
    }
}
