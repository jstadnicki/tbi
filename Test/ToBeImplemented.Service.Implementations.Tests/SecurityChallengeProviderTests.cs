namespace ToBeImplemented.Service.Implementations.Tests
{
    using System;

    using Moq;

    using NUnit.Framework;

    using ToBeImplemented.Business.ViewModel;
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


        [Test]
        public void T005_Is_ChallengeValid_Must_Return_True_When_Passing_Only_Odd_Number_And_Challenge_Is_OddType()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.IsChallengeValid("1234asd", "24", ChallengeType.EvenNumbers);

            // assert
            Assert.True(result);

            // assert-mock
        }

        [Test]
        public void T006_Is_ChallengeValid_Must_Return_False_When_Passing_Only_Odd_Number_And_Challenge_Is_Not_OddType()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.IsChallengeValid("1234asd", "24", ChallengeType.OddNumbers);

            // assert
            Assert.False(result);

            // assert-mock
        }


        [Test]
        public void T007_Is_ChallengeValid_Must_Return_True_When_Entering_EvenNumber_And_Is_Of_Type_Odd()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.IsChallengeValid("12a34a34sd", "133", ChallengeType.OddNumbers);

            // assert
            Assert.True(result);

            // assert-mock
        }

        [Test]
        public void T008_Is_ChallengeValid_Must_Return_False_When_Entering_EvenNumber_And_Is_Not_Of_Type_Odd()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.IsChallengeValid("12a34a34sd", "133", ChallengeType.EvenNumbers);

            // assert
            Assert.False(result);

            // assert-mock
        }

        [Test]
        public void T009_Is_ChallengeValid_Must_Return_True_When_Entering_Characters_And_Challenge_Is_Characters()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.IsChallengeValid("12a34a34sd", "aasd", ChallengeType.CharactersOnly);

            // assert
            Assert.True(result);

            // assert-mock
        }

        [Test]
        public void T010_Is_ChallengeValid_Must_Return_False_When_Entering_Characters_And_Challenge_Is_Characters()
        {
            // arrange

            // arrange-mock

            // act
            var result = this.sut.IsChallengeValid("12a34a34sd", "24", ChallengeType.OddNumbers);

            // assert
            Assert.False(result);

            // assert-mock
        }


        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void T011_Is_ChallengeValid_Must_Throw_When_Security_Challenge_Type_Is_Unknown()
        {
            // arrange

            // arrange-mock

            // act
            this.sut.IsChallengeValid("", "", 0);

            // assert

            // assert-mock
        }
    }
}