using AdventOfCodeCommon;

namespace DumboOctopus;

public class OctopusGrid
{
    private readonly Octopus[,] map;

    public int Flashes { get; private set; }

    public OctopusGrid(string fileName)
    {
        var strings = File.ReadAllLines(fileName);

        var width = strings[0].ToCharArray().Length;
        var height = strings.Length;

        map = new Octopus[height, width];

        for (var h = 0; h < height; h++)
        {
            var points = strings[h].ToCharArray();
            for (var w = 0; w < width; w++)
            {
                var energy = (int) char.GetNumericValue(points[w]);
                map[h, w] = new Octopus(energy, (h, w));
            }
        }
    }

    public void DoStep()
    {
        for (var h = 0; h < map.GetLength(0); h++)
        for (var w = 0; w < map.GetLength(1); w++)
            IncreaseOctopus(map[h, w]);

        for (var h = 0; h < map.GetLength(0); h++)
        for (var w = 0; w < map.GetLength(1); w++)
            map[h, w].Reset();
    }

    private void IncreaseOctopus(Octopus octopus)
    {
        if (!octopus.IncreaseEnergy()) return;

        Flashes++;

        var neighbors = map.GetNeighborsWithDiagonals(octopus.Position.H, octopus.Position.W);

        foreach (var neighbor in neighbors)
            if (neighbor != null)
                IncreaseOctopus(neighbor);
    }
}
