

using System.ComponentModel.DataAnnotations;

namespace AniRecipes.Models.Dto
{
    public class RecipeDTO
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
