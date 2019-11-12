using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FavoriteLiquor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid Favoriter { get; set; }

        [Required]
        [ForeignKey(nameof(Liquor))]
        public int LiquorId { get; set; }

        public virtual Liquor Liquor { get; set; }
    }
}
