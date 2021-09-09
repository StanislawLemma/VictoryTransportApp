<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportDriver.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.ReportDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/jquery.datetimepicker.css" rel="stylesheet" />

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
            doc.save("Loads.pdf");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="form-horizontal">
        <h3>Driver Report</h3>
        <hr />

        <div class="form-row">
            <div class="col-3">
                <asp:Label ID="Label6" runat="server" CssClass="col-form-label" Text="Driver"></asp:Label>
                <asp:DropDownList ID="ddlDriverName" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:DropDownList>
            </div>

            <div class="col-3">
                <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Truck #"></asp:Label>
                <asp:DropDownList ID="ddlTruckNo" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:DropDownList>
            </div>
            <div class="col-3">
                <asp:Label ID="Label10" runat="server" CssClass="col-form-label" Text="Pickup Date Start"></asp:Label>
                <asp:TextBox ID="txtLStartDate" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
            </div>

            <div class="col-3">
                <asp:Label ID="Label9" runat="server" CssClass="col-form-label" Text="Pickup Date End"></asp:Label>
                <asp:TextBox ID="txtLEndDate" runat="server" CssClass="form-control form-control-sm col-md-6"></asp:TextBox>
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
                <asp:Label ID="Label5" runat="server" CssClass="col-form-label" Text="Min. Load Price"></asp:Label>
                <asp:TextBox ID="txtMinLoadPrice" runat="server" CssClass="form-control form-control-sm col-md-6"> </asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label7" runat="server" CssClass="col-form-label" Text="Max. Load Price"></asp:Label>
                <asp:TextBox ID="txtMaxLoadPrice" runat="server" CssClass="form-control form-control-sm col-md-6"> </asp:TextBox>
            </div>

            <div class="col-3">
                <asp:Label ID="Label13" runat="server" CssClass="col-form-label" Text="Min. Driver Fee"></asp:Label>
                <asp:TextBox ID="txtMinDriverFee" runat="server" CssClass="form-control form-control-sm col-md-6"> </asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label14" runat="server" CssClass="col-form-label" Text="Max. Driver Fee"></asp:Label>
                <asp:TextBox ID="txtMaxDriverFee" runat="server" CssClass="form-control form-control-sm col-md-6"> </asp:TextBox>
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
                                <th scope="col">Driver</th>
                                <th scope="col">Pickup Date</th>
                                <th scope="col">Pickup</th>
                                <th scope="col">Delivery Date</th>
                                <th scope="col">Delivery</th>
                                <th scope="col">Rate #</th>
                                <th scope="col">Load #</th>
                                <th scope="col">Truck #</th>
                                <th scope="col">Load Price</th>
                                <th scope="col">Driver Fee</th>
                                <th scope="col">Total Cost</th>
                                <th scope="col">Explntn</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("driver_name") %></td>
                    <td><%# Eval("start_date") %></td>
                    <td><%# Eval("pick_loc") %></td>
                    <td><%# Eval("end_date") %></td>
                    <td><%# Eval("del_loc") %></td>
                    <td><%# Eval("rate_no") %></td>
                    <td><%# Eval("no") %></td>
                    <td><%# Eval("truck_no") %></td>
                    <td class="load_price"><%# Eval("load_price") %></td>
                    <td class="driver_price"><%# Eval("driver_fee") %></td>
                    <td><%# Eval("total_cost") %></td>
                    <td><%# Eval("explanation") %></td>
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

                    <div class="col-6"></div>
                    <strong>
                        <asp:Label ID="Label15" runat="server" CssClass="col-form-label" Text="Total Load Cost:"></asp:Label>
                        <asp:Label ID="load_result" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>


                        <asp:Label ID="Label17" runat="server" CssClass="col-form-label" Text="Total Driver Cost:"></asp:Label>
                        <asp:Label ID="driver_result" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>
                    </strong>
                </div>
            </div>
        </div>

    </div>

    <script>
        $(calculateLoadSum);
        $(calculateDriverSum);

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

        function calculateDriverSum() {

            var sum = 0;
            // iterate through each td based on class and add the values
            $(".driver_price").each(function () {

                var value = $(this).text();
                // add only if the value is number
                if (!isNaN(value) && value.length != 0) {
                    sum += parseFloat(value);
                }
            });

            var n = sum.toString();

            var final = n.concat(" ", "$")

            $('#driver_result').text(final);
        };
    </script>
</asp:Content>
