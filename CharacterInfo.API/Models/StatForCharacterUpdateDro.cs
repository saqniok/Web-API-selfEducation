using System.ComponentModel.DataAnnotations;

namespace CharacterInfo.API.Models
{
    public class StatForCharacterUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(15)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
