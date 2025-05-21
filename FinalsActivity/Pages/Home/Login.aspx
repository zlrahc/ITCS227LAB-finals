<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Home/HomeMaster.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalsActivity.Pages.Home.Login" %>

<asp:Content ID="Login" ContentPlaceHolderID="HomeMasterContent" runat="server">
<div class="forms-body">

    <div class="forms-container">

        <h1>Log In</h1>

        <table>
            <tr>
                <td>Email Address</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="forms-input"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtPassword" runat="server" CssClass="forms-input"></asp:TextBox></td>
            </tr>
            <tr>
                <td><br /><asp:Button ID="btnLogin" runat="server" CssClass="forms-button" Text="Login" OnClick="btnLogin_Click" /></td>
            </tr>
            <tr style="text-align:center">
                <td>Don't have an account? <a href="Register.aspx">Sign up here!</a></td>
            </tr>
        </table>

    </div>

</div>
</asp:Content>
