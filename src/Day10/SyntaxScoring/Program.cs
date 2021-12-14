using SyntaxScoring;

var lines = File.ReadAllLines("input.txt");

var score = lines.Sum(SyntaxParser.GetLineScore);

Console.WriteLine($"The score is: {score}");
