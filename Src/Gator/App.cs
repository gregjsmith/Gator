using System;

namespace Gator
{
    public class App
    {
        public static string WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";

        public static string BaseMigrationsDirectory = WorkingDirectory + @"migrations\";

        public static string DbJsonCfgFile = WorkingDirectory + "database.json";
    }
}