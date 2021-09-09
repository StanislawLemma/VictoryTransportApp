<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoadsNew.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.LoadsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/gijgo@1.8.1/combined/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://cdn.jsdelivr.net/npm/gijgo@1.8.1/combined/css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <div class="form-row">
            <div class="col-10">
                <h4 class="heading">ADD LOAD</h4>
            </div>
            <div class="col-2">
                <asp:CheckBox ID="chkBilled" runat="server" CssClass="checkbox-inline form-control-lg float-right" Text="&nbsp BILLED" Checked="False" />
            </div>
        </div>

        <div class="form-group px-2">
            <h5 class="heading">General</h5>
            <div class="form-row">
                <div class="col-3">
                    <asp:Label ID="Label3" runat="server" class="col-form-label" Text="Load #"></asp:Label>
                    <asp:TextBox ID="txtLoadNo" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqName" class="text-danger" controltovalidate="txtLoadNo" errormessage="Please enter Load Number" />
                </div>
                <div class="col-3">
                    <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Rate #"></asp:Label>
                    <asp:TextBox ID="txtLRateNo" runat="server" CssClass="form-control form-control-sm col-md-8"> </asp:TextBox>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label5" runat="server" CssClass="col-form-label" Text="Truck #"></asp:Label>
                    <asp:DropDownList ID="ddlTruckNo" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label7" runat="server" CssClass="col-form-label" Text="Status"></asp:Label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="form-group p-2">
            <h5 class="heading">People</h5>
            <div class="form-row">
                <div class="col-3">
                    <asp:Label ID="Label19" runat="server" CssClass="col-form-label" Text="Customer"></asp:Label>
                    <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                        onselectedindexchanged="Customer_SelectedIndexChanged" CssClass="form-control form-control-sm col-md-8">
                    </asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Broker"></asp:Label>
                    <asp:DropDownList ID="ddlBroker" runat="server" AppendDataBoundItems="true"
                        CssClass="form-control form-control-sm col-md-8">
                    </asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Dispatcher"></asp:Label>
                    <asp:DropDownList ID="ddlDispatcher" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label6" runat="server" CssClass="col-form-label" Text="Driver"></asp:Label>
                    <asp:DropDownList ID="ddlDriverName" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:DropDownList>
                </div>
            </div>
        </div>



        <div class="form-group p-2">
            <div class="form-row">
                <div class="col-6">
                    <h5 class="heading">Pick Up Info</h5>
                </div>
                <div class="col-6">
                    <h5 class="heading">Delivery Info</h5>
                </div>
            </div>

            <div class="form-row">
                <div class="col-6">
                    <asp:Label ID="Label8" runat="server" class="col-form-label" Text="Company"></asp:Label>
                    <asp:TextBox ID="txtPCompany" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Label ID="Label9" runat="server" class="col-form-label" Text="Company"></asp:Label>
                    <asp:TextBox ID="txtDCompany" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="col-6">
                    <asp:Label ID="Label10" runat="server" class="col-form-label" Text="Address Line 1"></asp:Label>
                    <asp:TextBox ID="txtPAddress1" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Label ID="Label11" runat="server" class="col-form-label" Text="Address Line 1"></asp:Label>
                    <asp:TextBox ID="txtDAddress1" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="col-6">
                    <asp:Label ID="Label12" runat="server" class="col-form-label" Text="City/State/Zip"></asp:Label>
                    <asp:TextBox ID="txtPZip" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
                </div>
                <div class="col-3">
                    <asp:Label ID="Label13" runat="server" class="col-form-label" Text="City/State/Zip"></asp:Label>
                    <asp:TextBox ID="txtDZip" runat="server" CssClass="form-control form-control-sm col-md"></asp:TextBox>
                </div>
                <div class="col-3">
                    <button runat="server" id="btnDirection" onserverclick="btDirections_Click" class="btn directions_btn ml-4 green_button" title="Get Directions">
                        <i class="fas fa-map-marker-alt mr-1"></i>Get Directions
                    </button>
                    <asp:Label ID="Label29" runat="server"></asp:Label>

                </div>
            </div>

            <div class="form-row">
                <div class="col-2">
                    <asp:Label ID="Label14" runat="server" class="col-form-label" Text="Date Begin"></asp:Label>
                    <asp:TextBox ID="txtPStartDate" runat="server" CssClass="form-control form-control-sm col-md date_length"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" class="text-danger" controltovalidate="txtPStartDate" errormessage="Please enter a Date" />
                </div>

                <div class="col-4">
                    <asp:Label ID="Label17" runat="server" class="col-form-label" Text="Date End"></asp:Label>
                    <asp:TextBox ID="txtPEndDate" runat="server" CssClass="form-control form-control-sm col-md-6 date_length"></asp:TextBox>
                </div>

                <div class="col-2">
                    <asp:Label ID="Label16" runat="server" class="col-form-label" Text="Date Begin"></asp:Label>
                    <asp:TextBox ID="txtDStartDate" runat="server" CssClass="form-control form-control-sm col-md date_length"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" class="text-danger" controltovalidate="txtDStartDate" errormessage="Please enter a Date" />
                </div>

                <div class="col-4">
                    <asp:Label ID="Label18" runat="server" class="col-form-label" Text="Date End"></asp:Label>
                    <asp:TextBox ID="txtDEndDate" runat="server" CssClass="form-control form-control-sm col-md-6 date_length"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group p-2">
            <h5 class="heading">Details</h5>
            <div class="form-row">
                <div class="col-2">
                    <asp:Label ID="Label20" runat="server" CssClass="col-form-label" Text="Load Price"></asp:Label>
                    <asp:TextBox ID="txtLPrice" runat="server" onblur="findMilePrice()" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label21" runat="server" CssClass="col-form-label" Text="Driver Fee"></asp:Label>
                    <asp:TextBox ID="txtLDFee" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label22" runat="server" CssClass="col-form-label" Text="Fuel Cost"></asp:Label>
                    <asp:TextBox ID="txtLFuelCost" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label23" runat="server" CssClass="col-form-label" Text="Toll Cost"></asp:Label>
                    <asp:TextBox ID="txtLTollCost" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label24" runat="server" CssClass="col-form-label" Text="Miles"></asp:Label>
                    <asp:TextBox ID="txtLMiles" runat="server" onblur="findMilePrice()" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label25" runat="server" CssClass="col-form-label" Text="Mile Price"></asp:Label>
                    <asp:TextBox ID="txtLMilePrice" runat="server" CssClass="form-control form-control-sm col-md-8"></asp:TextBox>
                </div>
            </div>


            <div class="form-row">
                <div class="col-8 pt-2">
                    <asp:Label ID="Label27" runat="server" CssClass="col-form-label" Text="Notes"></asp:Label>
                    <asp:TextBox ID="txtLExp" TextMode="MultiLine" runat="server" CssClass="form-control col-md-7"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-xs-11 p-2">
            <asp:Button ID="Button2" runat="server" CssClass="btn green_button" Text="Save" OnClick="btSaveLoad_Click" />
            <asp:Label ID="Label26" runat="server"></asp:Label>
        </div>


        <div style="width: 100%; border: 1px solid rgba(0,0,0,.1);" class="p-2 mt-4">
            <table id="loadtable" class="table table-striped table-bordered display nowrap table-hover" style="width:100%">
                <thead class="thead-light">
                    <tr>
                        <th>Id</th>
                        <th>Load No</th>
                        <th>Truck</th>
                        <th>Status</th>
                        <%--<th>Driver</th>
                        <th>Broker</th>
                        <th>Dispatcher</th>--%>
                        <th>Customer</th>
                        <th>P. Comp</th>
                        <th>P. Date Begin</th>
                        <th>P. Date End</th>
                        <th>D. Comp</th>
                        <th>D. Date Begin</th>
                        <th>D. Date End</th>
                        <th>Billed</th>
                        <th>Load Price</th>
                        <th></th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <th colspan="12" style="text-align:right">Total:</th>
                        <th></th>
                    </tr>
                </tfoot>
            </table>
        </div>


        
    </div>

    <%-- Calculate Mile Price --%>
    <script type="text/javascript">
        function findMilePrice() {
            var loadprice = document.getElementById('txtLPrice').value;
            var miles = document.getElementById('txtLMiles').value;
            var mileprice = 0;

            if (parseFloat(loadprice))
                if (parseFloat(miles))
                    mileprice = parseFloat(loadprice / miles).toFixed(2);

            document.getElementById('txtLMilePrice').value = mileprice;
        }

    </script>

    <script src="Content/js/jquery.datetimepicker.full.js"></script>
    <script>
        /*jslint browser:true*/
        /*global jQuery, document*/

        jQuery(document).ready(function () {
            'use strict';

            jQuery('#txtPStartDate, #txtPEndDate, #txtDStartDate, #txtDEndDate').datetimepicker();
        });
    </script>

    <script src="/Content/js/loadTable.js"></script>
    
</asp:Content>
