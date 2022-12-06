List<string> Lines = File.ReadAllLines("Input.txt").ToList<string>();

//Part 1
Console.WriteLine("Part 1:");
int colsLine = Lines.FindIndex(s => s.StartsWith(" 1"));

int numStacks = int.Parse(Lines.ElementAt(colsLine).Trim().Split(' ').Last());

IEnumerable<Stack<char>> Stacks = new List<Stack<char>>();
for (int i = 0; i < numStacks; i++) Stacks = Stacks.Append(new Stack<char>());

for (int i = colsLine - 1; i >= 0; i--)
{
    string str = Lines.ElementAt(i) + " ";
    IEnumerable<string> crates = Enumerable.Range(0, str.Length / 4).Select(i => str.Substring(i * 4, 4));
    for (int j = 0; j < crates.Count(); j++)
    {
        if (!string.IsNullOrWhiteSpace(crates.ElementAt(j)))
        {
            Stacks.ElementAt(j).Push(crates.ElementAt(j).ElementAt(1));
        }
    }
}

for (int i = colsLine + 2; i < Lines.Count(); i++)
{
    IEnumerable<string> commands = Lines.ElementAt(i).Trim().Split(' ');
    int numberToMove = int.Parse(commands.ElementAt(1));
    int originStack = int.Parse(commands.ElementAt(3)) - 1;
    int targetStack = int.Parse(commands.ElementAt(5)) - 1;
    for (int j = 0; j < numberToMove; j++)
    {
        Stacks.ElementAt(targetStack).Push(Stacks.ElementAt(originStack).Pop());
    }
}

foreach (var stack in Stacks)
{
    Console.Write(stack.Pop());
}

//Part 2
Console.WriteLine("\nPart 2:");
Stacks = new List<Stack<char>>();
for (int i = 0; i < numStacks; i++) Stacks = Stacks.Append(new Stack<char>());

for (int i = colsLine - 1; i >= 0; i--)
{
    string str = Lines.ElementAt(i) + " ";
    IEnumerable<string> crates = Enumerable.Range(0, str.Length / 4).Select(i => str.Substring(i * 4, 4));
    for (int j = 0; j < crates.Count(); j++)
    {
        if (!string.IsNullOrWhiteSpace(crates.ElementAt(j)))
        {
            Stacks.ElementAt(j).Push(crates.ElementAt(j).ElementAt(1));
        }
    }
}

for (int i = colsLine + 2; i < Lines.Count(); i++)
{
    IEnumerable<string> commands = Lines.ElementAt(i).Trim().Split(' ');
    int numberToMove = int.Parse(commands.ElementAt(1));
    int originStack = int.Parse(commands.ElementAt(3)) - 1;
    int targetStack = int.Parse(commands.ElementAt(5)) - 1;
    Stack<char> Temp = new Stack<char>();
    for (int j = 0; j < numberToMove; j++)
    {
        Temp.Push(Stacks.ElementAt(originStack).Pop());
    }
    for (int j = 0; j < numberToMove; j++)
    {
        Stacks.ElementAt(targetStack).Push(Temp.Pop());
    }
}

foreach (var stack in Stacks)
{
    Console.Write(stack.Pop());
}