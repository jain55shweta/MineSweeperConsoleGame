using Domain;
using Models;
using Services;
namespace MinesweeperGame
{
    public class MinesweeperController
    {
        private readonly IPlayerService _playerService;
        private readonly IBoardService _boardService;
        private BoardDTO _boardDto;
        private PlayerDTO _playerDto;

        public MinesweeperController(IPlayerService playerService, IBoardService boardService)
        {
            _playerService = playerService;
            _boardService = boardService;
        }

        public BoardDTO CreateBoard()
        {
            var boardDto = _boardService.CreateBoard();
            _boardDto = boardDto;
            return boardDto;
        }

        public void PlaceMines(int noOfMine)
        {
            _boardService.PlaceMines(boardDto: _boardDto, noOfMine: noOfMine);
        }

        public PlayerDTO CreatePlayer(int lives)
        {
            var playerDto = _playerService.CreatePlayer(lives: lives);
            _playerDto = playerDto;
            return playerDto;
        }
        public void ShowBoard(bool isHitMine = false)
        {
            _boardService.showBoard(player: _playerDto, isHitMine: isHitMine);
        }
        public void UpdateBoard(string move)
        {
            var isValidMove = _playerService.IsValidMove(playerDto: _playerDto, direction: move, boardSize: _boardDto.Rows);
            if (isValidMove) {
                _playerService.UpdatePlayerMove(playerDto: _playerDto, direction: move, boardSize: _boardDto.Rows);
                var isMine = _boardService.IsMine(_playerDto.Row, _playerDto.Column);
                if (isMine)
                {
                    _playerService.UpdatePlayerLives(playerDto: _playerDto);
                    ShowBoard(isHitMine: true);
                }
                else
                {
                    ShowBoard();
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }

    }
}
