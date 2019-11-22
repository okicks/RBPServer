using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum LiquorCategory
    {
        Irish,
        Scotch,
        Japanese,
        Canadian,
        Bourbon,
        Tennessee,
        Rye,
        Blended,
        SingleMalt
    }

    public class Liquor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public LiquorCategory Category { get; set; }

        [Required]
        [DisplayName("% Alcohol")]
        public float PercentAlcohol { get; set; }

        [Required]
        public string Origin { get; set; }

    }
}
