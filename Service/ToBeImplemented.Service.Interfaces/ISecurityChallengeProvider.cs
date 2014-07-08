namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Business.ViewModel;

    public interface ISecurityChallengeProvider
    {
        ChallengeType GetChallengeType();
        string GetChallengeInput();

        bool IsChallengeValid(string p1, string p2, ChallengeType challengeType);
    }
}