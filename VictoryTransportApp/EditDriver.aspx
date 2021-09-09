<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDriver.aspx.cs" 
    ClientIDMode="Static" Inherits="VictoryTransportApp.EditDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">EDIT DRIVER</h4>
            </div>
        </div>

        <div class="form-group p-2">
            <div class="form-row">
                <div class="col-3">
                    <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Full Name"></asp:Label>
                    <asp:TextBox ID="txtDName" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqName" class="text-danger" ControlToValidate="txtDName" ErrorMessage="Please enter a Name." />
                </div>

                <div class="col-3">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtDEmail" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" class="text-danger" ControlToValidate="txtDEmail" ErrorMessage="Please enter an Email." />
                </div>

                <div class="col-3">
                    <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Phone"></asp:Label>
                    <asp:TextBox ID="txtDPhone" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" class="text-danger" ControlToValidate="txtDPhone" ErrorMessage="Please enter a Phone Number." />
                </div>

                <div class="col-3">
                    <asp:Label ID="Label5" runat="server" CssClass="col-form-label" Text="SSN"></asp:Label>
                    <asp:TextBox ID="txtDSsn" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" class="text-danger" ControlToValidate="txtDSsn" ErrorMessage="Please enter an SSN." />
                </div>

            </div>

            <div class="form-row">
                <div class="col-4">
                    <asp:Label ID="Label6" runat="server" CssClass="col-form-label" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtDAddress" TextMode="MultiLine" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                </div>

            </div>
        </div>

        <div class="col-xs-11 p-2">
            <asp:Button ID="Button1" runat="server" CssClass="btn green_button" Text="Update" OnClick="btUpdateDriver_Click" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>
