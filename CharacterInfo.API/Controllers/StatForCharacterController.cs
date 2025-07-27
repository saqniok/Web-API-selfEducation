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
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(
                c => c.Id == characterId);

            if (character == null)
                return NotFound();

            return Ok(character.StatsForCharacter);
        }

        [HttpGet("{statForCharacterId}", Name = "GetStatForCharacter")]
        public ActionResult<StatForCharacterDto> GetStatForCharacter(
            int characterId,
            int statForCharacterId)
        {
            // Validate the character ID before proceeding
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(
                c => c.Id == characterId);

            if (character == null)
                return NotFound();

            // Validate the description ID before proceeding
            var statForCharacter = character.StatsForCharacter.FirstOrDefault(
                d => d.Id == statForCharacterId);

            if (statForCharacter == null)
                return NotFound();

            // If both character and description are found, return the description
            return Ok(statForCharacter);
        }

        [HttpPost]
        public ActionResult<StatForCharacterDto> CreateStatForCharacter(
            int characterId, 
            StatForCharacterCreationDto statForCharacter)
        {

            //ModelState is a dictionary containing both the state of the model

            /* 
             * It's not necessary, because the API controller attribute
             * Annotations are automatically checked during model binding and
             * affect the ModelState dictionary and the API controller attribute ensures 
             * that in case of an invalid ModelState a 400 BadRequest is returned with the validation
             * 
             * if (!ModelState.IsValid)
             *      return BadRequest();
             */



            var character = CharactersDataStore.Current.Characters.FirstOrDefault(
                c => c.Id == characterId);

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

        // Add new action for Update Stats
        [HttpPut("{statForCharacterId}")]
        public ActionResult UpdateStatForCharacter(
            int characterId, 
            int statForCharacterId, 
            StatForCharacterUpdateDto statForCharacter)
        {
            //Checking character
            var character = CharactersDataStore.Current.Characters.FirstOrDefault(
                c => c.Id == characterId);

            if (character == null)
                return NotFound();

            // checking stat for character
            var statForCharacterFromStore = character.StatsForCharacter
                .FirstOrDefault(c => c.Id == statForCharacterId);

            if (statForCharacterFromStore == null)
                return NotFound();

            /*
             * According to the HTTP standard, `Put` should fully update a resource
             * That means that the consumer of the API must provide values for all fields of the resource
             * 
             * If the consumer doesn't provide a value for a field, that field should
             * be put to its default value. So we must update all fields.
             */

            statForCharacterFromStore.Name = statForCharacter.Name;
            statForCharacterFromStore.Description = statForCharacter.Description;

            // We return 204 No Content
            return NoContent();
        }
    }
}
