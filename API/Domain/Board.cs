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

        public bool CheckWinner(out char symbol)
        {
            // rows + columns
            for (int i = 0; i < BoardState.Count; i++)
            {
                if (BoardState[i][0] != ' ' && BoardState[i][0] == BoardState[i][1] && BoardState[i][1] == BoardState[i][2])
                {
                    symbol = BoardState[i][0];
                    return true;
                }
                if (BoardState[0][i] != ' ' && BoardState[0][i] == BoardState[1][i] && BoardState[1][i] == BoardState[2][i])
                {
                    symbol = BoardState[0][i];
                    return true;
                }
            }
            // diagonals
            if (BoardState[0][0] != ' ' && BoardState[0][0] == BoardState[1][1] && BoardState[1][1] == BoardState[2][2])
            {
                symbol = BoardState[0][0];
                return true;
            }
            if (BoardState[0][2] != ' ' && BoardState[0][2] == BoardState[1][1] && BoardState[1][1] == BoardState[2][0])
            {
                symbol = BoardState[0][2];
                return true;
            }

            symbol = ' ';
            return false;
        }

        public bool IsBoardFull()
        {
            foreach (var row in BoardState)
            {
                if (row.Contains(' '))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
