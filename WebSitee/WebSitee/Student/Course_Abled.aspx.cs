using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Student_Course_Abled : System.Web.UI.Page
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
        string str = "SELECT c.cid, c.c_id , t2.t_name AS ty_name , c.c_name , t.t_id AS te_id, t.t_name AS te_name , c.c_score , c.c_time , c.c_number , c.c_balannumber  FROM Course c LEFT JOIN teacher t ON t.t_id = c.te_id LEFT JOIN Type t2 ON t2.t_id = c.ty_id WHERE c.c_balannumber > 0 ORDER BY c.c_id; ";
        //string str = "SELECT c.c_id AS 课程编号, t2.t_name AS 课程类别, c.c_name AS 课程名称, t.t_name AS 教师名称, c.c_score AS 课程学分, c.c_time AS 课程学时, c.c_number AS 课程总容量, c.c_balannumber AS 课程剩余容量 FROM Course c LEFT JOIN teacher t ON t.t_id = c.te_id LEFT JOIN Type t2 ON t2.t_id = c.ty_id WHERE c.c_balannumber > 0 ORDER BY c.c_id; ";
        SqlDataAdapter da = new SqlDataAdapter(str, conn);
        conn.Open();
        da.Fill(ds);
        conn.Close();
        Course1.DataSource = ds;
        Course1.DataBind();
    }

    //选修按钮事件
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //说明是选修课程
        if(e.CommandName == "Select")
        {
            //将会打印不同的参数，根据不同的参数来获取值！
            // Response.Write(e.CommandArgument.GetType());        //将会打印一个String
            Response.Write("<script>alert(" + e.CommandArgument + ")</script>");
            //  int RowIndex = Convert.ToInt32(e.CommandArgument);
            //   DataKey keys = Course1.DataKeys[RowIndex];      //行中的数据;
            //   string perid = keys.Value.ToString();
            //   Response.Write("选修成功！");
            int row;
            try
            {
                row = System.Convert.ToInt32(e.CommandArgument);
            }catch(Exception ex)
            {
                
                Response.Write(ex.Message);
                row = -1;
            }

            //获得课程编号
            string courseId = Course1.Rows[row].Cells[1].Text;
            //获得学生编号
            string studentId = (string)Session["login_id"];
            //获得老师编号
            string teacherId = Course1.Rows[row].Cells[4].Text;

            string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";



            /*查看学生是否选修了该课程！*/
            string sqlSelect = "SELECT sc_status FROM SC WHERE s_id = @S_id AND c_id = @C_id AND t_id = @T_id";


            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sqlSelect;
            cmd.CommandType = System.Data.CommandType.Text;


            SqlParameter para = new SqlParameter("@S_id", SqlDbType.Char, 18);
            para.Value = studentId;
            cmd.Parameters.Add(para);
            SqlParameter para2 = new SqlParameter("@C_id", SqlDbType.Char, 18);
            para2.Value = courseId;
            cmd.Parameters.Add(para2);
            SqlParameter para3 = new SqlParameter("@T_id", SqlDbType.VarChar, 30);
            para3.Value = teacherId; ;
            cmd.Parameters.Add(para3);


            Response.Write("s");

            SqlDataReader dr;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {

                    cmd.Parameters.Clear();
                    /*如果学生没有选修该课程，那么就可以选修*/
                    SqlDataReader dr2;
                    
                    SqlConnection conn2 = new SqlConnection(strCon);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;
                    string str2 = "INSERT INTO SC(s_id, c_id, t_id, sc_status) VALUES(@S_id, @C_id, @T_id, @Sc_status)";
                    cmd2.CommandText = str2;
                    cmd2.CommandType = System.Data.CommandType.Text;
                    Response.Write(cmd2.CommandText);
                    
                    //添加查询对象，并且给参数赋值

                    SqlParameter para11 = new SqlParameter("@S_id", SqlDbType.Char, 18);
                    para11.Value = studentId;
                    SqlParameter para12 = new SqlParameter("@C_id", SqlDbType.Char, 18);
                    para12.Value = courseId;
                    SqlParameter para13 = new SqlParameter("@T_id", SqlDbType.VarChar, 30);
                    para13.Value = teacherId; ;
                    SqlParameter para14 = new SqlParameter("@Sc_status", SqlDbType.Int);
                    para14.Value = 1;
                    cmd2.Parameters.Add(para11);
                    cmd2.Parameters.Add(para12);
                    cmd2.Parameters.Add(para13);
                    cmd2.Parameters.Add(para14);

                    Response.Write("s");
                    conn2.Open();

                    /*在选修课程同时，还要修改课程容量*/
                    SqlDataReader dr3;
                    SqlConnection conn3 = new SqlConnection(strCon);
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = conn3;
                    string str3 = "UPDATE Course SET c_balannumber = (@C_balannumber - 1) WHERE c_id = @C_id";
                    cmd3.CommandText = str3;
                    cmd3.CommandType = System.Data.CommandType.Text;
                    SqlParameter para21 = new SqlParameter("@C_balannumber", SqlDbType.Int);
                    para21.Value = Course1.Rows[row].Cells[9].Text; ;
                    SqlParameter para22 = new SqlParameter("@C_id", SqlDbType.Char, 18);
                    para22.Value = courseId;
                    cmd3.Parameters.Add(para21);
                    cmd3.Parameters.Add(para22);










                    conn3.Open();
                    if (cmd2.ExecuteNonQuery() > 0 && cmd3.ExecuteNonQuery() > 0)
                    {
                        Response.Write("<script>选修成功！</script>");
                        Response.Redirect("Course_Abled.aspx");
                    }
                    else
                    {
                        Response.Write("<script>选修失败！</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert(\"您已选修过该课程！\");</script>");
                    //Response.Redirect("Course_Abled.aspx");
                }
                dr.Close();

            }
            catch (SqlException sqlException)
            {
                Response.Write(sqlException.Message);   //显示连接异常信息
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }









            

            





            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>选修成功！</script>");
                    Response.Redirect("Course_Abled.aspx");
                }
                else
                {
                    Response.Write("<script>选修失败！</script>");
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
}