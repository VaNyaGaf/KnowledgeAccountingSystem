namespace KnowledgeSystem.DAL.Abstractions.Entities
{
    public class UserSubject
    {
        public int Mark { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
