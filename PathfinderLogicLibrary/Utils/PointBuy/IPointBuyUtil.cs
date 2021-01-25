namespace PathfinderLogicLibrary.Utils.PointBuy
{
    public interface IPointBuyUtil
    {

        /// <summary>
        /// Minimum stat value
        /// </summary>
        int StatFloor { get; }
        /// <summary>
        /// Maximum stat value
        /// </summary>
        int StatCap { get; }
        /// <summary>
        /// Default starting value for every stat
        /// </summary>
        int DefaultStatValue { get; }
        /// <summary>
        /// Default starting points for the pointbuy calculator
        /// </summary>
        int DefaultStartingPoints { get; }

        /// <summary>
        /// Find point cost to increase a stat
        /// </summary>
        /// <param name="input"> The stat value to increase</param>
        /// <returns>The cost to increase the stat</returns>
        int FindIncreaseCost(int input);

        /// <summary>
        /// Find point cost to decrease a stat
        /// </summary>
        /// <param name="input"> The stat value to decrease</param>
        /// <returns>The cost to decrease the stat</returns>
        int FindDecreaseCost(int input);

        /// <summary>
        ///  Calculates the amount of points it costs to increment or decrement a stat
        ///  Based on pathfinder point buy costs
        /// </summary>
        /// <param name="input">Starting value</param>
        /// <param name="increase">true = increase, false = decrease</param>
        /// <returns>int - Cost to increase or decrease</returns>
        int FindCost(int input, bool increase);

        /// <summary>
        /// Find modifier value for a given stat value
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Modifier bonus or penalty </returns>
        int CalculateMod(int i);
    }
}