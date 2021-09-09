<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trucks.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.Trucks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">ADD TRUCK</h4>
            </div>
        </div>
        <div class="form-group p-2">
            <div class="form-row">
                <div class="col-3">
                    <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Truck #"></asp:Label>
                    <asp:TextBox ID="tbTNo" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqNo" class="text-danger" ControlToValidate="tbTNo" ErrorMessage="Please enter Truck Number." />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Plate"></asp:Label>
                    <asp:TextBox ID="tbTPlate" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" class="text-danger" ControlToValidate="tbTPlate" ErrorMessage="Please enter Truck Plate." />
                </div>

                <div class="col-3">
                    <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Model"></asp:Label>
                    <asp:TextBox ID="tbTModel" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                </div>

                <div class="col-3">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Year"></asp:Label>
                    <asp:TextBox ID="tbTYear" runat="server" CssClass="form-control form-control-sm col-md-10"></asp:TextBox>
                </div>
            </div>

            <div class="col-xs-11">
                <asp:Button ID="btSaveTruck" runat="server" CssClass="btn green_button" Text="Save" OnClick="btSaveTruck_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        

        <div style="width: 100%; border: 1px solid rgba(0,0,0,.1);" class="p-2 mt-4">
            <table id="trucktable" class="table table-striped table-bordered display nowrap" style="width: 100%">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Number</th>
                        <th>Plate</th>
                        <th>Model</th>
                        <th>Year</th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <script src="/Content/js/truckTable.js"></script>

</asp:Content>
