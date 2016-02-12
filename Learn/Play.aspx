<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Play.aspx.cs" Inherits="Play" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        #Video1 {
            position: absolute;
            top: 50px;
            left: 0px;
            width: 10px;
            border: 2px solid blue;
            display: block;
            z-index: 99;
        }

        #Video2 {
            position: absolute;
            top: 80px;
            left: 60px;
            width: 300px;
            border: 2px solid red;
            z-index: 100;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("video").bind("play", OnVideoPlay);
            $("audio").bind("play", OnAudioPlay);
        });

        function OnAudioPlay(evt) {
            var a = $("audio[id!='" + evt.target.id + "']").get();
            for (var i = 0; i < a.length; i++) {
                a[i].pause();
            }

        }

        function OnVideoPlay(evt) {
            var v = $("video[id!='" + evt.target.id + "']").get();
            for (var i = 0; i < v.length; i++) {
                v[i].pause();
            }
        }
    </script>
    <title></title>
    <script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <%--  <video id="Video1" controls loop autoplay >
           <source src="http://localhost:21929/testzip.m4a" type="video/mp4" />           
       </video>--%>
            <%--  <video src="tesstzip.m4a" controls autoplay >HTML5 Video is required for this example</video> --%>

            <asp:FileUpload ID="FileUpload11" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload"
                OnClick="btnUpload_Click" />
            <hr />
            <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="FileName" />
                    <%--  <asp:TemplateField>
                        <ItemTemplate>
                            <object type="application/x-shockwave-flash" data='dewplayer-vol.swf?mp3=File.ashx?Id=<%# Eval("Id") %>'
                                width="240" height="20" id="dewplayer">
                                <param name="wmode" value="transparent" />
                                <param name="movie" value='dewplayer-vol.swf?mp3=File.ashx?Id=<%# Eval("Id") %>' />
                            </object>
                            <%-- <video id="Video1" controls loop autoplay >
           <source src="http://localhost:21929/testzip.m4a" type="video/mp4" />           
       </video>--%>
                    <%-- </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--  <asp:HyperLinkField DataNavigateUrlFields="Id" Text="Download" DataNavigateUrlFormatString="~/File.ashx?Id={0}" HeaderText="Download" />--%>
                    <%--    <asp:TemplateField HeaderText="Sample Track">
        <HeaderStyle ForeColor="Blue" />
        <ItemTemplate>
            <asp:ImageButton ID="btnPlaySample" runat="server" CausesValidation="false" CommandName="Play" CommandArgument='<%# Eval("Id") %>' Imageurl="~/Images/ArrowLeft.png"/>
        </ItemTemplate>
    </asp:TemplateField>        --%>
                    <asp:TemplateField HeaderText="Audio / Video">
                        <ItemTemplate>
                          <%--  <asp:Literal ID="Literal1" runat="server"
                                Text='<%# Page.ResolveClientUrl(Eval("Url").ToString()) %>'></asp:Literal>--%>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="300px" />
                    </asp:TemplateField>
             
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
