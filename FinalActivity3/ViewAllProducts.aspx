<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ViewAllProducts.aspx.cs" Inherits="FinalActivity3.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-layout">

        <nav class="side-nav">
            <ul>
                <li><a href="ViewAllProducts.aspx">View All Products</a></li>
                <li><a href="MembersRecords.aspx">Members Records</a></li>
                <li><a href="TrasactionLog.aspx">Transaction Log</a></li>
                <li><a href="ReportModule.aspx">Report Module</a></li>
            </ul>
        </nav>

        <div class="admin-content">
            
            <asp:GridView ID="GridView1" CssClass="styled-gridview" runat="server" AutoGenerateColumns="true"></asp:GridView>

           

            <asp:Panel ID="pnlAddProduct" runat="server">

                <table>
                    <tr>
                        <td>ProductID</td>
                        <td><asp:TextBox ID="txtProductID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Product Name</td>
                        <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Stocks</td>
                        <td><asp:TextBox ID="txtStocks" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>SRP</td>
                        <td><asp:TextBox ID="txtSRP" runat="server"></asp:TextBox></td>
                    </tr>
                </table>

                 <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />

            </asp:Panel>

        </div>

        

    </div>

</asp:Content>
