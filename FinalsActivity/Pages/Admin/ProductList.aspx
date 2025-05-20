<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="FinalsActivity.Pages.Admin.ProductList" %>

<asp:Content ID="ProductList" ContentPlaceHolderID="AdminMasterContent" runat="server">
    
    <h2 style="color: #333; margin-bottom: 15px;">
        Product List
    </h2>

    <asp:GridView ID="grdUserList" runat="server" CssClass="styled-gridview" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <%# ((decimal)Eval("Price")).ToString("C", new System.Globalization.CultureInfo("fil-PH")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Stocks" HeaderText="Stocks" />
            <asp:TemplateField HeaderText="SRP">
                <ItemTemplate>
                    <%# ((decimal)Eval("SRP")).ToString("C", new System.Globalization.CultureInfo("fil-PH")) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />

    <asp:Panel ID="pnlAddProduct" runat="server" CssClass="add-product-form">
        <h3>Add New Product</h3>
        <asp:TextBox ID="txtProductID" runat="server" Placeholder="Product ID" CssClass="form-control" /><br />
        <asp:TextBox ID="txtProductName" runat="server" Placeholder="Product Name" CssClass="form-control" /><br />
        <asp:TextBox ID="txtPrice" runat="server" Placeholder="Price" CssClass="form-control" /><br />
        <asp:TextBox ID="txtStocks" runat="server" Placeholder="Stocks" CssClass="form-control" /><br />
        <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" CssClass="btn btn-primary" />
    </asp:Panel>

</asp:Content>