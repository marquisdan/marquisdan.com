using System;

namespace marquisdanWAP.Pathfinder
{
    /// <summary>
    /// Does math for point buy systems for pathfinder utility
    /// </summary>
    /// 
    public class PointBuyCalculator
    {
        private const int StatFloor = 7; //minimum allowed stat
        private const int StatCap = 18; //maximum allowed stat;
        protected internal const int DefaultPoints = 20; //default starting points
        protected internal const int DefaultStat = 10; //default stat starting value
        private const int NumStats = 6; //number of stats

        public int[] Stat { get; set; }
        public int[] Spent { get; set; }
        public int Points { get; set; }
        public Races RaceStats { get; set; }

        /// <summary>
        /// Non parameterized constructor defaults to 20 points
        /// </summary>
        public PointBuyCalculator()
        {
            Stat = new int[NumStats];
            Spent = new int[NumStats];
            Points = DefaultPoints;
            for (int i =0 ; i < NumStats; i++)
            {
                Stat[i] = DefaultStat;
                Spent[i] = 0;
            }
            RaceStats = new Races();
        }

        /// <summary>
        /// Paramaterized constructor creates a calculator with a given number of points to spend
        /// </summary>
        /// <param name="startingPoints"></param>
        /// <param name="startingStat"></param>
        public PointBuyCalculator(int startingPoints, int startingStat)
        {
            Stat = new int[NumStats];
            Spent = new int[NumStats];
            Points = startingPoints;
            for (int i = 0; i < NumStats; i++)
            {
                Stat[i] = startingStat;
                Spent[i] = 0;
            }
            RaceStats = new Races();
        }

        /// <summary>
        /// Resets points to a custom value
        /// </summary>
        /// <param name="newPoints"></param>
        /// <param name="newStat"></param>
        public void ResetPoints(int newPoints, int newStat)
        {
            Stat = new int[NumStats];
            Spent = new int[NumStats];
            Points = newPoints;
            for (int i = 0; i < NumStats; i++)
            {
                Stat[i] = newStat;
                Spent[i] = 0;
            }
        }

        /// <summary>
        /// Sets points to default value
        /// </summary>
        public void ResetPointsToDefault()
        {
            ResetPoints(DefaultPoints, DefaultStat);
        }

        /// <summary>
        /// Increase a stat (unless we are already at max)
        /// </summary>
        /// <param name="s"></param>
        internal void IncrementStat(int s)
        {
            //Check if enough points avail & we are under max, then increment stat
            if (Points > 0 && Stat[s] < StatCap && PointBuyUtils.FindCost(Stat[s], true) <= Points)
            {
                var step = (PointBuyUtils.FindCost(Stat[s], true));
                Points -= step;
                Spent[s] += step;
                Stat[s]++;
            }
        }

        /// <summary>
        /// Decrease a stat (unless we are already at min)
        /// </summary>
        /// <param name="s"></param>
        internal void DecrementStat(int s)
        {
            //Check if stat[s] is above floor, then decrement stat
            if (Stat[s] > StatFloor)
            {
                var step = (PointBuyUtils.FindCost(Stat[s], false));
                Points += step;
                Spent[s] -= step;
                Stat[s]--;
            }
        }

        //Returns total stat including racial bonus
        public int FindTotalStat(int s, int r)
        {
            return (Stat[s] + r);
        }

        //Returns modifier for total stat + racial bonus
        public int FindTotalMod(int s, int r)
        {
            return PointBuyUtils.FindMod(Stat[s]) + ( (int)Math.Floor((decimal)r / 2) );
        }

        //Reset races to default values
        public void ResetRaces()
        {
            RaceStats = new Races();
        }
    }
}
