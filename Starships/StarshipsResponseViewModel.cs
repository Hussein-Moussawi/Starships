using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starships
{
    public class StarshipsResponseViewModel
    {
 
        public string NextPageUrl { get; set; }

        public string PrevPageUrl { get; set; }

        public List<StarshipViewModel> StarshipModels { get; set; }
    }
}
