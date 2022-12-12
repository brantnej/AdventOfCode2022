List<string> Lines = System.IO.File.ReadAllLines("Input.txt").ToList();
HashSet<(int, int)> VisitedLocations = new HashSet<(int, int)>();

(int, int) HeadLocation = (0, 0);
(int, int) TailLocation = (0, 0);

foreach (var line in Lines)
{
    string[] input = line.Split(' ');
    for (int i = 0; i < int.Parse(input[1]); i++)
    {
        if (string.Equals("U", input[0]))
        {
            HeadLocation.Item1 += 1;
        }
        if (string.Equals("D", input[0]))
        {
            HeadLocation.Item1 -= 1;
        }
        if (string.Equals("L", input[0]))
        {
            HeadLocation.Item2 -= 1;
        }
        if (string.Equals("R", input[0]))
        {
            HeadLocation.Item2 += 1;
        }

        //Simulate Tail
        if (Math.Abs(HeadLocation.Item1 - TailLocation.Item1) == 2)
        {
            if (HeadLocation.Item1 > TailLocation.Item1) TailLocation.Item1 += 1;
            else TailLocation.Item1 -= 1;
            TailLocation.Item2 = HeadLocation.Item2;
        }
        if (Math.Abs(HeadLocation.Item2 - TailLocation.Item2) == 2)
        {
            if (HeadLocation.Item2 > TailLocation.Item2) TailLocation.Item2 += 1;
            else TailLocation.Item2 -= 1;
            TailLocation.Item1 = HeadLocation.Item1;
        }
        VisitedLocations.Add(TailLocation);
    }
}
Console.WriteLine(VisitedLocations.Count());

//Part2
(int, int)[] Knots = new (int, int)[10];
HashSet<(int, int)> VisitedLocations2 = new HashSet<(int, int)>();
foreach (var line in Lines)
{
    string[] input = line.Split(' ');
    for (int i = 0; i < int.Parse(input[1]); i++)
    {
        if (string.Equals("U", input[0]))
        {
            Knots[0].Item1 += 1;
        }
        if (string.Equals("D", input[0]))
        {
            Knots[0].Item1 -= 1;
        }
        if (string.Equals("L", input[0]))
        {
            Knots[0].Item2 -= 1;
        }
        if (string.Equals("R", input[0]))
        {
            Knots[0].Item2 += 1;
        }

        for (int j = 1; j < Knots.Length; j++)
        {
            //handle diagonals which weren't possible before
            if (Math.Abs(Knots[j-1].Item1 - Knots[j].Item1) == 2 && (Math.Abs(Knots[j - 1].Item2 - Knots[j].Item2) == 2))
            {
                if (Knots[j - 1].Item1 > Knots[j].Item1) Knots[j].Item1 += 1;
                else Knots[j].Item1 -= 1;
                if (Knots[j - 1].Item2 > Knots[j].Item2) Knots[j].Item2 += 1;
                else Knots[j].Item2 -= 1;
            }
            //Simulate Tail
            if (Math.Abs(Knots[j-1].Item1 - Knots[j].Item1) == 2)
            {
                if (Knots[j - 1].Item1 > Knots[j].Item1) Knots[j].Item1 += 1;
                else Knots[j].Item1 -= 1;
                Knots[j].Item2 = Knots[j - 1].Item2;
            }
            if (Math.Abs(Knots[j - 1].Item2 - Knots[j].Item2) == 2)
            {
                if (Knots[j - 1].Item2 > Knots[j].Item2) Knots[j].Item2 += 1;
                else Knots[j].Item2 -= 1;
                Knots[j].Item1 = Knots[j - 1].Item1;
            }
        }
        VisitedLocations2.Add(Knots[Knots.Length - 1]);
    }
}
Console.WriteLine(VisitedLocations2.Count());