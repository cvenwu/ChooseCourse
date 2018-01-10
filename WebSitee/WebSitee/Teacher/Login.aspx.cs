using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string teacherLoginId = UserName.Text.Trim();
                string teacherLoginPwd = Password.Text.Trim();
                TeacherLoginUtil(teacherLoginId, teacherLoginPwd);
        }
        }

    private void TeacherLoginUtil(string teacherLoginId, string teacherLoginPwd)
    {
        SqlDataReader dr;   //新建DataReader对象


        string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";

        //新建到数据库的连接
        SqlConnection conn = new SqlConnection(strCon);

        //新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT t_status FROM Teacher WHERE t_id = @TeacherId  AND t_pwd = @TeacherName;";
        cmd.CommandType = System.Data.CommandType.Text;

        //添加查询对象，并且给参数赋值
        SqlParameter para = new SqlParameter("@TeacherId", SqlDbType.Char, 18);
        para.Value = teacherLoginId;
        cmd.Parameters.Add(para);
        SqlParameter para2 = new SqlParameter("@TeacherName", SqlDbType.VarChar, 30);
        para2.Value = teacherLoginPwd;
        cmd.Parameters.Add(para2);

        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                /*如果用户选择了记住我*/
                if (RememberMe.Checked = true)
                {
                    HttpCookie cookie = new HttpCookie("teacherlogin");
                    cookie.Values.Add("teacherLoginId", teacherLoginId);
                    cookie.Values.Add("teacherLoginPwd", teacherLoginPwd);
                    cookie.Expires = DateTime.Now.AddDays(14);  //设置有效期为14天
                }
                Session.Add("login_id", teacherLoginId);    //将学生ID编号添加到Session缓存中
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert(\"学号和密码不对！请重新输入！\");</script>");
                UserName.Text = "";
                Password.Text = "";
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
    }



    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

    }
}