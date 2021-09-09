<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDispatcher.aspx.cs" 
    ClientIDMode="Static" Inherits="VictoryTransportApp.EditDispatcher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">EDIT DISPATCHER</h4>
            </div>
        </div>
        <div class="form-group p-2">
            <div class="form-row">
                <div class="col-3">
                    <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Full Name"></asp:Label>
                    <asp:TextBox ID="txtDispatcherName" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqName" class="text-danger" controltovalidate="txtDispatcherName" errormessage="Please enter a Name." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" class="text-danger" controltovalidate="txtEmail" errormessage="Please enter an Email." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Phone"></asp:Label>
                    <asp:TextBox ID="txtDispatcherPhone" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" class="text-danger" controltovalidate="txtDispatcherPhone" errormessage="Please enter a Phone Number." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="SSN"></asp:Label>
                    <asp:TextBox ID="txtDispatcherSsn" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" class="text-danger" controltovalidate="txtDispatcherSsn" errormessage="Please enter an SSN." />
                </div>
            </div>

            <div class="col-xs-11">
                <asp:Button ID="Button1" runat="server" CssClass="btn green_button" Text="Update" OnClick="btUpdateDispatcher_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        

    </div>

</asp:Content>
