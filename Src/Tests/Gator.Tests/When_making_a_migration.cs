using System.IO;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_making_a_migration
    {
        [Test]
        public void A_migration_directory_is_created()
        {
            Program.Main("make version1".Split(' '));

            var mgdir = Directory.Exists(App.BaseMigrationsDirectory + "version1");

            Assert.IsTrue(mgdir);
        }
        

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(App.BaseMigrationsDirectory, true);
        }
    }
}