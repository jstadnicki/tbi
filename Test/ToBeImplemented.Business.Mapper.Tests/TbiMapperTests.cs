using System;

namespace ToBeImplemented.Business.Mapper.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Tests.ObjectMothers;

    [TestFixture]
    public class TbiMapperTests : TbiBaseTest
    {
        public override void Once()
        {
            TbiMapper.Initialize();
        }

        public override void OncePerTest()
        {
            /* empty on purpose */
        }

        [Test]
        public void T001_Can_Map_Concept_To_ConceptViewModel_Must_Map_Null_Collections_To_Empty_Collections()
        {
            // arrange
            var concept = ConceptModelFactory.Create();

            // act
            var result = Mapper.Map<ConceptViewModel>(concept);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(null, result.Author);
            Assert.AreEqual(321, result.AuthorId);
            Assert.NotNull(result.Comments);
            Assert.AreEqual(0, result.Comments.Count);
            Assert.AreEqual(new DateTime(2014, 1, 1), result.Created);
            Assert.AreEqual("test-concept-description", result.Description);
            Assert.AreEqual(3, result.DisplayCount);
            Assert.AreEqual(2, result.EditCount);
            Assert.AreEqual(3333, result.Id);
            Assert.AreEqual(new DateTime(2014, 1, 1), result.LastUpdate);
            Assert.NotNull(result.Tags);
            Assert.AreEqual(0, result.Tags.Count);
            Assert.AreEqual("test-concept-title", result.Title);
            Assert.AreEqual(3, result.VoteDown);
            Assert.AreEqual(2, result.VoteUp);
        }


        [Test]
        public void T002_Can_Map_User_To_AuthorViewModel()
        {
            // arrange
            var user = UserModelFactory.Create();

            // arrange-mock

            // act
            var result = Mapper.Map<AuthorViewModel>(user);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual("test-user-display-name", result.DisplayName);
            Assert.AreEqual("test@user.email", result.Email);
            Assert.AreEqual(99, result.Id);

            // assert-mock
        }


        [Test]
        public void T003_Can_Map_Tag_To_TagViewModel()
        {
            // arrange
            var tag = TagModelFactory.Create();

            // arrange-mock

            // act
            var result = Mapper.Map<TagViewModel>(tag);

            // assert
            Assert.NotNull(result);
            Assert.NotNull(result.Concepts);
            Assert.AreEqual(331, result.Id);
            Assert.AreEqual("test-tag-text", result.Text);

            // assert-mock
        }


        [Test]
        public void T004_Can_Map_Comment_To_CommantViewModel()
        {
            // arrange
            var comment = CommentModelFactory.Create();

            // arrange-mock

            // act
            var result = Mapper.Map<CommentViewModel>(comment);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual("test-user-display-name", result.AuthorDisplayName);
            Assert.AreEqual(99, result.AuthorId);
            Assert.AreEqual(99876, result.Id);
            Assert.AreEqual("test-comment-text", result.Text);
            Assert.AreEqual(new DateTime(1998, 5, 6), result.Created);

            // assert-mock
        }


        [Test]
        public void T005_Can_Map_From_AddConceptViewModelWithoutTags_To_Concept()
        {
            // arrange
            var source = AddConceptViewModelFactory.CreateValidWithoutTags();

            // arrange-mock

            // act
            var result = Mapper.Map<Concept>(source);

            // assert
            Assert.Null(result.Author);
            Assert.NotNull(result);
            Assert.NotNull(result.Comments);
            Assert.NotNull(result.Tags);
            Assert.AreEqual(44, result.AuthorId);
            Assert.AreEqual("test-add-concept-view-model-descriptions", result.Description);
            Assert.AreEqual(0, result.DisplayCount);
            Assert.AreEqual(0, result.EditCount);
            Assert.AreEqual(0, result.Id);
            Assert.AreEqual("test-add-concept-view-model-title", result.Title);
            Assert.AreEqual(0, result.VoteDown);
            Assert.AreEqual(0, result.VoteUp);

            // assert-mock
        }


        [Test]
        public void T006_Can_Map_From_Concept_To_EditConceptViewModel()
        {
            // arrange
            var source = ConceptModelFactory.CreateFull(1).Single();

            // arrange-mock

            // act
            var result = Mapper.Map<EditConceptViewModel>(source);

            // assert
            Assert.NotNull(result);
            Assert.NotNull(result.Tags);
            Assert.AreEqual(322, result.Id);
            Assert.AreEqual(99, result.AuthorId);
            Assert.AreEqual("test-concept-description", result.Description);
            Assert.False(string.IsNullOrWhiteSpace(result.Tags));
            Assert.True(result.Tags.Contains("test-tag-text"));
            Assert.AreEqual("test-concept-title", result.Title);

            // assert-mock
        }


        [Test]
        public void T007_Can_Map_From_Tag_To_String()
        {
            // arrange
            var source = TagModelFactory.Create();

            // arrange-mock

            // act
            var result = Mapper.Map<string>(source);

            // assert
            Assert.AreEqual("test-tag-text", result);

            // assert-mock
        }

        [Test]
        public void T008_Can_Map_From_List_Of_Tags_To_String_Semicolon_Separated()
        {
            // arrange
            var s1 = TagModelFactory.Create("s");
            var s2 = TagModelFactory.Create("d");
            var s3 = TagModelFactory.Create("g");

            var tagsList = new List<Tag> { s1, s2, s3 };

            // arrange-mock

            // act
            var result = Mapper.Map<string>(tagsList);

            // assert
            Assert.AreEqual("s;d;g", result);

            // assert-mock
        }
    }
}
