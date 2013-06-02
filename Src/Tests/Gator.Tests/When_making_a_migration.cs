using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;

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

        [Test]
        public void The_Version_json_file_will_hold_metadata_about_the_migration()
        {
            Program.Main("make version1".Split(' '));

            var content = File.ReadAllText(App.BaseMigrationsDirectory + "/version1/version.json");

            var cfg = JsonConvert.DeserializeObject<MigrationConfig>(content);

            Assert.IsNotNull(cfg);
        }

        [Test]
        public void Will_not_remake_or_overwrite_if_the_migration_already_exists()
        {
            Program.Main("make version1".Split(' '));

            var content1 = File.ReadAllText(App.BaseMigrationsDirectory + "/version1/version.json");

            Program.Main("make version1".Split(' '));

            var content2 = File.ReadAllText(App.BaseMigrationsDirectory + "/version1/version.json");

            Assert.AreEqual(content1, content2);

        }
        

        [TearDown]
        public void TearDown()
        {
            HardDelete(App.BaseMigrationsDirectory);
        }
    }
}