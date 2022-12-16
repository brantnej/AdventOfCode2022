using Day13;

IEnumerable<string> Lines = File.ReadAllLines("Input.txt");

int ComparePacket(Packet left, Packet right)
{
    if (left.IsInteger && right.IsInteger)
    {
        if (left.Value < right.Value) return 1;
        else if (left.Value > right.Value) return -1;
    }
    if (!left.IsInteger && !right.IsInteger)
    {
        for (int i = 0; i < Math.Min(left.Subpackets.Count, right.Subpackets.Count); i++)
        {
            int res = ComparePacket(left.Subpackets[i], right.Subpackets[i]);
            if (res != 0) return res;
        }
        if (left.Subpackets.Count < right.Subpackets.Count) return 1;
        else if (left.Subpackets.Count > right.Subpackets.Count) return -1;
    }
    if (left.IsInteger && !right.IsInteger)
    {
        Packet EncapsulatedLeft = new Packet()
        {
            IsInteger = false,
            Subpackets = new List<Packet>()
                {
                    new Packet()
                    {
                        IsInteger = true,
                        Value = left.Value
                    }
                }
        };
        int res = ComparePacket(EncapsulatedLeft, right);
        if (res != 0) return res;
    }
    else if (!left.IsInteger && right.IsInteger)
    {
        Packet EncapsulatedRight = new Packet()
        {
            IsInteger = false,
            Subpackets = new List<Packet>()
                {
                    new Packet()
                    {
                        IsInteger = true,
                        Value = right.Value
                    }
                }
        };
        int res = ComparePacket(left, EncapsulatedRight);
        if (res != 0) return res;
    }
    return 0;
}

(Packet, int) GeneratePacket(string input, int index)
{
    Packet res = new Packet();
    string number = "";
    while (true)
    {
        if (input[index] == '[')
        {
            (Packet subpacket, index) = GeneratePacket(input, index + 1);
            res.Subpackets.Add(subpacket);
        }
        if (input[index] == ']')
        {
            if (!string.IsNullOrEmpty(number))
            {
                res.Subpackets.Add(new Packet()
                {
                    IsInteger = true,
                    Value = int.Parse(number)
                });
            }
            return (res, index + 1);
        }
        if (input[index] == ',')
        {
            if (!string.IsNullOrEmpty(number))
            {
                res.Subpackets.Add(new Packet()
                {
                    IsInteger = true,
                    Value = int.Parse(number)
                });
                number = "";
            }
        }
        else number += input[index];
        index++;
    }
}

List<Packet> packets = new List<Packet>();
packets.Add(new Packet()
{
    Subpackets = new List<Packet>()
    {
        new Packet()
        {
            IsInteger = true,
            Value = 2
        }
    },
    IsDivider = true
});

packets.Add(new Packet()
{
    Subpackets = new List<Packet>()
    {
        new Packet()
        {
            IsInteger = true,
            Value = 6
        }
    },
    IsDivider = true
});

int index = 1;
int sum = 0;
for (int i = 0; i < Lines.Count(); i += 3)
{
    (Packet left, _) = GeneratePacket(Lines.ElementAt(i), 1);
    (Packet right, _) = GeneratePacket(Lines.ElementAt(i + 1), 1);
    packets.Add(left);
    packets.Add(right);
    if (ComparePacket(left, right) == 1)
    {
        sum += index;
    }
    index++;
}

packets.Sort((p1, p2) => ComparePacket(p2, p1));
var p = packets.IndexOf(packets.First(p => p.IsDivider)) + 1;
var l = packets.IndexOf(packets.Last(p => p.IsDivider)) + 1;
Console.WriteLine(sum);
Console.WriteLine(p * l);