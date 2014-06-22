namespace ToBeImplemented.Service.Implementations
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
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
                    expected = this.GetSecurityString(challenge, char.IsLetter, x => true);
                    break;
                case ChallengeType.EvenNumbers:
                    expected = this.GetSecurityString(challenge, char.IsDigit, CharToIntIsEven);
                    break;
                case ChallengeType.OddNumbers:
                    expected = this.GetSecurityString(challenge, char.IsDigit, CharToIntIsOdd);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("challengeType");
            }
            return expected.ToLower() == userInput.ToLower();
        }

        private static bool CharToIntIsOdd(char x)
        {
            return int.Parse(x.ToString()) % 2 != 0;
        }

        private static bool CharToIntIsEven(char x)
        {
            return int.Parse(x.ToString()) % 2 == 0;
        }

        private string GetSecurityString(
            string challenge,
            Func<char, bool> isValidCharacter,
            Func<char, bool> isValidNumber)
        {
            var sb = new StringBuilder();
            challenge.ToList().ForEach(
                x =>
                {
                    if (isValidCharacter(x) && isValidNumber(x))
                    {
                        sb.Append(x);
                    }
                });
            return sb.ToString();
        }
    }
}