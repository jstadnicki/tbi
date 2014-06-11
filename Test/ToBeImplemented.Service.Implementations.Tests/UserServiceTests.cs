namespace ToBeImplemented.Service.Implementations.Tests
{
    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Service.Interfaces;

    [TestFixture]
    public class UserServiceTests : TbiBaseTest
    {
        private IRegisterService sut;
        private Mock<IUserRepository> mockUsersRepository;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockUsersRepository = new Mock<IUserRepository>();
            this.sut = new RegisterService(this.mockUsersRepository.Object);
        }


        [Test]
        public void T001_RegisterUser_Must_Pass_Value_To_Underlying_Repository_And_Return_Operation_Result()
        {
            // arrange
            var registerModel = RegisterUserModelFactory.CreateValid();

            // arrange-mock
            this.mockUsersRepository.Setup(s => s.RegisterUser(It.IsAny<RegisterUser>())).Returns(999);

            // act
            var result = this.sut.RegisterUser(registerModel);

            // assert
            Assert.AreEqual(999, result);

            // assert-mock
            this.mockUsersRepository.Verify(x => x.RegisterUser(It.IsAny<RegisterUser>()), Times.Once);
        }
    }
}