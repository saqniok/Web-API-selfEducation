using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController] // this itsn't strictly necessary, but it adds some useful features
    [Route("api/characters")] // This attribute defines the base route for all actions in this controller.
    public class CharacterController : ControllerBase
    {
        [HttpGet]  // This attribute defines the route for this action method.
        public ActionResult<IEnumerable<CharacterDto>> GetCities()
        {
            return Ok(CharactersDataStore.Current.Characters); // Returns a 200 OK response with the list of cities.
        }

        [HttpGet("{id}")] // This attribute defines the route for this action method with a parameter.
        public ActionResult<CharacterDto> GetCity(int id)
        {
            var cityToReturn = CharactersDataStore.Current.Characters.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
                return NotFound(); // Returns a 404 Not Found response if the city is not found.

            return Ok(cityToReturn);
        }
    }
}
