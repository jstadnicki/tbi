namespace ToBeImplemented.Business.Implementations.Tests
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers;

    [TestFixture]
    public class ConceptLogicTests : TbiBaseTest
    {
        private IConceptLogic sut;

        private Mock<IConceptService> mockConceptService;

        public override void Once()
        {
            TbiMapper.Initialize();
        }

        public override void OncePerTest()
        {
            this.mockConceptService = new Mock<IConceptService>();
            this.sut = new ConceptLogic(this.mockConceptService.Object);
        }


        [Test]
        public void T001_List_Must_Fetch_All_Concepts_From_Service_With_All_Navigation_Properties_And_Convert_That_To_View_Models()
        {
            // arrange
            var concepts = ConceptModelFactory.CreateFull(6);

            // arrange-mock
            this.mockConceptService.Setup(s => s.GetAllConceptsWithAllCollections()).Returns(concepts);

            // act
            var result = this.sut.List();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(6, result.Concepts.Count);

            // assert-mock
            this.mockConceptService.Verify(v => v.GetAllConceptsWithAllCollections(), Times.Once);
        }
    }
}
