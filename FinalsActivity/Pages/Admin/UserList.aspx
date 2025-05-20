<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="FinalsActivity.Pages.Admin.UserList" %>

<asp:Content ID="UserList" ContentPlaceHolderID="AdminMasterContent" runat="server">
    
    <h2 style="color: #333; margin-bottom: 15px;">Member Records</h2>

    <asp:GridView ID="grdUserList" runat="server" CssClass="styled-gridview" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="UserName" HeaderText="User Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="MemberType" HeaderText="Member Type" />
        </Columns>
    </asp:GridView>


</asp:Content>
