using System.Globalization;

namespace CalculadoraSimple.Domain
{
    public class Utils
    {
        public string Format(decimal value) => value.ToString("#,##0.##", CultureInfo.InvariantCulture);
    }
}
