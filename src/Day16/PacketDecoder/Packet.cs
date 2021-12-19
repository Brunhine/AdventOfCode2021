namespace PacketDecoder;

public abstract class Packet
{
    public int Version { get; init; }
    public int Type { get; init; }

    public abstract int GetVersionSum();

    public override string ToString()
    {
        return Convert.ToString(Version, 2).PadLeft(3, '0') + Convert.ToString(Type, 2).PadLeft(3, '0');
    }
}
