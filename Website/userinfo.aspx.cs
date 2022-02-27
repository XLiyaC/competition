using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class userinfo : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = cn;
        cmd.CommandText = "SELECT * FROM generalusers Where id=@userid";
        cmd.Parameters.AddWithValue("@userid", Session["geuserid"]);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label2.Text = rd["id"].ToString();
        Label5.Text = rd["name"].ToString();
        Label6.Text = rd["code"].ToString();
        Label7.Text = rd["age"].ToString();
        Label4.Text = rd["logintime"].ToString();
        Label3.Text = rd["grade"].ToString();
        //TextBox1.Text = rd["name"].ToString();
        //TextBox2.Text = rd["code"].ToString();
        //TextBox3.Text = rd["age"].ToString();
        //TextBox1.Visible = false;
        //TextBox2.Visible = false;
        //TextBox3.Visible = false;
        rd.Close();
        cn.Close();
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("generaluser.aspx"); //跳转到用户界面
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx"); //跳转到登录界面
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //"修改"名字信息
        cmd.CommandText = "UPDATE generalusers SET generalusers.`name`=@gename WHERE generalusers.id=@geid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@gename", TextBox1.Text);
        cmd.Connection = cn;         //打开数据库连接，执行 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label1.Text = "提示：" + i + "条记录修改成功！";

            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label1.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //"修改"密码信息
        cmd.CommandText = "UPDATE generalusers SET generalusers.`code`=@code WHERE generalusers.id=@geid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@code", TextBox2.Text);
        cmd.Connection = cn;         //打开数据库连接，执行 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label8.Text = "提示：" + i + "条记录修改成功！";

            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label8.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //"修改"年龄信息
        cmd.CommandText = "UPDATE generalusers SET generalusers.age=@age WHERE generalusers.id=@geid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@age", TextBox3.Text);
        cmd.Connection = cn;         //打开数据库连接，执行 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label9.Text = "提示：" + i + "条记录修改成功！";

            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label9.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "DELETE FROM generalusers WHERE id=@geid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Connection = cn;         //打开数据库连接，执行 delete 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label10.Text = "提示：" + i + "条记录删除成功！";

            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label10.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
        Response.Redirect("login.aspx"); //跳转到登录界面
    }
}