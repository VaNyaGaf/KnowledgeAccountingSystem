using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KnowledgeSystem.DAL.Abstractions.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<UserSubject> UserSubjects { get; set; }
    }
}
