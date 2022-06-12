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
        private IPointsRepository _pointsRepository;
        private SquareCalculator _calculator;
        public SquaresController(IPointsRepository pointsRepository, SquareCalculator calculator)
        {
            _pointsRepository = pointsRepository;
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
                var result = _pointsRepository.FormatResultList(square);
                return Ok(result);
            }
          
        }
    }
}
