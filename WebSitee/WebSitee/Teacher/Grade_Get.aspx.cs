using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Teacher_Grade_Get : System.Web.UI.Page
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


    /*如果用户登录，那么就展示全部课程*/
    private void InitData()
    {
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";
        SqlConnection conn = new SqlConnection(strCon);
        DataSet ds = new DataSet();
        string str = "SELECT sc.c_id AS 课程编号, c.c_name AS 课程名称, s.s_id AS 学号 , s.s_name AS 学生姓名, sc.sc_score AS  成绩 FROM SC sc LEFT JOIN Student s ON sc.s_id = s.s_id LEFT JOIN Course c ON sc.c_id = c.c_id ORDER BY sc.c_id; ";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds);
        conn.Close();
        Grade1.DataSource = ds;
        Grade1.DataBind();
    }

}