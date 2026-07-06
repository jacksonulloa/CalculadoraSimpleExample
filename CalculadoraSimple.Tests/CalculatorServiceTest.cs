using CalculadoraSimple.Domain;

namespace CalculadoraSimple.Tests
{
    public class CalculatorServiceTest
    {
        [Theory]
        [InlineData(10, 5, "Resultado de la suma: 15")]
        [InlineData(100, 50, "Resultado de la suma: 150")]
        [InlineData(1000, 250.5, "Resultado de la suma: 1,250.5")]
        [InlineData(1234.567, 0, "Resultado de la suma: 1,234.57")]
        public void Sum_ShouldReturnExpectedResult(decimal a, decimal b, string expected)
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var result = service.Sum(a, b);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Sum_ShouldReturnFormattedResult()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var result = service.Sum(1000, 250.5m);
            Assert.Contains("1,250.5", result);
        }
        [Fact]
        public void Subtract_ShouldReturnFormattedResult()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var result = service.Subtract(1000, 250);
            Assert.Contains("750", result);
        }
        [Fact]
        public void Multiply_ShouldReturnFormattedResult()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var result = service.Multiply(10, 5);
            Assert.Contains("50", result);
        }
        [Fact]
        public void Divide_ShouldReturnFormattedResult()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            var result = service.Divide(10, 2);
            Assert.Contains("5", result);
        }
        [Fact]
        public void Divide_ShouldThrowException_WhenDivisorIsZero()
        {
            var formatter = new Utils();
            var service = new CalculatorService(formatter);
            Assert.Throws<DivideByZeroException>(() =>
                service.Divide(10, 0)
            );
        }
    }
}
