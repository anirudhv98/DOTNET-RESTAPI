using AniRecipes.Data;
using AniRecipes.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AniRecipes.Controllers
{
    [Route("api/RecipeAPI")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class RecipeAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDTO>> GetRecipes()
        {
            return Ok(RecipeStore.recipeList);
        }

        [HttpGet("{id:int}", Name = "GetRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RecipeDTO> GetRecipe(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var recipe = RecipeStore.recipeList.FirstOrDefault(u => u.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<RecipeDTO> CreateRecipe([FromBody] RecipeDTO recipeDTO)
        {
            if (RecipeStore.recipeList.FirstOrDefault(u => u.Id == recipeDTO.Id) != null)
            {
                ModelState.AddModelError("CustomError", "Recipe already exists");
                return BadRequest(ModelState);
            }
            if (recipeDTO == null)
            {
                return BadRequest();
            }
            if (recipeDTO.Id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            recipeDTO.Id = RecipeStore.recipeList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            RecipeStore.recipeList.Add(recipeDTO);
            return CreatedAtRoute("GetRecipe", new { id = recipeDTO.Id }, recipeDTO);
        }

        [HttpDelete("{id:int}",Name = "DeleteRecipe")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRecipe(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var ans = RecipeStore.recipeList.FirstOrDefault(u=>u.Id == id);
            if(ans==null)
            {
                return NotFound();
            }
            RecipeStore.recipeList.Remove(ans);
            return NoContent();

        }

        [HttpPut("{id:int}", Name = "UpdateRecipe")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateRecipe(int id, [FromBody] RecipeDTO recipe)
        {
            if(id<0 ||  (id!=recipe.Id)) {
                return BadRequest();
            }

            var r = RecipeStore.recipeList.FirstOrDefault(u=>u.Id==id);
            if(r==null)
            {
                return NotFound();
            }
            r.Name= recipe.Name;
            return NoContent();
        }
    }
}
