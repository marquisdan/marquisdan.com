using System.Collections.Generic;
using System.Threading.Tasks;
using DBAccess.Models.Models;

namespace DBAccess.DataService.Pathfinder
{
    public interface IRaceDataService
    {
        Dictionary<string, Dictionary<string, int>> GetCoreRaceStatsDictionary();

        Task<List<IRaceModel>> GetRaces();

        Task<List<IRaceModel>> GetRaces(string category);

        Task SeedRaces();
    }
}