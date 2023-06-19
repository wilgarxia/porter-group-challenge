namespace PorterGroup.Challenge.Tests;

public class NumberConverterTests
{
    private readonly INumberConverter _sut = new NumberConverter(); 

    [Theory]
    [ClassData(typeof(ConvertToWordsData))]
    public void ConvertToWordsShouldReturnNumberWordsWhenGivenAnIntegerNumber(int number, string expected)
    {
        // Act
        var result = _sut.ToWords(number);

        // Assert
        result.Should().Be(expected);
    }
}

public class ConvertToWordsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {        
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
        yield return new object[] { 60, "sessenta" };
        yield return new object[] { 70, "setenta" };
        yield return new object[] { 80, "oitenta" };
        yield return new object[] { 90, "noventa" };
        yield return new object[] { 100, "cem" };
        yield return new object[] { 101, "cento e um" };
        yield return new object[] { 123, "cento e vinte e três" };
        yield return new object[] { 200, "duzentos" };
        yield return new object[] { 201, "duzentos e um" };
        yield return new object[] { 223, "duzentos e vinte e três" };
        yield return new object[] { 300, "trezentos" };
        yield return new object[] { 400, "quatrocentos" };
        yield return new object[] { 500, "quinhentos" };
        yield return new object[] { 600, "seiscentos" };
        yield return new object[] { 700, "setecentos" };
        yield return new object[] { 800, "oitocentos" };
        yield return new object[] { 900, "novecentos" };
        yield return new object[] { 1_000, "mil" };
        yield return new object[] { 1_001, "mil e um" };
        yield return new object[] { 1_023, "mil e vinte e três" };
        yield return new object[] { 1_100, "mil e cem" };
        yield return new object[] { 1_101, "mil cento e um" };
        yield return new object[] { 1_123, "mil cento e vinte e três" };
        yield return new object[] { 1_200, "mil e duzentos" };
        yield return new object[] { 1_223, "mil duzentos e vinte e três" };
        yield return new object[] { 2_000, "dois mil" };
        yield return new object[] { 2_001, "dois mil e um" };
        yield return new object[] { 2_023, "dois mil e vinte e três" };
        yield return new object[] { 1_000_000, "um milhão" };
        yield return new object[] { 1_000_001, "um milhão e um" };
        yield return new object[] { 1_000_100, "um milhão e cem" };
        yield return new object[] { 1_000_101, "um milhão cento e um" };
        yield return new object[] { 1_001_101, "um milhão mil cento e um" };
        yield return new object[] { 1_101_101, "um milhão cento e um mil cento e um" };
        yield return new object[] { 2_000_000, "dois milhões" };
        yield return new object[] { 2_000_001, "dois milhões e um" };
        yield return new object[] { 2_000_100, "dois milhões e cem" };
        yield return new object[] { 2_000_101, "dois milhões cento e um" };
        yield return new object[] { 2_001_101, "dois milhões mil cento e um" };
        yield return new object[] { 2_101_101, "dois milhões cento e um mil cento e um" };
        yield return new object[] { 857_986, "oitocentos e cinquenta e sete mil novecentos e oitenta e seis" };
        yield return new object[] { 469_937_098, 
            "quatrocentos e sessenta e nove milhões novecentos e trinta e sete mil e noventa e oito" };
        //2_147_483_647
        yield return new object[] {int.MaxValue, 
            "dois bilhões cento e quarenta e sete milhões quatrocentos e oitenta e três mil seiscentos e quarenta e sete" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}