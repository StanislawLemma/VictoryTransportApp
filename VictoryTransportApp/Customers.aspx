<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">ADD CUSTOMER</h4>
            </div>
        </div>

        <div class="form-group p-2">
            <div class="form-row">
                <div class="col-4">
                    <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Title"></asp:Label>
                    <asp:TextBox ID="txtCTitle" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqName" class="text-danger" controltovalidate="txtCTitle" errormessage="Please enter a Title." />
                </div>

                <div class="col-4">
                    <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Phone"></asp:Label>
                    <asp:TextBox ID="txtCPhone" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                </div>

                <div class="col-4">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtCEmail" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="col-4">
                    <asp:Label ID="Label6" runat="server" CssClass="col-form-label" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtCAddress" TextMode="MultiLine" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-xs-11 p-2">
            <asp:Button ID="Button1" runat="server" CssClass="btn green_button" Text="Save" OnClick="btSaveCustomer_Click" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

        <div style="width: 100%; border: 1px solid rgba(0,0,0,.1);" class="p-2 mt-4">
            <table id="customertable" class="table table-striped table-bordered display nowrap" style="width: 100%">
                <thead class="thead-light">
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Phone</th>
                        <th>Email</th>
                        <th>Address</th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <script src="/Content/js/customerTable.js"></script>

</asp:Content>
