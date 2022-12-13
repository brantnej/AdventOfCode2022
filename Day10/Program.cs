List<string> Lines = System.IO.File.ReadAllLines("Input.txt").ToList();

int cycle = 0;
int X = 1;
int sigStrengthSum = 0;

void incrementSignalSum()
{
    if ((cycle + 20) % 40 == 0)
    {
        sigStrengthSum += cycle * X;
    }
}

foreach (string line in Lines)
{
    cycle++;
    incrementSignalSum();
    var command = line.Split(" ");
    if (string.Equals(command[0], "addx"))
    {
        cycle++;
        incrementSignalSum();
        X += int.Parse(command[1]);
    }
}

Console.WriteLine(sigStrengthSum);

//Part 2
cycle = 0;
X = 1;
char[,] CRT = new char[6, 40];
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 40; j++) CRT[i, j] = ' ';
}
void drawPixel()
{
    int row = (cycle - 1) / 40;
    int col = (cycle - 1) % 40;
    if (Math.Abs(col - X) <= 1)
    {
        CRT[row, col] = '#';
    }
}

foreach (string line in Lines)
{
    cycle++;
    drawPixel();
    var command = line.Split(" ");
    if (string.Equals(command[0], "addx"))
    {
        cycle++;
        drawPixel();
        X += int.Parse(command[1]);
    }
}
for (int i = 0; i <6; i++)
{
    Console.WriteLine(string.Join("", Enumerable.Range(0, 40).Select(x => CRT[i, x]).ToArray()));
}