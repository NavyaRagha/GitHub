﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Learn</title>
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
            <div class="navbar navbar-default navbar-fixed-top menu-Background" role="navigation">
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
                                <li><a href="home">Home</a></li>
                                <li class="active"><a href="user">Learn</a></li>
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
            <div class="container center">
                <div class="row">
                    <asp:HiddenField ID="hdnusername" runat="server" />
                    <asp:GridView ID="grdchaptr" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="CapitalLetters" HeaderText="Capital Letters" />
                            <asp:BoundField DataField="SmallLetters" HeaderText="Small Letters" />
                            <asp:BoundField DataField="Kannada" HeaderText="Kannada" />
                            <asp:BoundField DataField="Hindi" HeaderText="Hindi" />
                            <asp:TemplateField HeaderText="Audio / Video">
                                <ItemTemplate>
                                    <audio controls="controls" id="audio-A">
                                        <source src='<%# "FileCS.ashx?id=" + Eval("Id") %>' type="audio/wav" />
                                    </audio>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="questionnaireGrid" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="False" OnRowDataBound="questionnaire_databound" DataKeyNames="QuestionID">
                        <Columns>
                            <asp:BoundField HeaderText="Question ID" Visible="true" DataField="QuestionNumber" />
                            <asp:TemplateField HeaderText="Questions">
                                <ItemTemplate>
                                    <%# Eval("Question") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Response">
                                <ItemTemplate>
                                    <asp:GridView ID="grdResponse" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                        <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="RadioButton1" runat="server" />
                                                </ItemTemplate>
                                                    </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                                </ItemTemplate>
                                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Audio / Video">
                                                <ItemTemplate>
                                                    <audio controls="controls" id="audio-A">
                                                        <source src='<%# "FileCS.ashx?id=" + Eval("Id") %>' type="audio/wav" />
                                                    </audio>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="form-group">
                        <div class="col-md-8"></div>
                        <div class="col-md-3">
                            <asp:ImageButton ID="imgPrevious" runat="server" Height="50" ImageUrl="~/Images/Prev.jpg" />
                            <asp:ImageButton ID="imgNext" runat="server" Height="50" ImageUrl="~/Images/Next.jpg" OnClick="OnClick_Next" />
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
