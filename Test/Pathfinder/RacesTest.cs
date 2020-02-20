using System.Linq;
using marquisdanWAP.Pathfinder;
using NUnit.Framework;

namespace marquisdanWAP.Test.Pathfinder
{
    public class RacesTest
    {
        public class InitializerTests
        {
            [Test]
            public void InitializerTest()
            {
                var result = new Races();

                Assert.That(result.RaceArray.Length, Is.EqualTo(Races.NumCoreRaces * Races.StatBlockSize));
            }

            [Test]
            public void CoreRaceDictionary()
            {
                var results = Races.GetCoreRaceDictionary();

                Assert.That(results.Count, Is.EqualTo(Races.NumCoreRaces));
                foreach (var race in results)
                {
                        Assert.That(race.Value.Length, Is.EqualTo(Races.StatBlockSize));
                }
            }
        }
    }
}