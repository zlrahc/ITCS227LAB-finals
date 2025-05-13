<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FinalActivity3.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Registration</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                    <td>Confirm Password</td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="forms-input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnRegister" runat="server" CssClass="forms-input" Text="Register" OnClick="btnRegister_Click" /></td>
                </tr>
            </table>

        </div>

</asp:Content>
