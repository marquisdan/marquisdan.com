using System.Collections.Generic;

namespace PathfinderLogicLibrary.StaticData
{
    public static class StatNames
    {
        public const string Strength = "Strength";
        public const string Dexterity = "Dexterity";
        public const string Constitution = "Constitution";
        public const string Intelligence = "Intelligence";
        public const string Wisdom = "Wisdom";
        public const string Charisma = "Charisma";

        public static readonly List<string> ListStatNames = new List<string>
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        };
    }
}
