using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class mesvisual : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        cmd.Connection = cn;
        cmd.CommandText = "SELECT * FROM view_total";
        MySqlDataAdapter da = new MySqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        this.ViewState["ds"] = ds;
        da.Fill(ds, "中药材");
        GridView1.DataSource = ds.Tables["中药材"]; //⑷将 GridView3 绑定到 ds 的“meList”表       
        GridView1.DataBind();
        cn.Close();
    }

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
        //第一个表格中选择到的药材的评分详情
        Session.Add("medid", GridView1.SelectedRow.Cells[1].Text); //保存用户号到 Session 的 medid 项中
        Session.Add("medname", GridView1.SelectedRow.Cells[2].Text); //保存用户号到 Session 的 medname 项中
        Response.Redirect("medvisual(2).aspx"); //跳转到中药材可视化界面
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //显示均分
        cmd.Connection = cn;
        cmd.CommandText = "SELECT AVG(attention) as 均分 FROM demand";
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label1.Text = rd["均分"].ToString();
        rd.Close();
        cn.Close();
    }
}