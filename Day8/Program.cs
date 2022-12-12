using Day8;

List<string> Lines = System.IO.File.ReadAllLines("Input.txt").ToList();
/*
 * make tree struct with tallest left, tallest right, etc.
 * for each tree, set tallest left to tallest left of the left tree, unless left tree is taller, then that one
 * repeat for up, down, right
 * for each tree, check if height is taller than all 4 values, then it is visible
 */

int width = Lines.First().Length;

Tree[,] forest = new Tree[Lines.Count(), width];
for (int i = 0; i < Lines.Count; i++)
{
    for (int j = 0; j < Lines[i].Length; j++)
    {
        forest[i, j] = new Tree()
        {
            Height = int.Parse(Lines[i][j].ToString())
        };
    }
}

//find max left
for (int i = 0; i < Lines.Count; i++)
{
    //For finding visible trees
    int[] lastIndexOfHeight = new int[10];
    for (int j = 0; j < width; j++)
    {
        if (j == 0)
        {
            forest[i, j].VisibleLeft = 0;
            forest[i, j].MaxLeft = -1;
        }
        else
        {
            forest[i, j].MaxLeft = Math.Max(forest[i, j - 1].Height, forest[i, j - 1].MaxLeft);
            forest[i, j].VisibleLeft = j - lastIndexOfHeight.Skip(forest[i, j].Height).Max();
        }
        lastIndexOfHeight[forest[i, j].Height] = j;
    }
}

//find max right
for (int i = 0; i < Lines.Count; i++)
{
    //For finding visible trees
    int[] lastIndexOfHeight = new int[10];
    lastIndexOfHeight = lastIndexOfHeight.Select(i => -1).ToArray();
    for (int j = width - 1; j >= 0; j--)
    {
        if (j == width - 1)
        {
            forest[i, j].MaxRight = -1;
            forest[i, j].VisibleRight = 0;
        }
        else
        {
            forest[i, j].MaxRight = Math.Max(forest[i, j + 1].Height, forest[i, j + 1].MaxRight);

            if (lastIndexOfHeight.Skip(forest[i, j].Height).Count(i => i != -1) == 0)
            {
                forest[i, j].VisibleRight = width - j - 1;
            }
            else
            {
                forest[i, j].VisibleRight = lastIndexOfHeight.Skip(forest[i, j].Height).Where(i => i != -1).Min() - j;
            }
        }
        lastIndexOfHeight[forest[i, j].Height] = j;
    }
}

//find max top
for (int j = 0; j < width; j++)
{
    //For finding visible trees
    int[] lastIndexOfHeight = new int[10];
    for (int i = 0; i < Lines.Count(); i++)
    {
        if (i == 0)
        {
            forest[i, j].MaxTop = -1;
            forest[i, j].VisibleTop = 0;
        }
        else
        {
            forest[i, j].MaxTop = Math.Max(forest[i - 1, j].Height, forest[i - 1, j].MaxTop);
            forest[i, j].VisibleTop = i - lastIndexOfHeight.Skip(forest[i, j].Height).Max();
        }
        lastIndexOfHeight[forest[i, j].Height] = i;
    }
}

//find max bottom
for (int j = 0; j < width; j++)
{
    //For finding visible trees
    int[] lastIndexOfHeight = new int[10];
    lastIndexOfHeight = lastIndexOfHeight.Select(i => -1).ToArray();
    for (int i = Lines.Count() - 1; i >= 0; i--)
    {
        if (i == Lines.Count() - 1)
        {
            forest[i, j].MaxBottom = -1;
            forest[i, j].VisibleBottom = 0;
        }
        else
        {
            forest[i, j].MaxBottom = Math.Max(forest[i + 1, j].Height, forest[i + 1, j].MaxBottom);

            if (lastIndexOfHeight.Skip(forest[i, j].Height).Count(i => i != -1) == 0)
            {
                forest[i, j].VisibleBottom = Lines.Count() - 1 - i;
            }
            else
            {
                forest[i, j].VisibleBottom = lastIndexOfHeight.Skip(forest[i, j].Height).Where(i => i != -1).Min() - i;
            }
        }
        lastIndexOfHeight[forest[i, j].Height] = i;
    }
}

int sumVisible = 0;
int maxScenicScore = 0;
//Find which are visible
for (int i = 0; i < Lines.Count(); i++)
{
    for (int j = 0; j < width; j++)
    {
        Tree current = forest[i, j];
        int SS = current.ScenicScore;
        if (SS > maxScenicScore) maxScenicScore = SS;
        if (current.Height > current.MaxTop) sumVisible++;
        else if (current.Height > current.MaxBottom) sumVisible++;
        else if (current.Height > current.MaxLeft) sumVisible++;
        else if (current.Height > current.MaxRight) sumVisible++;
    }
}

Console.WriteLine(sumVisible);
Console.WriteLine(maxScenicScore);