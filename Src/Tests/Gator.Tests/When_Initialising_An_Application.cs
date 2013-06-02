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

            var fs = File.Exists(App.WorkingDirectory + "database.json");

            Assert.IsTrue(fs);

        }


        [Test]
        public void The_database_json_file_holds_database_level_metadata()
        {
            Program.Main("init".Split(' '));

            var file = File.ReadAllText(App.WorkingDirectory + "database.json");

            var content = JsonConvert.DeserializeObject<DbConfig>(file);

            Assert.IsNotNull(content);
        }

        [Test]
        public void The_metadata_includes_default_values_to_be_updated()
        {
            Program.Main("init".Split(' '));

            var file = File.ReadAllText(App.WorkingDirectory + "database.json");

            var content = JsonConvert.DeserializeObject<DbConfig>(file);

            Assert.AreEqual(content.type, "unspecified");
            Assert.AreEqual(content.currentVersion, "none");
            Assert.AreEqual(content.connectionString, "");
        }

        [Test]
        public void A_Root_versions_directory_is_created_within_the_working_directory()
        {
            Program.Main("init".Split());

            var dir = Directory.Exists(App.WorkingDirectory + "versions");

            Assert.IsTrue(dir);
        }

        [Test]
        public void User_will_get_a_warning_message_if_the_application_has_already_been_initialized()
        {
            Program.Main("init".Split());

            var file = File.Exists(App.WorkingDirectory + "database.json");

            Assert.IsTrue(file);

            try
            {
                Program.Main("init".Split());

                Assert.Fail();

            }
            catch (GatorException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Warning -- Application already exists"));
            }


        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(App.WorkingDirectory + "database.json");
            Directory.Delete(App.WorkingDirectory + "versions");
        }
    }
}
