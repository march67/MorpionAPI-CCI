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
    
        public void SetRandomMove(char symbol)
        {
            Random random = new Random();
            int rowInput;
            int columnInput;

            do
            {
                rowInput = random.Next(BoardState.Count);
                columnInput = random.Next(BoardState[0].Count);
            } while (!CheckValidCellForInput(rowInput, columnInput));

            SetMove(rowInput, columnInput, symbol);
        }

        public bool CheckValidCellForInput(int row, int column)
        {
            if (BoardState[row][column] != ' ')
            {
                return false;
            }

            return true;
        }
    }
}
