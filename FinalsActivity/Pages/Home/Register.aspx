<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Home/HomeMaster.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalsActivity.Pages.Home.Register" %>

<asp:Content ID="Register" ContentPlaceHolderID="HomeMasterContent" runat="server">
<div class="forms-body">

    <div class="forms-container">

        <h1>Register</h1>

        <table>
            <tr>
                <td>First Name</td>
                <td>Last Name</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtFirstName" runat="server" CssClass="forms-input"></asp:TextBox></td>
                <td><asp:TextBox ID="txtLastName" runat="server" CssClass="forms-input"></asp:TextBox></td>
            </tr>
        </table>
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
                <td>Membership Type</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="drpMemberType" runat="server" CssClass="forms-dropdown">
                    <asp:ListItem>Silver</asp:ListItem>
                    <asp:ListItem>Gold</asp:ListItem>
                    <asp:ListItem>Platinum</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td><br /><asp:Button ID="btnRegister" runat="server" CssClass="forms-button" Text="Register" OnClick="btnRegister_Click" /></td>
            </tr>
            <tr style="text-align:center">
                <td>Already have an account? <a href="Login.aspx">Log in here!</a></td>
            </tr>
        </table>

    </div>

</div>
</asp:Content>
