using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Directory
    {
        public string Name;
        public IEnumerable<Directory> Subdirectories;
        public Directory? Parent;
        public IEnumerable<File> Files;
        public int Size = 0;

        public Directory(string name)
        {
            Subdirectories = new List<Directory>();
            Parent = null;
            Files = new List<File>();
            Name = name;
        }
        public Directory(string name, Directory parent)
        {
            Subdirectories = new List<Directory>();
            Parent = parent;
            Files = new List<File>();
            Name = name;
        }
    };
    public struct File
    {
        public string Name;
        public int Size;
    };

}
