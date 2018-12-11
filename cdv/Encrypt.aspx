<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Encrypt.aspx.cs" Inherits="Encrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Dữ liệu
        <asp:TextBox ID="txtData" runat="server" TextMode="MultiLine" Width="400" Height="80"></asp:TextBox>
        <br /><br />
        Key
        <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <br /><br />
        Kết quả
        <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Width="400" Height="80"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btMD5" runat="server" Text="MD5" OnClick="btMD5_Click" />
        <asp:Button ID="btEcrypt" runat="server" Text="Encrypt" OnClick="btEcrypt_Click" />
        <asp:Button ID="btDeEncrypt" runat="server" Text="Decrypt" OnClick="btDeEncrypt_Click" />
    </div>
    </form>
</body>
</html>
