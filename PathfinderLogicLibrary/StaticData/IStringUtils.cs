using System.Collections.Generic;

namespace PathfinderLogicLibrary.Utils
{
    public interface IStringUtils
    {
        string BuildRaceBonusString(List<string> bonusList, List<string> penaltyList);
    }
}