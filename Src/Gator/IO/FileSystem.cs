using System.IO;

namespace Gator.IO
{
    public class FileSystem : IFile
    {
        public void Create(string path)
        {
            File.Create(path);
        }

        public void CreateWithContent(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public void Remove(string path)
        {
            File.Delete(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}