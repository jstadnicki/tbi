namespace ToBeImplemented.Service.Implementations.Tests
{
    using System;

    using NUnit.Framework;

    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    [TestFixture]
    public class UserPasswordHasherTests : TbiBaseTest
    {
        private IUserPasswordHasher sut;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.sut = new Md5UserPasswordHasher();
        }


        [Test]
        public void T()
        {
            // arrange
            var viewModel = RegisterUserViewModelFactory.CreateValid();
            var now = new DateTime(2000, 1, 1);
            // arrange-mock

            // act
            var result = this.sut.GetHash(viewModel.Password, now.ToFileTime().ToString());

            // assert
            Assert.AreEqual("71AFE53FAE9005A2931929C6DE0EE7D0", result);

            // assert-mock
        }
    }
}