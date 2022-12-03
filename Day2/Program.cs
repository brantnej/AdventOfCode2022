IEnumerable<string> Lines = File.ReadAllLines("Input.txt");

//Part 1
int score = 0;

foreach (var line in Lines)
{
    if (line[2] == 'X')
    {
        score++;
        if (line[0] == 'A') score += 3;
        if (line[0] == 'C') score += 6;
    }
    if (line[2] == 'Y')
    {
        score += 2;
        if (line[0] == 'A') score += 6;
        if (line[0] == 'B') score += 3;
    }
    if (line[2] == 'Z')
    {
        score += 3;
        if (line[0] == 'B') score += 6;
        if (line[0] == 'C') score += 3;
    }
}

Console.WriteLine(score);

//Part 2
score = 0;

foreach (var line in Lines)
{
    if (line[2] == 'X')
    {
        if (line[0] == 'A') score += 3;
        if (line[0] == 'B') score += 1;
        if (line[0] == 'C') score += 2;
    }
    if (line[2] == 'Y')
    {
        score += 3;
        if (line[0] == 'A') score += 1;
        if (line[0] == 'B') score += 2;
        if (line[0] == 'C') score += 3;
    }
    if (line[2] == 'Z')
    {
        score += 6;
        if (line[0] == 'A') score += 2;
        if (line[0] == 'B') score += 3;
        if (line[0] == 'C') score += 1;
    }
}

Console.WriteLine(score);