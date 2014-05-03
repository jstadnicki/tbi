using System;

namespace ToBeImplemented.Business.Mapper.Tests
{
    using AutoMapper;

    using NUnit.Framework;

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
    }
}
