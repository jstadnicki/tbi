namespace ToBeImplemented.Application.TbiDependencyResolver.Tests
{
    using Autofac;

    using NUnit.Framework;

    using ToBeImplemented.Application.Web.Controllers;
    using ToBeImplemented.Application.Web.TbiDependencyResolver;
    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Infrastructure.Adapters;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Service.Interfaces;

    [TestFixture]
    public class TbiDependencyResolverTest : TbiBaseTest
    {
        private IContainer sut;

        public override void Once()
        {
            this.sut = TbiAutofacResolver.Initialize();
        }

        public override void OncePerTest()
        {
            /* empty on purpose */
        }


        [Test]
        public void T001_Registers_ConceptService()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IConceptService>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ConceptService), result.GetType());

            // assert-mock
        }


        [Test]
        public void T002_Registers_Concept_Repository()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IConceptRepository>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ConceptRepository), result.GetType());

            // assert-mock
        }


        [Test]
        public void T003_Registers_ConceptLogic()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IConceptLogic>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ConceptLogic), result.GetType());
            // assert-mock
        }


        [Test]
        public void T004_Registers_Tags_Repository()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<ITagRepository>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(TagRepository), result.GetType());

            // assert-mock
        }


        [Test]
        public void T005_Registers_DateTime_Adapter()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IDateTimeAdapter>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(DateTimeAdapter), result.GetType());

            // assert-mock
        }


        [Test]
        public void T006_Registers_Guid_Adapter()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IGuidAdapter>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(GuidAdapter), result.GetType());

            // assert-mock
        }

        [Test]
        public void T006_Registers_Users_Logic()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IRegisterLogic>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(RegisterLogic), result.GetType());

            // assert-mock
        }

        [Test]
        public void T006_Registers_SecurityChallengeProvider()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<ISecurityChallengeProvider>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(SimpleSecurityChallengeProvider), result.GetType());

            // assert-mock
        }


        [Test]
        public void T007_Registers_UserService()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IRegisterService>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(RegisterService), result.GetType());

            // assert-mock
        }


        [Test]
        public void T008_Registers_UserRepository()
        {
            // arrange

            // arrange-mock

            // act
            var result = sut.Resolve<IUserRepository>();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(UserRepository), result.GetType());

            // assert-mock
        }
    }
}
