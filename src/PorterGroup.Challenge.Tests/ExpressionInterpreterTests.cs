namespace PorterGroup.Challenge.Tests;

public class ExpressionInterpreterTests
{
    [Theory]
    [InlineData("1           +1", 2)]
    [InlineData("2 + 2 - 2", 2)]
    [InlineData("10 - 4 / 2", 8)]
    [InlineData("2 + 3 * 5", 17)]
    [InlineData("4 + 6 * 2 - 8 / 4", 14)]
    [InlineData("0 * 5 + 2", 2)]
    [InlineData("8 - 4 * 2", 0)]
    [InlineData("-2 + 4 * 3", 10)]
    [InlineData("-2 + 2", 0)]
    [InlineData("-22 * ", 0)]
    [InlineData("-5 + ", -5)]
    [InlineData("-5 + +", -5)]
    [InlineData("--5 + +", -5)]
    [InlineData("--5 +     a  +", -5)]
    public void Evaluate_ShouldReturnExpectedResult_WhenGivenAnExpression(string expression, double expectedResult)
    {
        // Act
        var result = ExpressionInterpreter.Evaluate(expression);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("2 / 0")]
    public void Evaluate_ShouldShouldThrowADivideByZeroException_WhenGivenAnExpressionWithADivisionByZero(string expression)
    {
        // Act
        Action act = () => ExpressionInterpreter.Evaluate(expression); ;

        // Assert
        act.Should().Throw<DivideByZeroException>();
    }
}