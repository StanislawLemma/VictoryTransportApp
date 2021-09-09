<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brokers.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.Brokers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">ADD BROKER</h4>
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
                    <asp:RequiredFieldValidator runat="server" ID="reqName" class="text-danger" ControlToValidate="txtBrokerName" ErrorMessage="Please enter a Name." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" class="text-danger" ControlToValidate="txtEmail" ErrorMessage="Please enter an Email." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Phone"></asp:Label>
                    <asp:TextBox ID="txtBrokerPhone" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" class="text-danger" ControlToValidate="txtBrokerPhone" ErrorMessage="Please enter a Phone Number." />
                </div>
            </div>

            <div class="col-xs-11">
                <asp:Button ID="Button1" runat="server" CssClass="btn green_button" Text="Save" OnClick="btSaveBroker_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        

        <div style="width: 100%; border: 1px solid rgba(0,0,0,.1);" class="p-2 mt-4">
            <table id="brokertable" class="table table-striped table-bordered display nowrap" style="width: 100%">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Customer</th>
                        <th>Phone</th>
                        <th>Email</th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <script src="/Content/js/brokerTable.js"></script>
</asp:Content>
