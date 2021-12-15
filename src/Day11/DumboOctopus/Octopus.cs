namespace DumboOctopus;

public class Octopus
{
    public int EnergyLevel { get; set; }
    public bool HasFlashed { get; set; }

    public (int H, int W) Position { get; set; }

    public Octopus(int energyLevel, (int h, int w) position)
    {
        EnergyLevel = energyLevel;
        Position = position;
        HasFlashed = false;
    }

    /// <summary>
    ///     Increases the energy level of this octopus by 1.
    ///     If this increase causes the octopus to flash, true will be returned.
    ///     If the octopus has already flashed, or energy level is too low, false will be returned.
    /// </summary>
    /// <returns>True if this caused the octopus to flash; otherwise false</returns>
    public bool IncreaseEnergy()
    {
        EnergyLevel++;

        if (HasFlashed || EnergyLevel <= 9) return false;

        HasFlashed = true;
        return true;
    }

    public void Reset()
    {
        if (!HasFlashed) return;

        EnergyLevel = 0;
        HasFlashed = false;
    }
}
