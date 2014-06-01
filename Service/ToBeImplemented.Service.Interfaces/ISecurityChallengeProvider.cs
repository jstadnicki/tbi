namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Domain.ViewModel;

    public interface ISecurityChallengeProvider
    {
        ChallengeType GetChallengeType();
        string GetChallengeInput();

        bool IsChallengeValid(string p1, string p2, ChallengeType challengeType);
    }
}