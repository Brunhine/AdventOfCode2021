namespace SyntaxScoring;

internal class Character
{
    public readonly char Char;
    public bool Matched;

    public Character(char c)
    {
        Char = c;
        Matched = false;
    }

    public void MarkMatched()
    {
        Matched = true;
    }
}
