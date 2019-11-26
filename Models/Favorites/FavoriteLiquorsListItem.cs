using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Favorites
{
    public class FavoriteLiquorsListItem
    {
        public int Id { get; set; }
        public Guid Favoriter { get; set; }
        public string LiquorName { get; set; }
        public bool IsStarred { get; set; }
    }
}
