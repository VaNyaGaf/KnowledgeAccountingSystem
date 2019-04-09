using Microsoft.AspNetCore.Identity;

namespace KnowledgeSystem.WebApi.Auth
{
    public class AuthUser : IdentityUser
    {
        public AuthUser() { }
        public AuthUser(string userName) : base(userName) { }
    }
}
