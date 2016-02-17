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
using System.Net.Mail;
using System.Net;
public partial class ForgotPassword : System.Web.UI.Page
{
    public string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnPassRec_Click(object sender, EventArgs e)
    {

        string cs = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Select * from Users where Email='" + txtemailid.Text + "' ", con);
            con.Open();
            SqlDataAdapter sDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sDa.Fill(dt);
            if (dt.Rows.Count != 0 )
            {
                string myGuID = Guid.NewGuid().ToString();
                int Uid = Convert.ToInt32(dt.Rows[0][0]);
                SqlCommand cmd1= new SqlCommand( "insert into ForgotPassRequests values( '" + myGuID  + "','" + Uid  + "',getdate())", con);
                cmd1.ExecuteNonQuery();

                //send Email



                 string toEmailAddress = dt.Rows[0][3].ToString();
                string Username = dt.Rows[0][1].ToString();
                //string EmailBody = "Hi" + Username + ",<br/></br> test mail <br/> --http://localhost:21929/RecoverPassword.aspx?Uid=" + myGuID;
                string EmailBody = "Hi" + Username + ",<br/></br> test mail <br/>" + myGuID;
                MailMessage PassrecMail = new MailMessage("navs.navya@gmail.com", toEmailAddress);
                PassrecMail.Body = EmailBody;
                PassrecMail.IsBodyHtml = true;
                PassrecMail.Subject = "Reset Password";
                // < network host = "mail.momle.com" port = "1025" userName = "it@cedarglenhomes.com" password = "guard1*n" />

                SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 465);
                SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
               // SmtpClient SMTP = new SmtpClient("mail.momle.com", 1025);
                SMTP.Credentials = new NetworkCredential()
                {
                    UserName = "navs.navya@gmail.com",
                    Password = "#canada1234"

                    //UserName = "it@momle.com",
                    //Password = "guard1*n"
                };
                SMTP.EnableSsl = true;
                SMTP.Send(PassrecMail);

                lblpassrec.Text = "Check your E-mail to reset your password";
                lblpassrec.ForeColor = Color.Green;
            }
            else
            {
                lblpassrec.Text = "Please enter a valid E-mail ID";
                lblpassrec.ForeColor = Color.Red;
            }
        }
    }
}