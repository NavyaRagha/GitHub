<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>shfjsag</title>
      <script>
        function eraseText()
        {
            document.getElementById("txtheader").value = "";
            document.getElementById("txtExplain").value = "";
            document.getElementById("txtcontentType").value = "";
            document.getElementById("txtKannada").value = "";
            document.getElementById("txtHindi").value = "";
        }
    </script>
    <h1>Welcome Admin</h1>

        <div class="container">
            <div class="form-horizontal">
                <%--   <div class="center-page">--%>
            
                         <label class="col-xs-11">Select File to Uplaod</label>
            <div class="col-xs-11">
                <asp:FileUpload ID="FileUpload11" runat="server" />
            </div>


            <label class="col-xs-11">File Header</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtheader" runat="server" Class="form-control" placeholder="File Heading"></asp:TextBox>
            </div>

            <label class="col-xs-11">Explain</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtExplain" runat="server" Class="form-control" placeholder="Explanation here" TextMode="Password"></asp:TextBox>
            </div>
            
            <label class="col-xs-11">Content Type</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtContentType" runat="server" Class="form-control" placeholder="audio/mpeg3" TextMode="Password"></asp:TextBox>
            </div>

            <label class="col-xs-11">Kannada</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtKannada" runat="server" Class="form-control" placeholder="Kannada Translate" TextMode="MultiLine"></asp:TextBox>
            </div>
            
            <label class="col-xs-11">Hindi</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtHindi" runat="server" Class="form-control" placeholder="Hindi Translate" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="col-xs-11 space-vert">
                 <asp:Button ID="btnUpload" runat="server" Class ="btn btn-success" Text="Upload" OnClick="btnUpload_Click" />
              <%--  <asp:Button ID="btnSignup" runat="server" Class ="btn btn-success" Text="Register" OnClick="btnSignup_Click" />--%>
                <input type="button" value="Clear" class="btn btn-danger raised round"  onclick="javascript:eraseText();"/> <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>

        </div>
                <hr />
            </div>
    
    
</asp:Content>

