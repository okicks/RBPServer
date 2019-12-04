using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RecipeRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        public Guid Rater { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}
