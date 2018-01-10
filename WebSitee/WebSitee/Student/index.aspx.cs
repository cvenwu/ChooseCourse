using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;



public partial class Student_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
        if(CheckUserIsLogin() == true)
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
        if(Session["login_id"] == null)
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
        string str = "SELECT c.c_id AS 课程编号, t2.t_name AS 课程类别, c.c_name AS 课程名称, t.t_name AS 教师名称, c.c_score AS 课程学分, c.c_time AS 课程学时, c.c_number AS 课程总容量, c.c_balannumber AS 课程剩余容量 FROM Course c LEFT JOIN teacher t ON t.t_id = c.te_id LEFT JOIN Type t2 ON t2.t_id = c.ty_id ORDER BY c.c_id; ";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds);
        conn.Close();
        Course1.DataSource = ds;
        Course1.DataBind();
    }
}