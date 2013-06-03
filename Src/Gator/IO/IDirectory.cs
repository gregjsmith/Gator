namespace Gator.IO
{
    public interface IDirectory
    {
        void Create(string path);
        void Remove(string path);
        void RemoveRecursive(string path);
        bool Exists(string path);
    }
}