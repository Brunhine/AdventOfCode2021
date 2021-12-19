namespace PacketDecoder;

public class OperatorPacket : Packet
{
    public int LengthTypeId { get; init; }

    public List<Packet> SubPackets { get; set; }

    public OperatorPacket()
    {
        SubPackets = new List<Packet>();
    }

    public override int GetVersionSum()
    {
        return Version + SubPackets.Sum(p => p.GetVersionSum());
    }

    public override string ToString()
    {
        var val = LengthTypeId == 0 ? string.Join("", SubPackets).Length : SubPackets.Count;
        var str = LengthTypeId
                  + Convert.ToString(val, 2).PadLeft(LengthTypeId == 0 ? 15 : 11, '0');
        str = SubPackets.Aggregate(str, (current, packet) => current + packet);
        return base.ToString() + str;
    }
}
