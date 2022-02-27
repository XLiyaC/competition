using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    //声明和创建全局变量      
    MySqlConnection cn = new MySqlConnection("server=localhost; database=crop; user id=root; password=1234");
    MySqlDataAdapter da = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand();
    public string attdata,attsort,attdata2;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["medname"] + "的评分总观：";
        cmd.Connection = cn;
        cmd.CommandText = "SELECT attention as 评分,COUNT(demand.medid) as 频数 from demand WHERE demand.medid=@meid group by attention ";
        cmd.Parameters.AddWithValue("@meid", Session["medid"]);
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        if (rd.HasRows)     //依次读入 rd 的记录统计收藏数         
        {
            attsort = "[";      //类别字符串初始化             
            attdata = "[";   //图书出版数量字符串初始化 
            attdata2 = "[";   //图书出版数量字符串初始化            
            while (rd.Read())         //依次读入 rd 的记录添加到数组字符串中             
            {
                attsort = attsort + "'" + rd.GetString(0) + "',";   //添加类别                  
                attdata = attdata + rd.GetString(1) + ","; //添加图书出版数量 
                attdata2 = attdata2 + "{name:'" + rd.GetString(0) + "分',value:" + rd.GetString(1) + "},";  //添加等级和人数              

            }
            attsort = attsort + "]";
            attdata = attdata + "]";
            attdata2 = attdata2 + "]";
        }
        rd.Close();   //关闭 rd         
        cn.Close();   //关闭 cn 
        //Response.Write(attsort);
        //Response.Write(attdata);
        //Response.Write(attdata2);//检查 JSON 数据是否正确
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //显示均分
        cmd.Connection = cn;
        cmd.CommandText = "SELECT AVG(attention) as 均分 FROM demand WHERE demand.medid=@meid";
        //@meid在载入页面时已经被定义
        cn.Open();
        MySqlDataReader rd = cmd.ExecuteReader(); //执行 SQL 命令获得客户表前向只读数据流
        rd.Read();
        Label2.Text = rd["均分"].ToString();
        rd.Close();
        cn.Close();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("generaluser.aspx"); //跳转到用户界面
    }
}