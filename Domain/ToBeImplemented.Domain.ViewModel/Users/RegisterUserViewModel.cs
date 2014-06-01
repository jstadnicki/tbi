namespace ToBeImplemented.Domain.ViewModel.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string PasswordConfirmation { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        public string SecurityChallengeText { get; set; }

        [Required]
        public string SecurityResult { get; set; }

        public ChallengeType ChallengeType { get; set; }
    }
}