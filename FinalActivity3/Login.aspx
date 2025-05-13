<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalActivity3.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Log In</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="forms-container">

            <h2>Log In</h2>

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
                    <td><asp:Button ID="btnLogin" runat="server" CssClass="forms-input" Text="Log In" OnClick="btnLogin_Click" /></td>
                </tr>   
            </table>

        </div>

</asp:Content>
