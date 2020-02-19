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
        private const int DefaultPoints = 20; //default starting points
        private const int DefaultStat = 10; //default stat starting value
        private const int NumStats = 6; //number of stats

        public int[] Stat { get; set; }
        public int[] Spent { get; set; }
        public int Points { get; set; }
        public Races RaceStats { get; set; }

        /*
        Constructor defaults to 20 points if no value is provided
        */
        public PointBuyCalculator()
        {
            Stat = new int[NumStats];
            Spent = new int[NumStats];
            Points = DefaultPoints;
            for (int i =0 ; i <= NumStats; i++)
            {
                Stat[i] = DefaultStat;
                Spent[i] = 0;
            }
            RaceStats = new Races();
        }

        /*
    Constructor to set points to user provided value
    */
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

        public void newPoints(int newPoints, int newStat)
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
        ///  Increments or decrements stat.
        ///  If passed bool is true, stat will increment
        ///  If passed bool is false, stat will decrement
        /// </summary>
        /// <param name="s">stat to increase/decrease</param>
        /// <param name="increase">true = increment, false = decrement</param>
        public void IncrementStat(int s, bool increase)
        {
            int step = 0; //value to be added/subtracted
            if (increase)
            {
                //Check if enough points avail then increment stat
                if ( Points > 0 && Stat[s] < StatCap && FindCost(Stat[s], true) <= Points )
                {
                    step = (FindCost(Stat[s], true));
                    Points -= step;
                    Spent[s] += step;
                    Stat[s]++;
                }
            }

            else if (!increase)
            {
                //Check if stat[s] is above floor, then decrement stat
                if (Stat[s] > StatFloor)
                {
                    step += (FindCost(Stat[s], false));
                    Points += step;
                    Spent[s] -= step;
                    Stat[s]--;
                }
            }   
        }


        /// <summary>
        ///  Calculates the amount of points it costs to increment or decrement a stat
        ///  Based on pathfinder point buy costs
        /// </summary>
        /// <param name="input">Starting value</param>
        /// <param name="increase">true = increase, false = decrease</param>
        /// <returns></returns>
        protected int FindCost(int input, bool increase)
        {
            //initialize cost
            int cost = 0; 

            //Convert input number to user's target value (eg. User is at 10, wants to go to 11.. convert 10 to 11 to find cost)
            if (increase && input > 9)
            {
                input += 1;
            }

            else if ( !increase && input <=10 )
            {
                input -= 1;
            }
        
            //Find cost. Forumla changes depending on if number is below 10, between 10 and 14, and 1+
            if ( input > 10 && input < 14)
            {
                cost = 1;
            }

            if (input > 13)
            {
                cost = (int)Math.Floor((decimal)((input - 10) / 2));
            }

            if (input < 10)
            {
                cost = (int)Math.Ceiling((decimal) ((10 - input) / 2.0)) * -1;
            }

            /*Returns absolute value of calculated cost.
        Shouldn't have to convert absolute value since everything is cast to int but does anyway to prevent unforseen errors */
            return Math.Abs(cost);
        }

        //Returns calculated modifier for a given stat. 
        public int FindMod(int i)
        {

            int mod = 0;  //calculated stat modifier to be returned.
            if (i < 10)
            {
                mod = (int) Math.Floor( (10 - (decimal) i) / -2 );
            }
            else if (i >= 10)
            {
                mod = (int) Math.Floor( (decimal)(i - 10) / 2) ;
            }
            return mod;
        }

        //Returns total stat including racial bonus
        public int FindTotalStat(int s, int r)
        {
            return (Stat[s] + r);
        }

        //Returns modifier for total stat + racial bonus
        public int FindTotalMod(int s, int r)
        {
            return FindMod(Stat[s]) + ( (int)Math.Floor((decimal)r / 2) );
        }

        //Reset races to defualt values
        public void ResetRaces()
        {
            RaceStats = new Races();
        }
    }
}
