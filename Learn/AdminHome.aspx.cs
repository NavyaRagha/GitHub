using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

     
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {Int32 fkkey=0;
        using (BinaryReader br = new BinaryReader(FileUpload11.PostedFile.InputStream))
        {
            byte[] bytes = br.ReadBytes((int)FileUpload11.PostedFile.InputStream.Length);
            string strConnString = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
             

                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        
                        // BeginTransaction() Requires Open Connection
                        con.Open();

                        transaction = con.BeginTransaction();

                        // Assign Transaction to Command
                        cmd.Transaction = transaction;

                        // Execute 1st Command
                        cmd.CommandText = "insert into beg_Ind_1(FileName, Description, ContentType,Data) values (@Name,@Description, @ContentType, @Data)" ;
                        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload11.PostedFile.FileName));
                        cmd.Parameters.AddWithValue("@ContentType", txtContentType.Text );
                        cmd.Parameters.AddWithValue("@Description", txtExplain.Text );
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                       

                        cmd.CommandText = "Select top 1 Id from beg_Ind_1 order by Id Desc";
                        cmd.Connection = con;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            fkkey = Convert.ToInt32(dt.Rows[0][0]); 
                        }
                        else
                        {
                            transaction.Rollback();
                           
                        }
                       
                        // Execute 2nd Command
                        cmd.CommandText = "insert into beg_Tra_1( BegIndId, Kannada,Hindi) values (@fkkey, @Kannada, @Hindi)";
                        cmd.Parameters.AddWithValue("@fkkey", fkkey);
                        cmd.Parameters.AddWithValue("@Kannada", txtKannada.Text);
                        cmd.Parameters.AddWithValue("@Hindi", txtHindi.Text);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                    //cmd.CommandText = "insert into tblFiles(Name, ContentType, Data) values (@Name, @ContentType, @Data)";
                    //cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload11.PostedFile.FileName));
                    //cmd.Parameters.AddWithValue("@ContentType", "audio/mpeg3");
                    //cmd.Parameters.AddWithValue("@Data", bytes);
                    //cmd.Connection = con;
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}