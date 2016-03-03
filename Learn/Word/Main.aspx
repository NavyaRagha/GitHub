<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Word_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%-- Add content controls here --%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <%--     <asp:Timer ID="UpdateTimer" runat="server" Interval="10000" OnTick="UpdateTimer_Tick" Enabled="False"></asp:Timer>--%>

            <asp:UpdatePanel ID="TimedPanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="imgNext" EventName ="Click" />
                </Triggers>
                <ContentTemplate>
                        <div class="row" id="quest">
               <asp:HiddenField ID="hdnusername" runat="server" />
                    <asp:GridView ID="grdWord" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="Word" HeaderText="Capital Letters" />
                            <asp:BoundField DataField="Kannada" HeaderText="Kannada" />
                            <asp:BoundField DataField="KannadaDesc" HeaderText="Kannada" />
                            <asp:BoundField DataField="Hindi" HeaderText="Hindi" />
                            <asp:BoundField DataField="HindiDesc" HeaderText="Hindi" />
                            <asp:TemplateField HeaderText="Audio / Video">
                                <ItemTemplate>
                                    <audio controls="controls" id="audio-A">
                                        <source src='<%# "FileCS.ashx?id=" + Eval("BegWordId") %>' type="audio/wav" />
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
                   <asp:GridView ID="grdWordResponse" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
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
                          <div><asp:Label runat="server" ID="lblSuccess" CssClass="text-success" /></div
                </ContentTemplate>
            </asp:UpdatePanel></asp:Content>