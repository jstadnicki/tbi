namespace ToBeImplemented.Business.Implementations.Tests
{
    using System;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Implementations.Tests;

    public class LoginLogicTests : TbiBaseTest
    {
        private ILoginLogic sut;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.sut = new LoginLogic();
        }

        [Test]
        public void T001_GetLoginViewModel_Must_Return_Empty_View_Model()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.GetLoginViewModel();

            // assert
            Assert.AreEqual(typeof(BussinesResult<LoginViewModel>), result.GetType());
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.IsTrue(string.IsNullOrEmpty(result.Data.Login));
            Assert.IsTrue(string.IsNullOrEmpty(result.Data.Password));
            Assert.AreEqual(false, result.Data.RememberMe);

            // assert-mock
        }
    }
}