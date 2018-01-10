using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Student_College_Get : System.Web.UI.Page
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
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";
        SqlConnection conn = new SqlConnection(strCon);
        DataSet ds = new DataSet();
        string str = "SELECT c_id AS 院编号, c_name AS 院名称 FROM college";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds);
        conn.Close();
        Course1.DataSource = ds;
        Course1.DataBind();
    }



}