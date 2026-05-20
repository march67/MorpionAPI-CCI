using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MorpionAPI.Domain;
using MorpionAPI.Presentation.DTOs;

namespace MorpionAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("Board")]
        public ActionResult<List<List<char>>> GetBoard()
        {
           var formatted = _board.BoardState.Select(row => string.Join("|", row));
           var formatted2 = string.Join("\n-+-+-\n", formatted);

           return Ok(formatted2);
        }
    }
}
