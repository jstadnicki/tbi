namespace ToBeImplemented.Application.TbiDependencyResolver.Tests
{
    using Autofac;

    using NUnit.Framework;

    using ToBeImplemented.Application.Web.Controllers;
    using ToBeImplemented.Application.Web.TbiDependencyResolver;
    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
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
    }
}
