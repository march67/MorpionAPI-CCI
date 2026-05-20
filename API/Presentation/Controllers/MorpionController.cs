using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MorpionAPI.Domain;
using MorpionAPI.Presentation.DTOs;

namespace MorpionAPI.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MorpionController : ControllerBase
    {
        private Board _board;
        public MorpionController(Board board)
        {
            _board = board;
        }

        [HttpPost("InputMove")]
        public IActionResult SetInputMoveOnBoard(InputMoveRequest inputMove)
        {
            int row = inputMove.Row;
            int column = inputMove.Column;
            int symbol = inputMove.Symbol;
            _board.BoardState[row][column] = (char)symbol;
            return Ok();
        }

        [HttpPost("InputRandomMove")]
        public IActionResult SetInputRandomMoveOnBoard(InputRandomMoveRequest inputMove)
        {
            _board.SetRandomMove(inputMove.Symbol);
            return Ok();
        }

        [HttpPost("InputRandomMovesUntilGameEnds")]
        public IActionResult SetInputRandomMoveOnBoard(InputRandomMovesUntilGameEndsRequest inputMove)  
        {
            char playerStart = Random.Shared.Next(2) == 0
                ? inputMove.SymbolPlayer1
                : inputMove.SymbolPlayer2;
            
            char currentSymbol = playerStart;

            while (!_board.CheckWinner(out _) && !_board.IsBoardFull())
            {
                _board.SetRandomMove(currentSymbol);

                currentSymbol = currentSymbol == inputMove.SymbolPlayer1
                    ? inputMove.SymbolPlayer2
                    : inputMove.SymbolPlayer1;
            }

            return Ok();
        }

        [HttpGet("Board")]
        public ActionResult<List<List<char>>> GetBoard()
        {
           var formatted = _board.BoardState.Select(row => string.Join("|", row));
           var formatted2 = string.Join("\n-+-+-\n", formatted);

           return Ok(formatted2);
        }

        [HttpGet("BoardState")]
        public ActionResult<List<List<char>>> GetBoardState()
        {
            return Ok(_board.BoardState);
        }

        //[HttpGet("CheckWinner")]
        //public ActionResult<Boolean> CheckWinner()
        //{
        //  if (_board.CheckWinner(out char symbol)) { return Ok(symbol); }
        //  return Ok();
        //}  
    }
}
