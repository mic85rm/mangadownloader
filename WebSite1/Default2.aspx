<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:TextBox ID="txtLinkManga" runat="server" Width="740px"></asp:TextBox><asp:Button ID="btnScarica" runat="server" Text="Download" OnClick="btnScarica_Click" />
          <asp:Label ID="lblNumeroCapitoli" runat="server" Text="Numero Capitoli: "></asp:Label>

        </div>
      
        <asp:ListBox ID="lstbxListaCapitoli" runat="server" Height="421px" Width="402px" OnSelectedIndexChanged="lstbxListaCapitoli_SelectedIndexChanged" SelectionMode="Single" AutoPostBack="true" ></asp:ListBox>
      <asp:ListBox ID="lstbxListaLinkDownload" runat="server" Height="421px" Width="402px"></asp:ListBox>
      
    </form>
</body>
</html>
