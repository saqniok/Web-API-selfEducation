using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController] // this itsn't strictly necessary, but it adds some useful features
    [Route("api/cities")] // This attribute defines the base route for all actions in this controller.
    public class CitiesController : ControllerBase
    {
        [HttpGet]  // This attribute defines the route for this action method.
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities); // Returns a 200 OK response with the list of cities.
        }

        [HttpGet("{id}")] // This attribute defines the route for this action method with a parameter.
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound(); // Returns a 404 Not Found response if the city is not found.
            }

            return Ok(cityToReturn);

        }
    }
}
