<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SOAPClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Simplified Calculator, uses only integer.</div>
        Number 1:
        <asp:TextBox ID="TBNum1" runat="server">0</asp:TextBox>
        <br />
        Number 2:
        <asp:TextBox ID="TBNum2" runat="server">0</asp:TextBox>
        <p>
            <asp:Button ID="BAdd" runat="server" OnClick="Button3_Click" Text="+" />
            <asp:Button ID="BSub" runat="server" OnClick="BSub_Click" style="width: 18px" Text="-" />
            <asp:Button ID="BMul" runat="server" OnClick="BMul_Click" Text="X" />
            <asp:Button ID="BDiv" runat="server" OnClick="BDiv_Click" Text="/" />
        </p>
        Result:
        <asp:TextBox ID="TBResult" runat="server"></asp:TextBox>
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
