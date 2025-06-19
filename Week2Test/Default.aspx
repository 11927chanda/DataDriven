<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Week2Test.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label1" runat="server" Text="This is a label"></asp:Label>
            <br />
            <asp:GridView ID="gvResult" runat="server" OnRowDataBound="gvResult_RowDataBound"></asp:GridView>
        </div>
       
    </form>
</body>
</html>
