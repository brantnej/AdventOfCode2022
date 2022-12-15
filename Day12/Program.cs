using Day12;

string[] Lines = File.ReadAllLines("Input.txt").ToArray();


IEnumerable<Node> Nodes = new List<Node>();
Node start = new Node();
for (int i = 0; i < Lines.Count(); i++)
{
    for (int j = 0; j < Lines[i].Length; j++)
    {
        Node newNode = new Node()
        {
            XCoord = i,
            YCoord = j
        };
        if (Lines[i][j] == 'E')
        {
            newNode.End = true;
            newNode.Height = 'z';
        }
        else if (Lines[i][j] == 'S')
        {
            newNode.Start = true;
            newNode.Height = 'a';
            start = newNode;
            
        }
        else newNode.Height = Lines[i][j];
        Nodes = Nodes.Append(newNode);
    }
}

int GetDistanceToEnd(Node start)
{
    Queue<Node> queue = new Queue<Node>();
    foreach (var node in Nodes)
    {
        node.Distance = 0;
        node.Visited = false;
    }
    queue.Enqueue(start);
    start.Visited = true;
    while (true)
    {
        if (!queue.Any()) return int.MaxValue;
        Node current = queue.Dequeue();
        if (current.End)
        {
            return current.Distance;
        }
        foreach (var node in Nodes.Where(n => !n.Visited &&
                ((Math.Abs(n.XCoord - current.XCoord) <= 1 && n.YCoord == current.YCoord) ||
                (Math.Abs(n.YCoord - current.YCoord) <= 1 && n.XCoord == current.XCoord)) &&
            n.Height - current.Height <= 1))
        {
            node.Visited = true;
            node.Distance = current.Distance + 1;
            queue.Enqueue(node);
        }
    }
}
Console.WriteLine(GetDistanceToEnd(start));

//part 2
int GetDistanceToFirstA(Node end)
{
    Queue<Node> queue = new Queue<Node>();
    foreach (var node in Nodes)
    {
        node.Distance = 0;
        node.Visited = false;
    }
    queue.Enqueue(end);
    end.Visited = true;
    while (true)
    {
        Node current = queue.Dequeue();
        if (current.Height == 'a')
        {
            return current.Distance;
        }
        foreach (var node in Nodes.Where(n => !n.Visited &&
                ((Math.Abs(n.XCoord - current.XCoord) <= 1 && n.YCoord == current.YCoord) ||
                (Math.Abs(n.YCoord - current.YCoord) <= 1 && n.XCoord == current.XCoord)) &&
            current.Height - n.Height <= 1))
        {
            node.Visited = true;
            node.Distance = current.Distance + 1;
            queue.Enqueue(node);
        }
    }
}

Console.WriteLine(GetDistanceToFirstA(Nodes.First(n => n.End == true)));