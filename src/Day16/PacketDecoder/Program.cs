using PacketDecoder;

var hexString = File.ReadAllText("input.txt");

var packet = Decoder.Decode(hexString);

Console.WriteLine($"The Version Sum of the BITS Transmission is: {packet.GetVersionSum()}");
Console.WriteLine($"The Value of the BITS Transmission is: {packet.GetValue()}");
