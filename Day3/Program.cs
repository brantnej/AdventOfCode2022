IEnumerable<string> Lines = File.ReadAllLines("Input.txt");

//Part 1
int sum = 0;
foreach (var line in Lines)
{
    var compartment1 = line.Substring(0, line.Length / 2);
    var compartment2 = line.Substring(line.Length/2);
    foreach (char item in compartment1.Intersect(compartment2))
    {
        if (item <= 'Z')
        {
            sum += (int)item - 38;
        }
        else
        {
            sum += (int)item - 96;
        }
    }
}
Console.WriteLine(sum);

//Part 2
sum = 0;
for (int i = 0; i < Lines.Count(); i+= 3)
{
    char item = Lines.ElementAt(i)
        .Intersect(Lines.ElementAt(i + 1))
        .Intersect(Lines.ElementAt(i + 2))
        .First();
    if (item <= 'Z')
    {
        sum += (int)item - 38;
    }
    else
    {
        sum += (int)item - 96;
    }
}
Console.WriteLine(sum);