namespace ToBeImplemented.Business.Implementations.Tests
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers;

    [TestFixture]
    public class UsersLogicTests : TbiBaseTest
    {
        private IUsersLogic sut;
        private Mock<ISecurityChallengeProvider> mockSecurityChallengeProvider;
        private Mock<IUserService> mockUserService;

        public override void Once()
        {
            TbiMapper.Initialize();
        }

        public override void OncePerTest()
        {
            this.mockSecurityChallengeProvider = new Mock<ISecurityChallengeProvider>();
            this.mockUserService = new Mock<IUserService>();
            this.sut = new UsersLogic(this.mockSecurityChallengeProvider.Object, this.mockUserService.Object);
        }


        [Test]
        public void T001_CreateRegisterViewModel_Must_Return_Initialized_ViewModel_For_UserRegistration()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.GetRegisterViewModel();

            // assert
            Assert.AreEqual(typeof(BussinesResult<RegisterUserViewModel>), result.GetType());

            // assert-mock
        }


        [Test]
        public void T002_Newly_RegisterUserViewModel_Must_Have_Properties_Initialized()
        {
            // arrange

            // arrange-mock
            this.mockSecurityChallengeProvider.Setup(s => s.GetChallengeInput()).Returns("abc");
            this.mockSecurityChallengeProvider.Setup(s => s.GetChallengeType()).Returns(ChallengeType.CharactersOnly);

            // act
            var result = this.sut.GetRegisterViewModel();

            // assert
            Assert.AreEqual(true, result.Success);
            Assert.NotNull(result.Data.SecurityChallengeText);
            Assert.AreEqual(ChallengeType.CharactersOnly, result.Data.ChallengeType);
            Assert.AreEqual("abc", result.Data.SecurityChallengeText);

            // assert-mock
            this.mockSecurityChallengeProvider.Verify(v => v.GetChallengeInput(), Times.Once);
            this.mockSecurityChallengeProvider.Verify(v => v.GetChallengeType(), Times.Once);
        }


        [Test]
        public void T003_RegisterUser_Must_Call_SecurityProvider_If_Challenge_Result_Is_Correct()
        {
            // arrange
            var rvm = RegisterUserViewModelFactory.CreateValid();

            // arrange-mock
            this.mockSecurityChallengeProvider.Setup(
                s => s.IsChallengeValid(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChallengeType>()))
                .Returns(true);

            // act
            this.sut.RegisterUser(rvm);

            // assert

            // assert-mock
            this.mockSecurityChallengeProvider.Verify(
                v => v.IsChallengeValid(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChallengeType>()),
                Times.Once);
        }

        [Test]
        public void T004_RegisterUser_When_Challenge_Is_Not_Valid_Must_Not_Call_Service_For_Creating_Of_User()
        {
            // arrange
            var rvm = RegisterUserViewModelFactory.CreateValid();

            // arrange-mock
            this.mockSecurityChallengeProvider.Setup(
                s => s.IsChallengeValid(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChallengeType>()))
                .Returns(false);

            // act
            this.sut.RegisterUser(rvm);

            // assert

            // assert-mock
            this.mockUserService.Verify(v => v.RegisterUser(It.IsAny<RegisterUser>()), Times.Never);
            this.mockSecurityChallengeProvider.Verify(
                v => v.IsChallengeValid(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChallengeType>()),
                Times.Once);
        }

        [Test]
        public void T005_RegisterUser_When_Challenge_Is_Not_Valid_Must_Return_Not_Successfull_With_Error_Message()
        {
            // arrange
            var rvm = RegisterUserViewModelFactory.CreateValid();

            // arrange-mock
            this.mockSecurityChallengeProvider.Setup(
                s => s.IsChallengeValid(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChallengeType>()))
                .Returns(false);

            // act
            var result = this.sut.RegisterUser(rvm);

            // assert
            Assert.False(result.Success);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(-1, result.Data);
            Assert.AreEqual("--- security challenge failed ---", result.Errors.First());

            // assert-mock
            this.mockUserService.Verify(v => v.RegisterUser(It.IsAny<RegisterUser>()), Times.Never);
            this.mockSecurityChallengeProvider.Verify(
                v => v.IsChallengeValid(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChallengeType>()),
                Times.Once);
        }

    }
}