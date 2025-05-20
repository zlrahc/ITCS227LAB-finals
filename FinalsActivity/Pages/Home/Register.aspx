<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Home/HomeMaster.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalsActivity.Pages.Home.Register" %>

<asp:Content ID="Register" ContentPlaceHolderID="HomeMasterContent" runat="server">
<div class="login-body">

    <div class="forms-container">

        <h2>Register</h2>

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
                <td><asp:DropDownList ID="drpMemberType" runat="server" CssClass="forms-input">
                    <asp:ListItem>Silver</asp:ListItem>
                    <asp:ListItem>Gold</asp:ListItem>
                    <asp:ListItem>Platinum</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnRegister" runat="server" CssClass="forms-input" Text="Register" OnClick="btnRegister_Click" />
                    <br />
                    Already have an account? <a href="Login.aspx">Log in here!</a></td>
            </tr>
        </table>

    </div>

</div>
</asp:Content>
