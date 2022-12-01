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
int[] top3 = { 0, 0, 0 };
runningSum = 0;
foreach (string line in Lines)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        runningSum += int.Parse(line);
    }
    else
    {
        if (runningSum > top3.Last())
        {
            top3[2]= runningSum;
        }
        runningSum = 0;
        Array.Sort(top3);
        Array.Reverse(top3);
    }
}
Console.WriteLine(top3.Sum());