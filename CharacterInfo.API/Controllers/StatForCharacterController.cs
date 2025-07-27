using CharacterInfo.API.Models;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/characters/{characterId}/statforcharacter")]
    [ApiController]
    public class StatForCharacterController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<StatForCharacterDto>> GetStatsOfCharacter(int characterId)
        {
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(c => c.Id == characterId);

            if (character == null)
                return NotFound();

            return Ok(character.StatsForCharacter);
        }

        [HttpGet("{statforcharacterid}", Name = "GetStatForCharacter")]
        public ActionResult<StatForCharacterDto> GetStatForCharacter(int characterId, int statForCharacterId)
        {
            // Validate the character ID before proceeding
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(c => c.Id == characterId);

            if (character == null)
                return NotFound();

            // Validate the description ID before proceeding
            var statForCharacter = character.StatsForCharacter.FirstOrDefault(d => d.Id == statForCharacterId);

            if (statForCharacter == null)
                return NotFound();

            // If both character and description are found, return the description
            return Ok(statForCharacter);
        }

        [HttpPost]
        public ActionResult<StatForCharacterDto> CreateStatForCharacter(int characterId, [FromBody] StatForCharacterCreationDto statForCharacter)
        {
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(c => c.Id == characterId);

            if (character == null)
                return NotFound();

            // demo purposes - calculate max StatId value
            var maxStatsForCharacterId = CharactersDataStore.Current.Characters.SelectMany(
                c => c.StatsForCharacter).Max(s => s.Id);

            var finalStatForCharacter = new StatForCharacterDto()
            {
                Id = ++maxStatsForCharacterId,
                Name = statForCharacter.Name,
                Description = statForCharacter.Description
            };

            character.StatsForCharacter.Add(finalStatForCharacter);

            return CreatedAtRoute("GetStatForCharacter",
                new
                {
                    characterId = characterId,
                    statForCharacterId = finalStatForCharacter.Id
                },
                finalStatForCharacter);

        }
    }
}
