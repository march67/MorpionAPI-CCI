namespace MorpionAPI.Domain
{
    public class Board
    {
        public List<List<char>> BoardState { get; set; }
    
            public Board()
            {
                BoardState = new List<List<char>> {
                    new List<char> { ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ' },
                    new List<char> { ' ', ' ', ' ' }
                };
            }
    
            public void SetMove(int row, int column, char symbol)
            {
                BoardState[row][column] = symbol;
            }
    
            //public List<List<char>> GetBoard()
            //{
            //    return BoardState;
            //}
    }
}
