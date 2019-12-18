using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Ratings
{
    public class CreateRecipeRating
    {
        public int RecipeId { get; set; }
        public Guid Rater { get; set; }
        public double Rating { get; set; }
    }
}
