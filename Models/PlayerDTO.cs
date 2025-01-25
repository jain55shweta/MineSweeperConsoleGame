namespace Models
{
    public class PlayerDTO
    {
        public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;
        public int Lives { get; set; } = 3;
        public int Moves { get; set; } = 0;

        public PlayerDTO(int row, int col, int lives, int moves)
        {
            Row = row;
            Column = col;
            Lives = lives;
            Moves = moves;
        }
    }
}
