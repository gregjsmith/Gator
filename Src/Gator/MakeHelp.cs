using System;
using Gator.Commands;

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