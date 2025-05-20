<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/User/UserMaster.master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="FinalsActivity.Pages.User.ShoppingCart" %>

<asp:Content ID="ShoppingCart" ContentPlaceHolderID="UserMasterContent" runat="server">
    
    <p class="title">SHOPPING CART</p>

    <asp:GridView ID="gvCart" runat="server" CssClass="styled-gridview" AutoGenerateColumns="False"
        OnRowCommand="gvCart_RowCommand">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Product" />
            <asp:BoundField DataField="Price" HeaderText="Price" 
                            DataFormatString="{0:C}" HtmlEncode="false" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Total" HeaderText="Total" 
                            DataFormatString="{0:C}" HtmlEncode="false" />
        
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Remove" 
                                CommandName="DeleteItem" 
                                CommandArgument='<%# Eval("CartID") %>' 
                                CssClass="add-cart-btn" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>