namespace ToBeImplemented.Service.Implementations
{
    using System;
    using System.Linq;
    using System.Text;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Service.Interfaces;

    public class SimpleSecurityChallengeProvider : ISecurityChallengeProvider
    {
        private readonly IDateTimeAdapter dateTimeAdapter;

        private readonly IGuidAdapter guidAdapter;

        public SimpleSecurityChallengeProvider(IDateTimeAdapter dateTimeAdapter, IGuidAdapter guidAdapter)
        {
            this.dateTimeAdapter = dateTimeAdapter;
            this.guidAdapter = guidAdapter;
        }

        public ChallengeType GetChallengeType()
        {
            var now = this.dateTimeAdapter.Now;
            var key = now.Millisecond % 3;
            return (ChallengeType)(key + 1);
        }

        public string GetChallengeInput()
        {
            var guid = this.guidAdapter.NewGuid();
            var withDashes = guid.ToString();
            var result = withDashes.Replace("-", string.Empty);
            return result;
        }

        public bool IsChallengeValid(string challenge, string userInput, ChallengeType challengeType)
        {
            string expected;
            switch (challengeType)
            {
                case ChallengeType.CharactersOnly:
                    expected = this.GetCharactesOnly(challenge);
                    break;
                case ChallengeType.EvenNumbers:
                    expected = this.GetEvenNumber(challenge);
                    break;
                case ChallengeType.OddNumbers:
                    expected = this.GetOddNumbers(challenge);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("challengeType");
            }
            return expected.ToLower() == userInput.ToLower();
        }

        private string GetOddNumbers(string challenge)
        {
            StringBuilder sb = new StringBuilder();
            challenge.ToList().ForEach(
                x =>
                {
                    if (char.IsDigit(x))
                    {
                        if (int.Parse(x.ToString()) % 2 != 0)
                        {
                            sb.Append(x);
                        }
                    }
                });
            return sb.ToString();
        }

        private string GetEvenNumber(string challenge)
        {
            StringBuilder sb = new StringBuilder();
            challenge.ToList().ForEach(
                x =>
                {
                    if (char.IsDigit(x))
                    {
                        if (int.Parse(x.ToString()) % 2 == 0)
                        {
                            sb.Append(x);
                        }
                    }
                });
            return sb.ToString();
        }

        private string GetCharactesOnly(string challenge)
        {
            StringBuilder sb = new StringBuilder();
            challenge.ToList().ForEach(
                x =>
                {
                    if (char.IsLetter(x))
                    {
                        sb.Append(x);
                    }
                });
            return sb.ToString();
        }
    }
}