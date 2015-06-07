<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="TimeTracker.WebForm1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderCenter" runat="server">
    <h2>Navigate to any page</h2>
    <div class="UsersButton">
        <asp:ImageButton ID="imgbtnUsers" runat="server" ImageUrl="~/Images/UsersPage.jpg" OnClick="imgbtnUsers_Click" />
        <asp:ImageButton ID="imgbtnAdmins" runat="server" ImageUrl="~/Images/adminsPage.jpg" OnClick="imgbtnAdmins_Click" />
    </div>
</asp:Content>

