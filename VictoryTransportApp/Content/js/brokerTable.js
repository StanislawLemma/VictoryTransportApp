var table;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $.ajax({
        url: 'WebServices/BrokerService.asmx/GetBrokers',
        //url: 'WebServices/BrokerService.asmx/GetBrokersWithParams',
        method: 'post',
        dataType: 'json',
        //data: {
        //    tmpid: '2',
        //    name: 'Broker Test 2'
        //},
        success: function (data) {
            table = $('#brokertable').DataTable({
                paging: true,
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
                scrollX: true,
                data: data,
                columns: [
                    { 'data': 'Uid', visible: false },
                    { 'data': 'Name' },
                    { 'data': 'CustomerTitle' },
                    { 'data': 'Phone' },
                    { 'data': 'Email' },
                    {
                        data: 'Uid',
                        render: function (data, type, row, meta) {
                            return `<div class="text-center">
                                        <a href="EditBroker.aspx?id=${data}" class='btn btn-outline-success btn-sm' style='cursor:pointer;width:40%;'>
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
    var url = "Brokers.aspx/deleteBroker"

    swal.fire({
        title: 'Are you sure?',
        text: "Broker will be deleted.",
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
                data: JSON.stringify({ broker_id: id }),
                datatype: "json",
                success: function (response) {
                    console.log(response);
                    if (response.d === "done") {
                        toastr.success('Broker deleted.');

                        $('#brokertable').DataTable().destroy();
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


//$(document).ready(function () {
//    $.ajax({
//        url: 'WebServices/BrokerService.asmx/GetBrokers',
//        method: 'post',
//        dataType: 'json',
//        success: function (data) {
//            $('#brokertable').dataTable({
//                dom: 'Bfrtip',
//                paging: true,
//                buttons: [
//                    'searchPanes', 'pdf', 'excel', 'print', 'copy', 'colvis'
//                ],
//                scrollX: true,
//                data: data,
//                columns: [
//                    { 'data': 'Uid', visible: false },
//                    { 'data': 'Name' },
//                    { 'data': 'CustomerTitle' },
//                    { 'data': 'Phone' },
//                    { 'data': 'Email' }
//                ]
//            });
//        }
//    });
//});

