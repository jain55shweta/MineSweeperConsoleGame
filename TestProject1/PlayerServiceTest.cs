using Domain;
using Models;
using Services;

namespace TestProject1
{
    public class PlayerServiceTest
    {
        private IPlayerService _playerService;
        private PlayerDTO _player;

        [SetUp]
        public void Setup()
        {
            _playerService = new PlayerService();
            _player = _playerService.CreatePlayer(3);
            Assert.AreEqual(_player.Lives, 3);
        }

        [TestCase("down",1,0)]
        [TestCase("right",0,1)]
        public void MoveShouldUpdatePlayerPosition(string direction, int expectedRow, int expectedCol)
        {
            // Action
            var boardSize = 8;
            _playerService.UpdatePlayerMove(_player, direction, boardSize);

            // Assert
            Assert.AreEqual(expectedRow, _player.Row);
            Assert.AreEqual(expectedCol, _player.Column);
        }

        [TestCase("up")]
        [TestCase("left")]
        public void InValidMoveShouldReturnFalse(string direction)
        {
            // Assign Expected Data
            var expectedRow = _player.Row;
            var expectedCol = _player.Column;
            // Action
            var boardSize = 8;
            var isValidMove = _playerService.IsValidMove(_player, direction, boardSize);

            // Assert
            Assert.AreEqual(false, isValidMove);
            Assert.AreEqual(expectedRow, _player.Row);
            Assert.AreEqual(expectedCol, _player.Column);
        }

        [TestCase]
        public void CreatePlayerShouldReturnwithNoOFLives()
        {
            // Assign Expected Data
            var expectedNoOfLives = 2;
            // Action
            _playerService.UpdatePlayerLives(_player);

            // Assert
            Assert.AreEqual(expectedNoOfLives, _player.Lives);
        }
    }
}