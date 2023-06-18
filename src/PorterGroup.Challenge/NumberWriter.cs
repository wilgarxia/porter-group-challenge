namespace PorterGroup.Challenge;

public sealed class NumberWriter
{
    private static readonly Dictionary<long, string> Words = new() 
    {
        { 0, "zero"}, { 1, "um" }, { 2, "dois" }, { 3, "três" }, { 4, "quatro" }, { 5, "cinco" }, { 6, "seis" }, 
        { 7, "sete" }, { 8, "oito" }, { 9, "nove" }, { 10, "dez" }, { 11, "onze" }, { 12, "doze" }, { 13, "treze" }, 
        { 14, "quatorze" }, { 15, "quinze" },{ 16, "dezesseis" }, { 17, "dezessete" }, { 18, "dezoito" }, 
        { 19, "dezenove" }
    };

    public static string ConvertToWords(long number) =>

        number is < 0 or > 19 ? throw new ArgumentOutOfRangeException(nameof(number)) : Words[number];
}