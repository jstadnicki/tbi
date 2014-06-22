namespace ToBeImplemented.Business.Implementations.Tests
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.Owin.Security;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    [TestFixture]
    public class LoginLogicTests : TbiBaseTest
    {
        private Mock<ILoginService> mockLoginService;
        private ILoginLogic sut;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockLoginService = new Mock<ILoginService>();
            this.sut = new LoginLogic(this.mockLoginService.Object);
        }


        [Test]
        public void T001_CreateLoginViewModel_Must_Create_Valid_Empty_View_Model()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.GetLoginViewModel();

            // assert
            Assert.True(result.Success);
            Assert.AreEqual(typeof(LoginViewModel), result.Data.GetType());
            Assert.True(string.IsNullOrEmpty(result.Data.Password));
            Assert.True(string.IsNullOrEmpty(result.Data.UserName));
            Assert.AreEqual(false, result.Data.RememberMe);

            // assert-mock
        }


        [Test]
        public void T002_Login_Must_Call_Service_For_User_Indentity()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();
            var mockAuthenticationManager = new Mock<IAuthenticationManager>();

            // arrange-mock
            this.mockLoginService.Setup(s => s.GetUserIndentity(It.IsAny<LoginViewModel>()))
                .Returns(Task<ClaimsIdentity>.Run(() => new ClaimsIdentity()));

            // act
            var result = this.sut.Login(model, mockAuthenticationManager.Object);

            // assert
            Assert.True(result.Success);

            // assert-mock
            this.mockLoginService.Verify(v => v.GetUserIndentity(It.IsAny<LoginViewModel>()), Times.Once);
        }


        [Test]
        public void T003_Login_When_Claim_Is_Found_Must_SignIn_The_User()
        {
            // arrange
            var model = LoginViewModelFactory.CreateValid();
            var mockAuthenticationManager = new Mock<IAuthenticationManager>();

            // arrange-mock
            this.mockLoginService.Setup(s => s.GetUserIndentity(It.IsAny<LoginViewModel>()))
                .Returns(Task<ClaimsIdentity>.Run(() => new ClaimsIdentity()));

            // arrange-mock

            // act
            var result = this.sut.Login(model, mockAuthenticationManager.Object);

            // assert
            Assert.True(result.Success);

            // assert-mock
            mockAuthenticationManager.Verify(v => v.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()), Times.Once);
        }


        [Test]
        public void T004_Logout_Must_Call_Authentication_Signout_And_Return_Success()
        {
            // arrange
            var mockAuthenticationManager = new Mock<IAuthenticationManager>();

            // arrange-mock
            mockAuthenticationManager.Setup(s => s.SignOut(It.IsAny<string[]>())).Verifiable();

            // act
            var result = this.sut.LogOut(mockAuthenticationManager.Object);

            // assert
            Assert.True(result.Success);

            // assert-mock
            mockAuthenticationManager.Verify(v => v.SignOut(It.IsAny<string[]>()), Times.Once);
        }
    }
}