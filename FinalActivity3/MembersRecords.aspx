<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="MembersRecords.aspx.cs" Inherits="FinalActivity3.MemberRecords" %>
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

        </div>

    </div>

</asp:Content>
