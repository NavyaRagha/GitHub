<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sign In</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />
    <link href="css/buttons.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body> 
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm1" runat="server" EnableCdn="true">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
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
                            <li class="active"><a href="login">Sign In</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <!--Sign In Start -->
        <div class="container" style="border: 1px solid black;">
            <div class="form-horizontal">
                <h4 style="background-color: #66CCFF; color: #FFFFFF; font-size: larger; height: 40px">&nbsp;&nbsp; &nbsp; &nbsp;Login</h4>
                <div class="col-md-12">
                    <asp:Button ID="btnFacebook" runat="server" Text="Log in using Facebook" class="btn btn-facebook sharp" OnClick="Login_Click" /><br />
                    <asp:Button ID="btnGoogle" runat="server" Text="Log in using Gmail" class="btn btn-gmail sharp" OnClick="Login_Click" />
                </div>
            </div>
            <%--<br/>--%>
            <div>
                <div class="form-group">
                    <div class="col-md-6"></div>
                    <asp:Label runat="server" ID="lblUserName" CssClass="col-md-2 control-label" Text="Username"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUserName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsername" CssClass="text-danger " runat="server" ErrorMessage="The UserName is Required!" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6"></div>
                    <asp:Label runat="server" ID="Label2" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" CssClass="text-danger " runat="server" ErrorMessage="The Password is Required!" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-8"></div>
                    <div class="col-md-4">
                        <asp:CheckBox ID="chkRemember" runat="server" />
                        <asp:Label runat="server" ID="Label3" CssClass="control-label" Text="Remember Me?"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-8"></div>
                    <div class="col-md-4">
                        <asp:LinkButton ID="lbForgotPass" runat="server" PostBackUrl="~/ForgotPassword.aspx">Forgot Password!</asp:LinkButton><br />
                        <asp:Label runat="server" ID="lblreg" CssClass="control-label" Text="Don't you have account?"></asp:Label>
                        <asp:LinkButton ID="lnlRegister" runat="server" PostBackUrl="SignUp.aspx">Register Here! Click Me</asp:LinkButton>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr style="text-decoration: line-through; border: 1px solid lightgray;" />
                </div>
                <div class="form-group">
                    <div class="col-md-8"></div>
                    <div class="col-md-3">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-success raised round" OnClick="Login_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger raised round" OnClick="Login_Click" /><br />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
            <%--</td>--%>
            <%--  </tr>
     </table>--%>
        </div>

        <!--Sign In End -->
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
