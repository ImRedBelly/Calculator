using System.Linq;

namespace CalculatorService
{
    public static class ExpressionCalculator
    {
        public static bool TryCalculateResult(ref string expression)
        {
            try
            {
                if (!IsValidExpression(expression, out var result))
                {
                    expression = $"{expression} = Error";
                    return false;
                }
                else
                {
                    expression = $"{expression} = {result}";
                    return true;
                }
            }
            catch
            {
                expression = $"{expression} = Error";
                return false;
            }
        }


        private static bool IsValidExpression(string expression, out int result)
        {
            result = 0;
            if (!expression.Contains("+"))
                return false;

            var parts = expression.Split('+');
            if (parts.Length != 2)
                return false;

            result = int.Parse(parts[0]) + int.Parse(parts[1]);
            return parts.All(part => part.All(char.IsDigit));
        }
    }
}