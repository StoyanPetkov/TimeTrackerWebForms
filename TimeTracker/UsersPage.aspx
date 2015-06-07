<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="TimeTracker.UsersPage1" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="PlaceHolderCenter">
    <div class="MainDiv">
        <asp:DataGrid runat="server" ID="GridView" AutoGenerateColumns="false" DataKeyField="Id" OnItemDataBound="GridView_ItemDataBound" AllowPaging="True" OnPageIndexChanged="GridView_PageIndexChanged" OnSelectedIndexChanged="GridView_SelectedIndexChanged" PageSize="5">
            <Columns>
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Bind ("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="UserName">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Password" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblPassword" runat="server" Text='<%#Bind("Password") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn  HeaderText="FirstName">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblFirstName" Text='<%#Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="LastName">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblLastName" Text='<%#Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="E-Mail">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblMail" Text='<%#Bind("Mail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Role">
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" Text='<%# TimeTracker.Repository.Extension.ConvertRow((Eval("UserRole")).ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>

