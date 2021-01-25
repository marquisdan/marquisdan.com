using System;

namespace PathfinderLogicLibrary.Utils.PointBuy
{
    public class PointBuyUtil : IPointBuyUtil
    {

        public int StatFloor => 7;
        public int StatCap => 18;
        public int DefaultStatValue => 10;
        public int DefaultStartingPoints => 20;

        public int FindIncreaseCost(int input)
        {
            return FindCost(input, true);
        }

        public int FindDecreaseCost(int input)
        {
            return FindCost(input, false);
        }


        public int FindCost(int input, bool increase)
        {
            //First, adjust input up or down depending on if we are increasing or decreasing
            if (increase && input > 9)
            {
                input += 1;
            }

            else if (!increase && input <= 10)
            {
                input -= 1;
            }

            //Next find the marginal cost of the desired value 
            var cost = FindMarginalCost(input);

            //Returns absolute value of calculated cost.
            return Math.Abs(cost);
        }

        private int FindMarginalCost(int input)
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
                return (int)Math.Floor((decimal)((input - 10) / 2.0));
            }

            if (input < 10)
            {
                return (int)Math.Ceiling((decimal)((10 - input) / 2.0)) * -1;
            }

            throw new ArithmeticException("Number out of range!");
        }

        public int CalculateMod(int i)
        {
            if (i < 10)
            {
                return (int)Math.Floor((10 - (decimal)i) / -2);
            }

            return (int)Math.Floor((decimal)(i - 10) / 2);
        }
    }
}
