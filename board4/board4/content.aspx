<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="board4.content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Content</title>
</head>
<body>
    <form id="Content" runat="server">

        <p>글 내용</p>

        <table style="width:520px;">
            <tr>
                <td style="width:120px;">이름</td>
                <td style="width:400px;">
                    <asp:Label id="name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>작성일</td>
                <td>
                    <asp:Label id="date" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>제목</td>
                <td>
                    <asp:Label id="title" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colSpan="2">내용</td>
            </tr>
            <tr>
                <td colSpan="2">
                    <asp:Label id="strcontent" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colSpan="2">
                    <a href="list.aspx"><img src="images/b_list.gif" border="0"/></a>
                    <asp:TextBox Runat="server" ID="pwd" TextMode="Password"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="비밀번호를 입력해 주세요" ControlToValidate="pwd" Display="None"/>
                    <asp:imagebutton id="btnEdit" runat="server" ImageUrl="images/b_edit.gif" OnClick="btnEdit_Click"/>
                    <asp:imagebutton id="btnDelete" runat="server" ImageUrl="images/b_delete.gif" OnClick="btnDelete_Click"/>
                </td>
            </tr>
        </table>
        <asp:Label id="Error" runat="server" ForeColor="Red"
            BorderWidth="1px" BorderStyle="Solid" BorderColor="Red" Width="520px"
            Visible="False"></asp:Label><br/>
        <asp:ValidationSummary id="ValidationSummary1" runat="server"
             ShowMessageBox="True" ShowSummary="False" DisplayMode="List">
            </asp:ValidationSummary>
    </form>
</body>
</html>
