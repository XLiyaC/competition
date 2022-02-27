using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient; 

public partial class managinguser : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();      
    MySqlCommand cmd = new MySqlCommand(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  //如果是页面首次加载执行下面代码，如因按钮回传消息加载页面，则不执行         
        {
            Label3.Text = "欢迎" + Session["manausername"] + "进入中药材管理界面";
            Panel1.Visible = false;
            Panel2.Visible = false;//隐藏panel
            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM view_medicine";
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            this.ViewState["ds"] = ds;
            da.Fill(ds, "med");
            GridView1.DataSource = ds.Tables["med"]; //⑷将GridView1绑定到ds的“中药材”表med         
            GridView1.DataBind();

            cmd.CommandText = "SELECT * FROM view_content";
            da.SelectCommand = cmd;
            da.Fill(ds, "con");
            GridView2.DataSource = ds.Tables["con"];//⑷将GridView2绑定到ds2的“用户交流”表con
            GridView2.DataBind();
            cn.Close();   
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)this.ViewState["ds"];//获取 ViewState["ds"]的数据集，赋值给 ds 变量 
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ds.Tables["med"];
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)this.ViewState["ds"];//获取 ViewState["ds2"]的数据集，赋值给 ds2 变量 
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataSource = ds.Tables["con"];
        GridView2.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //选中一条中药材记录
        Panel1.Visible = true;//显示panel
        Label5.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox1.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox3.Text = GridView1.SelectedRow.Cells[4].Text;
        TextBox4.Text = GridView1.SelectedRow.Cells[5].Text;
        TextBox7.Text = GridView1.SelectedRow.Cells[6].Text;
        Image2.ImageUrl = "~/photo/"+GridView1.SelectedRow.Cells[6].Text;
        Button4.Visible = false; //设置“确定”按钮不可见         
        Button5.Visible = false; //设置“取消”按钮不可见 
        Label9.Visible = false;//设置不可见        
        Button1.Visible = true; //设置“添加”按钮可见         
        Button2.Visible = true; //设置“修改”按钮可见         
        Button3.Visible = true; //设置“删除”按钮可见         
        Label1.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //"修改"按钮
        //准备 SQL 操作命令，并添加参数值
        cmd.CommandType = CommandType.StoredProcedure;         
        cmd.CommandText = "proc_updatemedicine";
        cmd.Parameters.AddWithValue("@iid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mename", TextBox1.Text);
        cmd.Parameters.AddWithValue("@address", TextBox2.Text);
        cmd.Parameters.AddWithValue("@intro", TextBox3.Text);
        cmd.Parameters.AddWithValue("@origin", TextBox4.Text);
        cmd.Parameters.AddWithValue("@pic", TextBox7.Text);
        cmd.Connection = cn;         //打开数据库连接，执行修改 Update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label1.Text = "提示：" + i + "条记录修改成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label1.Text = ex.Message;         
        }         
        cn.Close();             //关闭数据库连接         
        RefreshGridView1();      //调用自定义过程，刷新 GridView1 
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        //"删除"按钮
        cmd.CommandText = "delete from medinfo where medinfo.id=@iid";
        cmd.Parameters.AddWithValue("@iid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行删除 delete 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label1.Text = "提示：" + i + "条记录删除成功！";  //报告成功删除                 
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label1.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接         
        RefreshGridView1();      //调用自定义过程，刷新 GridView1 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //"添加"按钮
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        Image2.Visible = false;
        Button1.Visible = false; //设置“添加”按钮不可见 
        Button2.Visible = false; //设置“修改”按钮不可见         
        Button3.Visible = false; //设置“删除”按钮不可见         
        Button4.Visible = true; //设置“确定”按钮可见         
        Button5.Visible = true; //设置“取消”按钮可见
        Label9.Visible = true;//设置可见         
        Label1.Text = "";
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //"确定"按钮
        //准备 SQL 操作命令，并添加参数值         
        cmd.CommandText = "Insert Into medinfo() Values(@name,@address,@intro,@origin,@pic)";
        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
        cmd.Parameters.AddWithValue("@address", TextBox2.Text);
        cmd.Parameters.AddWithValue("@intro", TextBox3.Text);
        cmd.Parameters.AddWithValue("@origin", TextBox4.Text);
        cmd.Parameters.AddWithValue("@pic", TextBox7.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label1.Text = "提示：" + i + "条记录插入成功！";  //报告成功修改                 
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label1.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接         
        RefreshGridView1();      //调用自定义过程，刷新 GridView1
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //"取消"按钮
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        Button1.Visible = true; //设置“插入”按钮可见 
        Button2.Visible = true; //设置“修改”按钮可见         
        Button3.Visible = true; //设置“删除”按钮可见         
        Button4.Visible = false; //设置“确定”按钮不可见         
        Button5.Visible = false; //设置“取消”按钮不可见         
        Label1.Text = ""; 
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //选择其中一条交流记录
        Panel2.Visible = true;//显示panel2
        Label6.Text = GridView2.SelectedRow.Cells[1].Text;
        Label7.Text = GridView2.SelectedRow.Cells[3].Text;
        TextBox5.Text = GridView2.SelectedRow.Cells[5].Text;
        Label8.Text = GridView2.SelectedRow.Cells[6].Text;
        TextBox6.Text = GridView2.SelectedRow.Cells[9].Text;
        Label4.Text = Session["manauserid"].ToString();        
        Label2.Text = "";
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        //"回复"按钮
        //准备 SQL 操作命令，并添加参数值 
        cmd.CommandType = CommandType.StoredProcedure;      
        cmd.CommandText = "proc_reply";
        cmd.Parameters.AddWithValue("@iid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@reply", TextBox6.Text);
        cmd.Parameters.AddWithValue("@medid", Label7.Text);
        cmd.Parameters.AddWithValue("@maid", Label4.Text);
        cmd.Connection = cn;         //打开数据库连接，执行修改 Update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label2.Text = "提示：" + i + "条记录修改成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label2.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接         
        RefreshGridView2();      //调用自定义过程，刷新 GridView1
    }

    protected void RefreshGridView1()
    {
        cn.Open();         //重新获取数据源         
        MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM view_medicine", cn);
        DataSet ds = new DataSet();
        da.Fill(ds, "中药材");
        GridView1.DataSource = ds.Tables["中药材"]; //⑷将GridView1绑定到ds的“中药材”表         
        GridView1.DataBind();
    }

    protected void RefreshGridView2()
    {
        cn.Open();         //重新获取数据源         
        string sql = "SELECT * FROM view_content";
        MySqlDataAdapter da2 = new MySqlDataAdapter(sql, cn);  //⑵创建数据适配器对象 da2
        DataSet ds2 = new DataSet();//⑶创建数据集对象ds2，并填充“用户交流”表        
        da2.Fill(ds2, "用户交流");
        GridView2.DataSource = ds2.Tables["用户交流"];//⑷将GridView2绑定到ds2的“用户交流”表
        GridView2.DataBind();
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("totalvisual.aspx");//跳转到可视化总观
    }
}