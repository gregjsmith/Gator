namespace Gator
{
    public interface IGatorCommand
    {
        string[] Args { set; }
        void Execute();
    }
}