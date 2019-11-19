using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using Models.Recipe;
using RBPServer.Models;

namespace Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        //[HttpPost]
        //public IHttpActionResult Create(RecipeCreate model)
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new RecipeService(userId);
        //    service.CreateRecipe(model);
        //    //route from Angular
        //    return RedirectToRoute(string/* Recipes*/);
        //}

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

        public IEnumerable<RecipeListItems> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes

                        .Select(e =>
                            new RecipeListItems
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Description = e.Description
                            }
                            );
                return query.ToArray();

            }
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
