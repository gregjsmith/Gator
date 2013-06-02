using System.IO;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_making_a_migration : TestEnvironment
    {
        [Test]
        public void A_migration_directory_is_created()
        {
            Program.Main("make version1".Split(' '));

            var mgdir = Directory.Exists(App.BaseMigrationsDirectory + "/version1");

            Assert.IsTrue(mgdir);
        }

        [Test]
        public void A_version_json_file_is_created()
        {
            Program.Main("make version1".Split(' '));

            var file = File.Exists(App.BaseMigrationsDirectory + "/version1/version.json");

            Assert.IsTrue(file);
        }
        

        [TearDown]
        public void TearDown()
        {
            HardDelete(App.BaseMigrationsDirectory);
        }
    }
}