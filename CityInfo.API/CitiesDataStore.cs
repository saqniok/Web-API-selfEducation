using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();     // Singleton instance

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Mechelen",
                    Description = "Mechelen is the city in Belgium"
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Brussels",
                    Description = "Brussels is the capital of Belgium"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Antwerp",
                    Description = "Antwerp is a city in Belgium"
                }
            };
        }
    }
}
