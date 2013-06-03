namespace Gator.IO
{
    public interface IFile
    {
        void Create(string path);
        void CreateWithContent(string path, string content);
        void Remove(string path);
        bool Exists(string path);
    }
}