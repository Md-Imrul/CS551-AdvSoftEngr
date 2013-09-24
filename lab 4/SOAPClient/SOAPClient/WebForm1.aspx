<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SOAPClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        Number 1:
        <asp:TextBox ID="TBNum1" runat="server">0</asp:TextBox>
        <br />
        Number 2:
        <asp:TextBox ID="TBNum2" runat="server">0</asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Height="26px" OnClick="Button1_Click" Text="Calculate" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-top: 0px" Text="Calculate(Remote)" />
        </p>
        Result:
        <asp:TextBox ID="TBResult" runat="server"></asp:TextBox>
    </form>
</body>
</html>
