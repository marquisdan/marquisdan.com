using System.Collections.Generic;
using System.Linq.Expressions;

namespace marquisdanWAP.Pathfinder
{
    /// <summary>
    /// Keeps track of race statistics for use in other classes
    /// </summary>
    public class Races
    {
        internal const int StatBlockSize = 7; // 0-5 are stats (STR/CON/DEX/INT/WIS/CHA), 6 is a flag to let users choose their own bonus stat.
        internal const int NumCoreRaces = 7; //Number of Core Races
        private const int NumRaces = NumCoreRaces; //Number of races to be generated;

        #region Race Keys
        internal const string KEY_DWARF = "dwarf";
        internal const string KEY_ELF = "elf";
        internal const string KEY_GNOME = "gnome";
        internal const string KEY_HALF_ELF = "half-elf";
        internal const string KEY_HALF_ORC = "half-orc";
        internal const string KEY_HALFlING = "halfling";
        internal const string KEY_HUMAN = "human";
        private string[] KEY_CORE_RACES = { KEY_DWARF, KEY_ELF, KEY_GNOME, KEY_HALF_ELF, KEY_HALFlING, KEY_HUMAN };
        #endregion

        //private const string CoreRaceKeys

        public int[,] RaceArray { get; set; }

        public Races()
        {
            SetupRaces();
        }

        /// <summary>
        /// Initializes race array
        /// TODO: Update to get from a JSON or similar
        /// TODO: Update to dictionary
        /// </summary>
        private void SetupRaces()
        {  
            RaceArray = new[,]
            {
            /*Key: 
            /STR, DEX, CON, INT, WIS, CHA, FLAG */
            // Core Races
                //Dwarf
                {0,0,2,0,2,-2,0},
                //Elf
                {0,2,-2,2,0,0,0},
                //Gnome
                {-2,0,2,0,0,2,0},
                //Half-Elf
                {0,0,0,0,0,0,1},
                //Half-Orc
                {0,0,0,0,0,0,1},
                //Halfling
                {-2,2,0,0,0,2,0},
                //Human
                {0,0,0,0,0,0,1}
            };
        }

        /// <summary>
        /// Get a dictionary of each race and its statblock
        /// Returns races from all rulebooks
        /// </summary>
        /// <returns></returns>
        protected static Dictionary<string, int[]> GetRaceDictionary()
        {
            var completeRaceDictionary = new Dictionary<string, int[]>();
            foreach (var race in GetCoreRaceDictionary())
            {
                completeRaceDictionary.Add(race.Key, race.Value);
            }
            return completeRaceDictionary;
        }

        /// <summary>
        /// Get a dictionary of all core races and stats
        /// </summary>
        /// <returns></returns>
        protected internal static Dictionary<string, int[]> GetCoreRaceDictionary()
        {
            return new Dictionary<string, int[]>
            {
                {KEY_DWARF, new[] {0, 0, 2, 0, 2, -2, 0}},
                {KEY_ELF, new[] {0, 2, -2, 2, 0, 0, 0}},
                {KEY_GNOME, new[] {0, 2, -2, 2, 0, 0, 0}},
                {KEY_HALF_ELF, new[] {0, 0, 0, 0, 0, 0, 1}},
                {KEY_HALF_ORC, new[] {0, 0, 0, 0, 0, 0, 1}},
                {KEY_HALFlING, new[] {-2, 2, 0, 0, 0, 2, 0}},
                {KEY_HUMAN, new[] {0, 0, 0, 0, 0, 0, 1}}
            };
        }
    }
}