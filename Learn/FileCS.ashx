<%@ WebHandler Language="C#" Class="FileCS" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;

public class FileCS : IHttpHandler
{
    public class Plays
    {
        public byte[] dta { get; set; } //      byte[] bytes;
        public string ContentType { get; set; } // string contentType;
        public string name { get; set; } //  string name;
    }

    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request.QueryString["id"]);
        string strConnString = ConfigurationManager.ConnectionStrings["LearnDBConnection"].ConnectionString;

        string name1;
        string contentType1;
        byte[] byt;


        using (LearnDBConnection db = new LearnDBConnection())
        {
            var playlist = db.Beg_Files.Where(x => x.BegAlphabetId == id)
                .Select(xy => new Plays()
                {
                    dta = (byte[]) xy.Play,
                    ContentType = xy.ContentType.ToString(),
                    name = xy.Name.ToString()
                }).FirstOrDefault();

            //}
            //using (SqlConnection con = new SqlConnection(strConnString))
            //    {
            //        using (SqlCommand cmd = new SqlCommand())
            //        {
            //            cmd.CommandText = "select Name, Data, ContentType from tblFiles where Id=@Id";
            //            cmd.Parameters.AddWithValue("@Id", id);
            //            //cmd.Connection = con;
            //            //con.Open();
            //            SqlDataReader sdr = cmd.ExecuteReader();
            //            sdr.Read();
            //            byt = (byte[])sdr["Data"];
            //            contentType1 = sdr["ContentType"].ToString();
            //            name1 = sdr["Name"].ToString();
            //            con.Close();
            //        }
            //    }

            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + playlist.name );
            context.Response.ContentType = playlist.ContentType;
            context.Response.BinaryWrite(playlist.dta);
            context.Response.End();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}