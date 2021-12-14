namespace SmokeBasin;

public class LowPoint : Position
{
    public int DangerLevel => Height + 1;

    public LowPoint((int h, int w) location, int height) : base(location, height)
    {
    }
}
