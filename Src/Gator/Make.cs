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
            var dir = App.BaseMigrationsDirectory + @"\" + _args.Name;
            Directory.CreateDirectory(dir);

            File.Create(dir + "/version.json");
        }
    }
}