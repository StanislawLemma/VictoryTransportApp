<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBroker.aspx.cs" 
    ClientIDMode="Static" Inherits="VictoryTransportApp.EditBroker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">EDIT BROKER</h4>
            </div>
        </div>
        <div class="form-group p-2">
            <div class="form-row">
                <div class="col-3">
                    <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Customer"></asp:Label>
                    <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Full Name"></asp:Label>
                    <asp:TextBox ID="txtBrokerName" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqName" class="text-danger" controltovalidate="txtBrokerName" errormessage="Please enter a Name." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" class="text-danger" controltovalidate="txtEmail" errormessage="Please enter an Email." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Phone"></asp:Label>
                    <asp:TextBox ID="txtBrokerPhone" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" class="text-danger" controltovalidate="txtBrokerPhone" errormessage="Please enter a Phone Number." />
                </div>
            </div>

            <div class="col-xs-11">
                <asp:Button ID="Button1" runat="server" CssClass="btn green_button" Text="Update" OnClick="btUpdateBroker_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        
</asp:Content>
