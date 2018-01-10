using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Student_Grade_Get : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (CheckUserIsLogin() == true)
        {
            InitData();
        }
        else
        {
            Response.Redirect("login.aspx");
        }



    }


    /*检测用户是否登录*/
    private bool CheckUserIsLogin()
    {
        if (Session["login_id"] == null)
        {
            Response.Write("<script language=javascript>alert('请先登录！');</script>");
            return false;
        }

        return true;
    }


    /*如果用户登录，那么就展示院系*/
    private void InitData()
    {


        SqlDataReader dr;
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";

        SqlConnection conn = new SqlConnection(strCon);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        string str = "SELECT sc.c_id AS 课程编号, c.c_name AS 课程名称, sc.sc_score AS 成绩 FROM SC sc  LEFT JOIN Course c ON sc.c_id = c.c_id LEFT JOIN Teacher t on sc.t_id = t.t_id WHERE sc.s_id = @StudentId ORDER BY sc.s_id , sc.t_id";
        cmd.CommandText = str;
        cmd.CommandType = System.Data.CommandType.Text;

        //添加查询对象，并且给参数赋值
        SqlParameter para = new SqlParameter("@StudentId", SqlDbType.Char, 18);
        para.Value = Session["login_id"];
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();
            Course1.DataSource = dr;
            Course1.DataBind();

        }
        catch (SqlException exception)
        {
            Response.Write(exception.Message);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}