using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;


public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Convert.ToString(Request.Cookies["um"]) ) && (!String.IsNullOrEmpty(Convert.ToString(Request.Cookies ["ptd"]))))
            {
                txtUserName.Text = Request.Cookies["um"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["ptd"].Value;
                chkRemember.Checked = true;
            }
        }
        Login_Click1(sender,e);
    }
    
    protected void Login_Click1(object sender, EventArgs e)
    {
        using (LearnDBConnection db = new LearnDBConnection())
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var userlog = db.Users.Single(a => a.Username == txtUserName.Text && a.Password == txtPassword.Text);
                    if (userlog != null)
                    {
                        if (chkRemember.Checked)
                        {
                            Response.Cookies["um"].Value = txtUserName.Text;
                            Response.Cookies["ptd"].Value = txtPassword.Text;
                            Response.Cookies["um"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["ptd"].Expires = DateTime.Now.AddDays(-1);
                        }
                        else
                        {
                            Response.Cookies["um"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["ptd"].Expires = DateTime.Now.AddDays(-1);

                        }
                        string utype;
                        utype = userlog.Usertype.ToString().Trim().ToUpper();
                        if (utype == "A")
                        {
                            Session["USERNAME"] = txtUserName.Text;
                            Session["ut"] = utype;
                            FormsAuthentication.RedirectFromLoginPage("admin", true); ;
                           
                        }
                        else if (utype == "U")
                        {

                            Session["USERNAME"] = txtUserName.Text;
                            Session["ut"] = utype;
                            Session["lgpr"] = userlog.LanguagePrefered;
                            FormsAuthentication.RedirectFromLoginPage("user", true); ;
                           // Response.Redirect("user",false);
                          
                        }
                    }
                    else
                    {
                        lblError.Text = "Invalid User or Password! ";
                    }
                }
                catch (Exception ex)
                {
                }
            
        }
        }
    }
}