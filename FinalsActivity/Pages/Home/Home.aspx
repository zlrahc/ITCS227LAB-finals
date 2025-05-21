<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Home/HomeMaster.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalsActivity.Pages.Home.Home" %>

<asp:Content ID="Home" ContentPlaceHolderID="HomeMasterContent" runat="server">
    
    <div class="center-container">
        <div class="login-box">
            <h2>Welcome</h2>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" PostBackUrl="~/Pages/Home/Login.aspx" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" PostBackUrl="~/Pages/Home/Register.aspx" />
        </div>
    </div>

</asp:Content>