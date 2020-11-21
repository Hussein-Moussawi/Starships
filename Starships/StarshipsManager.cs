using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
namespace Starships
{
    public class StarshipsManager : IStarshipsManager
    {
        private const string Url = "https://swapi.dev/api/starships/";

        public List<StarshipViewModel> GetStopsNumber(long distance)
        {
            var url = Url;
            List<StarshipViewModel> ships = new List<StarshipViewModel>();
           
            do
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(url)
                };

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = client.SendAsync(request);
                var result = response.Result.Content.ReadAsStringAsync().Result;
                var resultModel = JsonConvert.DeserializeObject<StarshipsResponseModel>(result);

                ships.AddRange(MapToViewModels(resultModel, distance));
                url = resultModel.NextPageUrl;

            } while (url != null);

            return ships;
        }

        private List<StarshipViewModel> MapToViewModels(StarshipsResponseModel starshipsResponse, long distance)
        {
            List<StarshipViewModel> viewModels = new List<StarshipViewModel>();

            foreach(var starship in starshipsResponse.StarshipModels)
            {
                int parsedStopsNumber;
                string stopsNumber;
                if(int.TryParse(starship.MaxDistanceByHour, out parsedStopsNumber))
                {
                    stopsNumber = (distance / (GetConsumablesByHour(starship.Consumables) * parsedStopsNumber)).ToString();
                }
                else
                {
                    stopsNumber = starship.MaxDistanceByHour;
                }

                viewModels.Add(new StarshipViewModel
                {
                    Name = starship.Name,

                    StopsNumber = stopsNumber
                }); ;
            }
            return viewModels;
        }

        private int GetConsumablesByHour(string consumables)
        {
            string[] time = consumables.Split(" ");

            var timeValue = int.Parse(time[0]);

            switch (time[1].ToLower())
            {
                case "years":
                case "year":
                    return timeValue * 365 * 24;
                case "month":
                case "months":
                    return timeValue * 30 * 24;
                case "week":
                case "weeks":
                    return timeValue * 7 * 24;
                case "day":
                case "days":
                    return timeValue * 24;
                default:
                    throw new ValidationException("couldn't get the time by hours");
            }
        }
    }
}
