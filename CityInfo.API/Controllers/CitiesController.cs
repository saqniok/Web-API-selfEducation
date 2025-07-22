using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController] // this itsn't strictly necessary, but it adds some useful features
    public class CitiesController : ControllerBase
    {
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
