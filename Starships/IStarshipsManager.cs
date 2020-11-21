using System.Collections.Generic;

namespace Starships
{
    public interface IStarshipsManager
    {
        List<StarshipViewModel> GetStopsNumber(long distance);
    }
}
