namespace Models
{
    public class BoardDTO
    {
        public char[,] Grid { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public BoardDTO(char[,] cell, int size)
        {
            Rows = size;
            Columns = size;
            Grid = cell;
        }
    }
}
