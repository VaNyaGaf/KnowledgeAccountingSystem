using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descriprion { get; set; }
    }
}
