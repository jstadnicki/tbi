namespace ToBeImplemented.Service.Implementations.Tests
{
    using System;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model;
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


        [Test]
        public void T002_Details_Must_Read_Concept_From_Database_With_All_Navigation_Properties_And_Return_To_Caller()
        {
            // arrange
            var dummyId = 123;
            var concept = ConceptModelFactory.CreateFull(1).Single();

            // arrange-mock
            this.mockConceptRepository.Setup(s => s.Details(It.IsAny<long>())).Returns(concept);

            // act
            var result = this.sut.Details(dummyId);

            // assert
            Assert.AreEqual(typeof(Concept), result.GetType());
            Assert.NotNull(result);
            Assert.NotNull(result.Author);
            Assert.NotNull(result.Tags);
            Assert.NotNull(result.Comments);
            Assert.AreEqual(322, result.Id);
            Assert.AreEqual("test-concept-title", result.Title);
            Assert.AreEqual("test-concept-description", result.Description);
            Assert.AreEqual(new DateTime(2003,4,4), result.Created);
            Assert.AreEqual(new DateTime(2003, 4, 4), result.LastUpdate);
            Assert.AreEqual(33, result.EditCount);
            Assert.AreEqual(44, result.VoteUp);
            Assert.AreEqual(3, result.VoteDown);
            Assert.AreEqual(43, result.DisplayCount);
            Assert.AreEqual(99, result.AuthorId);

            // assert-mock
            this.mockConceptRepository.Verify(v => v.Details(It.IsAny<long>()), Times.Once);
        }
    }
}
