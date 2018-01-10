using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using WebSitee;
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
            /*
                // Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
             */
            string strCon = "Integrated Security=SSPI;Initial Catalog='NetDesign';Data Source='DESKTOP-HJQH3C9';User ID='sa'; Password = 'sasa'; Connect Timeout = 30";

            //获取学生的学号以及密码
            string student_id = UserName.Text.Trim();
            string student_pwd = Password.Text.Trim();
            SqlDataReader dr;


            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT s_status FROM student WHERE s_id = @id AND s_pwd = @pwd";
            cmd.CommandType = CommandType.Text;
            SqlParameter para = new SqlParameter("@id", SqlDbType.Char, 18);
            para.Value = student_id;
            cmd.Parameters.Add(para);

            SqlParameter para2 = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
            para2.Value = student_pwd;
            cmd.Parameters.Add(para2);

            try
            {
                conn.Open();        //打开连接
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.Write("<script>alert('登录成功！')</script>");

                }
                else
                {
                    Response.Write("<script>alert('学号和密码错误!')</script>");
                }
                dr.Close();

            }catch(SqlException exception)
            {
                Response.Write(exception.Message);
            }
          





            }
        }
}