<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dispatchers.aspx.cs" 
    ClientIDMode="Static" Inherits="VictoryTransportApp.Dispatchers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-12">
                <h4 class="heading">ADD DISPATCHER</h4>
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
                <asp:Button ID="Button1" runat="server" CssClass="btn green_button" Text="Save" OnClick="btSaveDispatcher_Click" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        

        <div style="width: 100%; border: 1px solid rgba(0,0,0,.1);" class="p-2 mt-4">
            <%--<a ID="ButonDeleteRow" Class="btn btn-danger btn-sm"> Delete Row</a>--%>
            
            <table id="dispatchertable" class="table table-striped table-bordered display nowrap" style="width:100%">
                <thead class="thead-light">
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Phone</th>
                        <th>Email</th>
                        <th>SSN</th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>

    </div>

    <script src="/Content/js/dispatcherTable3.js"></script>

</asp:Content>
