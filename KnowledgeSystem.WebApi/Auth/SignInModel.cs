using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystem.WebApi.Auth
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
