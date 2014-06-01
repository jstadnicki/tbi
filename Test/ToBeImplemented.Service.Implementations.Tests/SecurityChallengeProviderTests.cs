namespace ToBeImplemented.Service.Implementations.Tests
{
    using System;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Service.Interfaces;

    public class SimpleSecurityChallengeProviderTests : TbiBaseTest
    {
        private Mock<IDateTimeAdapter> mockDateTimeAdapter;
        private Mock<IGuidAdapter> mockGuidAdapter;

        private ISecurityChallengeProvider sut;


        public override void Once()
        {
            /* empty on purpose */
        }

        public override void OncePerTest()
        {
            this.mockDateTimeAdapter = new Mock<IDateTimeAdapter>();
            this.mockGuidAdapter = new Mock<IGuidAdapter>();
            this.sut = new SimpleSecurityChallengeProvider(this.mockDateTimeAdapter.Object, mockGuidAdapter.Object);
        }


        [Test]
        public void T001_GetChallengeType_Must_Create_Even_Numbers_When_Rest_Of_Modulo3_Is_One()
        {
            // arrange

            // arrange-mock
            this.mockDateTimeAdapter.Setup(s => s.Now).Returns(new DateTime(1, 1, 1, 1, 1, 1, 1));

            // act
            var result = this.sut.GetChallengeType();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ChallengeType), result.GetType());
            Assert.AreEqual(ChallengeType.EvenNumbers, result);

            // assert-mock
        }

        [Test]
        public void T002_GetChallengeType_Must_Create_Odd_Numbers_When_Rest_Of_Modulo3_Is_Two()
        {
            // arrange

            // arrange-mock
            this.mockDateTimeAdapter.Setup(s => s.Now).Returns(new DateTime(1, 1, 1, 1, 1, 1, 2));

            // act
            var result = this.sut.GetChallengeType();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ChallengeType), result.GetType());
            Assert.AreEqual(ChallengeType.OddNumbers, result);

            // assert-mock
        }

        [Test]
        public void T003_GetChallengeType_Must_Create_Charactes_Only_When_Rest_Of_Modulo3_Is_Zero()
        {
            // arrange

            // arrange-mock
            this.mockDateTimeAdapter.Setup(s => s.Now).Returns(new DateTime(1, 1, 1, 1, 1, 1, 0));

            // act
            var result = this.sut.GetChallengeType();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(ChallengeType), result.GetType());
            Assert.AreEqual(ChallengeType.CharactersOnly, result);

            // assert-mock
        }


        [Test]
        public void T004_GetChallengeInput_Must_Create_String_Based_Guid_With_Dashes_Removed()
        {
            // arrange
            var guid = Guid.Parse("62B5AD4A-FAA9-40D7-B9CE-031CB1614AE2");
            var expected = "62B5AD4AFAA940D7B9CE031CB1614AE2";

            // arrange-mock
            this.mockGuidAdapter.Setup(s => s.NewGuid()).Returns(guid);

            // act
            var result = this.sut.GetChallengeInput();

            // assert
            Assert.AreEqual(expected.ToLower(), result.ToLower());

            // assert-mock
            this.mockGuidAdapter.Verify(v => v.NewGuid(), Times.Once);
        }
    }
}