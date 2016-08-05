using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for races
/// </summary>
public class races
{
    private const int statBlock = 7; // 0-5 are stats (STR/CON/DEX/INT/WIS/CHA), 6 is a flag to let users choose their own bonus stat.
    private const int coreRaces = 7; //Number of Core Races

    private const int numRaces = coreRaces; //Number of races to be generated;

    public int[,] raceArray { get; set; }


    public races()
    {
        setupRaces();
    }

    private void setupRaces()
    {   //Initialze array 
        //I need to make damn database already
        raceArray = new int[numRaces, statBlock]
        {
            /*Key: 
            /STR, DEX, CON, INT, WIS, CHA, FLAG */
            /**********
            Core Races
            *********/
            //Dwarf
            {0,0,2,0,2,-2,0},
            //Elf
            {0,2,-2,2,0,0,0},
            //Gnome
            {-2,0,2,0,0,2,0},
            //Half-Elf
            {0,0,0,0,0,0,1},
            //Half-Orc
            {0,0,0,0,0,0,1},
            //Halfling
            {-2,2,0,0,0,2,0},
            //Human
            {0,0,0,0,0,0,1}
        };
        
    }


}