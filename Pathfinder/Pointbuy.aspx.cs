﻿using System;
using System.Web.UI.WebControls;
using marquisdanWAP.Pathfinder;


public partial class Pathfinder_Pointbuy : System.Web.UI.Page
{
    private const int DefaultPoints = 20; //default number of points
    private const int DefaultStat = 10; //default stat value 
    private const int NumStats = 5; //for array size
    private const int Rows = 6; //Rows in the table (used in setting up label arrays
    private const int Cols = 7; //cols in table (used in setting up label arrays)


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            var pb = new PointBuyCalculator(DefaultPoints, DefaultStat);
            lblCurrentPointsVal.Text = pb.Points.ToString();
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
            HideCustomPointValue(); //Hide custom point text box and button
            PointBuyCalculator pb = new PointBuyCalculator(int.Parse(ddlStartingPoints.SelectedValue), DefaultStat);
            lblCurrentPointsVal.Text = pb.Points.ToString();
            Session["pb"] = pb;
            LinkAndUpdateLabels();
        }
        else
        {
            ShowCustomPointValue(); //Show custom point text box and button
            PointBuyCalculator pb = new PointBuyCalculator(DefaultPoints, DefaultStat);
            tbxCustomPoints.Text = DefaultPoints.ToString();
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
            PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
            pb.newPoints(int.Parse(tbxCustomPoints.Text), DefaultStat);
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
        PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
        pb.ResetRaces(); //Set race stats to default
        //Check for custom point flag
        if (pb.RaceStats.RaceArray[ddlRace.SelectedIndex, 6] != 1)
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
        PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
        pb.ResetRaces();
        pb.RaceStats.RaceArray[(ddlRace.SelectedIndex), ddlCustomStatChoice.SelectedIndex] = 2;
        LinkAndUpdateLabels();
        Session["pb"] = pb;
    }

    /*Reset everything to default */
    private void Reset()
    {
        /* Hide GUI for custom point values */
        HideCustomPointValue();

        PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
        pb.ResetRaces();
        pb.newPoints(DefaultPoints, DefaultStat);

        Session["pb"] = pb;
        LinkAndUpdateLabels();

    }

    /* Creates an array to manage labels, updates gui */
    private void LinkAndUpdateLabels()
    {
        PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
        Label[,] statLabel = new Label[Rows, Cols];
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
        for (int r = 0; r < Rows; r++)
        {
            /*Key
             0 = Title, 
             1 = Current value, 2 = Mod, 3 = Points spent,
             4 = Racial, 5 = Final Value 6 = Final Mod */
            statLabel[r, 1].Text = pb.Stat[r].ToString();
            statLabel[r, 2].Text = pb.PointBuyUtils.FindMod(pb.Stat[r]).ToString();
            statLabel[r, 3].Text = pb.Spent[r].ToString();
            statLabel[r, 4].Text = pb.RaceStats.RaceArray[ddlRace.SelectedIndex, r].ToString();
            statLabel[r, 5].Text = pb.PointBuyUtils.FindTotalStat(r, pb.RaceStats.RaceArray[ddlRace.SelectedIndex, r]).ToString();
            statLabel[r, 6].Text = pb.PointBuyUtils.FindTotalMod(r, pb.RaceStats.RaceArray[ddlRace.SelectedIndex, r]).ToString();
        }
        //Update total points
        lblCurrentPointsVal.Text = pb.Points.ToString();
        //update session
        Session["pb"] = pb;
    }

    private void Increase(int i)
    {
        PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
        pb.IncrementStat(i, true);
        Session["pb"] = pb;
    }

    private void Decrease(int i)
    {
        PointBuyCalculator pb = (PointBuyCalculator)Session["pb"];
        pb.IncrementStat(i, false);
        Session["pb"] = pb;
    }

    private void ShowCustomPointValue()
    {
        tbxCustomPoints.Visible = true;
        btnSetPoints.Visible = true;
    }

    private void HideCustomPointValue()
    {
        tbxCustomPoints.Visible = false;
        btnSetPoints.Visible = false;
    }


}