namespace ToBeImplemented.Service.Implementations
{
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

        public bool IsChallengeValid(string p1, string p2, ChallengeType challengeType)
        {
            throw new System.NotImplementedException();
        }
    }
}