namespace ExtendedPolymerization;

public class Polymer
{
    public string Template { get; }

    private List<PairInsertionRule> Instructions { get; }

    public string CurrentPolymer { get; set; }

    private Polymer(string template, List<PairInsertionRule> instructions)
    {
        Template = template;
        CurrentPolymer = template;

        Instructions = instructions;
    }

    public static Polymer BuildPolymer(List<string> input)
    {
        var template = input[0];
        var instructions = new List<PairInsertionRule>();

        for (var i = 2; i < input.Count; i++)
        {
            var rule = new PairInsertionRule
            {
                Pair = input[i].Split(" ")[0],
                Insertion = input[i].Split(" ")[2]
            };
            instructions.Add(rule);
        }

        return new Polymer(template, instructions);
    }

    public void DoStep()
    {
        var pairs = GetPairs();

        var polymer = pairs[0][0].ToString();

        foreach (var pair in pairs)
        {
            var instruction = Instructions.Single(i => i.Pair == pair);
            polymer += instruction.Insertion + pair[1];
        }

        CurrentPolymer = polymer;
    }

    public int GetPolymerScore()
    {
        var most = CurrentPolymer.GroupBy(x => x).OrderByDescending(x => x.Count()).First();
        var least = CurrentPolymer.GroupBy(x => x).OrderBy(x => x.Count()).First();

        return most.Count() - least.Count();
    }

    private List<string> GetPairs()
    {
        var pairs = new List<string>();
        for (var i = 0; i < CurrentPolymer.Length - 1; i++) pairs.Add(CurrentPolymer.Substring(i, 2));

        return pairs;
    }
}

public class PairInsertionRule
{
    public string Pair { get; set; }

    public string Insertion { get; set; }
}
