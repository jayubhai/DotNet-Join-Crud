<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="joincrud.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                  <asp:Label ID="orderid" runat="server" Text="Order Id"></asp:Label>
                  <asp:TextBox ID="txtorderid" runat="server"></asp:TextBox>
                  <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                  <br />
                <asp:Label ID="lblcustid" runat="server" Text="Customer Id"></asp:Label>
                <asp:DropDownList ID="ddcustid" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                  </asp:DropDownList>
                <br />
                <asp:Label ID="lblname" runat="server" Text="Cust Name"></asp:Label>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                <br />
                 <asp:Label ID="lblorderdate" runat="server" Text="OrderDate"></asp:Label>
                <asp:TextBox ID="txtorderdate" runat="server"></asp:TextBox>
                <br />
                 <asp:Label ID="lblshipdate" runat="server" Text="Ship Date"></asp:Label>
                <asp:TextBox ID="txtshipdate" runat="server"></asp:TextBox>
                <br />
                 <asp:Label ID="lblamt" runat="server" Text="Order Amount"></asp:Label>
                <asp:TextBox ID="txtamt" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblpayment" runat="server" Text="Payment Mode"></asp:Label>
                <asp:DropDownList ID="ddpayment" runat="server">
                    <asp:ListItem>Gpay</asp:ListItem>
                    <asp:ListItem>ATM</asp:ListItem>
                    <asp:ListItem>UPI</asp:ListItem>
                  </asp:DropDownList>
                <br />
                <asp:Label ID="lblremarks" runat="server" Text="Remarks"></asp:Label>
                <asp:TextBox ID="txtremarks" runat="server"></asp:TextBox>
                  <br />
                <br />
                <asp:Button ID="btninsert" runat="server" Text="Insert" OnClick="btninsert_Click" />
                 &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                 &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
                 &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnview" runat="server" Text="View" OnClick="btnview_Click" />
                  <br />
                  <br />
                  <asp:GridView ID="GridView1" runat="server">
                  </asp:GridView>
                  <br />
                  <asp:DropDownList ID="ddsearch" runat="server">
                      <asp:ListItem>--select query----</asp:ListItem>
                      <asp:ListItem>Q1</asp:ListItem>
                      <asp:ListItem>Q2</asp:ListItem>
                      <asp:ListItem>Q3</asp:ListItem>
                      <asp:ListItem>Q4</asp:ListItem>
                      <asp:ListItem>Q5</asp:ListItem>
                      <asp:ListItem>Q6</asp:ListItem>
                      <asp:ListItem>Q7</asp:ListItem>
                      <asp:ListItem>Q8</asp:ListItem>
                      <asp:ListItem>Q9</asp:ListItem>
                      <asp:ListItem>Q10</asp:ListItem>
                  </asp:DropDownList>
&nbsp;&nbsp;
                  <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Submit" />
                  <br />
                  <br />
                  <br />
                  <asp:GridView ID="GridView2" runat="server">
                  </asp:GridView>
                  <br />

            </center>
        </div>
    </form>
</body>
</html>
