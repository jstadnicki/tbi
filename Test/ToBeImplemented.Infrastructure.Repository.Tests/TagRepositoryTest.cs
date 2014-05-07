namespace ToBeImplemented.Infrastructure.Repository.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Service.Implementations.Tests;
    using ToBeImplemented.Tests.ObjectMothers;

    [TestFixture]
    public class TagRepositoryTest : TbiBaseTest
    {
        private Mock<ITbiContext> mockTbiContext;

        private ITagRepository sut;

        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockTbiContext = new Mock<ITbiContext>();
            this.sut = new TagRepository(this.mockTbiContext.Object);
        }


        [Test]
        public void T001_GetTag_Must_Fetch_Tags_From_Db_And_Return_Objects_That_Matches_Text_With_Given_Input_Tags()
        {
            // arrange
            var demandedTags = new List<string> { "square", "circle", "cat" };
            var dbTag1 = TagModelFactory.Create(1, "rectangle");
            var dbTag2 = TagModelFactory.Create(2, "circle");
            var dbTag3 = TagModelFactory.Create(3, "flower");
            var dbTag4 = TagModelFactory.Create(4, "square");

            var dbTags = new List<Tag> { dbTag1, dbTag2, dbTag3, dbTag4 }.AsQueryable();

            // arrange-mock
            this.mockTbiContext.Setup(s => s.Tags.Provider).Returns(dbTags.Provider);
            this.mockTbiContext.Setup(s => s.Tags.Expression).Returns(dbTags.Expression);
            this.mockTbiContext.Setup(s => s.Tags.ElementType).Returns(dbTags.ElementType);
            this.mockTbiContext.Setup(s => s.Tags.GetEnumerator()).Returns(dbTags.GetEnumerator());

            // act
            var result = this.sut.GetTags(demandedTags);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.True(result.Select(x => x.Id).Contains(4));
            Assert.True(result.Select(x => x.Id).Contains(2));
            Assert.True(result.Select(x => x.Id).Contains(0));

            Assert.True(result.Select(x => x.Text).Contains("square"));
            Assert.True(result.Select(x => x.Text).Contains("circle"));
            Assert.True(result.Select(x => x.Text).Contains("cat"));

            // assert-mock
            this.mockTbiContext.Verify(v => v.Tags, Times.Once);
        }
    }
}