using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserSubjectDTO> RatedByUsers { get; set; }
    }
}
