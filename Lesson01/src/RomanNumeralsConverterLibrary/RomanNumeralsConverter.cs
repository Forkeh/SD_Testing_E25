namespace RomanNumeralsConverterLibrary;

public class RomanNumeralsConverter
{
    private static readonly Dictionary<char, int> RomanValues = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    private static readonly HashSet<char> RepeatableNumerals = ['I', 'X', 'C', 'M'];
    private static readonly HashSet<char> NonRepeatableNumerals = ['V', 'L', 'D'];
    private static readonly HashSet<char> SubtractiveNumerals = ['I', 'X', 'C'];

    public int ConvertToDecimal(string romanNumeral)
    {
        if (string.IsNullOrEmpty(romanNumeral))
        {
            throw new ArgumentException("Roman numeral cannot be null or empty");
        }

        romanNumeral = romanNumeral.ToUpper();
        ValidateRomanNumeral(romanNumeral);

        var result = 0;

        for (var i = 0; i < romanNumeral.Length; i++)
        {
            var currentValue = RomanValues[romanNumeral[i]];

            if (i < romanNumeral.Length - 1)
            {
                var nextValue = RomanValues[romanNumeral[i + 1]];

                if (currentValue < nextValue)
                {
                    result += nextValue - currentValue;
                    i++; // Skip the next character as we've processed it
                    continue;
                }
            }

            result += currentValue;
        }

        if (result > 3999)
        {
            throw new ArgumentException("Roman numeral exceeds maximum value of 3999");
        }

        return result;
    }

    private void ValidateRomanNumeral(string romanNumeral)
    {
        for (var i = 0; i < romanNumeral.Length; i++)
        {
            var current = romanNumeral[i];

            if (!RomanValues.ContainsKey(current))
            {
                throw new ArgumentException($"Invalid Roman numeral character: {current}");
            }

            // Check for consecutive repetitions
            var consecutiveCount = 1;
            for (var j = i + 1; j < romanNumeral.Length && romanNumeral[j] == current; j++)
            {
                consecutiveCount++;
            }

            // V, L, D cannot be repeated
            if (NonRepeatableNumerals.Contains(current) && consecutiveCount > 1)
            {
                throw new ArgumentException($"Character '{current}' cannot be repeated.");
            }

            // I, X, C, M can be repeated up to 3 times
            if (RepeatableNumerals.Contains(current) && consecutiveCount > 3)
            {
                throw new ArgumentException($"Character '{current}' cannot be repeated more than 3 times");
            }

            // Check subtractive numeral rules
            if (i < romanNumeral.Length - 1)
            {
                var next = romanNumeral[i + 1];

                if (RomanValues[current] < RomanValues[next])
                {
                    if (!SubtractiveNumerals.Contains(current))
                    {
                        throw new ArgumentException($"Character '{current}' cannot be used as a subtractive numeral");
                    }

                    // Check valid subtractive combinations
                    if ((current == 'I' && next != 'V' && next != 'X') ||
                        (current == 'X' && next != 'L' && next != 'C') ||
                        (current == 'C' && next != 'D' && next != 'M'))
                    {
                        throw new ArgumentException($"Invalid subtractive combination: {current}{next}");
                    }
                }
            }
        }
    }
}