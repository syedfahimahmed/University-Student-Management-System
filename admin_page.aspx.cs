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

public partial class admin_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Label1.Text = Session["user"].ToString();

        }
        if (!IsPostBack)
        {
            caldata();
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
                cmd.CommandText = "Select ro_id, dept_id, sem_name, sec, ro_name FROM dbo.routine";
                cmd.Connection = con;
                con.Open();
                GridView3.DataSource = cmd.ExecuteReader();
                GridView3.DataBind();
                con.Close();
            }
        }

    }

    private void caldata()
    {
        using (SqlConnection con = new SqlConnection(
           WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select cal_id, cal_name FROM dbo.calender";
                cmd.Connection = con;
                con.Open();
                GridView5.DataSource = cmd.ExecuteReader();
                GridView5.DataBind();
                con.Close();
            }
        }

    }
    /*protected void Page_Load(object sender, EventArgs e)
    {
        //ConnectDB();
    }

    public void ConnectDB()
    {
        SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
        con.Open();
      if (con.State == System.Data.ConnectionState.Open)
        {
            DisplayMessage(this, "Connection to the database successful");
        }
        else
        {
            DisplayMessage(this, "Connection Failed");
        }
       
    }*/
    static public void DisplayMessage(Control page, string msg)
    {
        string myScript = String.Format("alert('{0}')", msg);
        ScriptManager.RegisterStartupScript(page, page.GetType(), "MyScript", myScript, true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*try
        {
            SqlConnection con = new SqlConnection(
                 WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();

            string query = "insert into student(s_id,_s_pass, dept_id, sem_name)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + ListBox1.Text + "','" + ListBox2.Text + "')";

            SqlCommand cmd = new SqlCommand(query, con);
        }
        catch (Exception ex)
        {
            DisplayMessage(this, ex.ToString());
           
        }*/
        try
        {
            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into student(s_id, s_pass, dept_id, sem_name) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            Response.Redirect("admin_page.aspx");
        }
        catch (Exception ex)
        {
                String script = "alert(\"Insert Failed\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        /*try
        {
            SqlConnection con = new SqlConnection(
                 WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();

            string query = "insert into student(s_id,_s_pass, dept_id, sem_name)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + ListBox1.Text + "','" + ListBox2.Text + "')";

            SqlCommand cmd = new SqlCommand(query, con);
        }
        catch (Exception ex)
        {
            DisplayMessage(this, ex.ToString());
           
        }*/
        try
        {
            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into teacher(t_id, t_pass, dept_id, designation) values ('" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList3.SelectedItem.Text + "','" + DropDownList10.SelectedItem.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            Response.Redirect("admin_page.aspx");
        }
        catch (Exception ex)
        {
            String script = "alert(\"Insert Failed\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        /*try
        {
            SqlConnection con = new SqlConnection(
                 WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();

            string query = "insert into student(s_id,_s_pass, dept_id, sem_name)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + ListBox1.Text + "','" + ListBox2.Text + "')";

            SqlCommand cmd = new SqlCommand(query, con);
        }
        catch (Exception ex)
        {
            DisplayMessage(this, ex.ToString());
           
        }*/
        try
        {
            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into event(e_title, e_date, e_detail) values ('" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            Response.Redirect("admin_page.aspx");
        }
        catch (Exception ex)
        {
            String script = "alert(\"Insert Failed\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
    }


    protected void Button11_Click(object sender, EventArgs e)
    {
        /*SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
        con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT [s_id], [s_name], [s_pass] FROM [student] WHERE [dept_id]='" + ListBox4.Text+ "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        GridView1.DataSource = dt;*/


        //string query = "select s_id, s_name,s_pass from student";
        //string queryName = "select s_name from student where s_id ='" + TextID.Text + "' ";

        //SqlCommand cmd = new SqlCommand(query, con);
        //string output = cmd.ExecuteScalar().ToString();
        /*SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
        con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT s_id, s_name, dept_id FROM student WHERE dept_id ='" + DropDownList4.SelectedItem.Text + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        GridView4.DataSource = dt;

        con.Close();*/
        //Response.Redirect("admin_page.aspx");
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        try
        {
            string deptUpload = DropDownList8.SelectedItem.Text;
            string semUpload = DropDownList7.SelectedItem.Text;
            string secUpload = DropDownList9.SelectedItem.Text;
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;

            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    using (SqlConnection con = new SqlConnection(
                   WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
                    {
                        string query = "insert into routine(dept_id, sem_name, sec, ro_name, ro_contenttype, ro_pdf) values(@dept_id, @sem_name, @sec, @ro_name, @ro_contenttype, @ro_pdf)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@dept_id", deptUpload);
                            cmd.Parameters.AddWithValue("@sem_name", semUpload);
                            cmd.Parameters.AddWithValue("@sec", secUpload);
                            cmd.Parameters.AddWithValue("@ro_name", filename);
                            cmd.Parameters.AddWithValue("@ro_contenttype", contentType);
                            cmd.Parameters.AddWithValue("@ro_pdf", bytes);
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
            String script = "alert(\"Upload Failed\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

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

    protected void Button4_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
        string contentType = FileUpload2.PostedFile.ContentType;
        try
        {
            using (Stream fs = FileUpload2.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    using (SqlConnection con = new SqlConnection(
                   WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
                    {
                        string query = "insert into calender(cal_name, cal_contenttype, cal_pdf) values(@cal_name, @cal_contenttype, @cal_pdf)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;

                            cmd.Parameters.AddWithValue("@cal_name", filename);
                            cmd.Parameters.AddWithValue("@cal_contenttype", contentType);
                            cmd.Parameters.AddWithValue("@cal_pdf", bytes);
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
            String script = "alert(\"Upload Failed\");";
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
                    cmd.CommandText = "Select cal_name, cal_contenttype, cal_pdf FROM calender where cal_id=@cal_id";
                    cmd.Parameters.AddWithValue("@cal_id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader str = cmd.ExecuteReader())
                    {
                        str.Read();
                        bytes = (byte[])str["cal_pdf"];
                        contentType = str["cal_contenttype"].ToString();
                        fileName = str["cal_name"].ToString();
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
        Session.Remove("user");
        Response.Redirect("Default.aspx");
    }
}


