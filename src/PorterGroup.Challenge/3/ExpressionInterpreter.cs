using System.Text.RegularExpressions;

namespace PorterGroup.Challenge;

public static class ExpressionInterpreter
{
    public static double Evaluate(string expression)
    {
        expression = Regex.Replace(expression, @"\s+", "");
        expression = Regex.Replace(expression, @"[^0-9+\-*/]", "");
        expression = SimplifyMultiplicationsAndDivisions(expression);

        return EvaluateBasicOperations(expression);
    }

    private static string SimplifyMultiplicationsAndDivisions(string expression)
    {
        // Multiplication and Division
        while (expression.Contains('*') || expression.Contains('/'))
        {
            (char Symbol, int Index) @operator = GetOperator(expression);
            (double Value, int StartIndex) leftOperand = GetLeftOperand(expression, @operator.Index);
            (double Value, int StartIndex) rightOperand = GetRightOperand(expression, @operator.Index);

            // evaluate chunk
            double result;

            if (@operator.Symbol == '*')
                result = leftOperand.Value * rightOperand.Value;
            else // division
            {
                if (rightOperand.Value == 0)
                    throw new DivideByZeroException();

                result = leftOperand.Value / rightOperand.Value;
            }

            expression = string.Concat(
                expression[..(leftOperand.StartIndex + 1)],
                result.ToString(),
                expression[rightOperand.StartIndex..]);
        }

        return expression;
    }

    private static (char Symbol, int Index) GetOperator(string expression)
    {
        int index = -1;
        char @operator = ' ';

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '*' || expression[i] == '/')
            {
                index = i;
                @operator = expression[i];
                break;
            }
        }

        return (@operator, index);
    }

    private static (double Value, int StartIndex) GetLeftOperand(string expression, int operatorIndex)
    {
        int leftOperandStart = operatorIndex - 1;

        while (leftOperandStart >= 0 && char.IsDigit(expression[leftOperandStart]))
            leftOperandStart--;

        int leftOperandLength = operatorIndex - leftOperandStart - 1;
        double result = double.Parse(expression.Substring(leftOperandStart + 1, leftOperandLength));

        return (result, leftOperandStart);
    }

    private static (double Value, int StartIndex) GetRightOperand(string expression, int operatorIndex)
    {
        int rightOperandStart = operatorIndex + 1;

        while (rightOperandStart < expression.Length && char.IsDigit(expression[rightOperandStart]))
            rightOperandStart++;

        int rightOperandLength = rightOperandStart - operatorIndex - 1;
        _ = double.TryParse(expression.Substring(operatorIndex + 1, rightOperandLength), out double result);

        return (result, rightOperandStart);
    }

    private static double EvaluateBasicOperations(string expression)
    {
        double result = 0;
        char @operator = '+';

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '+' || expression[i] == '-')
                @operator = expression[i];
            else
            {
                int operandStart = i;

                while (i < expression.Length && char.IsDigit(expression[i]))
                    i++;

                int operandLength = i - operandStart;
                double operand = double.Parse(expression.Substring(operandStart, operandLength));

                if (@operator == '+')
                    result += operand;
                else // subtraction
                    result -= operand;

                i--;
            }
        }

        return result;
    }
}
