using System.IO;

namespace Gator
{
    public class Make : IGatorCommand
    {
        private MakeArgs _args;

        public Make(string[] args)
        {
            _args = new MakeArgs(args);
        }

        public void Execute()
        {
            Directory.CreateDirectory(App.BaseMigrationsDirectory + _args.Name);
        }
    }
}