namespace Gator
{
    public class MakeArgs
    {
        private readonly string[] _args;

        public MakeArgs(string[] args)
        {
            _args = args;
        }

        public string Name { get { return _args[1]; } }
    }
}