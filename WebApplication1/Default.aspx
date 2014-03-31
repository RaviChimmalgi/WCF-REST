<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 419px;
        }
        .style2
        {
            width: 77px;
        }
        .style3
        {
            width: 63px;
        }
    </style>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table style="width:32%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Timeclock" ></asp:Label>
            </td>
            
        </tr>
        <tr>
        <td class="style2">
            <asp:Button ID="Button4" runat="server" Text="Clock Log" />
            </td>
        <td>
            &nbsp;</td>
       
        
        </tr>
        </table>
        <div id="div1" style="width:100%; " runat="server">
            <br />
        <table style="width: 210px">
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    <asp:ListItem>User1</asp:ListItem>
                    <asp:ListItem>User2</asp:ListItem>
                    <asp:ListItem>User3</asp:ListItem>
                    <asp:ListItem>User4</asp:ListItem>
                </asp:DropDownList>
            </td>
          
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
          
        </tr>
        <tr>
            <td class="style3">
                <asp:Button ID="Button1" runat="server" Text="Sign in" />
            </td>
            <td class="style1">
                <asp:Button ID="Button2" runat="server" Text="Sign out" />
            </td>
           
        </tr>
    </table>
            <br />
    </div>
    
    <div id="div2" >
    </div>
    
  
    <asp:TextBox ID="TextBox1" runat="server" Height="299px" Width="463px" 
        TextMode="MultiLine"></asp:TextBox>
    
  
    </form>
    </body>
</html>
