namespace DBAccess.Models.Models
{
    public interface IRaceModel
    {
        int Id { get; set; }
        public string Category { get; set; }
        string Name { get; set; }
        string Size { get; set; }
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        int Intelligence { get; set; }
        int Wisdom { get; set; }
        int Charisma { get; set; }
    }
}