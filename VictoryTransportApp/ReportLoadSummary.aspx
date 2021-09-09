<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportLoadSummary.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.ReportLoadSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/gijgo@1.8.1/combined/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://cdn.jsdelivr.net/npm/gijgo@1.8.1/combined/css/gijgo.min.css" rel="stylesheet" type="text/css" />

    <script src="Content/js/jspdf.js"></script>
    <script src="Content/js/FileSaver.js"></script>
    <script src="Content/js/jspdf.plugin.table.js"></script>

    <script>
        function generatefromtable() {
            var data = [], fontSize = 12, height = 0, doc;
            doc = new jsPDF('p', 'pt', 'a4', true);
            doc.setFont("times", "normal");
            doc.setFontSize(fontSize);
            //doc.text(20, 20, "hi table");
            data = [];
            data = doc.tableToJson('loadtable');
            height = doc.drawTable(data, {
                xstart: 10,
                ystart: 10,
                tablestart: 40,
                marginleft: 10,
                xOffset: 10,
                yOffset: 15
            });
            //doc.text(50, height + 20, 'hi world');
            doc.save("LoadSummary.pdf");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <h3>Load Summary Report</h3>
        <hr />

        <div class="form-row">
            <div class="col-3">
                <asp:Label ID="Label10" runat="server" CssClass="col-form-label" Text="Pickup Date Start"></asp:Label>
                <asp:TextBox ID="txtLStartDate" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>

            <div class="col-3">
                <asp:Label ID="Label9" runat="server" CssClass="col-form-label" Text="Pickup Date End"></asp:Label>
                <asp:TextBox ID="txtLEndDate" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>

            <div class="col-3">
                <asp:Label ID="Label1" runat="server" class="col-form-label" Text="Load #"></asp:Label>
                <asp:TextBox ID="txtLoadNo" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>

            <div class="col-3">
                <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Rate #"></asp:Label>
                <asp:TextBox ID="txtLRateNo" runat="server" CssClass="form-control form-control-sm col-md-6"> </asp:TextBox>
            </div>

        </div>

        <div class="form-row">

            <div class="col-3">
                <asp:Label ID="Label12" runat="server" CssClass="col-form-label" Text="Pick Up"></asp:Label>
                <asp:TextBox ID="txtLPLoc" runat="server" CssClass="form-control form-control-sm col-md-6"> </asp:TextBox>
            </div>

            <div class="col-3">
                <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Delivery"></asp:Label>
                <asp:TextBox ID="txtLDLoc" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>


            <div class="col-3">
                <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Truck #"></asp:Label>
                <asp:DropDownList ID="ddlTruckNo" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:DropDownList>
            </div>

            <div class="col-3">
                <asp:Label ID="Label6" runat="server" CssClass="col-form-label" Text="Driver"></asp:Label>
                <asp:DropDownList ID="ddlDriverName" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:DropDownList>
            </div>


        </div>

        <div class="col-xs-11 space-vert">
            <div class="btn-group" role="group" aria-label="Output Buttons">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Search" OnClick="btSaveLoad_Click" />
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Text="Clear Selections" OnClick="btClearLoad_Click" />
            </div>
        </div>
    </div>

    <hr />
    <h3 id="midTitle" runat="server">Active Loads</h3>

    <div class="panel panel-default">
        <%--load table begins--%>

        <asp:Repeater ID="rptrLoads" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <table id="loadtable" class="table table-sm table-striped table-bordered table-hover">
                        <thead style="background-color: #cbd6d0;">
                            <tr>
                                <th scope="col">Pickup Date</th>
                                <th scope="col">Pickup</th>
                                <th scope="col">Delivery Date</th>
                                <th scope="col">Delivery</th>
                                <th scope="col">Rate #</th>
                                <th scope="col">Load #</th>
                                <th scope="col">Truck #</th>
                                <th scope="col">Driver</th>
                                <th scope="col">Driver Phone</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("start_date") %></td>
                    <td><%# Eval("pick_loc") %></td>
                    <td><%# Eval("end_date") %></td>
                    <td><%# Eval("del_loc") %></td>
                    <td><%# Eval("rate_no") %></td>
                    <td><%# Eval("no") %></td>
                    <td><%# Eval("truck_no") %></td>
                    <td><%# Eval("driver_name") %></td>
                    <td><%# Eval("phone") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
                        <div class="table-responsive">
            </FooterTemplate>
        </asp:Repeater>


        <div class="container-fluid">
            <div class="form-horizontal">
                <div class="form-row">
                    <div class="btn-group" role="group" aria-label="Output Buttons">
                        <asp:Button ID="excel" runat="server" CssClass="btn btn-outline-success" Text="Excel" />
                        <asp:Button ID="pdf" runat="server" CssClass="btn btn-outline-success" Text="PDF" OnClientClick="generatefromtable()" />
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="Content/js/jquery.datetimepicker.full.js"></script>
    <script src="Content/js/jquery.table2excel.js"></script>
    <script>
        /*jslint browser:true*/
        /*global jQuery, document*/

        jQuery(document).ready(function () {
            'use strict';

            jQuery('#txtLStartDate, #txtLEndDate').datetimepicker();
        });
    </script>
    <script>
        $('#excel').click(function () {
            $('.table').table2excel({
                exclude: ".noExl",
                name: "Loads",
                filename: "Load Summary Data"
            });
        });
    </script>
</asp:Content>
