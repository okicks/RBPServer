using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Recipe
{
    public class RecipeCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Maximum amount of characters (50) reached.")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20000, ErrorMessage = "Maximum amount of characters (20000) reached.")]
        public string Description { get; set; }
    }
}
