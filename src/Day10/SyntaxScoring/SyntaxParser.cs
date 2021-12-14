namespace SyntaxScoring;

public static class SyntaxParser
{
    private static readonly List<char> CloseTags = new() {')', ']', '}', '>'};
    private static readonly List<char> OpenTags = new() {'(', '[', '{', '<'};

    public static int GetLineScore(string rawLine)
    {
        var line = rawLine.ToCharArray().Select(x => new Character(x)).ToList();

        for (var close = 0; close < line.Count; close++)
            if (IsCloseTag(line[close].Char))
                for (var open = close - 1; open >= 0; open--)
                    if (IsOpenTag(line[open].Char) && line[open].Matched == false)
                    {
                        if (TagsMatch(line[open].Char, line[close].Char))
                        {
                            line[open].MarkMatched();
                            line[close].MarkMatched();
                            break;
                        }

                        return GetScore(line[close].Char);
                    }

        return 0;
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

    private static int GetScore(char closingTag)
    {
        return closingTag switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => throw new ArgumentOutOfRangeException(nameof(closingTag))
        };
    }
}
