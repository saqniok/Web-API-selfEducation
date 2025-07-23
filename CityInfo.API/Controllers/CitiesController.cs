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

            return new JsonResult(
                new List<object>
                {
                    new {id = 1, Name = "Mechelen" },
                    new {id = 2, Name = "Antwerpen" },
                    new {id = 3, Name = "Brussels" }
                });
        }
    }
}
