IEnumerable<string> Lines = File.ReadAllLines("Input.txt");

//Part 1
int sum = 0;
foreach (var line in Lines)
{
    var l = line.Split(',');
    var x = l[0].Split('-');
    var y = l[1].Split('-');
    var idx0 = int.Parse(x[0]);
    var idx1 = int.Parse(x[1]);
    var idx2 = int.Parse(y[0]);
    var idx3 = int.Parse(y[1]);
    if (idx0 >= idx2 && idx1 <= idx3) sum++;
    else if (idx2 >= idx0 && idx3 <= idx1) sum++;
}
Console.WriteLine(sum);

//Part 2
sum = 0;
foreach (var line in Lines)
{
    var l = line.Split(',');
    var x = l[0].Split('-');
    var y = l[1].Split('-');
    var idx0 = int.Parse(x[0]);
    var idx1 = int.Parse(x[1]);
    var idx2 = int.Parse(y[0]);
    var idx3 = int.Parse(y[1]);
    if (idx0 >= idx2 && idx0 <= idx3) sum++;
    else if (idx2 >= idx0 && idx2 <= idx1) sum++;
}
Console.WriteLine(sum);