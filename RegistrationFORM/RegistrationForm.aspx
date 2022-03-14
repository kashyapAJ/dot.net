<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="userinfo.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div style="padding:5px;">
<h2>User Registration Form :-</h2>
<table class="table table-condensed" style="width:500px;">
<tr>
<td>
Name:
</td>
<td>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Phone No. :
</td>
<td>
    <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Gender :
</td>
<td>
    <asp:RadioButtonList ID="Gender" runat="server">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
        <asp:ListItem>Others</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
<tr>
<td>
City :
</td>
<td>
    <asp:DropDownList ID="City" runat="server">
        <asp:ListItem>Select Your City</asp:ListItem>
        <asp:ListItem>Delhi</asp:ListItem>
        <asp:ListItem>Bihar</asp:ListItem>
        <asp:ListItem>UP</asp:ListItem>
        <asp:ListItem>J & K</asp:ListItem>
        <asp:ListItem>Assam</asp:ListItem>
        <asp:ListItem>Haryana</asp:ListItem>
        <asp:ListItem>Punjab</asp:ListItem>
        <asp:ListItem>Karnataka</asp:ListItem>
        <asp:ListItem>Gujrat</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
    <tr>
<td>
Email ID :
</td>
<td>
    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Create Password :
</td>
<td>
    <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2" align="left">
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
</td>
</tr>
</table>
<asp:Label runat="server" ID="lblInfo" />

<br /><br />
    <asp:GridView ID="proDataGrid" runat="server" CssClass="table table-condensed" Width="500px"/>
</div>
</form>
</body>
</html>
