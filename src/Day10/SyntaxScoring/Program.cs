using SyntaxScoring;

var lines = File.ReadAllLines("input.txt");

var illegalCharScore = lines.Sum(SyntaxParser.GetIllegalLineScore);

Console.WriteLine($"The score is: {illegalCharScore}");

var autoCompleteScores =
    (from line in lines
        where !SyntaxParser.IsIllegalLine(line)
        select SyntaxParser.GetAutoCompleteLineScore(line)).ToList();

autoCompleteScores.Sort();

Console.WriteLine($"The middle autocomplete score is: {autoCompleteScores[autoCompleteScores.Count/2]}");