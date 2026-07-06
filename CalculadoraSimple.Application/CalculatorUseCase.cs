using CalculadoraSimple.Application.Dtos;
using CalculadoraSimple.Domain;

namespace CalculadoraSimple.Application
{
    public class CalculatorUseCase(CalculatorService _calculatorService)
    {
        public CalculatorService calculatorService = _calculatorService;

        public CalculatorResponseDto Sum(CalculatorRequestDto request)
        {
            var result = calculatorService.Sum(request.valorA, request.valorB);
            return new CalculatorResponseDto
            {
                Success = true,
                Message = "Operacion realizada correctamente.",
                Result = result
            };
        }
        public CalculatorResponseDto Subtract(CalculatorRequestDto request)
        {
            var result = calculatorService.Subtract(request.valorA, request.valorB);
            return new CalculatorResponseDto
            {
                Success = true,
                Message = "Operacion realizada correctamente.",
                Result = result
            };
        }
        public CalculatorResponseDto Multiply(CalculatorRequestDto request)
        {
            var result = calculatorService.Multiply(request.valorA, request.valorB);
            return new CalculatorResponseDto
            {
                Success = true,
                Message = "Operacion realizada correctamente.",
                Result = result
            };
        }
        public CalculatorResponseDto Divide(CalculatorRequestDto request)
        {
            var result = calculatorService.Divide(request.valorA, request.valorB);
            return new CalculatorResponseDto
            {
                Success = true,
                Message = "Operacion realizada correctamente.",
                Result = result
            };
        }
    }
}
