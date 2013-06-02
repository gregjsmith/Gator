using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Gator.Tests
{
    public class When_Initialising_An_Application
    {

        [Test]
        public void A_Database_json_file_is_created_at_the_application_root_directory()
        {
            Program.Main("init".Split(' '));

            var fs = File.Exists(App.DbJsonCfgFile);

            Assert.IsTrue(fs);

        }


        [Test]
        public void The_database_json_file_holds_database_level_metadata()
        {
            Program.Main("init".Split(' '));

            var file = File.ReadAllText(App.DbJsonCfgFile);

            var content = JsonConvert.DeserializeObject<DbConfig>(file);

            Assert.IsNotNull(content);
        }

        [Test]
        public void The_metadata_includes_default_values_to_be_updated()
        {
            Program.Main("init".Split(' '));

            var file = File.ReadAllText(App.DbJsonCfgFile);

            var content = JsonConvert.DeserializeObject<DbConfig>(file);

            Assert.AreEqual(content.type, "unspecified");
            Assert.AreEqual(content.currentVersion, "0.0.0");
            Assert.AreEqual(content.connectionString, "");
        }

        [Test]
        public void A_Root_versions_directory_is_created_within_the_working_directory()
        {
            Program.Main("init".Split());

            var dir = Directory.Exists(App.BaseMigrationsDirectory);

            Assert.IsTrue(dir);
        }

        [Test]
        public void Application_not_created_Again_when_it_has_already_been_initialized()
        {
            Program.Main("init".Split());

            var file1 = File.ReadAllText(App.DbJsonCfgFile);

            Program.Main("init".Split());

            var file2 = File.ReadAllText(App.DbJsonCfgFile);

            Assert.AreEqual(file1, file2);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(App.DbJsonCfgFile);
            Directory.Delete(App.BaseMigrationsDirectory);
        }
    }
}
