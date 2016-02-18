using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Play : System.Web.UI.Page
{
    public class Files
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        using (dbExtranetEntities db = new dbExtranetEntities())
        {
            using (var trans = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(FileUpload11.PostedFile.InputStream))
                    {
                        byte[] bytes = br.ReadBytes((int)FileUpload11.PostedFile.InputStream.Length);
                        var bf= new Beg_Files
                        {
                            Name = Path.GetFileName(FileUpload11.PostedFile.FileName),
                            ContentType = "audio/mpeg3",
                            Play  = bytes,
                            BegAlphabetId = 1
                        };
                        db.Beg_Files.Add(bf);
                        db.SaveChanges();
                        trans.Commit();
                    }
                    //Response.Redirect(Request.Url.AbsoluteUri);
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            
            }
        }
        //using (BinaryReader br = new BinaryReader(FileUpload11.PostedFile.InputStream))
                    //{
                    //    byte[] bytes = br.ReadBytes((int)FileUpload11.PostedFile.InputStream.Length);
                    //    string strConnString = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
                    //    using (SqlConnection con = new SqlConnection(strConnString))
                    //    {
                    //        using (SqlCommand cmd = new SqlCommand())
                    //        {
                    //            cmd.CommandText = "insert into Beg_Files(Name, ContentType, Play) values (@Name, @ContentType, @Play)";
                    //            cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload11.PostedFile.FileName));
                    //            cmd.Parameters.AddWithValue("@ContentType", "audio/mpeg3");
                    //            cmd.Parameters.AddWithValue("@Play", bytes);
                    //            cmd.Connection = con;
                    //            con.Open();
                    //            cmd.ExecuteNonQuery();
                    //            con.Close();
                    //        }
                    //    }
                    //}
                    //
                }
    private void BindGrid()
    {
        ////List<Files> file = new List<Files>();
        //int Id;
        //string Url;
        //string Name;
        //byte[] Data;
        //string strConnString = ConfigurationManager.ConnectionStrings["dbExtranetEntities"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(strConnString))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {



        //        SqlDataReader rdr = null;
        //        cmd.CommandText = "select Id, Name,Data from tblFiles";
        //        cmd.Connection = con;
        //        con.Open();

        //        rdr = cmd.ExecuteReader();
        //        rdr.Read();




        //        // byte[] temp = (byte[])rdr["Data"];

        //        //while (rdr.Read())
        //        //{
        //        //    file.Add(new Files()
        //        //    {
        //        Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
        //        //Url = rdr.GetString(rdr.GetOrdinal("Url"));
        //        Name = rdr.GetString(rdr.GetOrdinal("Name"));
        //        Data = (byte[])rdr["Data"];
        //        //});

        //        //}   


        //        GridView11.DataSource = rdr;
        //        GridView11.DataBind();
        //        con.Close();
        //    }
        //}
    }
    private void PlaySampleFile(object sender, GridViewCommandEventArgs e)
    {
       if (e.CommandName == "Play")
       {
           //Response.Redirect("/AV_Samples/" & e.CommandArgument);
       }
 }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal media = (Literal)e.Row.Cells[1].FindControl("Literal1");
            string mediaId = "media-" + media.UniqueID;
            string str = "";

            if (media.Text.EndsWith(".mp4"))
            {
                str = "<video src='" + media.Text + "' controls='controls' id='" + mediaId + "' />";
            }
            else
            {
                str = "<audio src='" + media.Text + "' controls='controls' id='" + mediaId + "' />";
            }
            media.Text = str;
        }
    }
}