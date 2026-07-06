using CalculadoraSimple.Application;
using CalculadoraSimple.Application.Dtos;
using CalculadoraSimple.Domain;

namespace CalculadoraSimple.Tests
{
    public class CalculatorUseCaseTest
    {
        [Fact]
        public void Sum_ShouldReturnSuccessResponse()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var useCase = new CalculatorUseCase(service);

            var request = new CalculatorRequestDto
            {
                valorA = 1000,
                valorB = 250.5m
            };

            var response = useCase.Sum(request);

            Assert.True(response.Success);
            Assert.Equal("Operacion realizada correctamente.", response.Message);
            Assert.Equal("Resultado de la suma: 1,250.5", response.Result);
        }

        [Fact]
        public void Divide_ShouldPropagateException_WhenDivisorIsZero()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var useCase = new CalculatorUseCase(service);

            var request = new CalculatorRequestDto
            {
                valorA = 10,
                valorB = 0
            };

            Assert.Throws<DivideByZeroException>(() =>
                useCase.Divide(request)
            );
        }
    }
}
