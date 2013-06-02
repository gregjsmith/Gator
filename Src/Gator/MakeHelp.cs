using System;

namespace Gator
{
    public class MakeHelp : IGatorCommand
    {
        public void Execute()
        {
            Console.WriteLine(@"
Help with making a migration.
");
        }
    }
}