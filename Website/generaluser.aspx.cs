using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class generaluser : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  //如果是页面首次加载执行下面代码，如因按钮回传消息加载页面，则不执行         
        {
            Label28.Text = "欢迎" + Session["generalname"] + "进入用户界面";//欢迎语
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;//panel先隐藏
            //gridview1、2先显示

            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM view_medicine";
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            this.ViewState["ds"] = ds;
            da.Fill(ds, "中药材");
            GridView1.DataSource = ds.Tables["中药材"]; //⑷将GridView1绑定到ds的“中药材”表        
            GridView1.DataBind();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_collected";
            cmd.Parameters.AddWithValue("@maid", Session["geuserid"]);
            da.SelectCommand = cmd;
            da.Fill(ds, "已收藏");
            GridView2.DataSource = ds.Tables["已收藏"];//⑷将GridView2绑定到ds2的“已收藏”表
            GridView2.DataBind();
            cn.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_medicine";
        cmd.Parameters.AddWithValue("@mename", "%"+TextBox3.Text+"%");
        MySqlDataAdapter da = new MySqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        this.ViewState["ds"] = ds;
        da.Fill(ds, "meList");
        GridView3.DataSource = ds.Tables["meList"]; //⑷将 GridView3 绑定到 ds 的“meList”表       
        GridView3.DataBind();
        cn.Close();
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)this.ViewState["ds"];//获取 ViewState["ds"]的数据集，赋值给 ds 变量 
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataSource = ds.Tables["meList"];
        GridView3.DataBind();
    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_selectmedicine";
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label1.Text = GridView3.SelectedRow.Cells[2].Text;
        TextBox4.Text = rd["产地"].ToString();
        TextBox5.Text = rd["功效"].ToString();
        TextBox6.Text = rd["相关药籍"].ToString();
        Image2.ImageUrl = "~/photo/" + GridView3.SelectedRow.Cells[6].Text;
        Label17.Text = "";
        Label18.Text = "";
        Label13.Text = "";
        Label14.Text = "";
        Label29.Text = "";
        Label32.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox22.Text = "";
        Panel1.Visible = false;
        Panel5.Visible = false;
        rd.Close();
        cn.Close();
    }



    protected void Button21_Click(object sender, EventArgs e)
    {
        //"留言详情"按钮
        Panel5.Visible = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_newmess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行insert 命令       
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label16.Text = "没有留言，可以在下方添加留言！";
                Button2.Visible = true;
                Button33.Visible = false;
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label16.Text = "可以在下方查看留言或更改留言！";
            Button2.Visible = false;
            Button33.Visible = true;
        }
        cn.Close();             //关闭数据库连接
        CheckMessage3();
    }

    protected void CheckMessage3()
    {
        //"查看留言"
        cmd.CommandText = "proc_checkmessage";
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox7.Text = rd["message"].ToString();
        TextBox8.Text = rd["reply"].ToString();
        rd.Close();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label18.Text = "留言内容如下：";
            }
        }
        catch (MySqlException ex)
        {
            Label18.Text = ex.Message;
        }
        cn.Close();
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        //第一个"留言添加"
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_updatemess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mess", TextBox7.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label7.Text = "提示：" + i + "条留言添加成功！";
                TextBox8.Text = "暂无";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label7.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        //panel1中“取消”按钮,第一个表格的留言"取消"
        string sql = "SELECT message.message as 留言 FROM message where message.medid = @meid and message.userid = @geid";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox7.Text = rd["留言"].ToString();
    }

    protected void Button23_Click(object sender, EventArgs e)
    {
        //"收藏评分详情"
        Panel1.Visible = true;
        string sql = "INSERT INTO demand(demand.userid,demand.medid) VALUES(@geid, @meid)";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行insert 命令       
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label17.Text = "没有收藏记录！下方可以添加收藏或评分！";
                Button17.Visible = true;
                Button25.Visible = false;//报告成功删除                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {            
            Label17.Text = "可以在下方查看评分或更改评分";
            Button17.Visible = false;
            Button25.Visible = true;
        }
        cn.Close();             //关闭数据库连接
        CheckScore3();
    }

    protected void CheckScore3()
    {
        //第一个表格查看收藏评分
        string sql = "SELECT interest,attention FROM demand where demand.medid = @meid and demand.userid = @geid";
        cmd.CommandText = sql;
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox22.Text = rd["attention"].ToString();
        Label32.Text = rd["interest"].ToString();
        cn.Close();
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        //"新增评分"
        cmd.CommandText = "UPDATE demand SET attention=@att WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@att", TextBox22.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label13.Text = "提示：" + i + "个评分添加成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label13.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button25_Click(object sender, EventArgs e)
    {
        //"更改评分"
        cmd.CommandText = "UPDATE demand SET attention=@att WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@att", TextBox22.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label13.Text = "提示：" + i + "个评分更改成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label13.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }



    protected void Button4_Click(object sender, EventArgs e)
    {
        //“确定收藏”按钮
        cmd.CommandText = "UPDATE demand SET interest='是' WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label4.Text = "提示：" + i + "条收藏成功！";
                Label32.Text = "是";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label4.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
        RefreshGridView2();  //刷新已收藏表
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        //“取消收藏”按钮
        cmd.CommandText = "UPDATE demand SET interest='否' WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label4.Text = "提示：" + i + "条收藏取消成功！";
                Label32.Text = "否";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label4.Text = "未收藏";
        }
        cn.Close();             //关闭数据库连接
        RefreshGridView2();  //刷新已收藏表
    }

    //中药材推荐表下方


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)this.ViewState["ds"];//获取 ViewState["ds"]的数据集，赋值给 ds 变量 
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ds.Tables["中药材"];
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_selectmedicine";
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label2.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox10.Text = rd["产地"].ToString();
        TextBox11.Text = rd["功效"].ToString();
        TextBox12.Text = rd["相关药籍"].ToString();
        Image3.ImageUrl = "~/photo/" + GridView1.SelectedRow.Cells[6].Text;
        Label8.Text = "";
        Label22.Text = "";
        Label5.Text = "";
        Label30.Text = "";
        Label33.Text = "";
        Label14.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox23.Text = "";
        Panel2.Visible = false;
        Panel7.Visible = false;
        rd.Close();
        cn.Close();
    }

    protected void Button20_Click(object sender, EventArgs e)
    {
        //"留言详情"
        Panel7.Visible = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_newmess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行insert 命令       
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Button6.Visible = true;
                Button32.Visible = false;
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label20.Text = "可以在下方查看留言或更改留言";
            Button6.Visible = false;
            Button32.Visible = true;
        }
        cn.Close();             //关闭数据库连接
        CheckMessage1();
    }

    protected void CheckMessage1()
    {
        //"查看留言"
        cmd.CommandText = "proc_checkmessage";
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox13.Text = rd["message"].ToString();
        TextBox14.Text = rd["reply"].ToString();
        rd.Close();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label22.Text = "留言内容如下：";
            }
        }
        catch (MySqlException ex)
        {
            Label22.Text = ex.Message;
        }
        cn.Close();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        //第二个"留言添加"
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_updatemess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mess", TextBox13.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label8.Text = "提示：" + i + "条留言添加成功！";
                TextBox14.Text = "暂无";                
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label8.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }


    protected void Button7_Click(object sender, EventArgs e)
    {
        //“取消”按钮,第二个表格的留言"取消"
        string sql = "SELECT message.message as 留言 FROM message where message.medid = @meid and message.userid = @geid";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox13.Text = rd["留言"].ToString();
    }

    protected void Button26_Click(object sender, EventArgs e)
    {
        //"收藏评分详情"
        Panel2.Visible = true;
        string sql = "INSERT INTO demand(demand.userid,demand.medid) VALUES(@geid, @meid)";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行insert 命令       
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label21.Text = "没有收藏或评分记录！下方可以添加收藏或评分！";
                Button18.Visible = true;
                Button28.Visible = false;//报告成功删除                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label21.Text = "可以在下方查看评分或更改评分";
            Button18.Visible = false;
            Button28.Visible = true;
        }
        cn.Close();             //关闭数据库连接
        CheckScore1();
    }

    protected void CheckScore1()
    {
        //第二个表格查看收藏评分
        string sql = "SELECT interest,attention FROM demand where demand.medid = @meid and demand.userid = @geid";
        cmd.CommandText = sql;
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox23.Text = rd["attention"].ToString();
        Label33.Text = rd["interest"].ToString();
        cn.Close();
    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        //"新增评分"
        cmd.CommandText = "UPDATE demand SET attention=@att WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@att", TextBox23.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label14.Text = "提示：" + i + "个评分添加成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label14.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }


    protected void Button28_Click(object sender, EventArgs e)
    {
        //"更改评分"
        cmd.CommandText = "UPDATE demand SET attention=@att WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@att", TextBox23.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label14.Text = "提示：" + i + "个评分更改成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label14.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        //“确定收藏”按钮
        cmd.CommandText = "UPDATE demand SET interest='是' WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label5.Text = "提示：" + i + "条收藏成功！";
                Label33.Text = "是";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label5.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
        RefreshGridView2();  //刷新已收藏表
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        //“取消收藏”按钮
        cmd.CommandText = "UPDATE demand SET interest='否' WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label5.Text = "提示：" + i + "条收藏取消成功！";
                Label33.Text = "否";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label5.Text = "未收藏";
        }
        cn.Close();             //关闭数据库连接
        RefreshGridView2();  //刷新已收藏表
    }


    //已收藏中药材表下方
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)this.ViewState["ds"];//获取 ViewState["ds"]的数据集，赋值给 ds 变量 
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataSource = ds.Tables["已收藏"];
        GridView2.DataBind();
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel8.Visible = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_selectmedicine";
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label3.Text = GridView2.SelectedRow.Cells[2].Text;
        TextBox16.Text = rd["产地"].ToString();
        TextBox17.Text = rd["功效"].ToString();
        TextBox18.Text = rd["相关药籍"].ToString();
        Image4.ImageUrl = "~/photo/" + GridView2.SelectedRow.Cells[5].Text;
        Label6.Text = "";
        Label9.Text = "";
        Label25.Text = "";
        Label31.Text = "";
        Label34.Text = "";
        Label15.Text = "";
        TextBox19.Text = "";
        TextBox20.Text = "";
        TextBox24.Text = "";
        Panel3.Visible = false;
        Panel9.Visible = false;
        rd.Close();
        cn.Close();
    }

    protected void Button22_Click(object sender, EventArgs e)
    {
        //"留言详情"
        Panel9.Visible = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_newmess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行insert 命令       
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Button10.Visible = true;
                Button30.Visible = false;//报告成功删除                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label24.Text = "可以在下方查看留言或更改留言";
            Button10.Visible = false;
            Button30.Visible = true;
        }
        cn.Close();             //关闭数据库连接
        CheckMessage2();
    }

    protected void CheckMessage2()
    {
        //"查看留言"
        cmd.CommandText = "proc_checkmessage";
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox19.Text = rd["message"].ToString();
        TextBox20.Text = rd["reply"].ToString();
        rd.Close();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label25.Text = "留言内容如下：";
            }
        }
        catch (MySqlException ex)
        {
            Label25.Text = ex.Message;
        }
        cn.Close();
    }


    protected void Button10_Click(object sender, EventArgs e)
    {
        //第三个"留言添加"
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_updatemess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mess", TextBox19.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label9.Text = "提示：" + i + "条留言添加成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label9.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button30_Click(object sender, EventArgs e)
    {
        //第三个的"留言修改"
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_updatemess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mess", TextBox19.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label9.Text = "提示：" + i + "条留言修改成功！";
                TextBox20.Text = "暂无";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label9.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        //“取消”按钮,第三个表格的留言"取消"
        string sql = "SELECT message.message as 留言 FROM message where message.medid = @meid and message.userid = @geid";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox19.Text = rd["留言"].ToString();
    }

    protected void Button29_Click(object sender, EventArgs e)
    {
        //"收藏评分详情"
        Panel3.Visible = true;
        string sql = "INSERT INTO demand(demand.userid,demand.medid) VALUES(@geid, @meid)";
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行insert 命令       
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label27.Text = "没有收藏或评分记录！下方可以添加收藏或评分！";
                Button19.Visible = true;
                Button31.Visible = false;//报告成功删除                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label27.Text = "可以在下方查看评分或更改评分";
            Button19.Visible = false;
            Button31.Visible = true;
        }
        cn.Close();             //关闭数据库连接
        CheckScore2();
    }

    protected void CheckScore2()
    {
        //第二个表格查看收藏评分
        string sql = "SELECT interest,attention FROM demand where demand.medid = @meid and demand.userid = @geid";
        cmd.CommandText = sql;
        cmd.Connection = cn;         //打开数据库连接，执行select 命令       
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        TextBox24.Text = rd["attention"].ToString();
        Label34.Text = rd["interest"].ToString();
        cn.Close();
    }

    protected void Button19_Click(object sender, EventArgs e)
    {
        //"新增评分"
        cmd.CommandText = "UPDATE demand SET attention=@att WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@att", TextBox24.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label15.Text = "提示：" + i + "个评分添加成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label15.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }


    protected void Button31_Click(object sender, EventArgs e)
    {
        //"更改评分"
        cmd.CommandText = "UPDATE demand SET attention=@att WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@att", TextBox24.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label15.Text = "提示：" + i + "个评分更改成功！";  //报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label15.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        //“确定收藏”按钮
        cmd.CommandText = "UPDATE demand SET interest='是' WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label6.Text = "提示：" + i + "条收藏成功！";
                Label34.Text = "是";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label6.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
        RefreshGridView2();  //刷新已收藏表
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        //“取消收藏”按钮
        cmd.CommandText = "UPDATE demand SET interest='否' WHERE demand.userid=@geid AND demand.medid=@meid";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 insert 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label6.Text = "提示：" + i + "条收藏取消成功！";
                Label34.Text = "否";                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label4 显示原因         
        {
            Label6.Text = "未收藏";
        }
        cn.Close();             //关闭数据库连接
        RefreshGridView2();  //刷新已收藏表
    }


    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        //第一个表格中选择到的药材的评分详情
        Session.Add("medid", GridView3.SelectedRow.Cells[1].Text); //保存用户号到 Session 的 medid 项中
        Session.Add("medname", GridView3.SelectedRow.Cells[2].Text); //保存用户号到 Session 的 medname 项中
        Response.Redirect("medvisual.aspx"); //跳转到中药材可视化界面
    }

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        //第一个表格中选择到的药材的被收藏数
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_collectnum";
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label29.Text = rd["收藏数"].ToString();
        rd.Close();
        cn.Close();
    }

    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        //第二个表格中选择到的药材的被收藏数
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_collectnum";
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label30.Text = rd["收藏数"].ToString();
        rd.Close();
        cn.Close();
    }

    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        //第二个表格中选择到的药材的评分详情
        Session.Add("medid", GridView1.SelectedRow.Cells[1].Text); //保存用户号到 Session 的 medid 项中
        Session.Add("medname", GridView1.SelectedRow.Cells[2].Text); //保存用户号到 Session 的 medname 项中
        Response.Redirect("medvisual.aspx"); //跳转到中药材可视化界面
    }

    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        //第三个表格中选择到的药材的被收藏数
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_collectnum";
        cmd.Parameters.AddWithValue("@meid", GridView2.SelectedRow.Cells[1].Text);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label31.Text = rd["收藏数"].ToString();
        rd.Close();
        cn.Close();
    }

    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        //第三个表格中选择到的药材的评分详情
        Session.Add("medid", GridView2.SelectedRow.Cells[1].Text); //保存用户号到 Session 的 medid 项中
        Session.Add("medname", GridView2.SelectedRow.Cells[2].Text); //保存用户号到 Session 的 medname 项中
        Response.Redirect("medvisual.aspx"); //跳转到中药材可视化界面
    }


    protected void RefreshGridView2()
    {
        cn.Open();         //重新获取数据源         
        string sql = "SELECT 编号,药材名,功效,相关药籍,图片 FROM view_collected";
        MySqlDataAdapter da2 = new MySqlDataAdapter(sql, cn);  //⑵创建数据适配器对象da 和 da2
        DataSet ds2 = new DataSet();//⑶创建数据集对象ds和ds2，并填充“中药材”表 和“用户交流”表        
        da2.Fill(ds2, "已收藏");
        GridView2.DataSource = ds2.Tables["已收藏"];//⑷将GridView2绑定到ds2的“用户交流”表
        GridView2.DataBind();
    }

    protected void Button32_Click(object sender, EventArgs e)
    {
        //第二个的"留言修改"
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_updatemess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView1.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mess", TextBox13.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label8.Text = "提示：" + i + "条留言修改成功！";
                TextBox14.Text = "暂无";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label8.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }

    protected void Button33_Click(object sender, EventArgs e)
    {
        //第一个的"留言修改"
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "proc_updatemess";
        cmd.Parameters.AddWithValue("@geid", Session["geuserid"]);
        cmd.Parameters.AddWithValue("@meid", GridView3.SelectedRow.Cells[1].Text);
        cmd.Parameters.AddWithValue("@mess", TextBox7.Text);
        cmd.Connection = cn;         //打开数据库连接，执行插入 update 命令         
        cn.Open();
        try
        {
            int i = cmd.ExecuteNonQuery(); //执行 SQL 命令，i 为受影响的记录行数             
            if (i > 0)
            {
                Label7.Text = "提示：" + i + "条留言修改成功！";
                TextBox8.Text = "暂无";//报告成功修改                 
            }
        }
        catch (MySqlException ex)   //捕获 try 后的程序段执行异常，用 Label1 显示原因         
        {
            Label7.Text = ex.Message;
        }
        cn.Close();             //关闭数据库连接
    }
}