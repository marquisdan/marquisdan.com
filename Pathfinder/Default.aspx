<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pathfinder_Pathfinder" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Marquisdan's Pathfinder Utilities</title>

        <!--Meta Tags -->
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>

        <!-- Javascript to get the dang dropdown menu to work -->
        <!-- See  http://stackoverflow.com/questions/21012382/bootstrap-navbar-dropdown-not-working-in-asp-net -->
        <script type="text/javascript" src="../Scripts/jquery-3.4.1.js"></script>
        <script type="text/javascript" src="../Scripts/bootstrap.js"></script>

        <!-- Link Twitter Bootstrap CSS and my own personal custom CSS -->
        <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css"/>
        <link href="../Content/DanCSS.css" rel="stylesheet" type="text/css"/>
    </head>

    <body>
        <form id="form1" runat="server">
            <!--Navbar-->
            <nav class="navbar navbar-expand-lg navbar-dark" style="background-color: DarkGreen">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#PathfinderNavToggleMenu" aria-controls="PathfinderNavToggleMenu" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <a class="navbar-brand" href="/Default.aspx">marquisdan.com</a>

                <div class="collapse navbar-collapse" id="PathfinderNavToggleMenu">
                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-white" href="/Default.aspx" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Pathfinder
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink" style="background-color: DarkGreen">
                                <a href="Default.aspx" class="nav-link text-white">Home </a>
                                <a href="Pointbuy.aspx" class="nav-link text-white">Point Buy Utility</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>  

            <div class="container-fluid">
                <div class="jumbotron">
                    <h1>
                        Welcome to marquisdan's pathfinder utilities page
                    </h1>
                    <p>
                        Imagine if you will, a page where I have created a bunch of Pathfinder utilities.
                        <br/>
                        This page will serve as a main menu. It's gonna be nice. Anyway for now just click <a href="Pointbuy.aspx">here</a> to go to the one page I have made so far.
                    </p>
                </div>
            </div>

        </form>
    </body>
</html>
