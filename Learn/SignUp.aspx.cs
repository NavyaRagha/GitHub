using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        if (txtusername.Text != "" && txtPassword.Text != "" && txtConfirmPass.Text != "" && txtEmail.Text != "" &&
            txtName.Text != "")
        { 
            if (txtPassword.Text == txtConfirmPass.Text)
            {
                string cs = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd =
                            new SqlCommand(
                                " Insert into Users values ('" + txtusername.Text + "','" + txtPassword.Text + "', '" +
                                txtEmail.Text + "','" + txtName.Text + "' , '" + "U" + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    lblMsg.ForeColor=Color.Green;
                    lblMsg.Text = "Registration Successfull";
                    Response.Redirect("~/SignIn.aspx");
                    con.Close();
                    }
                }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Password Do Not Match";
            }
            }
        else
        {
            lblMsg.ForeColor=Color.Red;
            lblMsg.Text = "All Fields Are Required";

        }
    }
    }
