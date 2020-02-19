<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pointbuy.aspx.cs" Inherits="Pathfinder_Pointbuy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marquisdan's Pathfinder Point Buy Utility</title>

    <!--Meta Tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <!-- Javascript to get the dang dropdown menu to work -->
    <!-- See  http://stackoverflow.com/questions/21012382/bootstrap-navbar-dropdown-not-working-in-asp-net -->
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>

    <!-- Link Twitter Bootstrap CSS and my own personal custom CSS -->
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Content/DanCSS.css" rel="stylesheet" type="text/css" /> 

</head>

<body style="background-color: whitesmoke">
<!-- <body style="background-color: green"> -->

    <form id="form1" runat="server">

        <!--Navbar-->
        <nav class="navbar NavBarGreenWhite">
            <div class="container-fluid">
                <!--Navbar Head -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#MainNavMenu">
                        <span class="sr-only">Collapsed Menu</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <!--Logo/Branding-->
                    <a class="navbar-brand" href="../Default.aspx/">MarquisDan.com</a>
                </div>
            
                <!-- Navbar body (collapsible) -->
                <div class="collapse navbar-collapse nav" id="MainNavMenu">
                    <ul class="nav navbar-nav">

                        <!-- Pathfinder Dropdown menu -->
                        <li class="dropdown">
                            <a href="Pathfinder.aspx" class="dropdown-toggle" data-toggle="dropdown">Pathfinder<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="Pathfinder.aspx">Pathfinder Home </a></li>
                                <li><a href="Pointbuy.aspx">Pathfinder Point Buy Utility</a></li>
                            </ul>
                        </li>

                    </ul>
                </div>
            </div>
        </nav>
        <!-- Script manager for AJAX -->
       <asp:ScriptManager ID ="ScriptManagerPointBuy" runat="server" /> 
        <!-- Update Panel for stat table and menu -->
       <asp:UpdatePanel ID="UpdatePanelPointBuy" runat="server" >
         <ContentTemplate>
             <div class="well-sm" style="background-color: white">
                <h2>Pathfinder Point Buy Utility</h2>
                <!--Stat Options Menu -->
                <table>
                    <thead>
                    </thead>
                    <tbody>
                        <!-- Stat Points -->
                        <tr>
                            <!-- Stat Dropdwon menu and title -->
                            <td>
                                <strong>
                                    <asp:Label AssociatedControlID="ddlStartingPoints" ID="lblStartingPointsTitle" runat="server" Text="Starting Points" ></asp:Label>
                                </strong>
                                <!-- Dropdown list to pick starting points -->
                                <asp:DropDownList ID="ddlStartingPoints" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStartingPoints_SelectedIndexChanged">
                                    <asp:ListItem Value="10">Low Fantasy (10)</asp:ListItem>
                                    <asp:ListItem Value="15">Standard Fantasy (15)</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="20">High Fantasy (20)</asp:ListItem>
                                    <asp:ListItem Value="25">Epic Fantasy (25)</asp:ListItem>
                                    <asp:ListItem Value="-99"> Other</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <!-- Hidden boxes for custom point amounts -->
                            <!-- This textbox and its button are invisible unless the 'other' option is chosen. 
                                    Visibility controlled with code-behind -->
                            <td>
                                <asp:TextBox ID="tbxCustomPoints" runat="server" Width="50px" Visible="False"></asp:TextBox>
                                <asp:Button ID="btnSetPoints" runat="server" Width="50px" Visible="False" Text="Set" OnClick="btnSetPoints_Click" />
                            </td>
                        </tr>

                        <!-- Race Stuff -->
                        <tr>
                            <!-- Race Dropdwon menu and title -->
                            <td>
                                <strong>
                                    <asp:Label AssociatedControlID="ddlRace" ID="lblRaceTitle" runat="server" Text="Race"></asp:Label>
                                </strong>
                                <asp:DropDownList ID="ddlRace" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRace_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">Dwarf (+2 CON/WIS, -2 CHA)</asp:ListItem>
                                    <asp:ListItem>Elf (+2 DEX/INT, -2 CON)</asp:ListItem>
                                    <asp:ListItem>Gnome (+2 CON/CHA, -2 STR)</asp:ListItem>
                                    <asp:ListItem>Half-Elf(+2 to Any)</asp:ListItem>
                                    <asp:ListItem>Half-Orc(+2 to Any)</asp:ListItem>
                                    <asp:ListItem>Halfling(+2 DEX/CHA, -2 STR)</asp:ListItem>
                                    <asp:ListItem>Human(+2 to Any)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <!-- Hidden boxes for custom stats -->
                                <!-- This textbox and its button are invisible unless a custom stat option is chosen. 
                                    Visibility controlled with code-behind -->
                                <strong>
                                    <asp:Label ID="lblCustomStatChoiceTitle" Visible="false" runat="server" Text="Stat"></asp:Label>
                                </strong>
                                <asp:DropDownList ID="ddlCustomStatChoice" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomStatChoice_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">STR</asp:ListItem>
                                    <asp:ListItem>DEX</asp:ListItem>
                                    <asp:ListItem>CON</asp:ListItem>
                                    <asp:ListItem>INT</asp:ListItem>
                                    <asp:ListItem>WIS</asp:ListItem>
                                    <asp:ListItem>CHA</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                    </tbody>
                </table>

                <!--Stat Table -->
                <table class="table table-striped">
                    <!--Head-->
                    <thead>
                        <tr>
                            <th class="text-center">Stat</th>
                            <th class="text-center">Starting Value</th>
                            <th class="hidden-xs  text-center">Mod </th>
                            <th class="hidden-xs text-center">Points spent</th>
                            <th class="hidden-xs text-center">Racial Bonus</th>
                            <th class="text-center">Final Value</th>
                            <th class="text-center">Final Mod</th>
                        </tr>
                    </thead>

                    <!--Body -->
                    <tbody class="text-center">

                        <!-- Str -->
                        <tr>
                            <td>
                                <asp:Label ID="lblStrTitle" runat="server" Text="<strong>STR: </strong>"> </asp:Label>
                            </td>
                            <td class="statMenu">
                                <asp:Button ID="btnStrDecrease" runat="server" Text="-" OnClick="btnStrDecrease_Click" />
                                <asp:Label ID="lblStrValue" runat="server" Text=" 10 "></asp:Label>
                                <asp:Button ID="btnStrIncrease" runat="server" Text="+" OnCommand="btnStrIncrease_Click" />
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblStrMod" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblStrPointsSpent" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="lblStrRacialBonus" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStrFinalValue" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStrFinalMod" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>

                        <!-- Dex -->
                        <tr>
                            <td>
                                <asp:Label ID="lblDexTitle" runat="server" Text="<strong>DEX: </strong>"></asp:Label>
                            </td>
                            <td class="statMenu">
                                <asp:Button ID="btnDexDecrease" runat="server" Text="-" OnClick="btnDexDecrease_Click" />
                                <asp:Label ID="lblDexValue" runat="server" Text=" 10 "></asp:Label>
                                <asp:Button ID="btnDexIncrease" runat="server" Text="+" OnClick="btnDexIncrease_Click" />
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblDexMod" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblDexPointsSpent" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="lblDexRacialBonus" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDexFinalValue" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDexFinalMod" runat="server" Text="0"></asp:Label>
                            </td>

                        </tr>

                        <!-- Con -->
                        <tr>
                            <td>
                                <asp:Label ID="lblConTitle" runat="server" Text="<strong>CON: </strong>"></asp:Label>
                            </td>
                            <td class="statMenu">
                                <asp:Button ID="btnConDecrease" runat="server" Text="-" OnClick="btnConDecrease_Click" />
                                <asp:Label ID="lblConValue" runat="server" Text=" 10 "></asp:Label>
                                <asp:Button ID="btnConIncrease" runat="server" Text="+" OnClick="btnConIncrease_Click" />
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblConMod" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblConPointsSpent" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="lblConRacialBonus" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblConFinalValue" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblConFinalMod" runat="server" Text="0"></asp:Label>
                            </td>

                        </tr>

                        <!-- Int -->
                        <tr>
                            <td>
                                <asp:Label ID="lblIntTitle" runat="server" Text="<strong>INT: </strong>"></asp:Label>
                            </td>
                            <td class="statMenu">
                                <asp:Button ID="btnIntDecrease" runat="server" Text="-" OnClick="btnIntDecrease_Click" />
                                <asp:Label ID="lblIntValue" runat="server" Text=" 10 "></asp:Label>
                                <asp:Button ID="btnIntIncrease" runat="server" Text="+" OnClick="btnIntIncrease_Click" />
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblIntMod" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblIntPointsSpent" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="lblIntRacialBonus" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIntFinalValue" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIntFinalMod" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>

                        <!-- Wis -->
                        <tr>
                            <td>
                                <asp:Label ID="lblWisTitle" runat="server" Text="<strong>WIS: </strong>"></asp:Label>
                            </td>
                            <td class="statMenu">
                                <asp:Button ID="btnWisDecrease" runat="server" Text="-" OnClick="btnWisDecrease_Click" />
                                <asp:Label ID="lblWisValue" runat="server" Text=" 10 "></asp:Label>
                                <asp:Button ID="btnWisIncrease" runat="server" Text="+" OnClick="btnWisIncrease_Click" />
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblWisMod" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblWisPointsSpent" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="lblWisRacialBonus" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWisFinalValue" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWisFinalMod" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>


                        <!-- Cha -->
                        <tr>
                            <td>
                                <asp:Label ID="lblChaTitle" runat="server" Text="<strong>CHA: </strong>"></asp:Label>
                            </td>
                            <td class="statMenu">
                                <asp:Button ID="btnChaDecrease" runat="server" Text="-" OnClick="btnChaDecrease_Click" />
                                <asp:Label ID="lblChaValue" runat="server" Text=" 10 "></asp:Label>
                                <asp:Button ID="btnChaIncrease" runat="server" Text="+" OnClick="btnChaIncrease_Click" />
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblChaMod" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs ">
                                <asp:Label ID="lblChaPointsSpent" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="hidden-xs">
                                <asp:Label ID="lblChaRacialBonus" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblChaFinalValue" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblChaFinalMod" runat="server" Text="0"></asp:Label>
                            </td>
                    </tbody>
                </table>
                <!--Bottom info-->
                <div>
                    <span style="font-size:150%">
                        <asp:Label ID="lblCurrentPointsTitle" runat="server" Text="<strong> Current Points: </strong>"></asp:Label>
                        <asp:Label ID="lblCurrentPointsVal" runat="server" Text="X"></asp:Label>
                    </span>
                    <span class="pull-right">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    </span>
                </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
