namespace ToBeImplemented.Infrastructure.Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Service.Implementations.Tests;
    using NUnit.Framework;

    using ToBeImplemented.Tests.ObjectMothers.Concepts;

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


        [Test]
        public void T006_GetConceptWithTags_Must_Get_Concept_With_Proper_Id_And_Include_Tags_For_Concept()
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

            var data = list.AsQueryable();

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.Provider).Returns(data.Provider);
            this.mockContext.Setup(s => s.Concepts.Expression).Returns(data.Expression);
            this.mockContext.Setup(s => s.Concepts.ElementType).Returns(data.ElementType);
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(data.GetEnumerator());

            // act
            var result = this.sut.GetConceptWithTags(3);

            // assert
            Assert.NotNull(result);
            Assert.NotNull(result.Tags);
            //            Assert.Null(result.Comments);
            //            Assert.Null(result.Author);
            Assert.AreEqual(3, result.Id);
            Assert.AreEqual(99, result.AuthorId);
            Assert.AreEqual(new DateTime(2003, 4, 4), result.Created);
            Assert.AreEqual("test-concept-description", result.Description);
            Assert.AreEqual(43, result.DisplayCount);
            Assert.AreEqual(33, result.EditCount);
            Assert.AreEqual(new DateTime(2003, 4, 4), result.LastUpdate);
            Assert.AreEqual("test-tag-text", result.Tags.ElementAt(0).Text);
            Assert.AreEqual(1, result.Tags.Count);
            Assert.AreEqual("test-valid-title-3", result.Title);
            Assert.AreEqual(3, result.VoteDown);
            Assert.AreEqual(44, result.VoteUp);


            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }


        [Test]
        public void T007_Save_Must_Passed_Save_Command_To_Context()
        {
            // arrange

            // arrange-mock
            this.mockContext.Setup(s => s.Save()).Verifiable();

            // act
            this.sut.Save();

            // assert

            // assert-mock
            this.mockContext.Verify(v => v.Save(), Times.Once);
        }


        [Test]
        public void T008_ConceptOnly_Calls_To_Context_And_Returns_Return()
        {
            // arrange
            var stub = ConceptModelFactory.CreateFull(3);

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(stub.GetEnumerator());

            // act
            var result = this.sut.ConceptsOnly();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(List<Concept>), result.GetType());

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }


        [Test]
        public void T009_ConceptsWithProperties_Must_Call_For_Concepts_From_Context_And_Ask_For_Additional_Properties_From_Passed_In_Argument_And_Return_Result_()
        {
            // arrange
            var stub = ConceptModelFactory.CreateFull(3).AsQueryable();

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(stub.GetEnumerator());
            this.mockContext.Setup(s => s.Concepts.Provider).Returns(stub.Provider);
            this.mockContext.Setup(s => s.Concepts.Expression).Returns(stub.Expression);
            this.mockContext.Setup(s => s.Concepts.ElementType).Returns(stub.ElementType);
            //            this.mockContext.Setup(s => s.Concepts.Include(It.IsAny<string>())).Returns<string>(stub.Include);

            // act
            var result = this.sut.ConceptsWithProperties(new[] { "a", "b" });

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(List<Concept>), result.GetType());

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
            //            this.mockContext.Verify(v => v.Concepts.Include(It.Is<string>(r => r == "a")));
            //            this.mockContext.Verify(v => v.Concepts.Include(It.Is<string>(r => r == "b")));
        }


        [Test]
        public void T010_ConceptOnly_Must_Call_For_Concepts_From_Context_And_Return_Without_Additional_Properties()
        {
            // arrange
            var list = ConceptModelFactory.CreateFull(1);

            list[0].Id = 2;

            var stub = list.AsQueryable();

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(stub.GetEnumerator());
            this.mockContext.Setup(s => s.Concepts.Provider).Returns(stub.Provider);
            this.mockContext.Setup(s => s.Concepts.Expression).Returns(stub.Expression);
            this.mockContext.Setup(s => s.Concepts.ElementType).Returns(stub.ElementType);

            // act
            var result = this.sut.ConceptOnly(2);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(Concept), result.GetType());

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }


        [Test]
        public void T011_GetConceptsCountByUserId_Must_Return_Count_Of_Concepts_Which_Were_Authored_By_Given_Parameter()
        {
            // arrange
            var concept1 = ConceptModelFactory.Create(1);
            var concept2 = ConceptModelFactory.Create(2);
            concept1.AuthorId = 1;
            concept2.AuthorId = 2;

            var stub = new List<Concept> { concept1, concept2 }.AsQueryable();

            // arrange-mock
            this.mockContext.Setup(s => s.Concepts.GetEnumerator()).Returns(stub.GetEnumerator());
            this.mockContext.Setup(s => s.Concepts.Provider).Returns(stub.Provider);
            this.mockContext.Setup(s => s.Concepts.Expression).Returns(stub.Expression);
            this.mockContext.Setup(s => s.Concepts.ElementType).Returns(stub.ElementType);

            // act
            var result = this.sut.GetConceptsCountByUserId(2);

            // assert
            Assert.AreEqual(1, result);

            // assert-mock
            this.mockContext.Verify(v => v.Concepts, Times.Once);
        }
    }
}
