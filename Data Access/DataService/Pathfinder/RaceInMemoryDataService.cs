using System.Collections.Generic;
using System.Threading.Tasks;
using DBAccess.Models.Models;

namespace DBAccess.DataService.Pathfinder
{
    public class RaceInMemoryDataService : IRaceDataService
    {
        private struct StatNames
        {
            internal const string Strength  = "Strength";
            internal const string Dexterity  = "Dexterity";
            internal const string Constitution = "Constitution";
            internal const string Intelligence = "Intelligence";
            internal const string Wisdom = "Wisdom";
            internal const string Charisma = "Charisma";
       }


        public Dictionary<string, Dictionary<string, int>> GetCoreRaceStatsDictionary()
        {
            return new Dictionary<string, Dictionary<string, int>>()
            {
                {
                    "Dwarf", new Dictionary<string, int>
                    {
                        {StatNames.Strength, 0},
                        {StatNames.Dexterity, 0},
                        {StatNames.Constitution, 2},
                        {StatNames.Intelligence, 0},
                        {StatNames.Wisdom, 2},
                        {StatNames.Charisma, -2},
                    }
                },
                {
                    "Elf", new Dictionary<string, int>
                    {
                        {StatNames.Strength, 0},
                        {StatNames.Dexterity, 2},
                        {StatNames.Constitution, -2},
                        {StatNames.Intelligence, 2},
                        {StatNames.Wisdom, 0},
                        {StatNames.Charisma, 0},
                    }
                },
                {
                    "Human", new Dictionary<string, int>
                    {
                        {StatNames.Strength, 0},
                        {StatNames.Dexterity, 0},
                        {StatNames.Constitution, 0},
                        {StatNames.Intelligence, 0},
                        {StatNames.Wisdom, 0},
                        {StatNames.Charisma, 0},
                    }
                },
            };
        }

        public Task<List<IRaceModel>> GetRaces()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IRaceModel>> GetRaces(string category)
        {
            throw new System.NotImplementedException();
        }

        public Task SeedRaces()
        {
            throw new System.NotImplementedException();
        }
    }
}