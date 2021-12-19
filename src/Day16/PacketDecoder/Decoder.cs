namespace PacketDecoder;

public static class Decoder
{
    public static Packet Decode(string hexString)
    {
        var binaryString = GetBinaryStringFromHexString(hexString);

        return GetPacket(binaryString);
    }

    private static Packet GetPacket(string binaryString)
    {
        var typeId = GetPacketType(binaryString);

        if (typeId == 4) return GetLiteralValuePacket(binaryString);

        return GetOperatorPacket(binaryString);
    }

    private static LiteralValuePacket GetLiteralValuePacket(string binaryString)
    {
        var packet = new LiteralValuePacket
        {
            Version = GetPacketVersion(binaryString),
            Type = GetPacketType(binaryString),
            NumberGroups = GetNumberGroups(binaryString[6..])
        };

        return packet;
    }

    private static OperatorPacket GetOperatorPacket(string binaryString)
    {
        var packet = new OperatorPacket
        {
            Version = GetPacketVersion(binaryString),
            Type = GetPacketType(binaryString),
            LengthTypeId = BinToInt(binaryString[6].ToString())
        };

        if (packet.LengthTypeId == 0)
        {
            var len = BinToInt(binaryString[7..22]);
            packet.SubPackets = GetSubPacketsByLength(binaryString[22..(22 + len)], len);
        }
        else
        {
            var num = BinToInt(binaryString[7..18]);
            packet.SubPackets = GetSubPacketsByCount(binaryString[18..], num);
        }

        return packet;
    }

    private static List<Packet> GetSubPacketsByCount(string s, int count)
    {
        var packets = new List<Packet>();

        while (packets.Count < count) packets.Add(GetPacket(s[string.Join("", packets).Length..]));

        return packets;
    }

    private static List<Packet> GetSubPacketsByLength(string s, int length)
    {
        var packets = new List<Packet>();

        while (string.Join("", packets).Length < length) packets.Add(GetPacket(s[string.Join("", packets).Length..]));

        return packets;
    }

    private static int GetPacketType(string binaryString)
    {
        return BinToInt(binaryString[3..6]);
    }

    private static int GetPacketVersion(string binaryString)
    {
        return BinToInt(binaryString[..3]);
    }

    private static int BinToInt(string binaryString)
    {
        return Convert.ToInt32(binaryString, 2);
    }

    private static List<string> GetNumberGroups(string s)
    {
        var list = new List<string>();
        var pos = 0;
        while (s.Length - pos >= 5)
        {
            var fiveBits = s[pos..(pos + 5)];
            list.Add(fiveBits[1..]);
            if (fiveBits[0] == '1')
                pos += 5;
            else
                return list;
        }

        return list;
    }

    private static string GetBinaryStringFromHexString(string hexString)
    {
        return string.Join(string.Empty,
            hexString.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
    }
}
