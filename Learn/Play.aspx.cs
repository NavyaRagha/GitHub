using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Play : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        using (BinaryReader br = new BinaryReader(FileUpload11.PostedFile.InputStream))
        {
            byte[] bytes = br.ReadBytes((int)FileUpload11.PostedFile.InputStream.Length);
            string strConnString = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "insert into tblFiles(Name, ContentType, Data) values (@Name, @ContentType, @Data)";
                    cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload11.PostedFile.FileName));
                    cmd.Parameters.AddWithValue("@ContentType", "audio/mpeg3");
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    private void BindGrid()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["LearnData"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Id, Name,Url,Data from tblFiles";
                cmd.Connection = con;
                con.Open();
                GridView11.DataSource = cmd.ExecuteReader();
                GridView11.DataBind();
                con.Close();
            }
        }
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