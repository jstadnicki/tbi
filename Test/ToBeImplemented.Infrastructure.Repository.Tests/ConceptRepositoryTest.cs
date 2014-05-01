namespace ToBeImplemented.Infrastructure.Repository.Tests
{
    using System.Linq;

    using Moq;

    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Service.Implementations.Tests;
    using NUnit.Framework;

    using ToBeImplemented.Tests.ObjectMothers;

    [TestFixture]
    public class ConceptRepositoryTest : TbiBaseTest
    {
        private IConceptRepository sut;

        private Mock<ITbiContext> mockContext;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockContext = new Mock<ITbiContext>();
            this.sut = new ConceptRepository(this.mockContext.Object);
        }

        [Test]
        public void T001_GetAllConceptsWithAllCollections_Must_Fetch_Data_From_Context_And_Return_It_From_As_A_List()
        {
            // arrange
            var concepts = ConceptModelFactory.CreateFull(2);

            // arrange-mock
            this.mockContext.Setup(x => x.Concepts).Returns(concepts.AsQueryable());

            // act
            var result = this.sut.GetAllConceptsWithAllCollections();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.NotNull(result.ElementAt(0).Author);
            Assert.NotNull(result.ElementAt(0).Comments);
            Assert.NotNull(result.ElementAt(0).Tags);

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }
    }
}
