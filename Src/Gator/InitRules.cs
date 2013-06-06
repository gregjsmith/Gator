using System;
using System.Collections;
using System.Collections.Generic;

namespace Gator
{
    public class InitRules : IEnumerable<Func<string[], string>>
    {
        private IEnumerable<Func<string[], string>> Rules()
        {
            Func<string[], string> initOnly = args =>
                {
                    if (args.Length == 1 && args[0] == "init")
                    {
                        return CommandType.Init;
                    }
                    return null;
                };

            return new List<Func<string[], string>>{initOnly};

        }
        public IEnumerator<Func<string[], string>> GetEnumerator()
        {
            return Rules().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}