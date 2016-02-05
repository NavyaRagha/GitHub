<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Your Password!</title>
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
                            <li class="active"><a href="join">Register</a></li>
                        </ul>
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
                            </li></ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="form-horizontal">
                <h2>Reset Password</h2>
                <hr />
                <div class="form-group">
                    <asp:Label runat="server" ID="lblmsg" CssClass="col-md-2 control-label"   Font-Size="XX-Large" Font-Bold="True" />
                    </div>

                <h4>&nbsp;</h4>
                <div class="form-group">
                    <asp:Label runat="server" ID="Label1" CssClass="col-md-2 control-label" Text="UserName" Visible="False" />
                    <div class="col-md-3">
                        <asp:Label runat="server" ID="lblUsername" CssClass="col-md-2 control-label" Text="UserName" Visible="False" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblPassword" CssClass="col-md-2 control-label" Text="New Password" Visible="False" />
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txtNewPass" TextMode="Password" CssClass="form-control" Visible="False" />
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="text-danger" ErrorMessage="Please enter your nes password!" ControlToValidate="txtNewPass"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" ID="lblRetypePassword" CssClass="col-md-2 control-label" Text="Confirm Password" Visible="False" />
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" Visible="False" />
                       
                        <asp:CompareValidator ID="cvPassword" runat="server"  CssClass="text-danger"  ErrorMessage="Both Password must be same!" ControlToCompare="txtConfirmPassword" ControlToValidate="txtNewPass"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button runat="server" ID="btnResetPassword" CssClass="btn btn-default" Text="Reset" Visible="False" OnClick="btnResetPassword_Click"  />
                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger raised round" PostBackUrl="login" /><br />
                    </div>
                </div>
            </div>
        </div>
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
