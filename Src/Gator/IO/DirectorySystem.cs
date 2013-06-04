using System.IO;

namespace Gator.IO
{
    public class DirectorySystem : IDirectory
    {
        public void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void Remove(string path)
        {
            Directory.Delete(path);
        }

        public void RemoveRecursive(string path)
        {
            Directory.Delete(path, true);
        }

        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}