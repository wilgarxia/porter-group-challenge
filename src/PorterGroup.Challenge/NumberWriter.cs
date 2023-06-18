using System.Text;

namespace PorterGroup.Challenge;

public sealed class NumberWriter
{
    private static readonly Dictionary<long, string> Words = new() 
    {
        { 0, "zero"}, { 1, "um" }, { 2, "dois" }, { 3, "três" }, { 4, "quatro" }, { 5, "cinco" }, { 6, "seis" }, 
        { 7, "sete" }, { 8, "oito" }, { 9, "nove" }, { 10, "dez" }, { 11, "onze" }, { 12, "doze" }, { 13, "treze" }, 
        { 14, "quatorze" }, { 15, "quinze" },{ 16, "dezesseis" }, { 17, "dezessete" }, { 18, "dezoito" }, 
        { 19, "dezenove" }, { 20, "vinte" }, { 30, "trinta" }, { 40, "quarenta" }, { 50, "cinquenta" }, 
        { 60, "sessenta" }, { 70, "setenta" }, { 80, "oitenta" }, { 90, "noventa" }, { 100, "cem" }, 
        { 200, "duzentos" }, { 300, "trezentos" }, { 400, "quatrocentos" }, { 500, "quinhentos" }, 
        { 600, "seiscentos" }, { 700, "setecentos" }, { 800, "oitocentos" }, { 900, "novecentos" }
    };

    private static readonly Dictionary<long, string> PluralWords = new() 
    {
        { 100, "cento" }
    };

    public static string ConvertToWords(long number) 
    {
        if (number < -999 || number > 999)
            throw new ArgumentOutOfRangeException(nameof(number));

        if (0 > number)
            return $"menos {ConvertToWords(Math.Abs(number))}";

        // if (Words.ContainsKey(number))
        //     return Words[number];

        int hundreds = (int)number % 1000;

        return GetHundreds(hundreds);
    }

    private static string GetHundreds(int number)
    {
        if (Words.ContainsKey(number))
            return Words[number];

        int hundreds = number / 100 * 100;
        int tens = number % 100 / 10;
        int ones = number % 10;
        StringBuilder hundredsWords = new();
        
        if (0 == hundreds)
        {
            hundredsWords.Append(GetTens(tens, ones));
            return hundredsWords.ToString();
        }

        if (100 == hundreds)
            hundredsWords.Append(PluralWords[hundreds]);
        else
            hundredsWords.Append(Words[hundreds]);
    
        if (tens > 0 || ones > 0)
        {
            hundredsWords.Append(" e ");
            hundredsWords.Append(GetTens(tens, ones));
        }

        return hundredsWords.ToString();
    }     

    private static string GetTens(int tens, int ones)
    {
        if (0 == tens || 1 == tens)
            return Words[tens * 1 + ones];

        if (0 == ones)
            return Words[tens * 10];

        StringBuilder tensString = new();

        tensString.Append(Words[tens * 10]);
        tensString.Append(" e ");
        tensString.Append(Words[ones]);

        return tensString.ToString();
    }     
}