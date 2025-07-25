using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CharactersDataStore
    {
        public List<CharacterDto> Characters { get; set; }
        public static CharactersDataStore Current { get; } = new CharactersDataStore();     // Singleton instance

        public CharactersDataStore()
        {
            Characters = new List<CharacterDto>()
            {
                new CharacterDto()
                {
                    Id = 1,
                    NickName = "Bruce Cambell",
                    ClassOfCharacter = "RockStar",
                    DescriptionsForCharacter = new List<DescriptionForCharacterDto>()
                    {
                        new DescriptionForCharacterDto() { Id = 1, Name = "Description 1", Description = "This is the first character" },
                        new DescriptionForCharacterDto() { Id = 2, Name = "Description 2", Description = "This is the first rock star character" }
                    }
                },
                new CharacterDto()
                {
                    Id = 2,
                    NickName = "Jhon Wick",
                    ClassOfCharacter = "Assasin",
                    DescriptionsForCharacter = new List<DescriptionForCharacterDto>()
                    {
                        new DescriptionForCharacterDto() { Id = 1, Name = "Description 1", Description = "This is the second character" },
                        new DescriptionForCharacterDto() { Id = 2, Name = "Description 2", Description = "This is the second assasin character" }
                    }
                },
                new CharacterDto()
                {
                    Id = 3,
                    NickName = "Harry Potter",
                    ClassOfCharacter = "Wizard",
                    DescriptionsForCharacter = new List<DescriptionForCharacterDto>()
                    {
                        new DescriptionForCharacterDto() { Id = 1, Name = "Description 1", Description = "This is the third character" },
                        new DescriptionForCharacterDto() { Id = 2, Name = "Description 2", Description = "This is the third wizard character" }
                    }
                }
            };
        }
    }
}
