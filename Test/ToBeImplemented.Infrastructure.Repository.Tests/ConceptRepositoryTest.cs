namespace ToBeImplemented.Infrastructure.Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Moq;

    using ToBeImplemented.Domain.Model;
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
            var concepts = ConceptModelFactory.CreateFull(2).AsQueryable();

            // arrange-mock
            //            this.mockContext.Setup(x => x.Concepts.Provider).Returns(concepts.Provider);
            //            this.mockContext.Setup(x => x.Concepts.Expression).Returns(concepts.Expression);
            //            this.mockContext.Setup(x => x.Concepts.ElementType).Returns(concepts.ElementType);
            this.mockContext.Setup(x => x.Concepts.GetEnumerator()).Returns(concepts.GetEnumerator());

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


        [Test]
        public void T002_Details_Must_Read_From_Repository_With_All_Navigation_Properties_With_Matching_Id()
        {
            // arrange
            var list = new List<Concept>();
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            for (int i = 0; i < 4; i++)
            {
                list[i].Id = i;
            }

            // arrange-mock
            this.mockContext.Setup(x => x.Concepts.Provider).Returns(list.AsQueryable().Provider);
            this.mockContext.Setup(x => x.Concepts.Expression).Returns(list.AsQueryable().Expression);
            this.mockContext.Setup(x => x.Concepts.ElementType).Returns(list.AsQueryable().ElementType);
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(list.AsQueryable().GetEnumerator());

            // act
            var result = this.sut.Details(3);

            // assert
            Assert.AreEqual(typeof(Concept), result.GetType());
            Assert.NotNull(result);
            Assert.NotNull(result.Author);
            Assert.NotNull(result.Tags);
            Assert.NotNull(result.Comments);
            Assert.AreEqual(3, result.Id);
            Assert.AreEqual("test-concept-title", result.Title);
            Assert.AreEqual("test-concept-description", result.Description);
            Assert.AreEqual(new DateTime(2003, 4, 4), result.Created);
            Assert.AreEqual(new DateTime(2003, 4, 4), result.LastUpdate);
            Assert.AreEqual(33, result.EditCount);
            Assert.AreEqual(44, result.VoteUp);
            Assert.AreEqual(3, result.VoteDown);
            Assert.AreEqual(43, result.DisplayCount);
            Assert.AreEqual(99, result.AuthorId);

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }


        [Test]
        public void T003_Add_Must_Save_Model_Into_Repository_And_Return_Saved_Id_Of_Saved_Entity()
        {
            // arrange
            var model = ConceptModelFactory.Create();
            var data = new List<Concept>().AsQueryable();

            // arrange-mock
            this.mockContext.Setup(x => x.Concepts.Provider).Returns(data.AsQueryable().Provider);
            this.mockContext.Setup(x => x.Concepts.Expression).Returns(data.AsQueryable().Expression);
            this.mockContext.Setup(x => x.Concepts.ElementType).Returns(data.AsQueryable().ElementType);
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());

            this.mockContext.Setup(s => s.Concepts.Add(It.IsAny<Concept>())).Callback<Concept>(c => c.Id = 42);

            // act
            var result = this.sut.Add(model);

            // assert
            Assert.AreEqual(42, result);

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
            this.mockContext.Verify(v => v.Save(), Times.Once);
        }


        [Test]
        public void T004_GetConceptTitle_Must_Fetch_Concept_Based_On_Id_And_Select_Title_Only()
        {
            var list = new List<Concept>();
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            for (int i = 0; i < 4; i++)
            {
                list[i].Id = i;
                list[i].Title = string.Format("test-valid-title-{0}", i);
            }

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.Provider).Returns(list.AsQueryable().Provider);
            this.mockContext.Setup(s => s.Concepts.Expression).Returns(list.AsQueryable().Expression);
            this.mockContext.Setup(s => s.Concepts.ElementType).Returns(list.AsQueryable().ElementType);
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(list.AsQueryable().GetEnumerator());

            // act
            var result = this.sut.GetConceptTitle(2);

            // assert
            Assert.AreEqual("test-valid-title-2", result);

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }


        [Test]
        public void T005_Delete_Must_Delete_From_Context_And_Save_Changes()
        {
            // arrange
            var list = new List<Concept>();
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            list.AddRange(ConceptModelFactory.CreateFull(1));
            for (int i = 0; i < 4; i++)
            {
                list[i].Id = i;
                list[i].Title = string.Format("test-valid-title-{0}", i);
            }

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.Provider).Returns(list.AsQueryable().Provider);
            this.mockContext.Setup(s => s.Concepts.Expression).Returns(list.AsQueryable().Expression);
            this.mockContext.Setup(s => s.Concepts.ElementType).Returns(list.AsQueryable().ElementType);
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(list.AsQueryable().GetEnumerator());

            // act
            this.sut.Delete(2);

            // assert

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Exactly(2));
            this.mockContext.Verify(v => v.Save(), Times.Once);
        }
    }
}
