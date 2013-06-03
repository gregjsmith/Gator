using System;

namespace Gator
{
    public static class Extensions
    {
        public static IGatorCommand Handle(this string[] args)
        {
            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                return new Help();
            }


            if (args.Length == 1 && args[0] == "help")
            {
                return new Help();
            }


            if (args.Length == 1 && args[0] == "init")
            {
                return CommandFactory.InitialiseCommand();
            }


            if (args.Length == 1 && args[0] == "make")
            {
                return new MakeHelp();
            }

            if (args.Length == 2 && args[0] == "make")
            {
                return CommandFactory.MakeCommand(args);
            }

            throw new InvalidOperationException("Arguments -- " + string.Join(" ", args) + " are not valid");
        }
    }
}