<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Loads.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.Loads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/gijgo@1.8.1/combined/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://cdn.jsdelivr.net/npm/gijgo@1.8.1/combined/css/gijgo.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <h3>Add Load</h3>
        <hr />

        <div class="form-row">
            <div class="col-3">
                <asp:Label ID="Label10" runat="server" CssClass="col-form-label" Text="Start Date"></asp:Label>
                <asp:TextBox ID="txtLStartDate" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label9" runat="server" CssClass="col-form-label" Text="End Date"></asp:Label>
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

        <div class="form-row">
            <div class="col-3">
                <asp:Label ID="Label5" runat="server" CssClass="col-form-label" Text="Load Price"></asp:Label>
                <asp:TextBox ID="txtLPrice" runat="server" onblur="findMilePrice()" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label7" runat="server" CssClass="col-form-label" Text="Driver Fee"></asp:Label>
                <asp:TextBox ID="txtLDFee" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label13" runat="server" CssClass="col-form-label" Text="Fuel Cost"></asp:Label>
                <asp:TextBox ID="txtLFuelCost" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label14" runat="server" CssClass="col-form-label" Text="Toll Cost"></asp:Label>
                <asp:TextBox ID="txtLTollCost" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="col-3">
                <asp:Label ID="Label17" runat="server" CssClass="col-form-label" Text="Miles"></asp:Label>
                <asp:TextBox ID="txtLMiles" runat="server" onblur="findMilePrice()" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label18" runat="server" CssClass="col-form-label" Text="Mile Price"></asp:Label>
                <asp:TextBox ID="txtLMilePrice" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label19" runat="server" CssClass="col-form-label" Text="Customer"></asp:Label>
                <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:DropDownList>
            </div>

        </div>

        <div class="form-row">
            <div class="col-8">
                <asp:Label ID="Label16" runat="server" CssClass="col-form-label" Text="Explanation"></asp:Label>
                <asp:TextBox ID="txtLExp" TextMode="MultiLine" runat="server" CssClass="form-control col-md-7"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="col-xs-11 space-vert">
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btSaveLoad_Click" />
        <asp:Label ID="Label15" runat="server"></asp:Label>
    </div>

    <hr />
    <h3>Loads</h3>

    <div class="panel panel-default">
        <%--load table begins--%>

        <asp:Repeater ID="rptrLoads" runat="server" OnItemCommand="rptrLoads_ItemCommand">
            <HeaderTemplate>
                <div class="table-responsive">
                    <table class="table table-sm table-striped table-bordered table-hover">
                        <thead style="background-color: #cbd6d0;">
                            <tr>
                                <th class="gj-hidden" scope="col">Uid</th>
                                <th scope="col">P. Date</th>
                                <th scope="col">Pickup</th>
                                <th scope="col">D. Date</th>
                                <th scope="col">Delivery</th>
                                <th scope="col">Rate#</th>
                                <th scope="col">Load#</th>
                                <th scope="col">Truck#</th>
                                <th scope="col">Driver</th>
                                <th scope="col">Customer</th>
                                <th scope="col">Load Price</th>
                                <th scope="col">Miles</th>
                                <th scope="col">Mile Cost</th>
                                <th scope="col">Exp</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="gj-hidden"><%# Eval("Uid") %></td>
                    <td><%# Eval("start_date") %></td>
                    <td><%# Eval("pick_loc") %></td>
                    <td><%# Eval("end_date") %></td>
                    <td><%# Eval("del_loc") %></td>
                    <td><%# Eval("rate_no") %></td>
                    <td><%# Eval("no") %></td>
                    <td><%# Eval("truck_no") %></td>
                    <td><%# Eval("driver_name") %></td>
                    <td><%# Eval("title") %></td>
                    <td class="load_price"><%# Eval("load_price") %></td>
                    <td><%# Eval("mile") %></td>
                    <td><%# Eval("mile_price") %></td>
                    <td><%# Eval("explanation") %></td>
                    <td style="width: 4%">
                        <div class="box">
                            <asp:Button ID="delete" runat="server" CssClass="btn btn-danger btn-sm" Text="DEL" UseSubmitBehavior="False" CommandName="delete" CommandArgument='<%# Eval("Uid") %>' />
                        </div>
                    </td>
                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
                </div>
                <%--<div class="table-responsive">--%>
            </FooterTemplate>
        </asp:Repeater>

                <%--</div>--%>
    </div>
    <script>
        $(calculateLoadSum);
        //$(calculateDriverSum);

        function calculateLoadSum() {

            var sum = 0;
            // iterate through each td based on class and add the values
            $(".load_price").each(function () {

                var value = $(this).text();
                // add only if the value is number
                if (!isNaN(value) && value.length != 0) {
                    sum += parseFloat(value);
                }
            });

            var n = sum.toString();

            var final = n.concat(" ", "$")

            $('#load_result').text(final);
        };
    </script>

    <div class="container">
        <div class="form-row float-right">
            <%--<div class="col-7"></div>--%>
            <strong>
                <asp:Label ID="Label8" runat="server" CssClass="col-form-label" Text="Total Load Cost:"></asp:Label>
                <asp:Label ID="load_result" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>
            </strong>
        </div>
    </div>
    <%--load table ends--%>

    <%-- Calculate Mile Price --%>
    <script type="text/javascript">
        function findMilePrice() {
            var loadprice = document.getElementById('txtLPrice').value;
            var miles = document.getElementById('txtLMiles').value;
            var mile_price = 0;

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

            jQuery('#txtLStartDate, #txtLEndDate').datetimepicker();
        });
    </script>
</asp:Content>
