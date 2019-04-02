using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
