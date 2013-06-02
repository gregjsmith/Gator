using NUnit.Framework;

namespace Gator.Tests
{
    public class When_handling_arguments
    {
        [Test]
        public void When_none_then_help()
        {
            var cmd = "".Split(' ').Handle();

            Assert.IsInstanceOf<Help>(cmd);
        }


        [Test]
        public void When_only_is_init_then_initialize()
        {
            var cmd = "init".Split(' ').Handle();

            Assert.IsInstanceOf<Initialize>(cmd);
        }

        [Test]
        public void When_only_is_help_then_help()
        {
            var cmd = "help".Split(' ').Handle();

            Assert.IsInstanceOf<Help>(cmd);
        }

        [Test]
        public void When_only_is_make_then_makehelp()
        {
            var cmd = "make".Split(' ').Handle();

            Assert.IsInstanceOf<MakeHelp>(cmd);
        }

        [Test]
        public void When_make_plus_name_then_make()
        {
            var cmd = "make version1".Split(' ').Handle();

            Assert.IsInstanceOf<Make>(cmd);
        }
    }
}
