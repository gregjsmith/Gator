using System;

namespace Gator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var cmd = args.Handle();

                cmd.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
