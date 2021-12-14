namespace SyntaxScoring;

public static class SyntaxParser
{
    private static readonly List<char> CloseTags = new() {')', ']', '}', '>'};
    private static readonly List<char> OpenTags = new() {'(', '[', '{', '<'};

    public static int GetIllegalLineScore(string rawLine)
    {
        var line = GetCharacterList(rawLine);

        for (var close = 0; close < line.Count; close++)
            if (IsCloseTag(line[close].Char))
                for (var open = close - 1; open >= 0; open--)
                    if (IsOpenTag(line[open].Char) && !line[open].Matched)
                    {
                        if (!TagsMatch(line[open].Char, line[close].Char)) return GetIllegalCharScore(line[close].Char);

                        line[open].MarkMatched();
                        line[close].MarkMatched();
                        break;
                    }

        return 0;
    }
    
    public static long GetAutoCompleteLineScore(string rawLine)
    {
        var line = GetCharacterList(rawLine);
        
        // mark all the matches
        for (int close = 0; close < line.Count; close++)
        {
            if (IsCloseTag(line[close].Char))
            {
                for (int open = close -1; open >= 0; open--)
                {
                    if (IsOpenTag(line[open].Char) && !line[open].Matched)
                    {
                        line[open].MarkMatched();
                        line[close].MarkMatched();
                        break;
                    }
                }
            }
        }

        var closingChars = new List<char>();

        for (int i = line.Count-1; i >= 0; i--)
        {
            if (!line[i].Matched)
            {
                closingChars.Add(GetClosingTag(line[i].Char));
            }
        }

        long score = 0;

        foreach (var closingChar in closingChars)
        {
            score = score * 5;
            score += GetAutocompleteCharScore(closingChar);
        }
        
        return score;
    }

    public static bool IsIllegalLine(string rawLine)
    {
        return GetIllegalLineScore(rawLine) > 0;
    }

    private static List<Character> GetCharacterList(string rawLine)
    {
        return rawLine.ToCharArray().Select(x => new Character(x)).ToList();
    }

    private static bool IsOpenTag(char c)
    {
        return OpenTags.Contains(c);
    }

    private static bool IsCloseTag(char c)
    {
        return CloseTags.Contains(c);
    }

    private static bool TagsMatch(char openTag, char closeTag)
    {
        return openTag switch
        {
            '(' => closeTag == ')',
            '[' => closeTag == ']',
            '{' => closeTag == '}',
            '<' => closeTag == '>',
            _ => false
        };
    }

    private static char GetClosingTag(char c)
    {
        return c switch
        {
            '(' => ')',
            '[' => ']',
            '{' =>  '}',
            '<' =>  '>',
            _ => throw new ArgumentOutOfRangeException(nameof(c))
        };
    }

    private static int GetIllegalCharScore(char c)
    {
        return c switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => throw new ArgumentOutOfRangeException(nameof(c))
        };
    }

    private static int GetAutocompleteCharScore(char c)
    {
        return c switch
        {
            ')' => 1,
            ']' => 2,
            '}' => 3,
            '>' => 4,
            _ => throw new ArgumentOutOfRangeException(nameof(c))
        };
    }

    
}
