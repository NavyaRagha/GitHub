using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    private int iTimes = 0;
 
    //public class Learning
    //{
    //    public int? Id { get; set; }
    //    public string CapitalLetters { get; set; }
    //    public string SmallLetters { get; set; }
    //    public string Explain { get; set; }
    //    public string Kannada { get;  set; }
    //    public string Hindi { get;  set; }
    //    public byte[] Play { get; set; }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/Word/Main.aspx");
        if (!IsPostBack)
        {
            if (Session["ut"].ToString() == "A")
            {
                Response.Redirect("admin");
            }
            else
            {
                BindGridQuestion();
            }
        }
        if (Session["USERNAME"] != null)
        {
            lblSuccess.Text = "Login Success!, Welcome " + Session["USERNAME"].ToString() ;
            hdnusername.Value = Session["USERNAME"].ToString();
        }
        else
        {
            Response.Redirect("login");
        }
      
    }

    private void BindGridQuestion()
    {
        int? getChaptersPerDay=0;
        int lessonCompleted = 0;
        int iSkip = 0;
        string username = hdnusername.Value;
        
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            var newuser = DataService.NewUser(username);
            if (newuser==0)
            {
                imgPrevious.Visible = false;
                getChaptersPerDay= DataService.GetTopicsPerChapter(lessonCompleted + 1);
                iSkip = 0;
            }
            else
            {
                //skip sum coursemst topic and take nect lesson 
                //iSkip=
                //getChaptersPerDay

            }
            grdchaptr.DataSource = DataService.LoadChapters(getChaptersPerDay);
            grdchaptr.DataBind();
        }
        
    }
    private int? answerSelectedIndex;
    private int? AnswerSelectedIndex
    {
        get
        {
            if (string.IsNullOrEmpty(Request.Form["idradio"]))
                return -1;
            else
                return Convert.ToInt32(Request.Form["idradio"]);
        }
        set
        {
            answerSelectedIndex = value;
           
        }
    }

   
    
    protected void OnClick_Next(object sender, EventArgs e)
    {
        //UpdateTimer.Enabled = true;
        int? getChaptersPerDay = 0;
        int? getNumQuestTaken = 0;
        int lessonCompleted = 0;
        int iSkip = 0;
        int i;
        ViewState["questnum"] = 0;
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            var newuser = DataService.NewUser(hdnusername.Value);
            if (newuser == 0)
            {
                getChaptersPerDay = DataService.GetTopicsPerChapter(lessonCompleted + 1);
                getNumQuestTaken = DataService.GetNumQuestTaken(hdnusername.Value, getChaptersPerDay);
                ViewState["questnum"] = getNumQuestTaken;
                imgPrevious.Visible = false;

                iSkip = 0;
            }
            else
            {
                ViewState["questnum"] = Convert.ToInt32(ViewState["questnum"]) + 1;
                //skip sum coursemst topic and take nect lesson 
                //iSkip=
                //getChaptersPerDay

            }
            List<DataService.LearningQuiz> quest= DataService.LoadQuiz(Convert.ToInt32(ViewState["questnum"]));
            lblQuest.Text = quest[0].QuestionNum + "   " + quest[0].Question;
            hdnAn.Value = Convert.ToString(quest[0].An);
            hdnMainQuestid.Value= Convert.ToString(quest[0].BegPrId);
            hdnTestQuestid.Value= Convert.ToString(quest[0].IdTestquiz);
            hdnTestQuestDay.Value = Convert.ToString(quest[0].IdquizDay);
        }
        grdchaptr.Visible = false;
        BindGridQuiz(getChaptersPerDay, Convert.ToInt32( hdnMainQuestid.Value));
        btnsubmit.Visible = true;

    }

    protected void BindGridQuiz(int? getchaptersperday, Int32 id)
    {

        grdResponse.DataSource = DataService.LoadQuizWithRandomSet(getchaptersperday, id,hdnusername.Value);
        grdResponse.DataBind();


        foreach (GridViewRow row1 in grdResponse.Rows)
        {
            if (row1.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild1 = (GridView)row1.FindControl("grdResponse");
                            Literal output = (Literal)row1.FindControl("RadioButtonMarkUp");
                            output.Text = String.Format(
                                "<input type='radio' name='idradio' id='RowSelector{0}' value='{0}'", row1.RowIndex);
               
                    if (AnswerSelectedIndex == row1.RowIndex)
                        if (answerSelectedIndex != -1)
                        {
                            output.Text += @" checked='checked'";
                        }
                output.Text += " />";
                
            }
       }
    }


    protected void OnClick_Submit(object sender, EventArgs e)
    {
        int irow = 0;
        if (AnswerSelectedIndex < 0)
        {
            lblSuccess.Text = "Please select your answer.";
            answerSelectedIndex = -1;
            return;
        }
        else
        {
            lblSuccess.Text = "";
            int radiobtnchk =
                Convert.ToInt32(grdResponse.DataKeys[AnswerSelectedIndex.GetValueOrDefault(-1)].Value);

            foreach (GridViewRow row1 in grdResponse.Rows)
            {
                irow = irow + 1;
                if (row1.RowType == DataControlRowType.DataRow)
                {
                    Label lblBegId = (Label) row1.FindControl("lblBegId");
                    Label lblTestgId = (Label) row1.FindControl("lblTestgId");
                    Label lblkan = (Label) row1.FindControl("lblkan");

                    string s = lblkan.Text;

                    if (irow == AnswerSelectedIndex + 1)
                    {
                        DataService.AnswerGiven(Convert.ToInt32(hdnTestQuestid.Value), hdnusername.Value,
                            Convert.ToInt32(lblBegId.Text));
                        break;
                    }

                }
            }
            answerSelectedIndex = -1;

            int getCoursemst = DataService.GetCoursemst(Convert.ToInt32(hdnTestQuestDay.Value));
            int getquestAnswered = DataService.GetquestAnswered(hdnTestQuestDay.Value, hdnusername.Value);
            if (getCoursemst == getquestAnswered)
            {
                bool res = DataService.ResultPassorFail(hdnTestQuestDay.Value,hdnusername.Value);
                if (res == true)
                {
                    Response.Redirect("user");
                }
                else
                {
                    bool sendBacktoSameCourse = DataService.SendBacktoSameCourse(hdnTestQuestDay.Value, hdnusername.Value);
                    Response.Redirect("user");
                }
            }
            else
            {
                OnClick_Next(sender, e);

            }

        }

    }
  protected void btnSignOut_Click(object sender,EventArgs e)
    {
        Session["USERNAME"] = null;
        Response.Redirect("home");
    }

    //protected void questionnaire_databound(object sender, GridViewRowEventArgs e)
    //{
    //    int? getChaptersPerDay = 0;
    //    int lessonCompleted = 0;
    //    int iSkip = 0;
    //    int ii = 1;
    //    using (dbExtranetEntities db = new dbExtranetEntities())
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            // Literal output = (Literal)e.Row.FindControl("RadioButtonMarkUp");
    //            // Output the markup except for the "checked" attribute
    //            //output.Text = String.Format(
    //            //    "<input type='radio' name='SuppliersGroup' id='RowSelector{0}' value='{0}'", e.Row.RowIndex);

    //            var newuser = DataService.NewUser(hdnusername.Value);
    //            if (newuser == 0)
    //            {
    //                ViewState["questnum"] = 1;
    //                imgPrevious.Visible = false;
    //                getChaptersPerDay = DataService.GetTopicsPerChapter(lessonCompleted + 1);
    //                iSkip = 0;
    //            }
    //            else
    //            {
    //                ViewState["questnum"] = Convert.ToInt32(ViewState["questnum"]) + 1;
    //                //skip sum coursemst topic and take nect lesson 
    //                //iSkip=
    //                //getChaptersPerDay

    //            }

    //            Int32 Id = Convert.ToInt32(questionnaireGrid.DataKeys[e.Row.RowIndex].Value);
    //            GridView grdResponse = e.Row.FindControl("grdResponse") as GridView;

    //            grdResponse.DataSource = DataService.LoadQuizWithRandomSet(Convert.ToInt32(ViewState["questnum"]), getChaptersPerDay, Id);
    //            grdResponse.DataBind();


    //            foreach (GridViewRow row1 in questionnaireGrid.Rows)
    //            {
    //                if (row1.RowType == DataControlRowType.DataRow)
    //                {
    //                    GridView gvChild1 = (GridView)row1.FindControl("grdResponse");
    //                    // Then do the same method for Button control column 
    //                    if (gvChild1 != null)
    //                    {
    //                        // i = 0;
    //                        foreach (GridViewRow rowchild1 in gvChild1.Rows)
    //                        {
    //                            if (rowchild1.RowType == DataControlRowType.DataRow)
    //                            {
    //                                // i = i + 1;
    //                                Literal output = (Literal)rowchild1.FindControl("RadioButtonMarkUp");
    //                                output.Text = String.Format(
    //                                    "<input type='radio' name='" + Id + "' id='RowSelector{0}' value='{0}'", e.Row.RowIndex);

    //                                if (SuppliersSelectedIndex == e.Row.RowIndex)
    //                                    output.Text += @" checked='checked'";
    //                                // Add the closing tag
    //                                output.Text += " />";


    //                            }
    //                        }
    //                    }
    //                }
    //            }


    //        }
    //    }
    //}
    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {

        //foreach (GridViewRow row1 in questionnaireGrid.Rows)
        //{
        //    if (row1.RowType == DataControlRowType.DataRow)
        //    {
        //        GridView gvChild1 = (GridView)row1.FindControl("grdResponse");
        //        // Then do the same method for Button control column 
        //        if (gvChild1 != null)
        //        {
        //            i = 0;
        //            foreach (GridViewRow rowchild1 in gvChild1.Rows)
        //            {
        //                if (rowchild1.RowType == DataControlRowType.DataRow)
        //                {
        //                    i = i + 1;
        //                    RadioButton btn = (RadioButton)rowchild1.FindControl("RadioButtonRunTime");
        //                    HtmlControl ctrl = (HtmlControl)rowchild1.FindControl("RadioButtonRunTime1");
        //                    var radioBtn = (HtmlInputRadioButton)rowchild1.FindControl("RadioButtonRunTime1");
        //                    //if (btn.SelectedIndex > - 1 )
        //                    //{
        //                    //    break;
        //                    //}
        //                    //else
        //                    //{
        //                    //    if (gvChild1.Rows.Count == i)
        //                    //    {
        //                    //        return;
        //                    //    }
        //                    //}
        //                }
        //            }
        //        }
        //    }
        //}
    }
    //private void PopulateRadioButtonList(RadioButtonList RadioButtonRunTime)
    //{
    //    // bind the 2nd RadioButtonList , Add manually through code
    //    for (int i = 0; i < 4; i++)
    //    {
    //        RadioButtonRunTime.Items.Add(new ListItem("Item Text " + i.ToString(), i.ToString()));
    //        RadioButtonRunTime.SelectedIndex = 2;
    //    }



    //    // Generate the DataTable, its a kind of DataSource for the dropdown box
    //    // :) Hey, Learn how to generate DataTable at runtime. Interesting ?
    //    DataSet dSet = new DataSet();
    //    DataTable dTable = new DataTable();
    //    DataColumn colId = new DataColumn("ID");
    //    try
    //    {
    //        dTable.Columns.Add(colId);
    //        DataColumn colName = new DataColumn("Name");
    //        dTable.Columns.Add(colName);
    //        for (int i = 0; i < 10; i++)
    //        {
    //            object[] obj = { i.ToString(), "Name " + i.ToString() };
    //            dTable.Rows.Add(obj);
    //        }

    //        // Add the generated table into dataset, so it will look like DataSet is populated through database
    //        dSet.Tables.Add(dTable);

    //        //// Bind 3rd RadioButtonList 
    //        //// Now try to bind the RadioButtonList 
    //        //RadioButonListBind.DataSource = dSet.Tables[0].DefaultView;
    //        //RadioButonListBind.DataBind();

    //        //// Lets bind the 4th RadioButtonList too
    //        //RadioButtonListBoundFire.DataSource = dSet.Tables[0]; // you can specify only Table too, but it is suggested to user DefualtView property
    //        //RadioButtonListBoundFire.DataBind();

    //    }
    //    catch (Exception ee)
    //    {
    //      //  lblError.Text = ee.ToString();
    //    }
    //    finally
    //    {
    //        dSet.Dispose();
    //        dTable.Dispose();
    //    }
    //}
  
}