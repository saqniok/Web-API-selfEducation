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
                    StatsForCharacter = new List<StatForCharacterDto>()
                    {
                        new StatForCharacterDto() { Id = 1, Name = "Strength", Description = "This stat give power for melee attacks" },
                        new StatForCharacterDto() { Id = 2, Name = "Stamina", Description = "This stat give ability for more attacks combo" }
                    }
                },
                new CharacterDto()
                {
                    Id = 2,
                    NickName = "Jhon Wick",
                    ClassOfCharacter = "Assasin",
                    StatsForCharacter = new List<StatForCharacterDto>()
                    {
                        new StatForCharacterDto() { Id = 1, Name = "Agility", Description = "This stat give more crticial chance for attack" },
                        new StatForCharacterDto() { Id = 2, Name = "Vitality", Description = "This stat gives more Health Points" }
                    }
                },
                new CharacterDto()
                {
                    Id = 3,
                    NickName = "Harry Potter",
                    ClassOfCharacter = "Wizard",
                    StatsForCharacter = new List<StatForCharacterDto>()
                    {
                        new StatForCharacterDto() { Id = 1, Name = "Intelligence", Description = "This stat give power for magic spells" },
                        new StatForCharacterDto() { Id = 2, Name = "Vitality", Description = "This stat gives more Health Points" }
                    }
                }
            };
        }
    }
}
