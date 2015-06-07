<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminsPage.aspx.cs" Inherits="TimeTracker.UsersPage" %>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderCenter" runat="server">
    <div class="MainDiv">
        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDeleting="GridViewUsers_RowDeleting" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit"  OnRowEditing="GridViewUsers_RowEditing"  OnRowUpdating="GridViewUsers_RowUpdating" OnDataBound="GridViewUsers_DataBound" Height="228px" style="top: -88px; left: 17px; width: 653px; float: left;" AllowPaging="True" OnPageIndexChanging="GridViewUsers_PageIndexChanging" PageSize="5" >
            <AlternatingRowStyle BackColor="#CCFFCC" BorderStyle="Solid" BorderWidth="2px" />
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbId" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First name">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last name">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account name">
                    <ItemTemplate>
                        <asp:TextBox ID="tbUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                    </ItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbPassword" Text='<%#Bind("Password") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID ="lblPassword" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone number">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label Id="lblPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="E-Mail">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbMail" runat="server" TextMode="Email" Text='<%# Bind("Mail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMail" runat="server" Text='<%# Bind("Mail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Role">
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" Text='<%# TimeTracker.Repository.Extension.ConvertRow((Eval("UserRole")).ToString()) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlRole" runat="server">
                            <asp:ListItem Value ="0">Edit role</asp:ListItem>
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="2">User</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" ShowHeader="false">
                <EditItemTemplate>
                <asp:LinkButton ID="lnkbtnUpdate" runat="server" CausesValidation="true" Text="Update" CommandName="Update"></asp:LinkButton>
                <asp:LinkButton ID="lnkbtnCancel" runat="server" CausesValidation="false" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <br />
        <table style="position: relative">
            <br />
            <tr>
                <td style="text-align:center">
                    <asp:Label ID="lblFirstName" runat="server" Text="First name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbFirstName"></asp:TextBox>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="lblLastName" runat="server" Text="Last name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbLastName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Label ID="lblAccName" runat="server" Text="Account name"></asp:Label>
                </td>
                <td style="width: 69px">
                    <asp:TextBox runat="server" ID="tbAccountName"></asp:TextBox>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="tbPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Label ID="lblMail" runat="server" Text="E-Mail"></asp:Label>
                </td>
                <td style="width: 69px">
                    <asp:TextBox runat="server" ID="tbMail"></asp:TextBox>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbPhoneNumber"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnReset" Text="Reset" OnClick="btnReset_Click" Width="60px"/>
                </td>
                <td>
                </td>
                <td style="float:right;">
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"/>
                </td>
            </tr>
        </table>
        </div>     
</asp:Content>

