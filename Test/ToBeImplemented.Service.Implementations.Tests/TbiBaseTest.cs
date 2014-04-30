namespace ToBeImplemented.Service.Implementations.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public abstract class TbiBaseTest
    {
        [TestFixtureSetUp]
        public abstract void Once();
        
        [SetUp]
        public abstract void OncePerTest();
    }
}