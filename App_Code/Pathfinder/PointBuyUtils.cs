using System;

namespace marquisdanWAP.Pathfinder
{
    public static class PointBuyUtils
    {
        /// <summary>
        ///  Calculates the amount of points it costs to increment or decrement a stat
        ///  Based on pathfinder point buy costs
        /// </summary>
        /// <param name="input">Starting value</param>
        /// <param name="increase">true = increase, false = decrease</param>
        /// <returns></returns>
        internal static int FindCost(int input, bool increase)
        {
            //First, adjust input up or down depending on if we are increasing or decreasing
            if (increase && input > 9)
            {
                input += 1;
            }

            else if ( !increase && input <=10 )
            {
                input -= 1;
            }
        
            //Next find the marginal cost of the desired value 
            var cost = FindMarginalCost(input);

            /*Returns absolute value of calculated cost.
            Shouldn't have to convert absolute value since everything is cast to int but does anyway to prevent unforseen errors */
            return Math.Abs(cost);
        }

        /// <summary>
        /// Get marginal point cost for a given value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static int FindMarginalCost(int input)
        {
            if (input == 10)
            {
                return 0;
            }

            if (input > 10 && input < 14)
            {
                return 1;
            }

            if (input >= 14)
            {
                return (int) Math.Floor((decimal) ((input - 10) / 2.0));
            }

            if (input < 10)
            {
                return (int) Math.Ceiling((decimal) ((10 - input) / 2.0)) * -1;
            }

            throw new ArithmeticException("Number out of range!");
        }

        internal static int FindMod(int i)
        {
            if (i < 10)
            {
               return (int) Math.Floor( (10 - (decimal) i) / -2 );
            }

            return (int) Math.Floor( (decimal)(i - 10) / 2) ;
        }
    }
}