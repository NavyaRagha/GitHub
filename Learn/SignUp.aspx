<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sign Up</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script>
        function eraseText()
        {
            document.getElementById("txtusername").value = "";
            document.getElementById("txtPassword").value = "";
            document.getElementById("txtConfirmPass").value = "";
            document.getElementById("txtName").value = "";
            document.getElementById("txtEmail").value = "";
        }
    </script>
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
                            <li class="active"><a href="join">Register</a></li>
                            <li ><a href="login">Log In</a></li>
                        </ul>
                        <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-left">
                         <li><a href="home">Home</a></li>
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
        <!--Sign Up Open-->
        <div class="center-page">
            <label class="col-xs-11">Username</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtusername" runat="server" Class="form-control" placeholder="Username"></asp:TextBox>
            </div>

            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtPassword" runat="server" Class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            
            <label class="col-xs-11">Confirm Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtConfirmPass" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
            </div>

            <label class="col-xs-11">Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
            </div>
            
            <label class="col-xs-11">Email</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
            </div>
            <div class="col-xs-11 space-vert">
                <asp:Button ID="btnSignup" runat="server" Class ="btn btn-success" Text="Register" OnClick="btnSignup_Click" />
                <input type="button" value="Clear" class="btn btn-danger raised round"  onclick="javascript:eraseText();"/> <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>

        </div>
        <!--Sign Up Close-->
            <!--Footer -->
            <hr/>
            <footer class="footer-pos">
                <div class ="container">
                    <p class="pull-right"><a href="#">Back to top</a></p>
                    <p>&copy 2015 TechTeach.com &middot; <a href="Default.aspx">Home</a>
                        <a href="#">About</a>&middot;<a href="#">Contact</a> &middot;<a href ="#">Start</a>
                    </p>
                    </div>
            </footer>
        <!--Footer-->
    </form>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
