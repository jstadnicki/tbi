namespace ToBeImplemented.Service.Implementations.Tests
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    public class LoginServiceTests : TbiBaseTest
    {
        private Mock<IUserPasswordStore<User, long>> mockUserStore;
        private ILoginService sut;
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
        public void T001_GetUser_Must_Pass_Call_To_The_Repository()
        {
            // arrange
            var model = UserModelFactory.Create();
            var mockPasswordHasher = new Mock<IPasswordHasher>();

            // arrange-mock
            (this.sut as UserService).PasswordHasher = mockPasswordHasher.Object;

            this.mockUserStore.Setup(s => s.FindByNameAsync(It.IsAny<string>())).Returns(Task.Run(() => model));

            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<string>()))
               .Returns(() =>PasswordVerificationResult.Success);

            // act
            var result = this.sut.GetUser("test-user-login", "test-user-password");

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(99, result.Id);
            Assert.AreEqual("test-user-display-name", result.DisplayName);
            Assert.AreEqual("test@user.email", result.Email);
            Assert.AreEqual("test-user-login", result.UserName);
            Assert.AreEqual("test-user-password-hash", result.PasswordHash);

            // assert-mock
            this.mockUserStore.Verify(v => v.FindByNameAsync(It.IsAny<string>()));
        }

        [Test]
        public void T002_GetUserIdentity_Must_Fetch_User_From_Db_Check_Password_And_Return_Identity_Based_On_User_Found_In_Db()
        {
            // arrange
            var loginModel = LoginViewModelFactory.CreateValid();
            var userModel = UserModelFactory.Create();
            userModel.UserName = loginModel.UserName;

            var mockClaimsFactory = new Mock<IClaimsIdentityFactory<User, long>>();
            var mockPasswordHasher = new Mock<IPasswordHasher>();

            (this.sut as UserService).ClaimsIdentityFactory = mockClaimsFactory.Object;
            (this.sut as UserService).PasswordHasher = mockPasswordHasher.Object;

            // arrange-mock
            this.mockUserStore.Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task<User>.FromResult(userModel));

            this.mockUserStore.Setup(s => s.GetPasswordHashAsync(It.IsAny<User>()))
                .Returns(Task<string>.FromResult(userModel.PasswordHash));

            mockClaimsFactory.Setup(
                s => s.CreateAsync(It.IsAny<UserManager<User, long>>(), It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task<ClaimsIdentity>.FromResult(new ClaimsIdentity()));

            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Success);

            // act
            var result = this.sut.GetUserIndentity(loginModel);
            var r = result.Result;

            // assert
            Assert.NotNull(r);

            // assert-mock
            this.mockUserStore.Verify(v => v.FindByNameAsync(It.IsAny<string>()));
            mockClaimsFactory.Verify(
                v => v.CreateAsync(It.IsAny<UserManager<User, long>>(), It.IsAny<User>(), It.IsAny<string>()),
                Times.Once());
            mockPasswordHasher
                .Verify(v => v.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }
}