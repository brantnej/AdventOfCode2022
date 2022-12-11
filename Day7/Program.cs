using Day7;
using Directory = Day7.Directory;
using File = Day7.File;

int TotalSizeOfDirectoriesSmallerThan100000 = 0;

//For part 2
IEnumerable<int> AllDirectorySizes = new List<int>();

int FindSize(Directory d)
{
    d.Size = d.Files.Select(f => f.Size).Sum();
    foreach (var subdirectory in d.Subdirectories)
    {
        d.Size += FindSize(subdirectory);
    }
    if (d.Size < 100000) TotalSizeOfDirectoriesSmallerThan100000 += d.Size;
    AllDirectorySizes = AllDirectorySizes.Append(d.Size);
    return d.Size;
}

List<string> Lines = System.IO.File.ReadAllLines("Input.txt").ToList();
Directory root = new Directory("/");
Directory current = root;

for (int i = 0; i < Lines.Count; i++)
{
    string[] command = Lines[i].Split(' ');
    //command
    if (string.Compare("$", command[0]) == 0)
    {
        if (string.Compare("cd", command[1]) == 0)
        {
            if (string.Compare("/", command[2]) == 0)
            {
                current = root;
            }
            else if (string.Compare("..", command[2]) == 0)
            {
                current = current.Parent;
            }
            else
            {
                if (!current.Subdirectories.Any(d => string.Compare(d.Name, command[2]) == 0))
                {
                    current.Subdirectories= current.Subdirectories.Append(new Directory(command[2], current));
                }
                current = current.Subdirectories.First(d => string.Compare(d.Name, command[2]) == 0);
            }
        }
    }
    else
    {
        if (string.Compare("dir", command[0]) == 0)
        {
            if (current.Subdirectories.Any(d => string.Compare(d.Name, command[1]) == 0))
            {
                continue;
            }
            else
            {
                current.Subdirectories = current.Subdirectories.Append(new Directory(command[1], current));
            }
        }
        else
        {
            current.Files = current.Files.Append(new File
            {
                Name = command[1],
                Size = int.Parse(command[0])
            });
        }
    }
}
FindSize(root);
Console.WriteLine(TotalSizeOfDirectoriesSmallerThan100000);

//part 2
int requiredDeletion = 30000000 - (70000000 - root.Size);
Console.WriteLine(AllDirectorySizes.Where(d => d > requiredDeletion).OrderByDescending(a => a).Last());