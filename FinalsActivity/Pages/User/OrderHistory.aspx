<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/User/UserMaster.master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="FinalsActivity.Pages.User.OrderHistory" %>

<asp:Content ID="OrderHistory" ContentPlaceHolderID="UserMasterContent" runat="server">
    
    <p class="title">Order History</p>

    <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="false"
        DataKeyNames="TransactionID" CssClass="styled-gridview" OnRowCommand="gvTransactions_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnViewDetails" runat="server" Text="View Details"
                        CommandName="ViewDetails" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlDetails" runat="server" Visible="false" CssClass="product-container" style="margin-top:20px;">
        <h3>Transaction Details</h3>
        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" CssClass="styled-gridview">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" />
                <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

</asp:Content>
