<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        try
        {
            string s_id = context.Request.QueryString["s_id"].ToString();
          
            SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
            con.Open();
            string query = "select s_photo from student where s_id=@s_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@s_id", s_id.ToString());
            object data = cmd.ExecuteScalar();
            con.Close();
            cmd.Dispose();
            context.Response.BinaryWrite((byte[])data);
        }
        catch (Exception ex)
        {

        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}