using AniRecipes.Models.Dto;

namespace AniRecipes.Data
{
    public static class RecipeStore
    {
        public static List<RecipeDTO> recipeList = new List<RecipeDTO>
            {
                new RecipeDTO{Id=1,Name="Dosa"},
                new RecipeDTO{Id=2, Name="Idli"}
            };
    }
}
