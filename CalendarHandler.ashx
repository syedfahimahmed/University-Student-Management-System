<%@ WebHandler Language="C#" Class="CalendarHandler" %>

using System;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;

public class CalendarHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        try
        {
            string cal_id = context.Request.QueryString["cal_id"].ToString();
            SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
            con.Open();
            string query = "select cal_pdf from calender where cal_id=@cal_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cal_id", 1);
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