using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBAccess.DataAccess;
using DBAccess.Models.Models;

namespace DBAccess.DataService.Pathfinder
{
    public class RaceSqlDataService : IRaceDataService
    {
        private readonly  ISqlDataAccess _dataAccess;
        private const string DbName = "PathfinderDB";

        public RaceSqlDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Dictionary<string, Dictionary<string, int>> GetCoreRaceStatsDictionary()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<IRaceModel>> GetRaces()
        {
            var races = await _dataAccess.LoadData<RaceModel, dynamic>("dbo.GetAllRaces",
                                                                    new {  },
                                                                    DbName);
            return races.ToList<IRaceModel>();
        }

        public async Task<List<IRaceModel>> GetRaces(string category)
        {
            var races = await _dataAccess.LoadData<RaceModel, dynamic>("dbo.GetRacesByCategory",
                                                            new { category },
                                                            DbName);
            return races.ToList<IRaceModel>();
        }

        public async Task<List<IRaceModel>> GetRacesByBook(string bookName)
        {
            var races = await _dataAccess.LoadData<RaceModel, dynamic>("dbo.GetRacesByBook",
                                                                new {bookName},
                                                                DbName);
            return races.ToList<IRaceModel>();
        }

        public async Task SeedRaces()
        {
            await _dataAccess.LoadData<object, dynamic>("dbo.SeedRaces", new { }, DbName);
        }
    }
}
