using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Student_System_Get : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CollogeToSearch.ToolTip = "请输入查询的学院";
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
        string str = "SELECT s.s_id AS 系部编号, s.s_name AS 系部名称, c.c_name AS 所属院 FROM System s LEFT JOIN College c ON s.c_id = c.c_id";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds);
        conn.Close();
        System1.DataSource = ds;
        System1.DataBind();
    }

    /*根据用户输入的系部名称查找该系部以及该系部所在的学院*/
    protected void SearchCollege(object sender, EventArgs e)
    {
        SqlDataReader dr;
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";

        SqlConnection conn = new SqlConnection(strCon);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        string sql = "SELECT s.s_id AS 系部编号, s_name AS 系部名称 FROM System s WHERE s.c_id = ( SELECT c_id FROM College WHERE c_name = @SystemName);";
        cmd.CommandText = sql;
        cmd.CommandType = System.Data.CommandType.Text;
        
        //添加查询对象，并且给参数赋值
        string collegeToSearch = CollogeToSearch.Text.Trim();
        SqlParameter para = new SqlParameter("@SystemName", SqlDbType.VarChar, 50);
        para.Value = collegeToSearch;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                conn.Close();
            }
            else
            {
                Response.Write("<script>alert('输入的学院名称错误!')</script>");
                CollogeToSearch.Text = "";
            }
        }catch(SqlException exception)
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