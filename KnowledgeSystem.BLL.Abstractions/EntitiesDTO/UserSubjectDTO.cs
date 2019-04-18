namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class UserSubjectDTO
    {
        public int Mark { get; set; }
        public UserDTO User { get; set; }
        public SubjectDTO Subject { get; set; }
    }
}
