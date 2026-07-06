using CalculadoraSimple.Application;
using CalculadoraSimple.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraSimple.Api.Controllers
{
    public class CalculatorController(CalculatorUseCase _calculatorUseCase) : ControllerBase
    {
        public CalculatorUseCase calculatorUseCase = _calculatorUseCase;
        [HttpPost("sum")]
        public IActionResult Sum([FromBody] CalculatorRequestDto request)
        {
            var response = calculatorUseCase.Sum(request);
            return Ok(response);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] CalculatorRequestDto request)
        {
            var response = calculatorUseCase.Subtract(request);
            return Ok(response);
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] CalculatorRequestDto request)
        {
            var response = calculatorUseCase.Multiply(request);
            return Ok(response);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CalculatorRequestDto request)
        {
            var response = calculatorUseCase.Divide(request);
            return Ok(response);
        }
    }
}
