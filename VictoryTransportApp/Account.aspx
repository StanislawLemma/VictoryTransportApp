<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" 
    ClientIDMode="Static" Inherits="VictoryTransportApp.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
        <div class="form-horizontal">
            <h2>Change Password</h2>
            <hr />
            
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Old Password"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="OldPassword" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="New Password"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="NewPassword" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="New Password Again"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="NewPassword2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="Button1" runat="server" Text="Update" CssClass="btn btn-default" OnClick="Button1_Click" />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </div>
            </div>
        </div>

</asp:Content>
