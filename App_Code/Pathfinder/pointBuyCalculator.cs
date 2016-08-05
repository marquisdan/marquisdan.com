using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Does math for point buy systems for pathfinder utility
/// </summary>
/// 
public class pointBuyCalculator
{
    private const int statFloor = 7; //minimum allowed stat
    private const int statCap = 18; //maximum allowed stat;
    private const int defaultPoints = 20; //default starting points
    private const int defaultStat = 10; //default stat starting value
    private const int numStats = 6; //number of stats

    public int[] stat { get; set; }
    public int[] spent { get; set; }
    public int points { get; set; }
    public races raceStats { get; set; }

    /*
    Constructor defaults to 20 points if no value is provided
    */
    public pointBuyCalculator()
    {
        stat = new int[numStats];
        spent = new int[numStats];
        points = defaultPoints;
        for (int i =0 ; i <= numStats; i++)
        {
            stat[i] = defaultStat;
            spent[i] = 0;
        }
        raceStats = new races();
    }

    /*
    Constructor to set points to user provided value
    */
    public pointBuyCalculator(int startingPoints, int startingStat)
    {
        stat = new int[numStats];
        spent = new int[numStats];
        points = startingPoints;
        for (int i = 0; i < numStats; i++)
        {
            stat[i] = startingStat;
            spent[i] = 0;
        }
        raceStats = new races();
    }

    public void newPoints(int newPoints, int newStat)
    {
        stat = new int[numStats];
        spent = new int[numStats];
        points = newPoints;
        for (int i = 0; i < numStats; i++)
        {
            stat[i] = newStat;
            spent[i] = 0;
        }
    }
    /*
    Increments or decrements stat.
    If passed bool is true, stat will increment
    If passed bool is false, stat will decrement */
    public void incrementStat(int s, bool increase)
    {
        int step = 0; //value to be added/subtracted
        if (increase)
        {
            //Check if enough points avail then increment stat
            if ( points > 0 && stat[s] < statCap && findCost(stat[s], true) <= points )
            {
                step = (findCost(stat[s], true));
                points -= step;
                spent[s] += step;
                stat[s]++;
            }
        }

        else if (!increase)
        {
            //Check if stat[s] is above floor, then decrement stat
            if (stat[s] > statFloor)
            {
                step += (findCost(stat[s], false));
                points += step;
                spent[s] -= step;
                stat[s]--;
            }
        }   
    }


    /**
    Calculates the amount of points it costs to increment or decrement a stat 
    Based on pathfinder point buy costs 
    */
    protected int findCost(int input, bool increase)
    {
        //initialize cost
        int cost = 0; 

        /**
        Convert intput number to user's target value (eg. User is at 10, wants to go to 11.. convert 10 to 11 to find cost)
        */
        if (increase && input > 9)
        {
            input += 1;
        }

        else if ( !increase && input <=10 )
        {
            input -= 1;
        }
        
        /**
        Find cost. Forumla changes depending on if number is below 10, between 10 and 14, and 1+
        */
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
    public int findMod(int i)
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
    public int findTotalStat(int s, int r)
    {
        return (stat[s] + r);
    }

    //Returns modifier for total stat + racial bonus
    public int findTotalMod(int s, int r)
    {
        return findMod(stat[s]) + ( (int)Math.Floor((decimal)r / 2) );
    }

    //Reset races to defualt values
    public void resetRaces()
    {
        raceStats = new races();
    }
}
