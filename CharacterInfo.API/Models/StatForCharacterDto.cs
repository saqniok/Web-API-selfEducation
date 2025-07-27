namespace CityInfo.API.Models
{
    public class StatForCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatValue { get; set; } = 0;
        public string? Description { get; set; }

    }
}
