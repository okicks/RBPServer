using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models.Recipe;
using Services;

namespace RBPServer.Controllers
{
    [RoutePrefix ("api/Recipe")]
    [Authorize]
    public class RecipesController : ApiController
    {
        [Route("AllRecipes")]
        public IHttpActionResult GetAll()
        {
            RecipeService recipeService = CreateRecipeService();
            var recipes = recipeService.GetRecipes();
            return Ok(recipes);
        }

        [Route("Recipe")]
        public IHttpActionResult Get(int id)
        {
            RecipeService recipeService = CreateRecipeService();
            var recipe = recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        [Route("Create")]
        public IHttpActionResult Post(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.CreateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }

        [Route("Edit")]
        public IHttpActionResult Put(RecipeEdit recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.UpdateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }

        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeService();

            if (!service.DeleteRecipe(id))
                return InternalServerError();

            return Ok();
        }

        private RecipeService CreateRecipeService()
        {
            var RecipeService = new RecipeService();
            return RecipeService;
        }
    }
}
