using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Ratings
{
    public class CreateLiquorRating
    {
        public int LiquorId { get; set; }
        public Guid Rater { get; set; }
        public double Rating { get; set; }
    }
}
