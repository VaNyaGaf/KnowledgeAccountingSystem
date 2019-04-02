using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class SubjectDTO
    {
        [Required]
        public string Name { get; set; }
        public string Descriprion { get; set; }
    }
}
