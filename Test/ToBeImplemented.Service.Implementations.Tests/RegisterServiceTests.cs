namespace ToBeImplemented.Service.Implementations.Tests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    [TestFixture]
    public class RegisterServiceTests : TbiBaseTest
    {
        private Mock<IUserPasswordStore<User, long>> mockUserStore;
        private IRegisterService sut;

        public override void Once()
        {
            TbiMapper.Initialize();
        }

        public override void OncePerTest()
        {
            this.mockUserStore = new Mock<IUserPasswordStore<User, long>>();
            this.sut = new UserService(this.mockUserStore.Object);
        }


        [Test]
        public void T001_Register_Must_Validate_Password_And_User_Hash_Password_()
        {
            // arrange
            var model = RegisterUserModelFactory.CreateValid();

            var mockPasswordValidator = new Mock<IIdentityValidator<string>>();
            var mockPasswordHasher = new Mock<IPasswordHasher>();
            var mockUserValidator = new Mock<IIdentityValidator<User>>();

            (sut as UserService).PasswordValidator = mockPasswordValidator.Object;
            (sut as UserService).PasswordHasher = mockPasswordHasher.Object;
            (sut as UserService).UserValidator = mockUserValidator.Object;

            // arrange-mock
            mockPasswordValidator.Setup(s => s.ValidateAsync(It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            mockPasswordHasher.Setup(s => s.HashPassword(It.IsAny<string>())).Returns("hashed");
            mockUserValidator.Setup(s => s.ValidateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);


            this.mockUserStore.Setup(s => s.CreateAsync(It.IsAny<User>())).Returns<User>(
                x =>
                {
                    x.Id = 444;
                    return Task.FromResult(x);
                });

            this.mockUserStore.Setup(s => s.SetPasswordHashAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Callback<User, string>((u, s) => u.PasswordHash = s)
                .Returns(Task.FromResult(IdentityResult.Success));

            // act
            var result = this.sut.RegisterUser(model);

            // assert
            Assert.AreEqual(444, result);

            // assert-mock
            this.mockUserStore.Verify(v => v.CreateAsync(It.Is<User>(vv => vv.PasswordHash == "hashed")), Times.Once);

        }
    }
}