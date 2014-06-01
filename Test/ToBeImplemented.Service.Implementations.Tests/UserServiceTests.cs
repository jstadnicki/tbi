namespace ToBeImplemented.Service.Implementations.Tests
{
    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    [TestFixture]
    public class UserServiceTests : TbiBaseTest
    {
        private IUserService sut;

        private Mock<IUserRepository> mockUserRepository;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockUserRepository = new Mock<IUserRepository>();
            this.sut = new UserService(this.mockUserRepository.Object);
        }


        [Test]
        public void T001_RegisterUser_Must_Pass_Value_To_Underlying_Repository()
        {
            // arrange
            var registerModel = RegisterUserModelFactory.CreateValid();

            // arrange-mock
            this.mockUserRepository.Setup(s => s.RegisterUser(It.IsAny<RegisterUser>())).Verifiable();

            // act
            this.sut.RegisterUser(registerModel);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(x => x.RegisterUser(It.IsAny<RegisterUser>()), Times.Once);
        }


        [Test]
        public void T002_RegisterUser_After_Successful_Register_Operation_Must_Read_User_From_Repository_Using_Id_From_Prev_Operation()
        {
            // arrange
            var registerModel = RegisterUserModelFactory.CreateValid();
            var userModel = UserModelFactory.Create();
            userModel.Id = 4;

            // arrange-mock
            this.mockUserRepository.Setup(s => s.RegisterUser(It.IsAny<RegisterUser>())).Returns(4);
            this.mockUserRepository.Setup(s => s.GetUser(It.IsAny<long>())).Returns(userModel);

            // act
            var result = this.sut.RegisterUser(registerModel);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(User), result.GetType());


            // assert-mock
            this.mockUserRepository.Verify(v => v.GetUser(It.Is<long>(r => r == 4)), Times.Once);
        }
    }
}