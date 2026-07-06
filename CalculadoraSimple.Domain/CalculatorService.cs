namespace CalculadoraSimple.Domain
{
    public class CalculatorService(Utils _utils)
    {
        public readonly Utils utils = _utils;
        public string Sum(decimal a, decimal b)
        {
            var result = a + b;
            return $"Resultado de la suma: {utils.Format(result)}";
        }
        public string Subtract(decimal a, decimal b)
        {
            var result = a - b;
            return $"Resultado de la resta: {utils.Format(result)}";
        }
        public string Multiply(decimal a, decimal b)
        {
            var result = a * b;
            return $"Resultado de la multiplicación: {utils.Format(result)}";
        }
        public string Divide(decimal a, decimal b)
        {
            if (b == 0)
                throw new DivideByZeroException("No se permite dividir entre cero.");
            var result = a / b;
            return $"Resultado de la división: {utils.Format(result)}";
        }
    }
}
