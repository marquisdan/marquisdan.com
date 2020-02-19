<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pathfinder_Pathfinder" Codebehind="Pathfinder.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Marquisdan's Pathfinder Utilities</title>

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

<body>
    <form id="form1" runat="server">

        <!--Navbar stuff-->
         <nav class=" navbar NavBarGreenWhite">
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
        
    <div class="container">
        <div class="well">
            <h1>
                Welcome to MarquisDan's pathfinder utilities page
            </h1>
            <p>
                Imagine if you will, a page where I have created a bunch of Pathfinder utilities.
                <br />
                This page will serve as a main menu. It's gonna be nice. Anyway for now just click <a href="Pointbuy.aspx">here</a> to go to the one page I have made so far.
            </p>
        </div>
    </div>

    </form>
</body>
</html>
