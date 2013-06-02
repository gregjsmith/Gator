using System;

namespace Gator
{
    public class Help : IGatorCommand
    {
        public void Execute()
        {
            Console.WriteLine(@"
Gator -- simple-minded db migrator
----------------------------------

commands: 

init: initialise a migrations application at the current working directory



");
        }
    }
}