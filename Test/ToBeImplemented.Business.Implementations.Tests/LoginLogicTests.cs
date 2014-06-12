namespace ToBeImplemented.Business.Implementations.Tests
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers;

    public class LoginLogicTests : TbiBaseTest
    {
        private ILoginLogic sut;

        private Mock<ILoginService> mockUserService;

        private Mock<IUserPasswordHasher> mockPasswordHasher;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockUserService = new Mock<ILoginService>();
            this.mockPasswordHasher = new Mock<IUserPasswordHasher>();
            this.sut = new LoginLogic(this.mockUserService.Object, this.mockPasswordHasher.Object);
        }

        [Test]
        public void T001_GetLoginViewModel_Must_Return_Empty_View_Model()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.GetLoginViewModel();

            // assert
            Assert.AreEqual(typeof(OperationResult<LoginViewModel>), result.GetType());
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.IsTrue(string.IsNullOrEmpty(result.Data.Login));
            Assert.IsTrue(string.IsNullOrEmpty(result.Data.Password));
            Assert.AreEqual(false, result.Data.RememberMe);

            // assert-mock
        }


        [Test]
        public void T002_Given_Valid_Model_Must_Ask_Service_For_Salt_For_Given_Login_Name()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();

            // arrange-mock
            this.mockUserService.Setup(s => s.GetSaltForUserLogin(It.IsAny<string>())).Verifiable();

            // act
            var result = this.sut.Login(model);

            // assert

            // assert-mock
            this.mockUserService.Verify(v => v.GetSaltForUserLogin(It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void T003_Given_Valid_Model_When_Service_Returns_Failure_When_Retriving_Salt_Must_Not_Create_Hash_And_Return_Failure_With_Error()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();
            var operationResult = OperationResultFactory<string>.CreateNotSuccessful();

            // arrange-mock
            this.mockUserService.Setup(s => s.GetSaltForUserLogin(It.IsAny<string>())).Returns(operationResult);
            this.mockPasswordHasher.Setup(s => s.GetHash(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            // act
            var result = this.sut.Login(model);

            // assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.AreEqual("---Password or login incorrect---", result.Errors.First());

            // assert-mock
            this.mockUserService.Verify(v => v.GetSaltForUserLogin(It.IsAny<string>()), Times.Once);
            this.mockPasswordHasher.Verify(v => v.GetHash(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }



        [Test]
        public void T004_Given_Valid_Model_When_Service_Returns_Salt_For_UserLogin_Must_Create_Hash()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();
            var userServiceResult = OperationResultFactory<string>.CreateSuccesful("test-salt");
            var passwordHashResut = OperationResultFactory<string>.CreateSuccesful("test-hash");

            // arrange-mock
            this.mockUserService.Setup(s => s.GetSaltForUserLogin(It.IsAny<string>())).Returns(userServiceResult);
            this.mockPasswordHasher.Setup(s => s.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns(passwordHashResut.Data);

            // act
            var result = this.sut.Login(model);

            // assert
            Assert.NotNull(result);

            // assert-mock
            this.mockUserService.Verify(v => v.GetSaltForUserLogin(It.IsAny<string>()), Times.Once);
            this.mockPasswordHasher.Verify(v => v.GetHash(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void T005_Given_Valid_Model_When_UserLoginExists_Must_Generate_Hash_And_Fetch_User_From_Service_Based_On_Login_And_Hashed_Password()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();
            var getSaltForUserLoginResult = OperationResultFactory<string>.CreateSuccesful("test-salt");
            var getHashResult = OperationResultFactory<string>.CreateSuccesful("test-hash");

            // arrange-mock
            this.mockUserService.Setup(s => s.GetSaltForUserLogin(It.IsAny<string>())).Returns(getSaltForUserLoginResult);
            this.mockPasswordHasher.Setup(s => s.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns(getHashResult.Data);
            this.mockUserService.Setup(s => s.GetUser(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            // act
            var result = this.sut.Login(model);

            // assert

            // assert-mock
            this.mockUserService.Verify(v => v.GetSaltForUserLogin(It.IsAny<string>()), Times.Once);
            this.mockPasswordHasher.Verify(v => v.GetHash(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            this.mockUserService.Verify(v => v.GetUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void T006_Given_Valid_Model_When_Login_And_Password_Does_Not_Match_Must_Return_Error_Of_PasswordOrLogin_Not_Match()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();
            var getSaltForUserLoginStubResult = OperationResultFactory<string>.CreateSuccesful("test-salt");
            var getHashStubResult = OperationResultFactory<string>.CreateSuccesful("test-hash");
            var getUserStubResult = OperationResultFactory<UserLoginModel>.CreateNotSuccessful();


            // arrange-mock
            this.mockUserService.Setup(s => s.GetSaltForUserLogin(It.IsAny<string>())).Returns(getSaltForUserLoginStubResult);
            this.mockPasswordHasher.Setup(s => s.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns(getHashStubResult.Data);
            this.mockUserService.Setup(s => s.GetUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(getUserStubResult);

            // act
            var result = this.sut.Login(model);

            // assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.AreEqual("---Password or login incorrect---", result.Errors.First());

            // assert-mock
            this.mockUserService.Verify(v => v.GetSaltForUserLogin(It.IsAny<string>()), Times.Once);
            this.mockPasswordHasher.Verify(v => v.GetHash(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            this.mockUserService.Verify(v => v.GetUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}