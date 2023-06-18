using System.Collections;
using FluentAssertions;

namespace PorterGroup.Challenge.Tests;

public class NumberWriterTests
{
    [Theory]
    [ClassData(typeof(ConvertToWordsData))]
    public void Test1(long number, string expected)
    {
        // Act
        var result = NumberWriter.ConvertToWords(number);

        // Assert
        result.Should().Be(expected);
    }
}

public class ConvertToWordsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 0, "zero" };
        yield return new object[] { 1, "um" };
        yield return new object[] { 2, "dois" };
        yield return new object[] { 3, "três" };
        yield return new object[] { 4, "quatro" };
        yield return new object[] { 5, "cinco" };
        yield return new object[] { 6, "seis" };
        yield return new object[] { 7, "sete" };
        yield return new object[] { 8, "oito" };
        yield return new object[] { 9, "nove" };
        yield return new object[] { 10, "dez" };
        yield return new object[] { 11, "onze" };
        yield return new object[] { 12, "doze" };
        yield return new object[] { 13, "treze" };
        yield return new object[] { 14, "quatorze" };
        yield return new object[] { 15, "quinze" };
        yield return new object[] { 16, "dezesseis" };
        yield return new object[] { 17, "dezessete" };
        yield return new object[] { 18, "dezoito" };
        yield return new object[] { 19, "dezenove" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}