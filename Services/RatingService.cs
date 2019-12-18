using Data;
using Models.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLiquorRating(CreateLiquorRating model)
        {
            var entity =
                new LiquorRating()
                {
                    Rater = _userId,
                    LiquorId = model.LiquorId,
                    Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LiquorRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateRecipeRating(CreateRecipeRating model)
        {
            var entity =
                new RecipeRating()
                {
                    Rater = _userId,
                    RecipeId = model.RecipeId,
                    Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
