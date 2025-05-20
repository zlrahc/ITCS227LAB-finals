<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/User/UserMaster.master" AutoEventWireup="true" CodeBehind="Storefront.aspx.cs" Inherits="FinalsActivity.Pages.User.Storefront" %>

<asp:Content ID="Storefront" ContentPlaceHolderID="UserMasterContent" runat="server">
    
    <p class="title">STORE</p>

    <div class="product-container">

        <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
        <ItemTemplate>

            <div class="product-card">
                <h3><%# Eval("ProductName") %></h3>
                <p>Price: <%# ((decimal)Eval("Price")).ToString("C", new System.Globalization.CultureInfo("fil-PH")) %></p>
                <p>Stocks:<%# Eval("Stocks") %></p>
                <p>SRP: <%# ((decimal)Eval("SRP")).ToString("C", new System.Globalization.CultureInfo("fil-PH")) %></p>

            <div class="cart-action">
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity-field" placeholder="0" TextMode="Number" Min="0"></asp:TextBox>
                <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="add-cart-btn" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
            </div>

            </div>

        </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>