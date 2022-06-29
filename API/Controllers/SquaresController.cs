using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private SquareCalculator _calculator;
        public SquaresController(SquareCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("GetSquaresFromPointSetId/{id}")]
        public IActionResult CalculateSquares(string id)
        {
            var square = _calculator.SquareCalculatorFunc(id);
            if (square == null)
            {
                return NotFound();
            }
            else
            {
                var result = _calculator.FormatResults(square);
                return Ok(result);
            }
          
        }
    }
}
