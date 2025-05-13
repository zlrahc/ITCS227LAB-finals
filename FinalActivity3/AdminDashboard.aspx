<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FinalActivity3.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <asp:FileUpload ID="fldImage" runat="server" />
        
        <asp:Button runat="server" Text="Upload" ID="btnUpload" OnClick="btnUpload_Click"></asp:Button>

    </div>
    <div>&nbsp;</div>

</asp:Content>
