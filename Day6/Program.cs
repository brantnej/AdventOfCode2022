List<string> Lines = File.ReadAllLines("Input.txt").ToList<string>();

int findStart(int requiredUniques, string line)
{
    for (int i = requiredUniques - 1; i < line.Length; i++)
    {
        HashSet<char> chars = new HashSet<char>();
        for (int j = 0; j < requiredUniques; j++)
        {
            chars.Add(line[i - j]);
        }
        if (chars.Count() == requiredUniques)
        {
            return i + 1;
        }
    }
    return 0;
}

string line = Lines.First();
Console.WriteLine(findStart(4, line));
Console.WriteLine(findStart(14, line));