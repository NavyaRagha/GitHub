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
            if (!String.IsNullOrEmpty(Convert.ToString(Request.Cookies["UM"]) ) && (!String.IsNullOrEmpty(Convert.ToString(Request.Cookies ["PWD"]))))
            {
                txtUserName.Text = Request.Cookies["UM"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["PWD"].Value;
                chkRemember.Checked = true;
            }
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
      
    }

    protected void Login_Click1(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Select * from Users where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text +
                    "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                if (chkRemember.Checked)
                {
                    Response.Cookies["UM"].Value = txtUserName.Text;
                    Response.Cookies["PWD"].Value = txtPassword.Text;
                    Response.Cookies["UM"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
                }
                else
                {
                    Response.Cookies["UM"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);

                }

                string utype;
                utype = dt.Rows[0][5].ToString().Trim();
                if (utype == "A")
                {
                    Session["USERNAME"] = txtUserName.Text;
                    Response.Redirect("~/AdminHome.aspx");
                }
                else if (utype == "U")
                {

                    Session["USERNAME"] = txtUserName.Text;
                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true); ;
                    Response.Redirect("~/UserHome.aspx");


                }

            }
            else
            {
                lblError.Text = "Invalid User or Password! ";
            }
        }
    }
}