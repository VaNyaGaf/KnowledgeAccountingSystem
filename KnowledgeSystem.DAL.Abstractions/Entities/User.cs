using System.Collections.Generic;

namespace KnowledgeSystem.DAL.Abstractions.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public IList<UserSubject> UserSubjects { get; set; }
    }
}
