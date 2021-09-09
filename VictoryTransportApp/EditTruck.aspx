<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTruck.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.EditTruck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">EDIT TRUCK</h4>
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
                <asp:Button ID="btSaveTruck" runat="server" CssClass="btn green_button" Text="Update" OnClick="btUpdateTruck_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        
    </div>

</asp:Content>
