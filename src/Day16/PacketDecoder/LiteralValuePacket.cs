namespace PacketDecoder;

public class LiteralValuePacket : Packet
{
    public List<string> NumberGroups { get; init; }

    public long NumberValue => Convert.ToInt64(string.Join("", NumberGroups), 2);

    public LiteralValuePacket()
    {
        NumberGroups = new List<string>();
    }

    public override long GetValue()
    {
        return NumberValue;
    }

    public override int GetVersionSum()
    {
        return Version;
    }

    public override string ToString()
    {
        var numGroupString = "";
        for (var i = 0; i < NumberGroups.Count; i++)
        {
            if (i < NumberGroups.Count - 1)
                numGroupString += "1";
            else
                numGroupString += "0";

            numGroupString += NumberGroups[i];
        }

        return base.ToString() + numGroupString;
    }
}
