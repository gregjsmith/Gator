using Gator.Commands;
using NUnit.Framework;

namespace Gator.Tests
{
    public class When_Getting_a_Command
    {
        [Test]
        public void Get_Help_for_blank_Arguments()
        {
            var app = new App();

            app.Boot();

            var help = app.GetCommand("".Split(' '));

            Assert.IsInstanceOf<Help>(help);
        }

        [Test]
        public void Get_Help_for_help()
        {
            var app = new App();

            app.Boot();

            var help = app.GetCommand("help".Split(' '));

            Assert.IsInstanceOf<Help>(help);
        }

        [Test]
        public void Get_Initialize_for_init()
        {
            var app = new App();

            app.Boot();

            var init = app.GetCommand("init".Split(' '));

            Assert.IsInstanceOf<Initialize>(init);
        }

        [Test]
        public void Get_MakeHelp_for_make()
        {
            var app = new App();
            
            app.Boot();

            var help = app.GetCommand("make".Split(' '));

            Assert.IsInstanceOf<MakeHelp>(help);
        }

        [Test]
        public void Get_Make_for_make_plus_name()
        {
            var app = new App();

            app.Boot();

            var make = app.GetCommand("make version1".Split(' '));

            Assert.IsInstanceOf<Make>(make);
        }
        
    }
}