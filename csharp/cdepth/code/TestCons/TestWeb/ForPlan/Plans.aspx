<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Plans.aspx.cs" Inherits="TestWeb.ForPlan.Plans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../contr/js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript">
        var op = 0;
        $(function () {
            $("#BtnAdd").click(function () {
                $("#TrAdd").removeClass("disnone"); $("#HidOp").val("1");
                var date = GetDate();
                $("#addDate").val(date);
                $("#dateTime").text(date);
                return false;
            });
            $("#BtnUpdate").click(function () {

                return false;
            });
            $("#BtnCancel").click(function () {
                $("#TrAdd").addClass("disnone");
                return false;
            });
            $("#PlanTable").find("tr").dblclick(function () {
            });
            $("#PlanTable").find("tr").each(function(){
                $(this).find("td").last().each(function () {
                    if ($(this).text() == "False") {
                        $(this).html("<input type='checkbox' checked='false' disabled='disabled'/>");
                    } else {
                        $(this).html("<input type='checkbox' checked='true' disabled='disabled'/>");
                    }
            }); 
            });
            $("#PlanTable").find("tr").find("td").eq(3).css("text-align", "left");
            $("#TrAdd").find("td").eq(3).css("text-align", "center");
            var date = GetDate();
            $("#dateTime").text(date);
        });
        function GetDate() {
            var date = new Date();
            var mon = date.getMonth() + 1;
            var day = date.getDate();
            var mydate = date.getFullYear() + "-" + (mon < 10 ? "0" + mon : mon) + "-" + (day < 10 ? "0" + day : day) + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
            return mydate;
        }
        function TbAp(table) {
            $("#PlanTable").append(table);
        }
    </script>
   <style type="text/css">
       .disnone {
           display:none;
       }
       body {
           background:url('../contr/img/bg.jpg') no-repeat ;
       }
       td {
           text-align:center; vertical-align:middle;
       }
       #divTop {
           height:30px;
           width:1000px;
           margin:20px auto;
           border:3px solid white;
           border-radius:5px;
           box-shadow:2px 1px 1px 1px green;
           vertical-align:middle;
       }
       #divContent {
           width:1000px;
           margin:30px auto;
           vertical-align:middle;
       }
       .btnClz {
           margin-right:20px;
           background-color:inherit;
           border:1px solid white;
           border-radius:4px;
           box-shadow:1px 1px 1px 1px green;
       }
       #PlanTable {
           margin:10px auto;
       }
        #PlanTable td{
        line-height:35px;
       }
          
       #DdlNames {
           height:20px;border:1px solid green;border-radius:3px;width:100px;
       }
   </style>
</head>

<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HidOp" runat="server"/>
        <asp:HiddenField ID="HidTab" runat="server"/>
     <div id="divTop">
         <table >
             <tr>
                 <td style="width:300px;padding-right:80px;">
                     当前时间:<span id="dateTime" ></span>
                 </td>
                 <td>
                    <asp:Button ID="BtnAdd" CssClass="btnClz" Text="添加" runat="server"/>
                 </td>
                 <td>
                     <asp:Button ID="BtnUpdate" CssClass="btnClz" Text="修改" runat="server"/>
                 </td>
                 <td>
                     <asp:Button ID="BtnSave" CssClass="btnClz" Text="保存" OnClick="BtnSave_Click" runat="server" />
                 </td>
                 <td>
                     <asp:Button ID="BtnCancel" CssClass="btnClz" Text="取消" runat="server" />
                 </td>
                 <td style="padding-left:180px;">
                     昵称：<asp:DropDownList runat="server" ID="DdlNames"  ></asp:DropDownList>
                 </td>
             </tr>
         </table>
     </div>
    <div id="divContent">
            <table id="PlanTable">
                <tr>
                    <th>
                        序号
                    </th>
                    <th width="200px">
                        昵称
                    </th>
                    <th width="200px">
                        日期
                    </th>
                    <th width="400px">
                        内容
                    </th>
                    <th width="50px">
                        完成
                    </th>
                </tr>
                <tr id="TrAdd" class="disnone">
                    <td>
                        <asp:TextBox ID="addno" runat="server" ReadOnly="true" Width="10px" />
                    </td>
                    <td>
                        <asp:TextBox ID="addName" runat="server" Width="60px" />
                    </td>
                    <td>
                        <asp:TextBox ID="addDate" runat="server" ReadOnly="true" Width="150px"  />
                       
                    </td>
                    <td style="text-align:center">
                       <asp:TextBox ID="addContent" runat="server" TextMode="MultiLine" Height="50px" Width="350px" style="text-align:center" />
                    </td>
                    <td>
                        <asp:CheckBox ID="AddStatu" runat="server"/>
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
