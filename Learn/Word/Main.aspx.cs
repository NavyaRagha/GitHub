using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Word_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            lblSuccess.Text = "Login Success!, Welcome " + Session["USERNAME"].ToString();
            hdnusername.Value = Session["USERNAME"].ToString();
        }
        else
        {
            Response.Redirect("login");
        }
    }

    private void BindGridQuestion()
    {
        int? getChaptersPerDay = 0;
        int lessonCompleted = 0;
        int iSkip = 0;
        string username = hdnusername.Value;

        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            var newuser = DataServiceWord.NewUser(username);
            if (newuser == 0)
            {
                imgPrevious.Visible = false;
                getChaptersPerDay = DataServiceWord.GetTopicsPerChapter(lessonCompleted + 1);
                iSkip = 0;
            }
            else
            {
                //skip sum coursemst topic and take nect lesson 
                //iSkip=
                //getChaptersPerDay

            }
            grdWord.DataSource = DataServiceWord.LoadChapters(getChaptersPerDay);
            grdWord.DataBind();
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
        using (dbExtranetEntitiesWord db = new dbExtranetEntitiesWord())
        {
            var newuser = DataServiceWord.NewUser(hdnusername.Value);
            if (newuser == 0)
            {
                getChaptersPerDay = DataServiceWord.GetTopicsPerChapter(lessonCompleted + 1);
                getNumQuestTaken = DataServiceWord.GetNumQuestTaken(hdnusername.Value, getChaptersPerDay);
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
            List<DataServiceWord.LearningQuiz> quest = DataServiceWord.LoadQuiz(Convert.ToInt32(ViewState["questnum"]));
            lblQuest.Text = quest[0].QuestionNum + "   " + quest[0].Question;
            hdnAn.Value = Convert.ToString(quest[0].An);
            hdnMainQuestid.Value = Convert.ToString(quest[0].BegPrId);
            hdnTestQuestid.Value = Convert.ToString(quest[0].IdTestquiz);
            hdnTestQuestDay.Value = Convert.ToString(quest[0].IdquizDay);
        }
        grdWord.Visible = false;
        BindGridQuiz(getChaptersPerDay, Convert.ToInt32(hdnMainQuestid.Value));
        btnsubmit.Visible = true;

    }
    protected void BindGridQuiz(int? getchaptersperday, Int32 id)
    {

        grdWordResponse.DataSource = DataServiceWord.LoadQuizWithRandomSet(getchaptersperday, id, hdnusername.Value);
        grdWordResponse.DataBind();


        foreach (GridViewRow row1 in grdWordResponse.Rows)
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
                Convert.ToInt32(grdWordResponse.DataKeys[AnswerSelectedIndex.GetValueOrDefault(-1)].Value);

            foreach (GridViewRow row1 in grdWordResponse.Rows)
            {
                irow = irow + 1;
                if (row1.RowType == DataControlRowType.DataRow)
                {
                    Label lblBegId = (Label)row1.FindControl("lblBegId");
                    Label lblTestgId = (Label)row1.FindControl("lblTestgId");
                    Label lblkan = (Label)row1.FindControl("lblkan");

                    string s = lblkan.Text;

                    if (irow == AnswerSelectedIndex + 1)
                    {
                        DataServiceWord.AnswerGiven(Convert.ToInt32(hdnTestQuestid.Value), hdnusername.Value,
                            Convert.ToInt32(lblBegId.Text));
                        break;
                    }

                }
            }
            answerSelectedIndex = -1;

            int getCoursemst = DataServiceWord.GetCoursemst(Convert.ToInt32(hdnTestQuestDay.Value));
            int getquestAnswered = DataServiceWord.GetquestAnswered(hdnTestQuestDay.Value, hdnusername.Value);
            if (getCoursemst == getquestAnswered)
            {
                bool res = DataServiceWord.ResultPassorFail(hdnTestQuestDay.Value, hdnusername.Value);
                if (res == true)
                {
                    Response.Redirect("user");
                }
                else
                {
                    bool sendBacktoSameCourse = DataServiceWord.SendBacktoSameCourse(hdnTestQuestDay.Value, hdnusername.Value);
                    Response.Redirect("user");
                }
            }
            else
            {
                OnClick_Next(sender, e);

            }

        }

    }
}