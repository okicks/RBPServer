using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using Models.Favorites;
using Models.Recipe;

namespace Services
{
    public class RecipeService
    {
        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    Name = model.Name,
                    Description = model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var recipeListItems =
                    ctx
                    .Recipes
                    .Select(e =>
                        new RecipeListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Description = e.Description,
                            RecipeRatings = e.RecipeRatings
                            //AverageRating = CalculateAverageRating(e.RecipeRatings)
                        }).ToArray();
                
                foreach (var recipe in recipeListItems)
                {
                    recipe.AverageRating = CalculateAverageRating(recipe.RecipeRatings);
                }

                return recipeListItems;

            }
        }

        private double CalculateAverageRating(ICollection<RecipeRating> recipeRatings)
        {
            var sum = 0d;
            foreach (var rating in recipeRatings)
            {
                sum = rating.Rating + sum;
            }

            return sum / recipeRatings.Count;
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.Id == id);

                return
                    new RecipeDetail
                    {
                        Name = entity.Name,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.Id == id);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
