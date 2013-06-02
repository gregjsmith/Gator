using System;

namespace Gator
{
    public static class Extensions
    {
        public static IGatorCommand Handle(this string[] args)
        {
            if (args.Length == 1 && args[0] == "init")
            {
                return new Initialize();
            }

            throw new InvalidOperationException("Arguments -- " + string.Join(" ", args) + " are not valid");
        }
    }
}