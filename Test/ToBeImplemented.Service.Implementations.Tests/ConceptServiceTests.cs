namespace ToBeImplemented.Service.Implementations.Tests
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers;

    [TestFixture]
    public class ConceptServiceTests : TbiBaseTest
    {
        private IConceptService sut;

        private Mock<IConceptRepository> mockConceptRepository;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockConceptRepository = new Mock<IConceptRepository>();
            this.sut = new ConceptService(this.mockConceptRepository.Object);

        }

        [Test]
        public void T001_GetAllConceptsWithAllCollections_Must_Call_Repository_To_Read_All_Data_And_Return_The_Result()
        {
            // arrange
            var concepts = ConceptModelFactory.CreateFull(4);

            // arrange-mock
            this.mockConceptRepository.Setup(x => x.GetAllConceptsWithAllCollections()).Returns(concepts);

            // act
            var result = this.sut.GetAllConceptsWithAllCollections();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.NotNull(result.ElementAt(3).Author);
            Assert.NotNull(result.ElementAt(3).Comments);
            Assert.NotNull(result.ElementAt(3).Tags);

            // assert-mock
            this.mockConceptRepository.Verify(x => x.GetAllConceptsWithAllCollections(), Times.Once);
        }
    }
}
