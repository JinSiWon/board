<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="board4.insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Insert</title>
</head>
<body>
    <form id="insert" runat="server">
        <p>글작성하기</p>
        <table>
            <tr>
                <td style="width:120px">이름</td>
                <td style="width:400px">
                    <asp:TextBox Runat="server" CssClass="input" ID="name" Width="100px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:120px">비밀번호</td>
                <td style="width:400px">
                    <asp:TextBox Runat="server" CssClass="input" ID="pwd" TextMode="Password" Width="100px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:120px">제목</td>
                <td style="width:400px">
                    <asp:TextBox Runat="server" CssClass="input" ID="title" Width="100px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">내용</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox Runat="server" CssClass="input" ID="content" Rows="7"
                        TextMode="MultiLine" Wrap="True" Columns="80"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"> 
                    <asp:ImageButton ID="PostButton" ImageUrl="images/b_save.gif" runat="server" OnClick="PostButton_Click1"></asp:ImageButton>
                    <a href="list.aspx"><img src="images/b_list.gif" border="0"/></a>
                    <a href="javascript:document.Insert.reset();">
                        <img src="images/b_reset.gif" border="0"/>
                    </a>
                </td>
            </tr>
        </table>
        <asp:Label id="Error" runat="server" ForeColor="Red"
            BorderWidth="1px" BorderStyle="Solid" BorderColor="Red" Width="520px"
            Visible="False"></asp:Label><br/>
    </form>
</body>
</html>
