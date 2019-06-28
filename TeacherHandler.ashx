<%@ WebHandler Language="C#" Class="TeacherHandler" %>

using System;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;

public class TeacherHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        try
        {
            string id = context.Request.QueryString["t_id"].ToString();
            int t_id = Int32.Parse(id);
            SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
            con.Open();
            string query = "select t_photo from teacher where t_id=@t_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@t_id", t_id);
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