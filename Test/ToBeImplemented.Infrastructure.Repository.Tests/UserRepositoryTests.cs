namespace ToBeImplemented.Infrastructure.Repository.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    public class UserRepositoryTests : TbiBaseTest
    {
        private IUserRepository sut;

        private Mock<ITbiContext> mockTbiContext;

        public override void Once()
        {
            TbiMapper.Initialize();
        }

        public override void OncePerTest()
        {
            this.mockTbiContext = new Mock<ITbiContext>();
            this.sut = new UserRepository(this.mockTbiContext.Object);
        }


        [Test]
        public void T001_RegisterUser_Must_Insert_New_User_Info_To_Context()
        {
            // arrange
            var registerModel = RegisterUserModelFactory.CreateValid();
            var users = new List<User>().AsQueryable();

            // arrange-mock
            this.mockTbiContext.Setup(s => s.Users.Provider).Returns(users.Provider);
            this.mockTbiContext.Setup(s => s.Users.Expression).Returns(users.Expression);
            this.mockTbiContext.Setup(s => s.Users.ElementType).Returns(users.ElementType);
            this.mockTbiContext.Setup(s => s.Users.GetEnumerator()).Returns(users.GetEnumerator());
            this.mockTbiContext.Setup(s => s.Save()).Verifiable();

            // act
            this.sut.RegisterUser(registerModel);

            // assert

            // assert-mock
            this.mockTbiContext.Verify(v => v.Users.Add(It.IsAny<User>()), Times.Once);
            this.mockTbiContext.Verify(v => v.Save(), Times.Once);
        }

        [Test]
        public void T002_RegisterUser_Must_Insert_New_User_Info_To_Context()
        {
            // arrange
            var registerModel = RegisterUserModelFactory.CreateValid();
            var users = new List<User>().AsQueryable();

            // arrange-mock
            this.mockTbiContext.Setup(s => s.Users.Provider).Returns(users.Provider);
            this.mockTbiContext.Setup(s => s.Users.Expression).Returns(users.Expression);
            this.mockTbiContext.Setup(s => s.Users.ElementType).Returns(users.ElementType);
            this.mockTbiContext.Setup(s => s.Users.GetEnumerator()).Returns(users.GetEnumerator());

            this.mockTbiContext.Setup(s => s.Users.Add(It.IsAny<User>())).Callback<User>(c => c.Id = 55);

            // act
            var result = this.sut.RegisterUser(registerModel);

            // assert
            Assert.AreEqual(55, result);

            // assert-mock
            this.mockTbiContext.Verify(v => v.Users.Add(It.IsAny<User>()), Times.Once);
            this.mockTbiContext.Verify(v => v.Save(), Times.Once);
        }

        [Test]
        public void T003_GetUser_Must_Return_User_From_Repository_That_Matches_The_Given_Id()
        {
            // arrange
            var userModel1 = UserModelFactory.Create();
            var userModel2 = UserModelFactory.Create();

            userModel1.Id = 444;
            userModel2.Id = 433;

            var users = new List<User> { userModel1, userModel2 }.AsQueryable();

            // arrange-mock
            this.mockTbiContext.Setup(s => s.Users.Provider).Returns(users.Provider);
            this.mockTbiContext.Setup(s => s.Users.Expression).Returns(users.Expression);
            this.mockTbiContext.Setup(s => s.Users.ElementType).Returns(users.ElementType);
            this.mockTbiContext.Setup(s => s.Users.GetEnumerator()).Returns(users.GetEnumerator());

            // act
            this.sut.GetUser(433);

            // assert

            // assert-mock
            this.mockTbiContext.Verify(v => v.Users, Times.Once);
        }
    }
}