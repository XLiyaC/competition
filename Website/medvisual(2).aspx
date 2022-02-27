<%@ Page Language="C#" AutoEventWireup="true" CodeFile="medvisual(2).aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>评分详情</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 300px;
        }
    </style>
</head>
<body style="height: 673px">
    <!--ECharts单文件引入-->
    <script src="echarts/dist/echarts-all.js"></script>
    <script type="text/javascript"> 
    <!--自定义带传入参数的ECharts绘图函数-->
        function myFunction(d1, d2)
        {
            var myChart = echarts.init(document.getElementById("main"));  //初始化图表
            var option = {  //设置option属性
            title: { text: '评分详情', x: 'center'},   //标题水平居中
            tooltip: {},    //鼠标悬浮交互时的信息提示由数据触发
            legend: { orient: 'vertical', x: 'left', data: ['评分'] }, // 图例垂直布局放左侧显示“数量”
            xAxis: { data: d1 },  //x轴标签数组
            yAxis: {},  //y轴标签数组
            toolbox: {
                show: true,
                feature:
                {
                    mark: {show: true },                 //辅助线标志
                    dataZoom: {show: true },             //数据框选区域缩放
                    dataView: {show: true, readOnly: false }, //数据视图
                    restore: {show: true },                 //重置
                    magicType: {                       //动态类型切换
                        show: true,
                        type: ['bar', 'line']         //柱状图和折线图
                    },
                    saveAsImage: { show: true } //保存图片
                }
            },
            series: [  // 驱动图表生成的数据系列
                   {
                        name: '评分',   //数据系列名称
                        type: 'bar',         //图表类型为柱状图
                        data: d2           //数据系列的数据内容
                    }
                 ]
         }
         myChart.setOption(option);  //为echarts对象加载数据
        }

        function myPie(d3) 
        {
            var myChart = echarts.init(document.getElementById("main2")); //初始化图表
            var option2 = { //设置option2属性
                title: {    //标题
                    text: '评分详情', //主标题文本
                    //subtext: '评分',      //副标题文本
                    x: 'center'                  //水平放置居中
                },
                tooltip: {},  //鼠标悬浮交互时的信息提示，默认数据触发
                legend: {   //图例
                    x: 'right',          //水平居右
                    data: ['评分']  //图例
                },
                series: [  // 驱动图表生成的数据系列
                    {
                        name: '评分', //数据系列名称
                        type: 'pie',       //图表类型饼图
                        radius: '60%',    //半径，支持绝对值（px）和百分比
                        data: d3        //绘图数据
                    }
                ]
            };
            //为echarts对象加载数据
            myChart.setOption(option2);
        }
     </script>

       




    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">返回前页</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">平均评分</asp:LinkButton>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
    
        <input id="Button1" type="button" value="绘制图表" onclick="myFunction(<%=attsort%>,<%=attdata%>)"/>

    </div>
        <div id="main" style="height: 221px">

        </div>
    <div>
        <input id="Button2" type="button" value="绘制饼图" onclick="myPie(<%=attdata2%>)"/></div>
        <div id="main2" class="auto-style1"></div>

    </form>

</body>
</html>
