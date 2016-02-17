using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
 
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
       
        if (!IsPostBack)
        {
            if (Session["ut"].ToString() == "A")
            {
                Response.Redirect("admin");
            }
            else
            {
                BindGrid();

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
    private void BindGrid()
    {
        int? getChaptersPerDay=0;
        int lessonCompleted = 0;
        int iSkip = 0;
        string username = hdnusername.Value;

       

        using (LearnDBConnection db = new LearnDBConnection())
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
  

    protected void questionnaire_databound(object sender, GridViewRowEventArgs e)
    {
        int? getChaptersPerDay = 0;
        int lessonCompleted = 0;
        int iSkip = 0;
        using (LearnDBConnection db = new LearnDBConnection())
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var newuser = DataService.NewUser(hdnusername.Value);
                if (newuser == 0)
                {
                    imgPrevious.Visible = false;
                    getChaptersPerDay = DataService.GetTopicsPerChapter(lessonCompleted + 1);
                    iSkip = 0;
                }
                else
                {
                    //skip sum coursemst topic and take nect lesson 
                    //iSkip=
                    //getChaptersPerDay

                }
                 
                Int32 Id = Convert.ToInt32(questionnaireGrid.DataKeys[e.Row.RowIndex].Value);
                GridView grdResponse = e.Row.FindControl("grdResponse") as GridView;
           
                grdResponse.DataSource = DataService.LoadQuizWithRandomSet(getChaptersPerDay, Id);
                grdResponse.DataBind();
            }
        }
    }

    protected void OnClick_Next(object sender, EventArgs e)
    {
        int? getChaptersPerDay = 0;
        int lessonCompleted = 0;
        int iSkip = 0;
        using (LearnDBConnection db = new LearnDBConnection())
        {
            var newuser = DataService.NewUser(hdnusername.Value);
            if (newuser == 0)
            {
                imgPrevious.Visible = false;
                getChaptersPerDay = DataService.GetTopicsPerChapter(lessonCompleted + 1);
                iSkip = 0;
            }
            else
            {
                //skip sum coursemst topic and take nect lesson 
                //iSkip=
                //getChaptersPerDay

            }
            questionnaireGrid.DataSource = DataService.LoadQuiz(getChaptersPerDay); 
            questionnaireGrid.DataBind();
        }
        grdchaptr.Visible = false;
    }


    protected void OnClick_Submit(object sender, EventArgs e)
    {
        //Save Results table and test table
        int? getChaptersPerDay = 0;
        int lessonCompleted = 0;
        int iSkip = 0;
        int cor = 0;
        int wrong = 0;
        int ansall = 0;
        var newuser = DataService.NewUser(hdnusername.Value);
        if (newuser == 0)
        {
            imgPrevious.Visible = false;
            getChaptersPerDay = DataService.GetTopicsPerChapter(lessonCompleted + 1);
            iSkip = 0;
        }
        else
        {
            //skip sum coursemst topic and take nect lesson 
            //iSkip=
            //getChaptersPerDay

        }


        foreach (GridViewRow row in questionnaireGrid.Rows)
        {
            //for (int i = 0; i < questionnaireGrid.Rows.Count; i++)
                //{
                //String header = questionnaireGrid.Columns[0].HeaderText;
                String quest = row.Cells[0].Text;
            String an = row.Cells[1].Text;

            if (row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView) row.FindControl("grdResponse");
                // Then do the same method for Button control column 
                if (gvChild != null)
                {
                    foreach (GridViewRow rowchild in gvChild.Rows)
                    {
                        if (rowchild.RowType == DataControlRowType.DataRow)
                        {
                            RadioButtonList btn = (RadioButtonList) rowchild.FindControl("RadioButton1");
                            HiddenField hdnan = (HiddenField) rowchild.FindControl("hdnAn");
                              if (btn.SelectedIndex < 0)
                               
                                    {
                                ansall = ansall + 1;
                                if (hdnan.Value == an)
                                {
                                    cor = cor + 1;
                                }
                                else
                                {
                                    wrong = wrong + 1;
                                }
                                break;
                                // do your work
                            }

                        }
                    }
                }
            }

            // }
        }
    

    }

    protected void btnSignOut_Click(object sender,EventArgs e)
    {
        Session["USERNAME"] = null;
        Response.Redirect("home");
    }
}