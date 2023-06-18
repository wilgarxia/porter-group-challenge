namespace PorterGroup.Challenge.Tests;

public class NumberWriterTests
{
    [Theory]
    [InlineData(-100)]
    [InlineData(100)]
    public void ConvertToWordsShouldThrowExceptionWhenGivenArgumentIsOutOfRange(int number)
    {
        // Act
        Action act = () => NumberWriter.ConvertToWords(number);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }


    [Theory]
    [ClassData(typeof(ConvertToWordsData))]
    public void ConvertToWordsShouldReturnNumberWordsWhenGivenAnIntegerNumber(long number, string expected)
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
        yield return new object[] { -21, "menos vinte e um" };
        yield return new object[] { -10, "menos dez" };
        yield return new object[] { -1, "menos um" };
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
        yield return new object[] { 20, "vinte" };
        yield return new object[] { 21, "vinte e um" };
        yield return new object[] { 30, "trinta" };
        yield return new object[] { 32, "trinta e dois" };
        yield return new object[] { 40, "quarenta" };
        yield return new object[] { 43, "quarenta e três" };
        yield return new object[] { 50, "cinquenta" };
        yield return new object[] { 54, "cinquenta e quatro" };        
        yield return new object[] { 60, "sessenta" };
        yield return new object[] { 65, "sessenta e cinco" };
        yield return new object[] { 70, "setenta" };
        yield return new object[] { 76, "setenta e seis" };
        yield return new object[] { 80, "oitenta" };
        yield return new object[] { 87, "oitenta e sete" };
        yield return new object[] { 90, "noventa" };
        yield return new object[] { 98, "noventa e oito" };        
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}