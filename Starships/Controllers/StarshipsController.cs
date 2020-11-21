using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Starships.Controllers
{
    [Route("api/starship")]
    [ApiController]
    public class StarshipsController : Controller
    {
        private readonly IStarshipsManager _starshipsManager;

        public StarshipsController(IStarshipsManager starshipsManager)
        {
            _starshipsManager = starshipsManager;
        }

        [HttpGet]
        [Route("stops")]
        public List<StarshipViewModel> GetStopsNumber(long distance)
        {
            return _starshipsManager.GetStopsNumber(distance);
        }
    }
}