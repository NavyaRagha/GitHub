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
        using (LearnDBConnection db = new LearnDBConnection())
        {
            var newuser = db.Beg_Result.Where(x => x.Username == hdnusername.Value).ToList();
            if (!newuser.Any())
            {
                 getChaptersPerDay = db.CourseMsts.Where(x => x.Lesson == lessonCompleted + 1).Select(x => x.Topics).SingleOrDefault();
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
            DataList1.DataSource = query;
            DataList1.DataBind();
        }
        
    }

    //    //int sum = 0;
    //    //String sRandomResult = "";

    //    //sum += r.Next(0, 100);
    //    //sRandomResult = sum.ToString();

    //    //Random oRandom =r.Next(0, 100);
    //    //    int iLongitudPin = 5;
    //    //    String sCharacters = "123456789ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
    //    //    int iLength = sCharacters.Length;
    //    //    char cCharacter;
    //    //    int iLongitudNuevaCadena = iLongitudPin;

    //    //    for (int i = 0; i < iLongitudNuevaCadena; i++)
    //    //    {
    //    //        cCharacter = sCharacters[oRandom.Next(iLength)];
    //    //        sRandomResult += cCharacter.ToString();
    //    //    }
    //    return (randomNumbers);
    //}

    protected void btnSignOut_Click(object sender,EventArgs e)
    {
        Session["USERNAME"] = null;
        Response.Redirect("home");
    }
}