namespace CityInfo.API.Models
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string? ClassOfCharacter { get; set; }
        public int CharacterLevel { get; set; }

        public int NumberOfStats
        {
            get { return StatsForCharacter.Count; }
        }
        public ICollection<StatForCharacterDto> StatsForCharacter { get; set; }
        = new List<StatForCharacterDto>();
    }
}
