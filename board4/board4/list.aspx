<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="board4.list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>list</title>
</head>
<body>
    <form id="list" runat="server">
        <table style="width:520px; border:0;">
            <tr>
                <td height="25"> 글 목록 <a href="insert.aspx"><img src="images/b_write.gif" border="0"/></a></td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false">
                        <SelectedItemStyle Font-Bold="true" />
                        <HeaderStyle Font-Bold="true" />
                        <Columns>
                            <asp:HyperLinkColumn DataNavigateUrlField="intseq" 
                                DataTextField="strtitle"
                                DataNavigateUrlFormatString="content.aspx?seq={0}"
                                HeaderText="제목">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:HyperLinkColumn>

                            <asp:BoundColumn DataField="strwriter" HeaderText="작성자">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="date" HeaderText="작성일">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
