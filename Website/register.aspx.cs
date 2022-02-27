using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class register : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Focus();
            TextBox3.Text = "0";
            TextBox2.Text = "000000";
        }
            
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "INSERT into generalusers(`name`,age,`code`,logintime) VALUES(@gename,@age,@gecode,CURRENT_TIMESTAMP)";
        cmd.Parameters.AddWithValue("@gename", TextBox1.Text);
        cmd.Parameters.AddWithValue("@age", TextBox3.Text);
        cmd.Parameters.AddWithValue("@gecode", TextBox2.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label1.Text = "恭喜您注册成功！";  //报告成功修改                 
                
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label1.Text = ex.Message;
            TextBox1.Text = "请重新输入";
            TextBox2.Text = "000000";
            TextBox3.Text = "0";
        }
        cn.Close();            //关闭数据库连接
        IdView();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx"); //跳转到登录界面
    }

    protected void IdView()
    {
        //查看生成的用户号
        string sql = "SELECT generalusers.id AS ID FROM generalusers WHERE generalusers.`name`=@na";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@na", TextBox1.Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label2.Text = rd["ID"].ToString();
        rd.Close();
        cn.Close();
    }

}