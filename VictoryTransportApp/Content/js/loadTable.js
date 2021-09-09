var table;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $.ajax({
        url: 'WebServices/LoadService.asmx/GetLoads',
        method: 'post',
        dataType: 'json',
        success: function (data) {
            table = $('#loadtable').dataTable({
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // Remove the formatting to get integer data for summation
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                                i : 0;
                    };

                    // Total over all pages
                    total = api
                        .column(12)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    // Total over this page
                    pageTotal = api
                        .column(12, { page: 'current' })
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    // Update footer
                    $(api.column(12).footer()).html(
                        '$' + pageTotal + ' ( $' + total + ' total)'
                    );
                },
                //dom: 'lBfrtip',
                paging: true,
                //buttons: [
                //    'searchPanes', 'pdf', 'excel', 'print', 'copy', 'colvis'
                //],
                dom: "<'row'<'col-sm-3'l><'col-sm-6'B><'col-sm-3'f>>" +
                    "<'row'<'col-sm-12'tr>>" +
                    "<'row'<'col-sm-5'i><'col-sm-7'p>>",
                buttons: [
                    {
                        extend: 'searchPanes',
                    },
                    {
                        extend: 'pdf',
                        pageSize: 'LEGAL',
                        orientation: 'landscape',
                        exportOptions: {
                            columns: ':visible',

                        }
                    },
                    {
                        extend: 'excel',
                        exportOptions: {
                            columns: ':visible',
                            rows: ':visible'
                        }
                    },
                    {
                        extend: 'print',
                        exportOptions: {
                            columns: ':visible',
                            rows: ':visible'
                        }
                    },
                    {
                        extend: 'copy',
                        exportOptions: {
                            columns: ':visible',
                            rows: ':visible'
                        }
                    },
                    {
                        extend: 'colvis',
                    },
                ],
                //sort: true,
                //searching: true,
                //scrollY: 200,
                scrollX: true,
                data: data,
                columns: [
                    { 'data': 'Uid', visible: false },
                    { 'data': 'LoadNo' },
                    { 'data': 'TruckNo' },
                    { 'data': 'Status' },
                    //{ 'data': 'BrokerName' },
                    //{ 'data': 'DispatcherName' },
                    { 'data': 'CustomerTitle' },
                    { 'data': 'PickCompany' },
                    {
                        'data': 'PickDateStart',
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            var minutes = String(date.getMinutes()).padStart(2, "0");
                            return month + "/" + date.getDate() + "/" + date.getFullYear() + " " + date.getHours() + ":" + minutes;
                        }
                    },
                    {
                        'data': 'PickDateEnd',
                        visible: false,
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            var minutes = String(date.getMinutes()).padStart(2, "0");
                            return month + "/" + date.getDate() + "/" + date.getFullYear() + " " + date.getHours() + ":" + minutes;
                        }
                    },
                    { 'data': 'DelCompany' },
                    {
                        'data': 'DelDateStart',
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            var minutes = String(date.getMinutes()).padStart(2, "0");
                            return month + "/" + date.getDate() + "/" + date.getFullYear() + " " + date.getHours() + ":" + minutes;
                        }
                    },
                    {
                        'data': 'DelDateEnd',
                        visible: false,
                        'render': function (jsonDate) {
                            var date = new Date(parseInt(jsonDate.substr(6)));
                            var month = date.getMonth() + 1;
                            var minutes = String(date.getMinutes()).padStart(2, "0");
                            return month + "/" + date.getDate() + "/" + date.getFullYear() + " " + date.getHours() + ":" + minutes;
                        }
                    },
                    {
                        'data': 'Billed'
                    },
                    {
                        'data': 'LoadPrice',
                        'render': function (loadprice) {
                            return "$" + loadprice;
                        }
                    },
                    {
                        data: 'Uid',
                        render: function (data, type, row, meta) {
                            return `<div class="text-center">
                                        <a href="EditLoad.aspx?id=${data}" class='btn btn-outline-success btn-sm' style='cursor:pointer;width:40%;'>
                                            Edit
                                        </a>
                                        <a tabindex="-1" class='btn btn-outline-danger btn-sm' style='cursor:pointer;width:40%;' onclick=DeleteRow(${data})>
                                            Del
                                        </a>
                                    </div>`
                        }, "width": "10%"
                    }
                ]
            });
        }
    });
}

function DeleteRow(id) {
    var url = "LoadsNew.aspx/deleteLoad"

    swal.fire({
        title: 'Are you sure?',
        text: "Load will be deleted.",
        showDenyButton: true,
        confirmButtonText: `Delete!`,
        confirmButtonColor: '#3a634c',
        denyButtonText: `No, cancel!`,
        icon: 'warning',
    }).then((result) => {
        if (result.isDenied) {
            return false;
        } else if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ load_id: id }),
                datatype: "json",
                success: function (response) {
                    console.log(response);
                    if (response.d === "done") {
                        toastr.success('Load is deleted.');

                        $('#loadtable').DataTable().destroy();
                        loadDataTable();
                    }
                    else {
                        toastr.error('Error when deleting!');
                    }
                }
            });
        }
    })
}
