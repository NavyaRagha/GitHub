<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Home</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="home"><span>
                            <img alt="Logo" src="Images/Learn.png" height="30" /></span>TecyCybo</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <asp:Button ID="btnSignOut" OnClick="btnSignOut_Click" runat="server" Class="btn btn-default navbar-btn" Text="Log Out" />
                            </li>
                        </ul>
                        <div class="navbar-collapse collapse">
                            <ul class="nav navbar-nav navbar-left">
                                <li class="active"><a href="home">Home</a></li>
                                <li><a href="#">About</a></li>
                                <li><a href="#">Contact</a></li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Start<b class="caret"></b></a>
                                    <ul class="dropdown-menu">
                                        <li class="dropdown-header">Menu1</li>
                                        <li role="separator" class="divider"></li>
                                        <li><a href="#">Learn1</a></li>
                                        <li><a href="#">Learn2</a></li>
                                        <li><a href="#">Learn3</a></li>
                                        <li role="separator" class="divider"></li>
                                        <li class="dropdown-header">Menu2</li>
                                        <li role="separator" class="divider"></li>
                                        <li><a href="#">Learn2-1</a></li>
                                        <li><a href="#">Learn2-2</a></li>
                                        <li><a href="#">Learn2-3</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label runat="server" ID="lblSuccess" CssClass="text-success" />
    </form>
    <!--Footer -->
    <hr />
    <footer>
        <div class="container">
            <p class="pull-right"><a href="#">Back to top</a></p>
            <p>
                &copy 2015 TechTeach.com &middot; <a href="Default.aspx">Home</a>
                <a href="#">About</a>&middot;<a href="#">Contact</a> &middot;<a href="#">Start</a>
            </p>
        </div>
    </footer>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
