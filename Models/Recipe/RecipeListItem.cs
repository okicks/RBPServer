using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<RecipeRating> RecipeRatings { get; set; }

        public double AverageRating { get; set; }
    }
}
