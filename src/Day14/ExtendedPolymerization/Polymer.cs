namespace ExtendedPolymerization;

public class Polymer
{
    public string Template { get; }

    private Dictionary<string, string> Rules { get; }

    private Dictionary<string, long> Pairs { get; set; }

    private Polymer(string template, Dictionary<string, string> rules)
    {
        Template = template;
        Rules = rules;
        Pairs = new Dictionary<string, long>();

        for (var i = 0; i < template.Length - 1; i++)
            Pairs[template[i..(i + 2)]] = Pairs.GetValueOrDefault(template[i..(i + 2)]) + 1;
    }

    public static Polymer BuildPolymer(List<string> input)
    {
        var template = input[0];
        var rules = new Dictionary<string, string>();

        for (var i = 2; i < input.Count; i++) rules.Add(input[i][..2], input[i][^1..]);

        return new Polymer(template, rules);
    }

    public void DoStep()
    {
        var newPairs = new Dictionary<string, long>();

        foreach (var (key, value) in Pairs)
        {
            var insert = Rules[key];
            var p1 = key[0] + insert;
            var p2 = insert + key[1];
            newPairs[p1] = newPairs.GetValueOrDefault(p1) + value;
            newPairs[p2] = newPairs.GetValueOrDefault(p2) + value;
        }

        Pairs = newPairs;
    }

    public long GetPolymerScore()
    {
        var letterCount = new Dictionary<char, long>();
        foreach (var (key, value) in Pairs)
        {
            letterCount[key[0]] = letterCount.GetValueOrDefault(key[0]) + value;
            letterCount[key[1]] = letterCount.GetValueOrDefault(key[1]) + value;
        }

        letterCount[Template[0]]++;
        letterCount[Template.Last()]++;

        return (letterCount.Values.Max() - letterCount.Values.Min()) / 2;
    }
}
