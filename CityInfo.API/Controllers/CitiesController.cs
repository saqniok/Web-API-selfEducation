using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController] // this itsn't strictly necessary, but it adds some useful features
    [Route("api/cities")] // This attribute defines the base route for all actions in this controller.
    public class CitiesController : ControllerBase
    {
        [HttpGet]  // This attribute defines the route for this action method.
        public JsonResult GetCities()
        {

            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")] // This attribute defines the route for this action method with a parameter.
        public JsonResult GetCity(int id)
        {
            return new JsonResult(
                CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));

        }
    }
}
