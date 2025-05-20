<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/User/UserMaster.master" AutoEventWireup="true" CodeBehind="Storefront.aspx.cs" Inherits="FinalsActivity.Pages.User.Storefront" %>

<asp:Content ID="Storefront" ContentPlaceHolderID="UserMasterContent" runat="server">
    
    Storefront

    <div class="product-container">

        <asp:Repeater ID="rptProducts" runat="server">
        <ItemTemplate>

            <div class="product-card">
                <h3>        <%# Eval("ProductName") %></h3>
                <p>Price:   <%# ((decimal)Eval("Price")).ToString("C", new System.Globalization.CultureInfo("fil-PH")) %></p>
                <p>Stocks:  <%# Eval("Stocks") %></p>
                <p>SRP:     <%# ((decimal)Eval("SRP")).ToString("C", new System.Globalization.CultureInfo("fil-PH")) %></p>
                <asp:Button ID="btnSelect" runat="server"
                    CommandName="SelectProduct"
                    CommandArgument='<%# Eval("ProductID") %>'
                    Text="Select" />
            </div>

        </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>