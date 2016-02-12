using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        if (txtusername.Text != "" && txtPassword.Text != "" && txtConfirmPass.Text != "" && txtEmail.Text != "" && ddlPreferedLanguage.SelectedItem.Text!="Select" && 
            txtName.Text != "")
        {
            if (txtPassword.Text == txtConfirmPass.Text)
            {

                using (LearnDBConnection db = new LearnDBConnection())
                {
                    using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        { 
                            var username = db.Users.Where(a=> a.Username == txtusername.Text).Select(x => x.Username).FirstOrDefault();
                            if (username == null)
                            {
                                var addUser = new User
                                {
                                    Username  = txtusername.Text,
                                    Password  = txtPassword.Text,
                                    Email = txtEmail.Text ,
                                    Name = txtName.Text,
                                    LanguagePrefered  = ddlPreferedLanguage.SelectedItem.Text,
                                   
                                };
                                db.Users.Add(addUser);
                            }
                            else
                            {
                                lblMsg.ForeColor = Color.Red;
                                lblMsg.Text = "Username Already Exists In Our Database";
                            }
                           
                            db.SaveChanges();
                            trans.Commit();
                            Response.Redirect("~/SignIn.aspx",false);

                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            
            //string cs = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
                //    using (SqlConnection con = new SqlConnection(cs))
                //    {

                //        SqlCommand cmduser =
                //            new SqlCommand("Select Username from Users where username ='" + txtusername.Text + "'", con);
                //    SqlDataAdapter sda = new SqlDataAdapter(cmduser);
                //    DataTable dt = new DataTable();
                //    sda.Fill(dt);
                //        if (dt.Rows.Count == 0)
                //        {

                //            SqlCommand cmd =
                //                new SqlCommand(
                //                    " Insert into Users values ('" + txtusername.Text + "','" + txtPassword.Text +
                //                    "', '" +
                //                    txtEmail.Text + "','" + txtName.Text + "' , '" + "U" + "')", con);
                //            con.Open();
                //            cmd.ExecuteNonQuery();
                //            lblMsg.ForeColor = Color.Green;
                //            lblMsg.Text = "Registration Successfull";
                //            Response.Redirect("~/SignIn.aspx");
                //            con.Close();
                //        }
                //        else
                //        {
                //        lblMsg.ForeColor = Color.Red;
                //        lblMsg.Text = "Username Already Exists In Our Database";
                //    }
                //}
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
