<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboras.aspx.cs" Inherits="LD5.DP.Laboras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" type="text/css" href="Style.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="LD5_11. Įsimintinos datos"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show initial data!" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table2" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show answers!" />
            <br />
            <br />
            <asp:Table ID="Table3" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
