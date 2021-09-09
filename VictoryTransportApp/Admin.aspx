<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <h3>Welcome Admin! Add User</h3>
        <hr />

        <div class="form-row">
            <div class="col-4">
                <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Username"></asp:Label>
                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Password"></asp:Label>
                <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>

        </div>

        <div class="form-row">
            <div class="col-4">
                <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Name-Surname"></asp:Label>
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
            </div>

            <div class="col-6">
                <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Email"></asp:Label>
                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="col-xs-11 space-vert">
        <asp:Button ID="btSaveUser" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btSaveUser_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>


    <hr />
    <h3>Users</h3>

    <div class="panel panel-default">
        <%--user table begins--%>

        <asp:Repeater ID="rptrUsers" runat="server" OnItemCommand="rptrUsers_ItemCommand">
            <HeaderTemplate>
                <table class="table table-sm table-striped table-bordered table-hover">
                    <thead style="background-color: #cbd6d0;">
                        <tr>
                            <th class="gj-hidden" scope="col">Uid</th>
                            <th scope="col">Username</th>
                            <th scope="col">Name-Surname</th>
                            <th scope="col">Email</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th class="gj-hidden"><%# Eval("Uid") %></th>
                    <td><%# Eval("username") %></td>
                    <td><%# Eval("name") %></td>
                    <td><%# Eval("email") %></td>
                    <td style="width: 4%">
                        <div class="box">
                            <asp:Button ID="delete" runat="server" CssClass="btn btn-danger btn-sm" Text="DEL" UseSubmitBehavior="False" CommandName="delete" CommandArgument='<%# Eval("Uid") %>' />
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
