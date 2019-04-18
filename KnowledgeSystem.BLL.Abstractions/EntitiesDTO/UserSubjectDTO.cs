namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class UserSubjectDTO
    {
        public int Mark { get; set; }
        public string UserId { get; set; }
        public UserDTO User { get; set; }
        public int SubjectId { get; set; }
        public SubjectDTO Subject { get; set; }
    }
}
