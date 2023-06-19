using System.Numerics;

namespace PorterGroup.Challenge.Tests;

public class ArrayAdderTests
{
    private readonly ArrayAdder _sut = new();

    [Fact]
    public void Sum_ShouldThrowArgumentException_WhenGivenAnIntegerArrayWithOneMillionItensOrMore()
    {
        // Arrange
        int[] array = new int[1_000_000];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 1;
        }

        // Act
        Action act = () => _sut.Sum(array);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("The array must have less than 1 million itens.");
    }

    [Fact]
    public void Sum_ShouldReturnTheSumOfAllItens_WhenGivenAnIntegerArray()
    {
        // Arrange
        int[] array = new int[999_999];
        BigInteger expectedSum = 999_999;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 1;
        }

        // Act
        var result = _sut.Sum(array);

        // Assert
        result.Should().Be(expectedSum);
    }
}