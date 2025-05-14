<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalActivity3.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-layout">
        <nav class="side-nav">
            <ul>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="History.aspx">History</a></li>
                <li><a href="Profile.aspx">Profile</a></li>
                <li><a href="Login.aspx">Log Out</a></li>
            </ul>
        </nav>

        <div class="admin-content">
            <h1>Product List</h1>
            <div class="product-container">
                <asp:Repeater ID="rptProducts" runat="server">
                    <ItemTemplate>
                        <a class="product-card" href='<%# Eval("ProductID", "Home.aspx?productId={0}") %>'>
                            <div class="product-card">
                                <div class="product-name"><%# Eval("ProductName") %></div>
                                <div class="product-price">₱<%# String.Format("{0:F2}", Eval("Price")) %></div>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="product-details">
                <h2>Selected Products</h2>
                <asp:Repeater ID="rptSelectedProducts" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Product Name</th>
                                <th>Price</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ProductName") %></td>
                            <td>₱<%# String.Format("{0:F2}", Eval("Price")) %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
