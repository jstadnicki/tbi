namespace ToBeImplemented.Business.Implementations.Tests
{
    using System;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel;
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
            var now = DateTime.Now;

            // arrange-mock
            this.mockConceptService.Setup(s => s.Add(It.IsAny<Concept>())).Returns(33);

            // act
            var result = this.sut.Add(model);

            // assert
            Assert.AreEqual(33, result);

            // assert-mock
            this.mockConceptService.Verify(
                v => v.Add(It.Is<Concept>(
                    i =>
                        i.Created >= now &&
                        i.LastUpdate >= now)),
                Times.Once());
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
    }
}
