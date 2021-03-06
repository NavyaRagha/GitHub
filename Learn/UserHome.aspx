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
   <%-- <script>
        function CheckOtherIsCheckedByGVID(spanChk) {
            var IsChecked = spanChk.checked;
            if (IsChecked) {
                spanChk.parentElement.parentElement.style.backgroundColor = '#228b22';
                spanChk.parentElement.parentElement.style.color = 'white';
            }

            var CurrentRdbID = spanChk.id;
            var Chk = spanChk;
            Parent = document.getElementById('grdResponse');
            var items = Parent.getElementsByTagName('input');

            for (i = 0; i < items.length; i++) {
                if (items[i].id != CurrentRdbID && items[i].type == "radio") {
                    if (items[i].checked) {
                        items[i].checked = false;
                        items[i].parentElement.parentElement.style.backgroundColor = 'white';
                        items[i].parentElement.parentElement.style.color = 'black';
                    }
                }
            }
        }</script>--%>
<%--    <script type="text/javascript">

        function fnCheckUnCheck(objId) {
            var grd1 = document.getElementById("<%= questionnaireGrid.ClientID %>");
     <%--$find('<%=questionnaireGrid.ClientID %>');--%>

   <%--  var grd = grd1.findText('grdResponse');
     //Collect A
     var rdoArray = grd.getElementsByTagName("input");

     for (i = 0; i <= rdoArray.length - 1; i++) {
         if (rdoArray[i].type == 'radio') {
             if (rdoArray[i].id != objId) {
                 rdoArray[i].checked = false;
             }
         }
     }
 }

    </script>--%>
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
          
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <%--     <asp:Timer ID="UpdateTimer" runat="server" Interval="10000" OnTick="UpdateTimer_Tick" Enabled="False"></asp:Timer>--%>

            <asp:UpdatePanel ID="TimedPanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="imgNext" EventName ="Click" />
                </Triggers>
                <ContentTemplate>
                        <div class="row" id="quest">
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
                                        <source src='<%# "FileCS.ashx?id=" + Eval("BegPrId") %>' type="audio/wav" />
                                    </audio>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  </div>
                     <div class="container center">
                <div class="row">
                    <asp:Label ID="lblQuest" runat="server"  Font-Size="14px" Font-Bold="True" BackColor="#3AC0F2"></asp:Label>
                    <asp:HiddenField ID="hdnAn" runat="server" />
                         <asp:HiddenField ID="hdnMainQuestid" runat="server"  />
                         <asp:HiddenField ID="hdnTestQuestid" runat="server"  />
                    <asp:HiddenField ID="hdnTestQuestDay" runat="server"  />
                   <asp:GridView ID="grdResponse" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" DataKeyNames="BegPrId">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:Literal ID="RadioButtonMarkUp" runat="server"></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Kannada">
                                                <ItemTemplate>
                                                    pri id<asp:Label ID="lblBegId" runat="server" Text='<%# Eval("BegPrId") %>'></asp:Label>
                                                     testid<asp:Label ID="lblTestgId" runat="server" Text='<%# Eval("idName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Kannada">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblkan" runat="server" Text='<%# Eval("Kannada") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hindi">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblhin" runat="server" Text='<%# Eval("Hindi") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Audio / Video">
                                                <ItemTemplate>
                                                    <audio controls="controls" id="audio-A">
                                                        <source src='<%# "FileCS.ashx?id=" + Eval("BegPrId") %>' type="audio/wav" />
                                                    </audio>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                   <%-- <asp:GridView ID="questionnaireGrid" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="False" OnRowDataBound="questionnaire_databound" DataKeyNames="Id">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnAn" runat="server" Value='<%# Eval("An") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Question ID" Visible="true" DataField="QuestionId" />
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
                                                    <asp:Literal ID="RadioButtonMarkUp" runat="server"></asp:Literal>
                                                    <%--<asp:RadioButton runat="server" ClientIDMode="Static"  name='<%# Eval("idName") %>' GroupName='<%# Eval("idName") %>'  ID="RadioButtonRunTime" >--%>
                                                    <%--   <asp:ListItem  ></asp:ListItem>--%>
                                                    <%--  </asp:RadioButton>--%>
                                                    <%--<input type="radio" ID="CheckBox1" runat="server"  name="1" />--%>
                                                    <%-- <input type="radio" id="RadioButtonRunTime1" runat="server" name='<%# Eval("idName") %>' value='<%# Eval("idName") %>' />--%>
                                                    <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                                        <asp:ListItem>north</asp:ListItem>
                                                        <asp:ListItem>west</asp:ListItem>
                                                    </asp:RadioButtonList>--%>
                                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="RadioButtonRunTime" ErrorMessage="RequiredFieldValidator">
                                                    </asp:RequiredFieldValidator>--%>
                                                <%--</ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Kannada">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Kannada") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hindi">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Hindi") %>'></asp:Label>
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
                    </asp:GridView>--%>
                    <div class="form-group">
                        <div class="col-md-8"></div>
                        <div class="col-md-3">
                            <asp:ImageButton ID="imgPrevious" runat="server" Height="50" ImageUrl="~/Images/Prev.jpg"  AlternateText="Prev"/>
                            <asp:ImageButton ID="imgNext" runat="server" Height="50" ImageUrl="~/Images/Next.jpg" OnClick="OnClick_Next" AlternateText ="Next" />
                           <%-- <asp:ImageButton ID="imgSubmit" runat="server" Height="50" ImageUrl="~/Images/Next.jpg" OnClick="OnClick_Submit" />--%>
                            <button  id="btnsubmit" runat="server" Visible="False" OnServerClick="OnClick_Submit" class="btn btn-primary">Submit <span class="badge">  <%# Eval("QuestionId") %></span></button>

<%--                                                        <asp:Button  id="Button1" runat="server" Visible="False" OnServerClick="OnClick_Submit" class="btn btn-primary">Submit <span class="badge">  <%# Eval("QuestionId") %></span></asp:Button>--%>
                            <%--<asp:Button ID="btnLogin1" ValidationGroup="vgsignin" runat="server" Text="Log in" class="btn btn-success raised round" OnClick="Login_Click1" />--%>
                        </div>
                    </div>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>




          
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
