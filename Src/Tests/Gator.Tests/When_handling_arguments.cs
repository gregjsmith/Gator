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
    }
}
