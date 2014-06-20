namespace ToBeImplemented.Service.Implementations.Tests
{
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    [TestFixture]
    public class UserServiceTests : TbiBaseTest
    {
        private Mock<IUserPasswordStore<User, long>> mockUserStore;
        private IUserService sut;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockUserStore = new Mock<IUserPasswordStore<User, long>>();
            this.sut = new UserService(this.mockUserStore.Object);
        }


        [Test]
        public void T001_GetUserIdByName_Passes_Call_To_User_Store_And_Returns_Value()
        {
            // arrange
            var user = UserModelFactory.Create();

            // arrange-mock
            this.mockUserStore.Setup(s => s.FindByNameAsync(It.IsAny<string>())).Returns(
                Task<User>.Run(() => user));

            // act
            var result = this.sut.GetUserIdFromUserName("test-user-name");

            // assert
            Assert.AreEqual(99, result);

            // assert-mock
            this.mockUserStore.Verify(v => v.FindByNameAsync(It.IsAny<string>()), Times.Once);
        }
    }
}