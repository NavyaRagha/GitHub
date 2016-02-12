using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
 
    public class Learning
    {
        public int Id { get; set; }
        public string CapitalLetters { get; set; }
        public string SmallLetters { get; set; }
        public string Explain { get; set; }
        public string Kannada { get;  set; }
        public string Hindi { get;  set; }
        public byte[] Play { get; set; }
    }
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
        using (LearnDBConnection db = new LearnDBConnection())
        {
            var newuser = db.Beg_Result.Where(x => x.Username == hdnusername.Value).ToList();
            if (!newuser.Any())
            {
                imgPrevious.Visible = false;
                 getChaptersPerDay = db.CourseMsts.Where(x => x.Lesson == lessonCompleted + 1).Select(x => x.Topics).SingleOrDefault();
                iSkip = 0;
            }
            var query = db.Beg_Alphabet.Join( db.Beg_Translate,x=> x.Id,y=> y.begAlphabetId , (x, y) =>new { x,y})
                .Join(db.Beg_Files,a=> a .x.Id ,b=> b.BegAlphabetId ,(a,b)=> new  {a,b}).Take(Convert.ToInt32( getChaptersPerDay))
                .Select(xy => new Learning()
            {
                Id=xy.a.x.Id,
                CapitalLetters  = xy.a.x.CapitalLetter,
                SmallLetters = xy.a.x.SmallLetter ,
                Kannada = xy.a.y.Kannada,
                Hindi = xy.a.y.Hindi,
                Play=xy.b.Play
            }).ToList();
            grdchaptr.DataSource = query;
            grdchaptr.DataBind();
        }
        
    }
    protected void questionnaire_databound(object sender, GridViewRowEventArgs e)
    {

        GridView rbl_responses = (GridView)e.Row.Cells[2].FindControl("grdResponse");

        question = (vwCurrentSurvey)e.Row.DataItem;

        if (e.Row.RowType == DataControlRowType.DataRow && question != null)
        {
            rbl_responses..Add(new ListItem("A: " + question.ResponseA, "A"));
            rbl_responses.Items.Add(new ListItem("B: " + question.ResponseB, "B"));
            rbl_responses.Items.Add(new ListItem("C: " + question.ResponseC, "C"));
            rbl_responses.Items.Add(new ListItem("D: " + question.ResponseD, "D"));
        }

    }


   
    protected void OnClick_Next(object sender, EventArgs e)
    {
        grdchaptr.Visible = false;

        rblTest.DataSource=


        Response.Write("hi");
    }

    protected void btnSignOut_Click(object sender,EventArgs e)
    {
        Session["USERNAME"] = null;
        Response.Redirect("home");
    }
}