using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderLogicLibrary.Utils
{
    public class StringUtils : IStringUtils
    {
        public string BuildRaceBonusString(List<string> bonusList, List<string> penaltyList)
        {
            var returnString = new StringBuilder();

            //Return out right away for filthy humans with 0 bonuses
            if (bonusList.Count == 0 && penaltyList.Count == 0)
            {
                return returnString.ToString();
            }

            //Add bonuses
            if (bonusList.Count > 0)
            {
                AppendRacialsToStringBuilder(bonusList, returnString);
            }

            //Add penalties
            if (penaltyList.Count > 0)
            {
                if (bonusList.Count > 0)
                {
                    returnString.Append(",");
                }
                returnString.Append(" ");
                AppendRacialsToStringBuilder(penaltyList, returnString);
            }

            return returnString.ToString();
        }

        private static void AppendRacialsToStringBuilder(List<string> bonusList, StringBuilder returnString)
        {
            for (int i = 0; i < bonusList.Count; i++)
            {
                returnString.Append($" {bonusList[i]}");
                if (i + 1 != bonusList.Count)
                {
                    returnString.Append(",");
                }
            }
        }
    }
}
