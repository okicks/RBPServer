using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        [ForeignKey(nameof(Liquor))]
        public int LiquorId { get; set; }

        public virtual Liquor Liquor { get; set; }
    }
}
