using TransparentOrigami;

var input = File.ReadAllLines("input.txt");
var paper = new Paper(input);
paper.DoFolds(1);

Console.WriteLine($"After 1 Fold, there are {paper.VisibleDots.Count} visible dots.");
