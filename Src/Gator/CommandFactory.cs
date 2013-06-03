using Gator.IO;

namespace Gator
{
    public class CommandFactory
    {
        public static IGatorCommand MakeCommand(string[] args)
        {
            return new Make(args, new FileSystem(), new DirectorySystem());
        }

        public static IGatorCommand InitialiseCommand()
        {
             return new Initialize(new FileSystem(), new DirectorySystem());
        }
    }
}