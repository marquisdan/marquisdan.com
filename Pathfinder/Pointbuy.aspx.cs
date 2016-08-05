using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Pathfinder_Pointbuy : System.Web.UI.Page
{
    private const int defaultPoints = 20; //default number of points
    private const int defaultStat = 10; //default stat value 
    private const int numStats = 5; //for array size
    private const int rows = 6; //Rows in the table (used in setting up label arrays
    private const int cols = 7; //cols in table (used in setting up label arrays)


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            pointBuyCalculator pb = new pointBuyCalculator(defaultPoints, defaultStat);
            lblCurrentPointsVal.Text = pb.points.ToString();
            Session["pb"] = pb;
            LinkAndUpdateLabels();
            Page.Title = "Dan's awesome Pathfinder Calculator!";
        }
    }

    /**
    Button Event handlers, aka why I need to learn JavaScript/Ajax, holy crap
    */
    //Str Increase
    protected void btnStrIncrease_Click(object sender, CommandEventArgs e)
    {
        Increase(0);
        LinkAndUpdateLabels();
    }
    //Str Decrease
    protected void btnStrDecrease_Click(object sender, EventArgs e)
    {
        Decrease(0);
        LinkAndUpdateLabels();
    }

    //Dex Increase
    protected void btnDexIncrease_Click(object sender, EventArgs e)
    {
        Increase(1);
        LinkAndUpdateLabels();
    }
    //Dex Decrease
    protected void btnDexDecrease_Click(object sender, EventArgs e)
    {
        Decrease(1);
        LinkAndUpdateLabels();
    }

    //Con Increase
    protected void btnConIncrease_Click(object sender, EventArgs e)
    {
        Increase(2);
        LinkAndUpdateLabels();
    }
    //Con Decrease
    protected void btnConDecrease_Click(object sender, EventArgs e)
    {
        Decrease(2);
        LinkAndUpdateLabels();
    }

    //Int Increase
    protected void btnIntIncrease_Click(object sender, EventArgs e)
    {
        Increase(3);
        LinkAndUpdateLabels();
    }
    //Int Decrease
    protected void btnIntDecrease_Click(object sender, EventArgs e)
    {
        Decrease(3);
        LinkAndUpdateLabels();
    }

    //Wis Increase
    protected void btnWisIncrease_Click(object sender, EventArgs e)
    {
        Increase(4);
        LinkAndUpdateLabels();
    }
    //Wis Decrease
    protected void btnWisDecrease_Click(object sender, EventArgs e)
    {
        Decrease(4);
        LinkAndUpdateLabels();
    }
    //Cha Increase
    protected void btnChaIncrease_Click(object sender, EventArgs e)
    {
        Increase(5);
        LinkAndUpdateLabels();
    }
    //Cha Decrease
    protected void btnChaDecrease_Click(object sender, EventArgs e)
    {
        Decrease(5);
        LinkAndUpdateLabels();
    }

    //Reset
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlStartingPoints.SelectedIndex = 2;
        Reset();
    }

    //Changes amount of points for Pointbuy Utility via dropdown list
    protected void ddlStartingPoints_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Debug line
        // lblStartingPointsTitle.Text = ddlStartingPoints.SelectedValue.ToString();
        if (ddlStartingPoints.SelectedIndex != 4)
        {
            hideCustomPointValue(); //Hide custom point text box and button
            pointBuyCalculator pb = new pointBuyCalculator(int.Parse(ddlStartingPoints.SelectedValue), defaultStat);
            lblCurrentPointsVal.Text = pb.points.ToString();
            Session["pb"] = pb;
            LinkAndUpdateLabels();
        }
        else
        {
            showCustomPointValue(); //Show custom point text box and button
            pointBuyCalculator pb = new pointBuyCalculator(defaultPoints, defaultStat);
            tbxCustomPoints.Text = defaultPoints.ToString();
            Session["pb"] = pb;
            LinkAndUpdateLabels();
        }
    }

    //Button to set custom points
    protected void btnSetPoints_Click(object sender, EventArgs e)
    {
        try
        {
            tbxCustomPoints.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
            pb.newPoints(int.Parse(tbxCustomPoints.Text), defaultStat);
            Session["pb"] = pb;
            LinkAndUpdateLabels();
        }
        catch
        {
            //This is some temporary shit until I stop being lazy and add validation to the front end.
            tbxCustomPoints.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
        }
    }

    //Dropdown list to set race for user
    protected void ddlRace_SelectedIndexChanged(object sender, EventArgs e)
    {
        pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
        pb.resetRaces(); //Set race stats to default
        //Check for custom point flag
        if (pb.raceStats.raceArray[ddlRace.SelectedIndex, 6] != 1)
        {
            //Hide custom menu, recalculate
            ddlCustomStatChoice.Visible = false;
            lblCustomStatChoiceTitle.Visible = false;
            LinkAndUpdateLabels();
        }
        else
        {
            //Show Custom Menu
            lblCustomStatChoiceTitle.Visible = true;
            ddlCustomStatChoice.Visible = true;
            LinkAndUpdateLabels();
        }

        Session["pb"] = pb;
    }

    //dropdown list to change custom stat info
    protected void ddlCustomStatChoice_SelectedIndexChanged(object sender, EventArgs e)
    {
        pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
        pb.resetRaces();
        pb.raceStats.raceArray[(ddlRace.SelectedIndex), ddlCustomStatChoice.SelectedIndex] = 2;
        LinkAndUpdateLabels();
        Session["pb"] = pb;
    }

    /*Reset everything to default */
    private void Reset()
    {
        /* Hide GUI for custom point values */
        hideCustomPointValue();

        pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
        pb.resetRaces();
        pb.newPoints(defaultPoints, defaultStat);

        Session["pb"] = pb;
        LinkAndUpdateLabels();

    }

    /* Creates an array to manage labels, updates gui */
    private void LinkAndUpdateLabels()
    {
        pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
        Label[,] statLabel = new Label[rows, cols];
        /* STR */
        statLabel[0, 0] = lblStrTitle;
        statLabel[0, 1] = lblStrValue;
        statLabel[0, 2] = lblStrMod;
        statLabel[0, 3] = lblStrPointsSpent;
        statLabel[0, 4] = lblStrRacialBonus;
        statLabel[0, 5] = lblStrFinalValue;
        statLabel[0, 6] = lblStrFinalMod;

        /* DEX */
        statLabel[1, 0] = lblDexTitle;
        statLabel[1, 1] = lblDexValue;
        statLabel[1, 2] = lblDexMod;
        statLabel[1, 3] = lblDexPointsSpent;
        statLabel[1, 4] = lblDexRacialBonus;
        statLabel[1, 5] = lblDexFinalValue;
        statLabel[1, 6] = lblDexFinalMod;

        /*CON*/
        statLabel[2, 0] = lblConTitle;
        statLabel[2, 1] = lblConValue;
        statLabel[2, 2] = lblConMod;
        statLabel[2, 3] = lblConPointsSpent;
        statLabel[2, 4] = lblConRacialBonus;
        statLabel[2, 5] = lblConFinalValue;
        statLabel[2, 6] = lblConFinalMod;

        /*INT*/
        statLabel[3, 0] = lblIntTitle;
        statLabel[3, 1] = lblIntValue;
        statLabel[3, 2] = lblIntMod;
        statLabel[3, 3] = lblIntPointsSpent;
        statLabel[3, 4] = lblIntRacialBonus;
        statLabel[3, 5] = lblIntFinalValue;
        statLabel[3, 6] = lblIntFinalMod;

        /*WIS*/
        statLabel[4, 0] = lblWisTitle;
        statLabel[4, 1] = lblWisValue;
        statLabel[4, 2] = lblWisMod;
        statLabel[4, 3] = lblWisPointsSpent;
        statLabel[4, 4] = lblWisRacialBonus;
        statLabel[4, 5] = lblWisFinalValue;
        statLabel[4, 6] = lblWisFinalMod;

        /*CHA*/
        statLabel[5, 0] = lblChaTitle;
        statLabel[5, 1] = lblChaValue;
        statLabel[5, 2] = lblChaMod;
        statLabel[5, 3] = lblChaPointsSpent;
        statLabel[5, 4] = lblChaRacialBonus;
        statLabel[5, 5] = lblChaFinalValue;
        statLabel[5, 6] = lblChaFinalMod;

        //Update columns for each row
        for (int r = 0; r < rows; r++)
        {
            /*Key
             0 = Title, 
             1 = Current value, 2 = Mod, 3 = Points spent,
             4 = Racial, 5 = Final Value 6 = Final Mod */
            statLabel[r, 1].Text = pb.stat[r].ToString();
            statLabel[r, 2].Text = pb.findMod(pb.stat[r]).ToString();
            statLabel[r, 3].Text = pb.spent[r].ToString();
            statLabel[r, 4].Text = pb.raceStats.raceArray[ddlRace.SelectedIndex, r].ToString();
            statLabel[r, 5].Text = pb.findTotalStat(r, pb.raceStats.raceArray[ddlRace.SelectedIndex, r]).ToString();
            statLabel[r, 6].Text = pb.findTotalMod(r, pb.raceStats.raceArray[ddlRace.SelectedIndex, r]).ToString();
        }
        //Update total points
        lblCurrentPointsVal.Text = pb.points.ToString();
        //update session
        Session["pb"] = pb;
    }

    private void Increase(int i)
    {
        pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
        pb.incrementStat(i, true);
        Session["pb"] = pb;
    }

    private void Decrease(int i)
    {
        pointBuyCalculator pb = (pointBuyCalculator)Session["pb"];
        pb.incrementStat(i, false);
        Session["pb"] = pb;
    }

    private void showCustomPointValue()
    {
        tbxCustomPoints.Visible = true;
        btnSetPoints.Visible = true;
    }

    private void hideCustomPointValue()
    {
        tbxCustomPoints.Visible = false;
        btnSetPoints.Visible = false;
    }


}