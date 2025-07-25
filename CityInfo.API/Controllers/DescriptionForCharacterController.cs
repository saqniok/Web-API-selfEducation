using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/characters/{characterId}/descriptionforcharacter")]
    [ApiController]
    public class DescriptionForCharacterController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<DescriptionForCharacterDto>> GetDescriptionsOfCharacter(int characterId)
        {
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(c => c.Id == characterId);

            if (character == null)
                return NotFound();

            return Ok(character.DescriptionsForCharacter);
        }

        [HttpGet("{descriptionforcharacterid}")]
        public ActionResult<DescriptionForCharacterDto> GetDescriptionForCharacter(int characterId, int descriptionForCharacterId)
        {
            // Validate the character ID before proceeding
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(c => c.Id == characterId);

            if (character == null)
                return NotFound();

            // Validate the description ID before proceeding
            var descriptionForCharacter = character.DescriptionsForCharacter.FirstOrDefault(d => d.Id == descriptionForCharacterId);

            if (descriptionForCharacter == null)
                return NotFound();

            // If both character and description are found, return the description
            return Ok(descriptionForCharacter);
        }
    }
}
