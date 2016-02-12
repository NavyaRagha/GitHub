<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayNow.aspx.cs" Inherits="PlayNow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="FlowPlayer/flowplayer-3.2.12.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        flowplayer("a.player", "FlowPlayer/flowplayer-3.2.16.swf", {
            plugins: {
                pseudo: { url: "FlowPlayer/flowplayer.pseudostreaming-3.2.12.swf" }
            },
            clip: { provider: 'pseudo', autoPlay: false },
        });
    </script>

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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
          <%--  <hr />
            <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                RepeatColumns="2" CellSpacing="5" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                <ItemTemplate>
                    <u>
                        <%# Eval("Name") %></u>
                    <hr />
                    <a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("Id", "FileCS.ashx?Id={0}") %>'></a>
                </ItemTemplate>
                <ItemTemplate>
                    <audio controls="controls" id="audio-A">
                        <source src='<%# "FileCS.ashx?id=" + Eval("Id") %>' type="audio/wav" />
                    </audio>
                </ItemTemplate>
            </asp:DataList>--%>

             <asp:GridView ID="DataList1" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" >
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="FileName" />
                 
                 <%--   <asp:TemplateField HeaderText="Audio / Video">
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server"
                                Text='<%# Page.ResolveClientUrl(Eval("Url").ToString()) %>'></asp:Literal>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="300px" />
                    </asp:TemplateField>--%>
           <asp:TemplateField HeaderText="Audio / Video">
                    
                <ItemTemplate>
                    <audio controls="controls" id="audio-A">
                        <source src='<%# "FileCS.ashx?id=" + Eval("Id") %>' type="audio/wav" />
                    </audio>
                </ItemTemplate>
                   </asp:TemplateField >
                </Columns>

            </asp:GridView>
          
        </div>
    </form>
</body>
</html>
