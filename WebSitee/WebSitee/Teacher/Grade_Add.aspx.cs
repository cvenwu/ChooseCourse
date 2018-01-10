using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Teacher_Grade_Add : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (CheckUserIsLogin() == true)
        {
            //InitData();
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
    /*
    private void InitData()
    {
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";
        SqlConnection conn = new SqlConnection(strCon);
        DataSet ds = new DataSet();
        string str = "SELECT sc.c_id AS 课程编号, c.c_name AS 课程名称, s.s_id AS 学号 , s.s_name AS 学生姓名 FROM SC sc LEFT JOIN Student s ON sc.s_id = s.s_id LEFT JOIN Course c ON sc.c_id = c.c_id WHERE sc.sc_score IS NULL ORDER BY sc.c_id; ";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds);
        Grade1.DataSource = ds;

        Grade1.DataBind();
        conn.Close();
    }*/







    //添加成绩按钮事件
    protected void AddCourse(object sender, EventArgs e)
    {
        /*获取用户填写的值*/
        string courseId = CourseId.Text.Trim();
        string studentId = StudentId.Text.Trim();
        string courseGrade = CourseGrade.Text.Trim();
        string teacherId = (string)Session["login_id"];


        SqlDataReader dr;
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";

        SqlConnection conn = new SqlConnection(strCon);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        string str = "INSERT INTO SC VALUES(@StudentId, @CourseId, @TeacherId, @Sc_score, @Sc_status);";
        cmd.CommandText = str;
        cmd.CommandType = System.Data.CommandType.Text;

        //添加查询对象，并且给参数赋值
        SqlParameter para = new SqlParameter("@CourseId", SqlDbType.Char, 18);
        para.Value = courseId;
        cmd.Parameters.Add(para);
        SqlParameter para2 = new SqlParameter("@StudentId", SqlDbType.Char, 18);
        para2.Value = studentId;
        cmd.Parameters.Add(para2);
        SqlParameter para3 = new SqlParameter("@TeacherId", SqlDbType.VarChar, 30);
        para3.Value = teacherId; ;
        cmd.Parameters.Add(para3);
        SqlParameter para4 = new SqlParameter("@Sc_score", SqlDbType.Char, 18);
        para4.Value = courseGrade;
        cmd.Parameters.Add(para4);

        SqlParameter para5 = new SqlParameter("@Sc_status", SqlDbType.Float, 3);
        para5.Value = "1";
        cmd.Parameters.Add(para5);


        Response.Write(cmd.CommandText);

        try
        {
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>插入成功！</script>");
                Response.Redirect("Grade_Add.aspx");
            }
            else
            {
                Response.Write("<script>插入失败！</script>");
            }

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
