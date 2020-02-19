namespace Pathfinder
{
    /// <summary>
    /// Summary description for races
    /// </summary>
    public class Races
    {
        private const int StatBlock = 7; // 0-5 are stats (STR/CON/DEX/INT/WIS/CHA), 6 is a flag to let users choose their own bonus stat.
        private const int CoreRaces = 7; //Number of Core Races

        private const int NumRaces = CoreRaces; //Number of races to be generated;

        public int[,] RaceArray { get; set; }


        public Races()
        {
            SetupRaces();
        }

        /// <summary>
        /// Initializes race aray
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
    }
}