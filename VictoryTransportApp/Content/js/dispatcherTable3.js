var table;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $.ajax({
        url: 'WebServices/DispatcherService.asmx/GetDispatchers',
        method: 'post',
        dataType: 'json',
        success: function (data) {
            table = $('#dispatchertable').DataTable({
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
                    { 'data': 'Phone' },
                    { 'data': 'Email' },
                    { 'data': 'Ssn' },
                    {
                        data: 'Uid',
                        render: function (data, type, row, meta) {
                            return `<div class="text-center">
                                        <a href="EditDispatcher.aspx?id=${data}" class='btn btn-outline-success btn-sm' style='cursor:pointer;width:40%;'>
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
    var url = "Dispatchers.aspx/deleteDispatcher"

    swal.fire({
        title: 'Are you sure?',
        text: "Dispatcher will be deleted.",
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
                data: JSON.stringify({ dispatcher_id: id }),
                datatype: "json",
                success: function (response) {
                    console.log(response);
                    if (response.d === "done") {
                        toastr.success('Dispatcher deleted.');

                        $('#dispatchertable').DataTable().destroy();
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

