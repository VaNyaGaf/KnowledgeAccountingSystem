using System.ComponentModel.DataAnnotations;

namespace KnowledgeSystem.BLL.Abstractions.EntitiesDTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
