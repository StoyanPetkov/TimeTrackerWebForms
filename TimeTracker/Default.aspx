<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TimeTracker.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderCenter" runat="server">
    <div class="MainDiv">
        <div class="row">
            <table>
                <tr>
                    <td>User</td>
                    <td><asp:TextBox runat="server" ID="tbUserName"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 26px">Password</td>
                    <td style="height: 26px"><asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnLogIn" Text="Log In" runat="server" OnClick="btnLogIn_Click"/></td>
                </tr>
            </table>
        </div>

        <div class="RegisterRow">
            <table style="position: relative">
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Username"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="loginTbUserName">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Password" ID="loginTbPassword"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="First name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="loginTbFirstName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Last name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="loginTbLastName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="E-Mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="loginTbMail"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Mobile"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="loginTbPhone"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </asp:Content>