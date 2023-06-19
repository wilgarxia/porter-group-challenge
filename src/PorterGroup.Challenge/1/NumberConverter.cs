using System.Text;

namespace PorterGroup.Challenge;

public sealed class NumberConverter : INumberConverter
{
    public string ToWords(int number) 
    {
        if (number < 0)
            return $"menos {ToWords(Math.Abs(number))}";

        if (CheckPredefinedValues(number) is var result && result.Success)
            return result.Value;

        StringBuilder numberAsWords = new();
        bool appendAnd = false;

        for (byte i = 0; number > 0; i++, number /= 1000)
        {
            int hundreds = number % 1000;
            int thousands = (int)Math.Pow(1000, i);

            if (0 == hundreds)
                continue;
            
            string hundredsChunk = GetHundreds(hundreds);

            if (0 == i) // Hundreds
            {
                numberAsWords.Insert(0, hundredsChunk);
                appendAnd = hundreds <= 100;
                appendAnd = appendAnd || hundreds % 100 == 0;
            }
            else if (i == hundreds && 1 == i) // Thousands
            {
                numberAsWords.Insert(0, $"{ShortScaleWords[thousands]}{(appendAnd ? " e " : " ")}");
                appendAnd = false;
            }
            else // Short Scale
            {
                string shortScaleChunk = 1 == hundreds ? ShortScaleWords[thousands] : ShortScalePluralWords[thousands];
                string finalChunk = appendAnd ? " e " : " ";

                numberAsWords.Insert(0, $"{hundredsChunk} {shortScaleChunk}{finalChunk}");
                appendAnd = false;
            }
        }

        return numberAsWords.ToString().Trim();
    }

    private static (bool Success, string Value) CheckPredefinedValues(int number)
    {
        if (UnitsWords.ContainsKey(number))
            return (true, UnitsWords[number]);

        if (TensWords.ContainsKey(number))
            return (true, TensWords[number]);

        if (HundredsWords.ContainsKey(number))
            return (true, HundredsWords[number]);

        return (false, string.Empty);
    }

    private static string GetHundreds(int number)
    {
        StringBuilder hundredsWords = new();
        int hundreds = number / 100 * 100;
        int tens = number % 100 / 10;
        int ones = number % 10;
        
        if (0 == hundreds)
        {
            hundredsWords.Append(GetTensAndOnes(tens, ones));
            return hundredsWords.ToString();
        }

        if (tens > 0 || ones > 0)
        {
            hundredsWords.Append(100 == hundreds ? "cento" : HundredsWords[hundreds]);
            hundredsWords.Append(" e ");
            hundredsWords.Append(GetTensAndOnes(tens, ones));
        }
        else
            hundredsWords.Append(HundredsWords[hundreds]);

        return hundredsWords.ToString();
    }     

    private static string GetTensAndOnes(int tens, int ones)
    {
        if (0 == tens || 1 == tens)
            return UnitsWords[tens * 1 + ones];

        if (0 == ones)
            return TensWords[tens * 10];

        StringBuilder tensString = new();

        tensString.Append(TensWords[tens * 10]);
        tensString.Append(" e ");
        tensString.Append(UnitsWords[ones]);

        return tensString.ToString();
    }

    private static readonly Dictionary<int, string> UnitsWords = new()
    {
        { 0, "zero"}, 
        { 1, "um" }, 
        { 2, "dois" }, 
        { 3, "três" }, 
        { 4, "quatro" }, 
        { 5, "cinco" }, 
        { 6, "seis" }, 
        { 7, "sete" }, 
        { 8, "oito" }, 
        { 9, "nove" }, 
        { 10, "dez" }, 
        { 11, "onze" }, 
        { 12, "doze" }, 
        { 13, "treze" }, 
        { 14, "quatorze" }, 
        { 15, "quinze" },
        { 16, "dezesseis" }, 
        { 17, "dezessete" }, 
        { 18, "dezoito" }, 
        { 19, "dezenove" }        
    };

    private static readonly Dictionary<int, string> TensWords = new()
    {
        { 20, "vinte" }, 
        { 30, "trinta" }, 
        { 40, "quarenta" }, 
        { 50, "cinquenta" }, 
        { 60, "sessenta" }, 
        { 70, "setenta" }, 
        { 80, "oitenta" }, 
        { 90, "noventa" }
    };

    private static readonly Dictionary<int, string> HundredsWords = new()
    {
        { 100, "cem" }, 
        { 200, "duzentos" }, 
        { 300, "trezentos" }, 
        { 400, "quatrocentos" }, 
        { 500, "quinhentos" }, 
        { 600, "seiscentos" }, 
        { 700, "setecentos" }, 
        { 800, "oitocentos" }, 
        { 900, "novecentos" }
    };
    
    // https://simple.wikipedia.org/wiki/Long_and_short_scales#Short_scale
    private static readonly Dictionary<int, string> ShortScaleWords = new()
    {
        { 1_000, "mil" }, 
        { 1_000_000, "milhão" }, 
        { 1_000_000_000, "bilhão" }
    };

    private static readonly Dictionary<int, string> ShortScalePluralWords = new()
    {
        { 1_000, "mil" }, 
        { 1_000_000, "milhões" }, 
        { 1_000_000_000, "bilhões" }
    };    
}