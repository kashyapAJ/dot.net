<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Employee._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div style="padding:5px;">
<h2>Add Data using SQL Stored Procedure</h2>
<table class="table table-condensed" style="width:500px;">
<tr>
<td>
Employee Name:
</td>
<td>
<asp:TextBox runat="server" ID="txtEmpName" placeholder="Enter Employee Name"
Width="150px"/>
</td>
</tr>
<tr>
<td>
Employee Designation:
</td>
<td>
<asp:TextBox TextMode="MultiLine" runat="server" ID="txtEmpDes"
Width="150px" placeholder="Enter Employee Designation"/>
</td>
</tr>
<tr>
<td colspan="2" align="left">
<asp:Button runat="server" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click"/>
</td>
</tr>
</table>
<asp:Label runat="server" ID="lblInfo" />

<br /><br />
<asp:GridView runat="server" ID="proDataGrid" CssClass="table table-condensed" Width="500px"/>
</div>
</form>
</body>
</html>
