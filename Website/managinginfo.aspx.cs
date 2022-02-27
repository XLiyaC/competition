using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class managinginfo : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = cn;
        cmd.CommandText = "SELECT * FROM managingusers Where id=@userid";
        cmd.Parameters.AddWithValue("@userid", Session["manauserid"]);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label4.Text = rd["id"].ToString();
        Label6.Text = rd["name"].ToString();
        Label7.Text = rd["age"].ToString();
        Label8.Text = rd["code"].ToString();
        Label5.Text = rd["logintime"].ToString();
        rd.Close();
        cn.Close();

        TextBox9.Text = "0";
        TextBox5.Text = "000000";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //"添加"新管理员
        cmd.CommandText = "INSERT INTO managingusers(`name`,age,`code`,logintime) VALUES(@name,@age,@code,CURRENT_TIMESTAMP) ";
        cmd.Parameters.AddWithValue("@name", TextBox4.Text);
        cmd.Parameters.AddWithValue("@age", TextBox9.Text);
        cmd.Parameters.AddWithValue("@code", TextBox5.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label2.Text = "恭喜您注册成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label2.Text = ex.Message;
                //"用户名已存在，请重新输入！";
            TextBox4.Text = "请重新输入";
            TextBox9.Text = "0";
            TextBox5.Text = "000000";
        }
        cn.Close();             //关闭数据库连接
        IdView();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx"); //跳转到登录界面
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("managinguser.aspx");//跳转到管理界面
    }

    protected void IdView()
    {
        //查看生成的用户号
        string sql = "SELECT managingusers.id AS ID FROM managingusers WHERE managingusers.`name`=@na";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@na", TextBox4.Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label3.Text = rd["ID"].ToString();
        rd.Close();
        cn.Close();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //"修改"名字信息
        string sql = "UPDATE managingusers SET managingusers.`name`=@maname WHERE managingusers.id=@maid";
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@maid", Session["manauserid"]);
        cmd.Parameters.AddWithValue("@maname", TextBox10.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令 
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

    protected void Button4_Click(object sender, EventArgs e)
    {
        //"修改"年龄信息
        string sql = "UPDATE managingusers SET managingusers.age=@age WHERE managingusers.id=@maid";
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@maid", Session["manauserid"]);
        cmd.Parameters.AddWithValue("@age", TextBox11.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令 
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
        //"修改"密码信息
        string sql = "UPDATE managingusers SET managingusers.`code`=@code WHERE managingusers.id=@maid";
        MySqlCommand cmd = new MySqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@maid", Session["manauserid"]);
        cmd.Parameters.AddWithValue("@code", TextBox12.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令 
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label10.Text = "提示：" + i + "条记录修改成功！";
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label10.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        //注销用户
        cmd.CommandText = "DELETE FROM managingusers WHERE id=@maid";
        cmd.Parameters.AddWithValue("@maid", Session["manauserid"]);
        cmd.Connection = cn;         //打开数据库连接，执行 delete 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label11.Text = "提示：" + i + "条记录删除成功！";

            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label11.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
        Response.Redirect("login.aspx"); //跳转到登录界面
    }
}