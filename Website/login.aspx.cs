using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;


public partial class login : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection("server=localhost;database=crop;user id=root;password=1234");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Focus();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlCommand cmd = new MySqlCommand(); //创建 cmd 对象并说明 SQL 命令和添加参数
        cmd.Connection = cn;
        cmd.CommandText = "Select * From managingusers Where name=@maname";
        cmd.Parameters.AddWithValue("@maname", TextBox1.Text);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得管理用户表前向只读数据流
        rd.Read(); //读取一行
        Label3.Text = rd["id"].ToString();
        if (rd.HasRows) //如果找到该管理用户，将用户输入的密码与数据库返回的密码进行比对
        {
            if (TextBox2.Text == (string)rd["code"]) //判断密码是否正确，密码正确
            {
                Session.Add("manauserid", Label3.Text); //保存用户号到 Session 的 manauserid 项中
                Session.Add("manausername", TextBox1.Text); //保存用户名到 Session 的 manausername 项中
                Response.Redirect("managinguser.aspx"); //跳转到管理用户界面
            }
            else
            {
                Label2.Text = "密码错误!";
                Response.Write("密码错误!"); //输出出错信息
                TextBox2.Text = ""; //清空密码
            }
        }
        else //如果未找到该管理用户，报告消息
        {
            Label2.Text = "该用户不存在!"; //报告该管理用户不存在
            Label3.Text = ""; //清空用户号
            TextBox1.Text = ""; //清空用户名
            TextBox2.Text = ""; //清空密码
        }
        rd.Close();
        cn.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        MySqlCommand cmd = new MySqlCommand(); //创建 cmd 对象并说明 SQL 命令和添加参数
        cmd.Connection = cn;
        cmd.CommandText = "Select * From generalusers Where name=@gename";
        cmd.Parameters.AddWithValue("@gename", TextBox1.Text);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得普通用户表前向只读数据流
        rd.Read(); //读取一行
        Label3.Text = rd["id"].ToString();
        if (rd.HasRows) //如果找到该普通用户，将用户输入的密码与数据库返回的密码进行比对
        {
            if (TextBox2.Text == (string)rd["code"]) //判断密码是否正确，密码正确
            {
                Session.Add("geuserid", Label3.Text); //保存用户号到 Session 的 geuserid 项中
                Session.Add("geusername", TextBox1.Text); //保存用户号到 Session 的 generalname 项中
                Response.Redirect("generaluser.aspx"); //跳转到普通用户界面
            }
            else
            {
                Label1.Text= "密码错误!"; //输出出错信息
                TextBox2.Text = ""; //清空密码
            }
        }
        else //如果未找到该普通用户，报告消息
        {
            Label1.Text = "该用户不存在!";
            Response.Write("该用户不存在!"); //报告该普通用户不存在
            Label3.Text = ""; //清空用户号
            TextBox1.Text = ""; //清空用户名
            TextBox2.Text = ""; //清空密码
        }
        rd.Close();
        cn.Close();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx"); //跳转到注册新用户界面
    }

}