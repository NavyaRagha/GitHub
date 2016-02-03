using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class RecoverPassword : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
     string GUIDvalue;
    DataTable dt= new DataTable();
    private int Uid;
    protected void Page_Load(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            GUIDvalue = Request.QueryString["Uid"];
            if (GUIDvalue != null)
            {
                SqlCommand cmd = new SqlCommand("select * from ForgotPassRequests where id='" + GUIDvalue + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {

                    Uid = Convert.ToInt32(dt.Rows[0][1]);
                }
                else
                {
                    lblmsg.Text = "Your Password Reset link is Expired or is Invali";
                    lblmsg.ForeColor = Color.Red;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        if (!IsPostBack)
        {
            if (dt.Rows.Count != 0)
            {
                txtNewPass.Visible = true;
                txtConfirmPassword.Visible = true;
                lblPassword.Visible = true;
                lblRetypePassword.Visible = true;
                btnResetPassword.Visible = true;
            }
            else
            {
                lblmsg.Text = "Your Password Reset link is Expired or is Invali";
                lblmsg.ForeColor = Color.Red;
            }
        }
    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        if (txtNewPass.Text != "" && txtConfirmPassword.Text != "" && txtNewPass.Text == txtConfirmPassword.Text)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("update users set password='" + txtNewPass.Text + "' where uid='" + Uid + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("delete from ForgotPassRequests where Uid='" + Uid + "'", con);
                cmd1.ExecuteNonQuery();
                Response.Redirect("~/SignIn.aspx");
            }
    }
}
}