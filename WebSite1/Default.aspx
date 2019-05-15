<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="MicheleControlli" Namespace="MicheleControlli" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          <cc1:Bottone ID="Bottone1" runat="server" OnClick="Bottone1_Click" />
        </div>
        <asp:TextBox ID="TextBox2" runat="server" Height="466px" Width="1393px" TextMode="MultiLine"></asp:TextBox>
    </form>
  
</body>
</html>
