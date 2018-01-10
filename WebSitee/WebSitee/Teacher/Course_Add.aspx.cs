using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Teacher_Course_Add : System.Web.UI.Page
{

    /*得到全部课程种类,并且将全部课程种类添加到DropDownList中*/
    protected void GetAllCourseType()
    {
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";
        SqlConnection conn = new SqlConnection(strCon);
        DataSet ds = new DataSet();
        string str = "SELECT t_id, t_name FROM Type; ";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds, "Type");
        CourseType.DataSource = ds.Tables["Type"].DefaultView;
        CourseType.DataTextField = "t_name";
        CourseType.DataBind();
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (CheckUserIsLogin() == true)
        {
            GetAllCourseType();
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


    


    /*点击添加按钮事件，进行开办课程登记*/
    protected void AddCourse(object sender, EventArgs e)
    {
        /*获取用户填写的值*/
        string courseId = CourseId.Text.Trim();
        string courseType = CourseType.SelectedItem.Text.Trim();
        string courseName = CourseName.Text.Trim();
        string courseScore = CourseScore.Text.Trim();
        string courseTime = CourseTime.Text.Trim();
        string courseNumber = CourseNumber.Text.Trim();


        SqlDataReader dr;
        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";

        SqlConnection conn = new SqlConnection(strCon);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        string str = "INSERT INTO Course VALUES(@CourseId, (SELECT t_id FROM Type WHERE t_name = @CourseType), @CourseName, @TeacherId, @CourseScore, @CourseTime, @CourseNumber, @CourseBalanNumber)";
        cmd.CommandText = str;
        cmd.CommandType = System.Data.CommandType.Text;

        //添加查询对象，并且给参数赋值
        SqlParameter para = new SqlParameter("@CourseId", SqlDbType.Char, 18);
        para.Value = courseId;
        cmd.Parameters.Add(para);
        SqlParameter para2 = new SqlParameter("@CourseType", SqlDbType.Char, 18);
        para2.Value = courseType;
        cmd.Parameters.Add(para2);
        SqlParameter para3 = new SqlParameter("@CourseName", SqlDbType.VarChar, 30);
        para3.Value = courseName; ;
        cmd.Parameters.Add(para3);
        SqlParameter para4 = new SqlParameter("@TeacherId", SqlDbType.Char, 18);
        para4.Value = Session["login_id"];
        cmd.Parameters.Add(para4);

        //@TeacherId, @CourseScore, @CourseTime, @CourseNumber, @CourseBalanNumber)";
        SqlParameter para5 = new SqlParameter("@CourseScore", SqlDbType.Float, 3);
        para5.Value = courseScore;
        cmd.Parameters.Add(para5);

        SqlParameter para6 = new SqlParameter("@CourseTime", SqlDbType.Int);
        para6.Value = courseTime;
        cmd.Parameters.Add(para6);

        SqlParameter para7 = new SqlParameter("@CourseNumber", SqlDbType.Int);
        para7.Value = courseNumber;
        cmd.Parameters.Add(para7);

        SqlParameter para8 = new SqlParameter("@CourseBalanNumber", SqlDbType.Int);
        para8.Value = courseNumber;
        cmd.Parameters.Add(para8);


        Response.Write(cmd.CommandText);

        try
        {
            conn.Open();
            if(cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>插入成功！</script>");
                Response.Redirect("Course_Add.aspx");
            }
            else{
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