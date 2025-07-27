namespace CityInfo.API.Models
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string? ClassOfCharacter { get; set; }
        public int CharacterLevel { get; set; }

        public int NumberOfDescriptions
        {
            get { return DescriptionsForCharacter.Count; }
        }
        public ICollection<DescriptionForCharacterDto> DescriptionsForCharacter { get; set; }
        = new List<DescriptionForCharacterDto>();
    }
}
