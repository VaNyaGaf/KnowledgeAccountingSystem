using System.Collections.Generic;

namespace KnowledgeSystem.DAL.Abstractions.Entities
{
    public  class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<UserSubject> UserSubjects { get; set; }
    }
}
