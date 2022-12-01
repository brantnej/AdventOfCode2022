IEnumerable<string> Lines = File.ReadAllLines("Input.txt");

//Part 1
int max = 0;
int runningSum = 0;
foreach (string line in Lines)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        runningSum += int.Parse(line);
    }
    else
    {
        if (runningSum > max)
        {
            max = runningSum;
        }
        runningSum = 0;
    }
}
Console.WriteLine(max);

//Part 2
IEnumerable<int> sums = new List<int>();
runningSum = 0;
foreach (string line in Lines)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        runningSum += int.Parse(line);
    }
    else
    {
        sums = sums.Append(runningSum);
        runningSum = 0;
    }
}
sums = sums.OrderByDescending(i => i);
Console.WriteLine(Enumerable.Range(0,3).Select(x => sums.ElementAt(x)).Sum());