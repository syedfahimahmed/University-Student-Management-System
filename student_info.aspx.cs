using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class student_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = "Handler.ashx?s_id=" + Session["ID"];
        if (Session["user"] != null)
        {
            LabelName.Text = Session["user"].ToString();
            Label1.Text = Session["Dept"].ToString();
            Label2.Text = Session["Sem"].ToString();
        }

        if (!IsPostBack)
        {
            filldata();
            //caldata();
        }

    }

    private void filldata()
    {
        using (SqlConnection con = new SqlConnection(
           WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "Select ro_id, dept_id, sem_name, sec, ro_name FROM dbo.routine where dept_id=(select dept_id from student where s_id='" + Session["ID"].ToString() + "'), sem_name=(select sem_name from student where s_id='" + Session["ID"].ToString() + "'),sec=(select sec from student where s_id='" + Session["ID"].ToString() + "')";
                cmd.CommandText = "Select ro_id, dept_id, sem_name, sec, ro_name FROM dbo.routine";
                cmd.Connection = con;
                con.Open();
                GridView2.DataSource = cmd.ExecuteReader();
                GridView2.DataBind();
                con.Close();
            }
        }

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Session.Remove("user");
        Session.Remove("ID");
        Session.Remove("Pass");
        Session.Remove("Dept");
        Session.Remove("Sem");
        Response.Redirect("Default.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string dept = Session["Dept"].ToString();
        string sem = Session["Sem"].ToString();

        using (SqlConnection con = new SqlConnection(
          WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select m_id, chap_name, m_name FROM dbo.material where dept_id='" + dept + "'and sem_name='" + sem + "' ";
                cmd.Connection = con;
                con.Open();
                GridView3.DataSource = cmd.ExecuteReader();
                GridView3.DataBind();
                con.Close();
            }
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        try
        {
            using (SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select m_name, m_contenttype, m_pdf FROM material where m_id=@m_id";
                    cmd.Parameters.AddWithValue("@m_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader str = cmd.ExecuteReader())
                    {
                        str.Read();
                        bytes = (byte[])str["m_pdf"];
                        contentType = str["m_contenttype"].ToString();
                        fileName = str["m_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            String script = "alert(\"Download Failed\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        string nameUpload = TextBox1.Text;
        string emailUpload = TextBox2.Text;
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;
        try
        {
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    using (SqlConnection con = new SqlConnection(
                   WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
                    {
                        string query = "update student set s_name=@s_name, s_email=@s_email, s_photo=@s_photo, s_contenttype=@s_contenttype, s_mname=@s_mname where s_id = '" + Session["ID"].ToString() + "'";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;

                            cmd.Parameters.AddWithValue("@s_name", nameUpload);
                            cmd.Parameters.AddWithValue("@s_email", emailUpload);

                            cmd.Parameters.AddWithValue("@s_photo", bytes);
                            cmd.Parameters.AddWithValue("@s_contenttype", contentType);
                            cmd.Parameters.AddWithValue("@s_mname", filename);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            String script = "alert(\"Update Failed\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        try
        {
            using (SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select ro_name, ro_contenttype, ro_pdf FROM routine where ro_id=@ro_id";
                    cmd.Parameters.AddWithValue("@ro_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader str = cmd.ExecuteReader())
                    {
                        str.Read();
                        bytes = (byte[])str["ro_pdf"];
                        contentType = str["ro_contenttype"].ToString();
                        fileName = str["ro_name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            String script = "alert(\"Download Failed\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
    }

}