namespace ToBeImplemented.Business.Implementations.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Concepts;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Tests.ObjectMothers;
    using ToBeImplemented.Tests.ObjectMothers.Concepts;

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


        [Test]
        public void T002_Details_Must_Fetch_All_Concept_Details_All_Comments_Details_From_Service_And_Return_ViewModel_To_Caller()
        {
            // arrange
            long dummyId = 42;
            var concept = ConceptModelFactory.CreateFull(1).Single();

            // arrange-mock
            this.mockConceptService.Setup(s => s.Details(It.IsAny<long>())).Returns(concept);

            // act
            var result = this.sut.Details(dummyId);

            // assert
            Assert.AreEqual(typeof(ConceptViewModel), result.GetType());
            Assert.NotNull(result);
            Assert.NotNull(result.Author);
            Assert.NotNull(result.Tags);
            Assert.NotNull(result.Comments);
            Assert.AreEqual(322, result.Id);
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
            this.mockConceptService.Verify(x => x.Details(It.IsAny<long>()), Times.Once);
        }


        [Test]
        public void T003_GetAddConceptViewModel_Must_Create_ViewModel_That_Will_Be_Used_When_Crating_New_Concept()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.GetAddConceptViewModel();

            // assert
            Assert.NotNull(result);
            Assert.NotNull(result.AuthorId);
            Assert.True(string.IsNullOrEmpty(result.Title));
            Assert.True(string.IsNullOrEmpty(result.Description));
            Assert.True(string.IsNullOrEmpty(result.Tags));

            // assert-mock
        }


        [Test]
        public void T004_Add_Must_Convert_To_Model_Setup_Dates_Pass_Model_To_Service_And_Return_Id_Of_Freshly_Added_Entity()
        {
            // arrange
            AddConceptViewModel model = AddConceptViewModelFactory.CreateValidWithoutTags();

            // arrange-mock
            this.mockConceptService.Setup(s => s.Add(It.IsAny<AddConcept>())).Returns(33);

            // act
            var result = this.sut.Add(model);

            // assert
            Assert.AreEqual(33, result);

            // assert-mock
            this.mockConceptService.Verify(v => v.Add(It.IsAny<AddConcept>()), Times.Once);
        }


        [Test]
        public void T005_GetDeleteViewModel_Must_Fetch_Concept_Title_From_Db_Add_Confirmation_Text_And_Return_To_Controller()
        {
            // arrange

            // arrange-mock
            this.mockConceptService.Setup(s => s.GetConceptTitle(It.IsAny<long>())).Returns("test-concept-title");

            // act
            var result = this.sut.GetDeleteViewModel(333);

            // assert
            Assert.AreEqual("test-concept-title", result.Title);
            Assert.AreEqual("test-concept-delete-confirmation", result.Confirmation);
            Assert.AreEqual(333, result.Id);

            // assert-mock
            this.mockConceptService.Verify(v => v.GetConceptTitle(It.IsAny<long>()), Times.Once);
        }


        [Test]
        public void T006_Delete_Must_Call_Service_To_Delete_Concept_With_Proper_Id()
        {
            // arrange

            // arrange-mock

            // act
            this.sut.Delete(3);

            // assert

            // assert-mock
            this.mockConceptService.Verify(v => v.Delete(It.Is<long>(vv => vv == 3)), Times.Once);
        }


        [Test]
        public void T007_GetEditConceptViewModel_Must_Read_Concept_With_Tags_From_Service_Map_To_View_Model_And_Return()
        {
            // arrange
            var concept = ConceptModelFactory.Create();
            concept.Id = 44;

            // arrange-mock
            this.mockConceptService.Setup(s => s.GetConceptWithTags(It.IsAny<long>())).Returns(concept);

            // act
            var result = this.sut.GetEditConceptViewModel(44);

            // assert
            Assert.AreEqual(typeof(UpdateConceptViewModel), result.GetType());
            Assert.AreEqual(44, result.Id);
            Assert.AreEqual(321, result.AuthorId);
            Assert.AreEqual("test-concept-description", result.Description);
            Assert.IsNull(result.Tags);
            Assert.AreEqual("test-concept-title", result.Title);

            // assert-mock
            this.mockConceptService.Verify(v => v.GetConceptWithTags(It.Is<long>(vv => vv == 44)), Times.Once);
        }


        [Test]
        public void T008_UpdateConcept_Must_Convert_To_Model_And_Pass_It_To_Service_For_Updating_Version_Without_Tags()
        {
            // arrange
            var model = UpdateConceptViewModelFactory.CreateValidWithoutTags();

            // arrange-mock
            this.mockConceptService.Setup(s => s.UpdateConcept(It.IsAny<UpdateConcept>())).Verifiable();

            // act
            this.sut.UpdateConcept(model);

            // assert

            // assert-mock
            this.mockConceptService.Verify(v => v.UpdateConcept(It.Is<UpdateConcept>(r => r.Id == 14)), Times.Once);
        }


        [Test]
        public void T009_ConceptsOnly_Must_Fetch_Concepts_Only_From_Service_And_Return_ViewModel()
        {
            // arrange

            // arrange-mock
            this.mockConceptService.Setup(s => s.ConceptsOnly()).Returns(Enumerable.Empty<Concept>().ToList());

            // act
            var result = this.sut.ConceptsOnly();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ListConceptViewModel), result.GetType());

            // assert-mock
            this.mockConceptService.Verify(v => v.ConceptsOnly(), Times.Once);
        }


        [Test]
        public void T010_ConceptOnly_Must_Fetch_Only_Concept_From_Service_And_Return_ViewModel()
        {
            // arrange
            var stub = ConceptModelFactory.Create(42);

            // arrange-mock
            this.mockConceptService.Setup(s => s.ConceptOnly(It.IsAny<long>())).Returns(stub);

            // act
            var result = this.sut.ConceptOnly(42);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ConceptViewModel), result.GetType());

            // assert-mock
            this.mockConceptService.Verify(v => v.ConceptOnly(It.IsAny<long>()), Times.Once);
        }


        [Test]
        public void T011_ConceptsWith_Must_Split_String_Using_Colon_As_Separator_And_Return_View_Model_As_A_Result()
        {
            // arrange

            // arrange-mock
            this.mockConceptService.Setup(s => s.ConceptsWithProperties(It.IsAny<IEnumerable<string>>()))
                .Returns(Enumerable.Empty<Concept>().ToList());

            // act
            var result = this.sut.ConceptsWith("A,B,C");

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ListConceptViewModel), result.GetType());

            // assert-mock
            this.mockConceptService.Verify(v => v.ConceptsWithProperties(It.Is<IEnumerable<string>>(
                r =>

                        r.Count() == 3 &&
                        r.Contains("A") &&
                        r.Contains("B") &&
                        r.Contains("C")
                    )), Times.Once);
        }

        [Test]
        public void T012_ConceptsWith_Must_Split_String_Using_Colon_As_Separator_Empty_Includes_Must_Be_Ignored_And_Return_View_Model_As_A_Result()
        {
            // arrange

            // arrange-mock
            this.mockConceptService.Setup(s => s.ConceptsWithProperties(It.IsAny<IEnumerable<string>>()))
                .Returns(Enumerable.Empty<Concept>().ToList());

            // act
            var result = this.sut.ConceptsWith("A,B,,,C");

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ListConceptViewModel), result.GetType());

            // assert-mock
            this.mockConceptService.Verify(v => v.ConceptsWithProperties(It.Is<IEnumerable<string>>(
                r =>

                        r.Count() == 3 &&
                        r.Contains("A") &&
                        r.Contains("B") &&
                        r.Contains("C")
                    )), Times.Once);
        }

        [Test]
        public void T013_ConceptsWith_Must_Split_String_Using_Colon_As_Separator_Navigation_Properties_Using_Dot_Must_Be_Preserved_And_Return_View_Model_As_A_Result()
        {
            // arrange

            // arrange-mock
            this.mockConceptService.Setup(s => s.ConceptsWithProperties(It.IsAny<IEnumerable<string>>()))
                .Returns(Enumerable.Empty<Concept>().ToList());

            // act
            var result = this.sut.ConceptsWith("A.a,B,,,C");

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ListConceptViewModel), result.GetType());

            // assert-mock
            this.mockConceptService.Verify(v => v.ConceptsWithProperties(It.Is<IEnumerable<string>>(
                r =>

                        r.Count() == 3 &&
                        r.Contains("A.a") &&
                        r.Contains("B") &&
                        r.Contains("C")
                    )), Times.Once);
        }
    }
}
